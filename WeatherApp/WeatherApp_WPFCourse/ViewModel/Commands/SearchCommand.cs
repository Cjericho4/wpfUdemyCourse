using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp_WPFCourse.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
                
        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
       {
            if (string.IsNullOrWhiteSpace(VM.Query))
            {
                return false;
            }
            return true;
       }

        public void Execute(object parameter)
        {
            VM.MakeQuery();
        }
    }
}
