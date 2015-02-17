﻿using DaysAway.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DaysAway.ViewModels
{
    public class CommitmentViewModel : INotifyPropertyChanged
    {

        public NavigateToCommitment NavigateToCommitment { get; set; }

        public CommitmentViewModel()
        {
            this.NavigateToCommitment = new NavigateToCommitment();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public int DaysAway
        {
            get
            {
                return (DueDate - DateTime.Now).Days;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
