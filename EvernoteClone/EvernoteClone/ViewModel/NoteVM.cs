using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;
using EvernoteClone_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EvernoteClone.ViewModel
{
    public class NoteVM
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set { selectedNotebook = value;
                //TODO: Get Notes
            }
        }
        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }

        public NoteVM()
        {
            NewNotebookCommand = new(this);
            NewNoteCommand = new(this);
        }

        public void CreateNotebook()
        {
            Notebook newNotebook = new()
            {
                Name = "New Notebook"
            };
            DatabaseHelper.Insert(newNotebook);
        }

        public void CreateNote(int notebookID)
        {
            Note newNote = new()
            {
                NotebookId = notebookID,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = "NewNote"
            };
            DatabaseHelper.Insert(newNote);
        }

        
    }
}
