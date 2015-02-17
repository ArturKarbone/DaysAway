using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DaysAway.Services
{
    public class NavigationService
    {     
        public void Navigate(Type sourcePageType, object parameter = null)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType, parameter);
        }
        public void GoBack()
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
