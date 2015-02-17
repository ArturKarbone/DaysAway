using DaysAway.Commands;
using DaysAway.Common;
using DaysAway.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DaysAway.ViewModels
{
    public class CommitmentViewModel : INotifyPropertyChanged
    {

        public ICommand NavigateToCommitment { get; set; }

        public CommitmentViewModel()
        {
            this.NavigateToCommitment = new RelayCommand<object>((parameter) =>
            {
                var navigationService = new NavigationService();
                var commitment = parameter as CommitmentViewModel;
                navigationService.Navigate(typeof(CommitmentView), commitment.Id);
            });
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
