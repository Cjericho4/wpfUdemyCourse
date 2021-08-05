using EvernoteClone_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class EndEditing : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public EndEditing(NoteVM vm)
        {
            ViewModel = vm;
        }

        public NoteVM ViewModel { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Notebook notebook and not null)
            {
                ViewModel.StopEditing(notebook);
            }
        }
    }
}
