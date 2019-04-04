using TimeTrialCup.DomainModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TimeTrialCup.WinApp
{
    public sealed class ResultsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CategoryTemplate { get; set; }
        public DataTemplate RiderTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if(item is CategoryResult)
            {
                return CategoryTemplate;
            }
            else if(item is RiderResult)
            {
                return RiderTemplate;
            }

            return base.SelectTemplateCore(item);
        }
    }
}
