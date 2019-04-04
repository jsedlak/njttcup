using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TimeTrialCup.DomainModel;

namespace TimeTrialCup.WinApp.ViewModels
{
    public sealed class ProcessedResultsViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _course;
        private string _subCourse;
        private string _usacPermit;
        private DateTime _dayOfEvent = DateTime.Today;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Course
        {
            get { return _course; }
            set
            {
                _course = value;
                OnPropertyChanged(nameof(Course));
            }
        }

        public string SubCourse
        {
            get { return _subCourse; }
            set
            {
                _subCourse = value;
                OnPropertyChanged(nameof(SubCourse));
            }
        }

        public string UsacPermit
        {
            get { return _usacPermit; }
            set
            {
                _usacPermit = value;
                OnPropertyChanged(nameof(UsacPermit));
            }
        }

        public DateTime DayOfEvent
        {
            get { return _dayOfEvent; }
            set
            {
                _dayOfEvent = value;
                OnPropertyChanged(nameof(DayOfEvent));
            }
        }

        public ObservableCollection<CategoryResult> Results { get; set; } = new ObservableCollection<CategoryResult>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
