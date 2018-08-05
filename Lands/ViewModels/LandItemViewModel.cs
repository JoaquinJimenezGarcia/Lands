using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Lands.Models;
using Xamarin.Forms;
using Lands.Views;

namespace Lands.ViewModels
{
    public class LandItemViewModel : Land
    {
        #region Commands
        public ICommand SelectLandCommand
        {
            get { return new RelayCommand(SelectLand); }
        }

        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandPage());
        }
        #endregion
    }
}
