using System.Collections.Generic;

namespace TimeTrialCup.WinApp.DataModel
{
    public sealed class ReferenceCategory
    {
        public string Name { get; set; }

        public IEnumerable<string> Aliases { get; set; }
    }
}
