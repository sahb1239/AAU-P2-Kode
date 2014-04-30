using System;
using System.Collections.Generic;

namespace ARK.ViewModel.Base.Filter
{
    public class FilterEventArgs : EventArgs
    {
        public FilterEventArgs(string searchText, IEnumerable<string> filtersActive)
        {
            SearchText = searchText;
            Filters = filtersActive;
        }

        public string SearchText { get; private set; }
        public IEnumerable<string> Filters { get; private set; }
    }
}