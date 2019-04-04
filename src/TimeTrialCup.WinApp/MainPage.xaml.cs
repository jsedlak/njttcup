using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TimeTrialCup.DomainModel;
using TimeTrialCup.WinApp.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TimeTrialCup.WinApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ProcessedResultsViewModel _dataContext;
        private readonly List<string> _teams = new List<string>();

        public MainPage()
        {
            this.InitializeComponent();

            _dataContext = new ProcessedResultsViewModel();
            this.DataContext = _dataContext;

            LoadTeams();
        }

        private void LoadTeams()
        {
            using (var reader = new StreamReader(this.GetType().Assembly.GetManifestResourceStream("TimeTrialCup.WinApp.Resources.RegisteredTeams.txt")))
            {
                while(!reader.EndOfStream)
                {
                    _teams.Add(reader.ReadLine());
                }
            }
        }

        private async void SaveFileClicked(object sender, RoutedEventArgs e)
        {
            // FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
            var picker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.Downloads
            };
            picker.FileTypeChoices.Add("JSON File", new[] { ".json" });

            var fileToSaveTo = await picker.PickSaveFileAsync();

            if(fileToSaveTo == null)
            {
                return;
            }

            var finalResult = new EventResult
            {
                Name = _dataContext.Name,
                DayOfEvent = _dataContext.DayOfEvent,
                Course = _dataContext.Course,
                UsacPermit = _dataContext.UsacPermit,
                SubCourse = _dataContext.SubCourse,
                Categories = _dataContext.Results.ToList()
            };

            using (var writer = new StreamWriter(await fileToSaveTo.OpenStreamForWriteAsync()))
            {
                await writer.WriteAsync(JsonConvert.SerializeObject(finalResult));
            }

            Trace.WriteLine("Saved!");
        }

        private async void OpenFileClicked(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.Downloads
            };

            picker.FileTypeFilter.Add(".csv");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                await ProcessFileAsync(file);

            }
        }

        private async Task<IEnumerable<string>> GetLinesAsync(StorageFile file)
        {
            var lines = new List<string>();
            using (var result = await file.OpenReadAsync())
            {
                using (var reader = new StreamReader(result.AsStreamForRead()))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        lines.Add(line.Trim());
                    }
                }
            }
            return lines;
        }

        public async Task ProcessFileAsync(StorageFile file)
        {
            _dataContext.Results.Clear();

            Trace.WriteLine($"Opened {file.Name}");

            _dataContext.Name = file.Name;
            _dataContext.Course = "";
            _dataContext.SubCourse = "";
            _dataContext.UsacPermit = "";
            _dataContext.DayOfEvent = DateTime.Today;

            var lines = await GetLinesAsync(file);
            CategoryResult currentCategory = null;

            foreach (var line in lines)
            {
                // empty line signifies the end of a table
                // so add and reset
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (currentCategory != null)
                    {
                        _dataContext.Results.Add(currentCategory);
                        currentCategory = null;
                    }

                    continue;
                }

                // table header
                if (currentCategory == null)
                {
                    currentCategory = new CategoryResult
                    {
                        Name = line,
                        Results = new List<RiderResult>()
                    };

                    continue;
                }

                // column headers?
                if (line.StartsWith("Place"))
                {
                    continue;
                }

                // otherwise, it's a rider result
                // Place, License #, First, Last, City, State, Time, Team
                // 0      1          2      3     4     5      6     7
                var splitData = line.Split(',');

                // check for DNF/DNS
                if (!int.TryParse(splitData[0], out int riderPlacing))
                {
                    continue;
                }

                var textInfo = CultureInfo.CurrentCulture.TextInfo;
                var name = textInfo.ToTitleCase(splitData[2].ToLower()) + " " + textInfo.ToTitleCase(splitData[3].ToLower());
                var selectedTeam = _teams.FirstOrDefault(team => 
                    Fastenshtein.Levenshtein.Distance(splitData[7], team) <= 3 || 
                    team.ToLower().Replace("'", "").Contains(splitData[7].ToLower().Replace("'", ""))
                );

                var points = 21 - riderPlacing;

                if(string.IsNullOrWhiteSpace(selectedTeam))
                {
                    selectedTeam = splitData[7];
                    points = 0;
                }

                // add the result
                ((List<RiderResult>)currentCategory.Results).Add(new RiderResult
                {
                    Place = riderPlacing,
                    License = splitData[1],
                    Name = name,
                    Points = points,
                    Time = GlobalizeRiderTime(splitData[6]),
                    Team = selectedTeam
                });
            }
        }

        private string GlobalizeRiderTime(string input)
        {
            // get the timespan format
            var timeSpanFormat = GetTimeSpanFormat(input);

            // and parse the rider's time
            if (!TimeSpan.TryParseExact(input, timeSpanFormat, CultureInfo.CurrentCulture, out TimeSpan riderTime))
            {
                Trace.WriteLine($"CANNOT PARSE TIME: {input} against format {timeSpanFormat}");
                return "";
            }

            return riderTime.ToString("dd\\:hh\\:mm\\:ss\\.fff");
        }

        private string GetTimeSpanFormat(string input)
        {
            var data = input.Split(new string[] { ":", "." }, StringSplitOptions.RemoveEmptyEntries);

            var result = new StringBuilder();

            if(data.Length > 4)
            {
                result.Append("dd\\:");
            }

            if(data.Length > 3)
            {
                result.Append("hh\\:");
            }

            result.Append("mm\\:ss");

            if (input.IndexOf(".") >= 0)
            {
                result.Append("\\.");
                var fCount = "";
                for (var fIndex = 0; fIndex < data.Last().Length; fIndex++)
                {
                    fCount += "f";
                }
                result.Append(fCount);
            }

            return result.ToString();
        }
    }
}
