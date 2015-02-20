using AutoMapper;
using DaysAway.DataModel;
using DaysAway.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DaysAway.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigationService NavigationService { get; set; }
        public ICommitmentRepository Repository { get; set; }
        public ICommand NavigateToAddNewCommitment { get; set; }

        public MainViewModel(INavigationService navigationService, ICommitmentRepository repository)
        {
            this.NavigationService = navigationService;
            this.Repository = repository;


            this.NavigateToAddNewCommitment = new RelayCommand(() =>
            {
                NavigationService.NavigateTo("Commitment", 0);
            });
        }

        private ObservableCollection<CommitmentViewModel> m_Commitments;
        public ObservableCollection<CommitmentViewModel> Commitments
        {
            get
            {
                return m_Commitments;
            }
            set
            {
                m_Commitments = value;
                RaisePropertyChanged();
            }
        }

        public async Task Bind()
        {
            var commitments = await Repository.GetAll();
            this.Commitments = new ObservableCollection<CommitmentViewModel>(commitments.Select(x => Mapper.Map<CommitmentViewModel>(x)));
        }
    }
}
