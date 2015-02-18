using AutoMapper;
using DaysAway.Commands;
using DaysAway.Common;
using DaysAway.DataModel;
using DaysAway.Services;
using GalaSoft.MvvmLight;
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
    public class CommitmentViewModel : ViewModelBase
    {

        public ICommand NavigateToCommitment { get; set; }
        public ICommand NavigateToAddNewCommitment { get; set; }
        public ICommand InsertUpdateCommitment { get; set; }

        public CommitmentViewModel()
        {
            this.NavigateToCommitment = new RelayCommand<CommitmentViewModel>((commitmentVM) =>
            {
                var navigationService = new NavigationService();               
                navigationService.Navigate(typeof(CommitmentView), commitmentVM.Id);
            });

       

            this.InsertUpdateCommitment = new RelayCommand<CommitmentViewModel>(async (commitmentVM)=>
            {
                var repo = new CommitmentInMemoryRepository();
                await repo.InsertUpdate(Mapper.Map<Commitment>(commitmentVM));
                var navigationService = new NavigationService();
                navigationService.Navigate(typeof(CommitmentGridView));
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
      

    }
}
