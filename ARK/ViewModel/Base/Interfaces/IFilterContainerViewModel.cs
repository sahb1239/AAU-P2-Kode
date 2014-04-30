﻿using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ARK.ViewModel.Base.Interfaces
{
    public class SearchEventArgs : EventArgs
    {
        public string SearchText { get; private set; }

        public SearchEventArgs(string searchText)
        {
            this.SearchText = searchText;
        }
    }

    public interface IFilterContainerViewModel : IViewModelBase
    {
        event EventHandler<SearchEventArgs> SearchTextChanged;

        bool EnableSearch { get; set; }
        bool EnableFilters { get; set; }

        ObservableCollection<FrameworkElement> Filters { get; set; }
    }
}