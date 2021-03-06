﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using ARK.Model;
using ARK.Model.DB;
using ARK.View.Protokolsystem.Additional;
using ARK.View.Protokolsystem.Confirmations;
using ARK.View.Protokolsystem.Pages;
using ARK.ViewModel.Base;
using ARK.ViewModel.Protokolsystem.Additional;
using ARK.ViewModel.Protokolsystem.Confirmations;

namespace ARK.ViewModel.Protokolsystem.Pages
{
    internal class ViewLongTripFormViewModel : ProtokolsystemContentViewModelBase
    {
        // Fields
        private readonly DbArkContext db = DbArkContext.GetDbContext(); // Database

        private FrameworkElement _infoPage;

        private List<LongTripForm> _longTripForms;

        private LongTripForm _selectedLongTripForm;

        // Constructor
        public ViewLongTripFormViewModel()
        {
            var db = DbArkContext.GetDbContext();

            ParentAttached += (sender, e) =>
                {
                    LongTripForms = db.LongTripForm.OrderByDescending(x => x.PlannedStartDate).ToList();

                    if (LongTripForms.Any())
                    {
                        SelectedLongTripForm = LongTripForms.First();
                    }

                    UpdateInfo();
                };
        }

        public ICommand CreateLongTripForm
        {
            get
            {
                return
                    GetCommand(() => ProtocolSystem.NavigateToPage(() => new CreateLongTripForm(), "OPRET NY LANGTUR"));
            }
        }

        // Props
        public List<LongTripForm> LongTripForms
        {
            get
            {
                if (_longTripForms != null) 
                {
                    foreach (LongTripForm ltf in _longTripForms)
                    {
                        if (ltf.Status != LongTripForm.BoatStatus.Denied)
                        {
                            if (System.DateTime.Now > ltf.PlannedEndDate.AddDays(1))
                            {
                                ltf.Status = LongTripForm.BoatStatus.Ended;
                            };
                        };
                    };
                }
                
                
                return _longTripForms;
            }

            set
            {
                _longTripForms = value;
                Notify();
            }
        }

        public LongTripForm SelectedLongTripForm
        {
            get
            {
                return _selectedLongTripForm;
            }

            set
            {
                _selectedLongTripForm = value;
                Notify();
                UpdateInfo();
            }
        }

        public ICommand ViewLongTripForm
        {
            get
            {
                return
                    GetCommand(() => ProtocolSystem.NavigateToPage(() => new ViewLongTripForm(), "LANGTURSBLANKETTER"));
            }
        }

        private ViewLongTripFormAdditionalInfoViewModel Info
        {
            get
            {
                return InfoPage.DataContext as ViewLongTripFormAdditionalInfoViewModel;
            }
        }

        private FrameworkElement InfoPage
        {
            get
            {
                return _infoPage ?? (_infoPage = new ViewLongTripFormAdditionalInfo());
            }
        }

        // ConfirmWindow
        public ICommand ShowConfirmDialog
        {
            get
            {
                return new RelayCommand(    
                    x => ConfirmTripData(),
                    x => SelectedLongTripForm != null && SelectedLongTripForm.Boat.BoatOut == false);
            }
        }

        public void ConfirmTripData()
        {
            {
                Trip trip = new Trip
                {
                    Id = db.Trip.OrderByDescending(t => t.Id).First().Id + 1,
                    TripStartTime = DateTime.Now,
                    Members = new List<Member>(SelectedLongTripForm.Members),
                    Boat = SelectedLongTripForm.Boat,
                    LongTrip = true,
                    Direction = "LANGTUR"
                };

                var dlg = new ViewLongTripConfirm();
                var confirmTripViewModel = (ViewLongTripConfirmViewModel)dlg.DataContext;
                confirmTripViewModel.Trip = trip;
                ProtocolSystem.ShowDialog(dlg);
            }
        }

        private void UpdateInfo()
        {
            Info.SelectedLongTripForm = SelectedLongTripForm;

            ProtocolSystem.ChangeInfo(InfoPage, Info);
        }
    }
}