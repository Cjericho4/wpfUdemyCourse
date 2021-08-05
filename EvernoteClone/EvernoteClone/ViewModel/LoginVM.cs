using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone_.Model;

namespace EvernoteClone.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        private bool isShowingRegisterView = false;
        private User user;

        public event PropertyChangedEventHandler PropertyChanged;

        public User User
        {
            get => user;
            set
            {
                user = value;
                onPropertyChanged("User");
            }
        }

        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                User = new User
                {
                    Username = username,
                    Password = Password,
                    Name = Name,
                    ConfirmPassword = ConfirmPsswd,
                    LastName = LastName
                };
                onPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                User = new User
                {
                    Username = Username,
                    Password = password,
                    Name = Name,
                    ConfirmPassword = ConfirmPsswd,
                    LastName = LastName
                };
                password = value;
                onPropertyChanged("Password");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                User = new User
                {
                    Name = name,
                    Username = Username,
                    Password = Password,
                    LastName = LastName,
                    ConfirmPassword = ConfirmPsswd
                };
                name = value;
                onPropertyChanged("Name");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set 
            {
                lastName = value;
                User = new User
                {
                    LastName = lastName,
                    Username = Username,
                    Password = Password,
                    Name = Name,
                    ConfirmPassword = ConfirmPsswd
                };
                onPropertyChanged("LastName");
            }
        }

        private string confirmPsswd;
        public string ConfirmPsswd
        {
            get { return confirmPsswd; }
            set
            {
                confirmPsswd = value;
                User = new User
                {
                    LastName = LastName,
                    Username = Username,
                    Password = Password,
                    Name = Name,
                    ConfirmPassword = ConfirmPsswd
                };
                onPropertyChanged("ConfirmPsswd");
            }
        }

        public LoginCommand LoginCommand { get; set; }
        public RegisterCommand RegisterCommandop { get; set; }
        public ShowRegisterCommand ShowRegisterCommand { get; set; }
        public LoginVM()
        {
            LoginVisibility = Visibility.Visible;
            RegisterVisibility = Visibility.Collapsed;

            RegisterCommandop = new(this);
            LoginCommand = new(this);
            ShowRegisterCommand = new(this);

            user = new();

        }

        private Visibility loginVisibility;

        public Visibility LoginVisibility
        {
            get => loginVisibility;
            set
            {
                loginVisibility = value;
                onPropertyChanged("LoginVisibility");
            }
        }
        private Visibility registerVisibility;

        public Visibility RegisterVisibility
        {
            get => registerVisibility;
            set
            {
                registerVisibility = value;
                onPropertyChanged("RegisterVisibility");
            }
        }
        public void SwitchViews()
        {
            isShowingRegisterView = !isShowingRegisterView;
            if (isShowingRegisterView)
            {
                RegisterVisibility = Visibility.Visible;
                LoginVisibility = Visibility.Collapsed;
            }
            else
            {
                RegisterVisibility = Visibility.Collapsed;
                LoginVisibility = Visibility.Visible;
            }
        }
        private void onPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void Login()
        {
            // TODO: Login!
        }

        public void Register()
        {
            //TODO: Register!
        }
    }
}
