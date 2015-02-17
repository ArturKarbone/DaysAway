using DaysAway.Services;
using DaysAway.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DaysAway.Commands
{
    public class NavigateToCommitment : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var navigationService = new NavigationService();
            var commitment = parameter as CommitmentViewModel;
            navigationService.Navigate(typeof(CommitmentView), commitment.Id);
        }
    }
}
