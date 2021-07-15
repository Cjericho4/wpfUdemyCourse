using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EvernoteClone.ViewModel;

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
            return true;
        }

        public void Execute(object parameter)
        {
            //TODO: Login Functionality 
        }
    }
}
