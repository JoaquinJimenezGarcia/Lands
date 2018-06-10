using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email 
        { 
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        
        public string Password 
        { 
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning 
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered { get; set; }

        public bool IsEnabled 
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }   
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand { get { return new RelayCommand(Login);  } }
        public ICommand RegisterCommand { get { return new RelayCommand(Register); } }
        #endregion

        private async void Login()
        {

            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    "You must enter a valid email.", 
                    "Accept");

                this.Email = string.Empty;

                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password.",
                    "Accept");

                this.Password = string.Empty;

                return;
            }

            this.IsEnabled = false;
            this.IsRunning = true;

            if(this.Email != "garcia" || this.Password != "555")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect.",
                    "Accept");

                this.IsEnabled = true;
                this.IsRunning = false;
                
                this.Password = string.Empty;
                this.Email = string.Empty;

                return;
            }

            await Application.Current.MainPage.DisplayAlert(
                    "Ok",
                    "Logged in!.",
                    "Accept");

            this.IsEnabled = true;
            this.IsRunning = false;
        }

        private async void Register()
        {
            
        }
    }
}
