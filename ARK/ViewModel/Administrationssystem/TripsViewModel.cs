﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using ARK.Model;
using ARK.Model.DB;
using ARK.Model.Extensions;
using ARK.View.Administrationssystem.Filters;
using ARK.View.Administrationssystem.Pages;
using ARK.ViewModel.Base;
using ARK.ViewModel.Base.Filter;
using ARK.ViewModel.Base.Interfaces.Filter;
using System.Collections.ObjectModel;

namespace ARK.ViewModel.Administrationssystem
{
    public class TripsViewModel : ContentViewModelBase, IFilterContentViewModel
    {
        public BoatListWindow NewBoatDialog;

        public TripMembersWindow NewTripMembersDialog;

        private List<Boat> _allBoats;

        private Trip _currentTrip;

        private Member _selectedMember;

        private List<Member> _allMembers;

        private bool _recentSave;

        private List<Trip> _trips;

        private IEnumerable<Trip> _tripsFiltered;

        public TripsViewModel()
        {
            ParentAttached += (sender, e) =>
                {
                    // Load data
                    using (var db = new DbArkContext())
                    {
                        _trips = db.Trip.Include(trip => trip.Members).ToList();
                        _allMembers = db.Member.OrderBy(m => m.FirstName).ToList();
                        _allBoats = db.Boat.ToList();

                        if (_trips.Count != 0)
                        {
                            if (CurrentTrip != null)
                            {
                                CurrentTrip = _trips[0];
                            }

                            // LocalTrip = CurrentTrip;
                        }
                    }

                    // Reset filter
                    ResetFilter();
                };

            // Setup filter
            var filterController = new FilterContent(this);
            filterController.EnableFilter(true, true);
            filterController.FilterChanged += (o, eventArgs) => UpdateFilter(eventArgs);
        }

        public List<Boat> AllBoats
        {
            get
            {
                return _allBoats;
            }

            set
            {
                _allBoats = value;
                Notify();
            }
        }

        public List<Member> AllMembers
        {
            get
            {
                return _allMembers;
            }

            set
            {
                _allMembers = value;
                Notify();
            }
        }

        public ICommand CancelChanges
        {
            get
            {
                return GetCommand(Reload);
            }
        }

        public Trip CurrentTrip
        {
            get
            {
                return _currentTrip;
            }

            set
            {
                if (_currentTrip != value)
                    RecentSave = false;

                _currentTrip = value;
                Notify();
            }
        }

        public Member SelectedMember
        {
            get
            {
                return _selectedMember;
            }
            set
            {
                _selectedMember = value;
                Notify();
            }
        }

        public bool RecentSave
        {
            get
            {
                return _recentSave;
            }

            set
            {
                _recentSave = value;
                Notify();
            }
        }

        public ICommand SaveChanges
        {
            get
            {
                // CurrentTrip = LocalTrip;
                return GetCommand(Save);
            }
        }

        public void OpenTrip(Trip boat)
        {
            CurrentTrip = TripsFiltered.FirstOrDefault(b => b.Id == boat.Id);

            if (CurrentTrip == null)
            {
                if (_trips.FirstOrDefault(b => b.Id == boat.Id) == null)
                {
                    ResetFilter();
                    CurrentTrip = _trips.FirstOrDefault(b => b.Id == boat.Id);
                }
                else
                {
                    MessageBox.Show("Båden eksisterer ikke mere i systemet.");
                }
            }
        }

        public ICommand ShowBoatDialog
        {
            get
            {
                return GetCommand(
                    () =>
                        {
                            NewBoatDialog = new BoatListWindow();
                            NewBoatDialog.DataContext = this;
                            NewBoatDialog.ShowDialog();
                        });
            }
        }

        public ICommand ShowBoatsContinue
        {
            get
            {
                return GetCommand(
                    e =>
                        {
                            NewBoatDialog.Close();

                            CurrentTrip.Boat = (Boat)e;
                            CurrentTrip.BoatId = CurrentTrip.Boat.Id;

                            NotifyCustom("CurrentTrip");
                        });
            }
        }

        public ICommand ShowMemberDialog
        {
            get
            {
                return GetCommand(
                    () =>
                    {
                        NewTripMembersDialog = new TripMembersWindow();
                        NewTripMembersDialog.DataContext = this;
                        NewTripMembersDialog.ShowDialog();
                    });
            }
        }

        public ICommand AddMemberToTrip
        {
            get
            {
                return GetCommand(
                    e =>
                    {
                        foreach (Member member in CurrentTrip.Members)
                        {
                            if ((Member)e == member)
                            {
                                MessageBox.Show("Medlem er allerede på tur");
                                return;
                            }
                        }


                        CurrentTrip.ObservableMembers.Add((Member)e);
                        NewTripMembersDialog.Close();
                    });
            }
        }

        public ICommand RemoveMemberFromTrip
        {
            get
            {
                return GetCommand(
                    () =>
                    {
                        CurrentTrip.ObservableMembers.Remove(SelectedMember);
                    });
            }
        }

        public IEnumerable<Trip> TripsFiltered
        {
            get
            {
                return _tripsFiltered;
            }

            set
            {
                _tripsFiltered = value;
                Notify();
            }
        }

        public FrameworkElement Filter
        {
            get
            {
                return new TripFilter();
            }
        }

        public void UpdateList<T>(IEnumerable<T> list)
        {
            var tmp = TripsFiltered;
            TripsFiltered = null;
            TripsFiltered = tmp;
        }

        private void Reload()
        {
            using (var db = new DbArkContext())
            {
                db.Entry(CurrentTrip).State = EntityState.Modified;
                db.Entry(CurrentTrip).Reload();
            }

            RecentSave = false;

            // Trigger notify - reset lists
            UpdateList<Trip>(TripsFiltered);

            NotifyCustom("CurrentTrip");
        }

        private void ResetFilter()
        {
            TripsFiltered = _trips;
        }

        private void Save()
        {
            using (var db = new DbArkContext())
            {
                Trip trip = db.Trip.Find(CurrentTrip.Id);
                db.Entry(trip).CurrentValues.SetValues(CurrentTrip);

                db.Entry(trip).State = EntityState.Modified;
                db.Entry(trip.Boat).State = EntityState.Modified;

                db.SaveChanges();
            }

            // Trigger notify - reset lists
            UpdateList<Trip>(TripsFiltered);

            RecentSave = true;
        }

        private void UpdateFilter(FilterChangedEventArgs args)
        {
            // Reset filters
            ResetFilter();

            if ((args.FilterEventArgs == null || !args.FilterEventArgs.Filters.Any())
                && (args.SearchEventArgs == null || string.IsNullOrEmpty(args.SearchEventArgs.SearchText)))
            {
                return;
            }

            // Filter
            if (args.FilterEventArgs != null && args.FilterEventArgs.Filters.Any())
            {
                TripsFiltered = FilterContent.FilterItems(TripsFiltered, args.FilterEventArgs);
            }

            // Tjek søgning
            if (args.SearchEventArgs != null && !string.IsNullOrEmpty(args.SearchEventArgs.SearchText))
            {
                TripsFiltered = TripsFiltered.Where(trip => trip.Filter(args.SearchEventArgs.SearchText)).ToList();
            }
        }
    }
}