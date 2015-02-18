using AutoMapper;
using DaysAway.DataModel;
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
    public class MainViewModel : ViewModelBase
    {
        public INavigationService NavigationService { get; set; }
        public ICommand NavigateToAddNewCommitment { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;

            this.NavigateToAddNewCommitment = new RelayCommand(() =>
            {
                NavigationService.NavigateTo("Commitment", 0);
            });


            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private List<CommitmentViewModel> m_Commitments;
        public List<CommitmentViewModel> Commitments
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
            var commitmentRepository = new CommitmentInMemoryRepository();
            this.Commitments = (await commitmentRepository.GetAll()).Select(x => Mapper.Map<CommitmentViewModel>(x)).ToList();
        }
    }
}
