using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EvernoteClone.ViewModel;
using EvernoteClone_.Model;

namespace EvernoteClone.ViewModel.Commands
{
    public class RegisterCommand 
    {
        public LoginVM VM { get; set; }

        public RegisterCommand(LoginVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChange;

        public bool CanExecute(object parameter)
        {
            User user = parameter as User;
            if (user == null)
                return false;
            if (string.IsNullOrEmpty(user.Username))
                return false;
            if (string.IsNullOrEmpty(user.Password))
                return false;
            if (string.IsNullOrEmpty(user.ConfirmPassword))
                return false;
            if (user.Password != user.ConfirmPassword)
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Register(); 
        }
    }
}
