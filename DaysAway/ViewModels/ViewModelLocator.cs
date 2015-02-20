/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DaysAway"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using DaysAway.DataModel;
using DaysAway.Repositories;
using DaysAway.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;

namespace DaysAway.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var navigationService = CreateNavigationService();

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<ICommitmentRepository>(() => new CommitmentInMemoryRepository());

            SimpleIoc.Default.Register<MainViewModel>();
            //SimpleIoc.Default.Register<CommitmentViewModel>();
            SimpleIoc.Default.Register<CommitmentViewModel>(() => new CommitmentViewModel(navigationService, new CommitmentInMemoryRepository()));
            
        }


        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure("Commitment", typeof(CommitmentView));
            navigationService.Configure("CommitmentGrid", typeof(CommitmentGridView));


            return navigationService;
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public CommitmentViewModel NewCommitment
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CommitmentViewModel>(Guid.NewGuid().ToString());
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}