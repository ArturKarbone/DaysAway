using AutoMapper;
using DaysAway.Common;
using DaysAway.DataModel;
using DaysAway.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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

        public INavigationService NavigationService { get; set; }
        public ICommitmentRepository Repository { get; set; }


        public CommitmentViewModel(INavigationService navigationService, ICommitmentRepository repository)
        {
            this.NavigationService = navigationService;
            this.Repository = repository;

            this.NavigateToCommitment = new RelayCommand<CommitmentViewModel>((commitmentVM) =>
            {
                NavigationService.NavigateTo("Commitment", commitmentVM.Id);
            });

            this.InsertUpdateCommitment = new RelayCommand<CommitmentViewModel>(async (commitmentVM) =>
            {
                await Repository.InsertUpdate(Mapper.Map<Commitment>(commitmentVM));
                NavigationService.NavigateTo("CommitmentGrid");
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


        public async void Bind(int key)
        {
            if (key != 0)
            {
                var commitment = Mapper.Map<CommitmentViewModel>(await Repository.Get(key));                
                this.Bind(commitment);
            }
            else
            {
                var model = App.Locator.NewCommitment;
                model.DueDate = DateTime.Now;

                this.Bind(model);
            }
        }

        private void Bind(CommitmentViewModel vm)
        {
            this.Id = vm.Id;
            this.Title = vm.Title;
            this.DueDate = vm.DueDate;

            this.RaisePropertyChanged("Title");
            this.RaisePropertyChanged("DueDate");
        }
    }
}
