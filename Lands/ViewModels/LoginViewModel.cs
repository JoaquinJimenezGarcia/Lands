using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email 
        { 
            get 
            {
                return email;
            } 
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    PropertyChanged?.Invoke(
                    this,
                        new PropertyChangedEventArgs(nameof(this.Email)));

                }
            }
        }
        
        public string Password 
        { 
            get
            {
                return password;
            }

            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    PropertyChanged?.Invoke(
                    this,
                        new PropertyChangedEventArgs(nameof(this.Password)));
                }
            }
        }
        public bool IsRunning 
        {
            get
            {
                return isRunning;
            }

            set
            {
                if (this.isRunning != value)
                {
                    this.isRunning = value;
                    PropertyChanged?.Invoke(
                    this,
                        new PropertyChangedEventArgs(nameof(this.IsRunning)));
                }
            }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnabled 
        {
            get
            {
                return isEnabled;
            }

            set
            {
                if (this.isEnabled != value)
                {
                    this.isEnabled = value;
                    PropertyChanged?.Invoke(
                    this,
                        new PropertyChangedEventArgs(nameof(this.IsEnabled)));
                }
            }    
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
