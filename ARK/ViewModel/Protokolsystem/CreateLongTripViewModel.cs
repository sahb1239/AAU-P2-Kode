﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARK.Model;
using System.Collections.ObjectModel;
using ARK.Model.DB;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;

namespace ARK.ViewModel.Protokolsystem
{
    public class CreateLongTripViewModel : ProtokolsystemContentViewModelBase
    {
        // Fields
        private List<Member> _members = new List<Member>();
        private readonly ObservableCollection<MemberViewModel> _selectedMembers = new ObservableCollection<MemberViewModel>(); // Members in boat
        private List<MemberViewModel> _membersFiltered;
        private List<LongTripForm> _longTripForms;

        // Constructor
        public CreateLongTripViewModel()
        {
            var db = DbArkContext.GetDbContext();

            // Set up variables to load of data
            Task<List<Member>> _membersAsync = null;

            // Async start load of data
            _membersAsync = db.Member.OrderBy(x => x.FirstName).ToListAsync();
            _membersFiltered = _membersAsync.Result.Select(member => new MemberViewModel(member)).ToList();
            
            // get long trip forms
            _longTripForms = db.LongTripForm.OrderBy(x => x.FormCreated).Where(x => true).ToList();
        }

        // Properties
        public DateTime FormCreated { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Comment { get; set; }

        public List<MemberViewModel> MembersFiltered
        {
            get { return _membersFiltered; }
            set { _membersFiltered = value; }
        }

        public ObservableCollection<MemberViewModel> SelectedMembers
        {
            get { return _selectedMembers; }
        }

        public List<LongTripForm> LongTripForms
        {
            get { return _longTripForms; }
            set { _longTripForms = value; }
        }

        public ICommand AddLongTrip
        {
            get
            {
                return GetCommand<object>(d =>
                {
                    var longTripForm = new LongTripForm();

                    longTripForm.Members = SelectedMembers.ToList();
                    longTripForm.Status = LongTripForm.BoatStatus.Awaiting;
                    longTripForm.FormCreated = DateTime.Now;
                    longTripForm.PlannedStartDate = StartDate;
                    longTripForm.PlannedEndDate = EndDate;
                });
            }
        }
    }
}
