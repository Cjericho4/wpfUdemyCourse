using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;
using EvernoteClone_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EvernoteClone.ViewModel
{
    public class NoteVM : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook selectedNotebook;

        public event PropertyChangedEventHandler PropertyChanged;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set { selectedNotebook = value;
                OnPropertyChanged("SelectedNotebook");
                GetNotes();
            }
        }
        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }

        public NoteVM()
        {
            NewNotebookCommand = new(this);
            NewNoteCommand = new(this);

            Notes = new();
            Notebooks = new();

            GetNotebooks();
        }

        private void GetNotebooks()
        {
           var notebooks = DatabaseHelper.Read<Notebook>();

            Notebooks.Clear();
            foreach(Notebook book in notebooks)
            {
                Notebooks.Add(book);
            }
        }

        private void GetNotes()
        {
            if (SelectedNotebook != null)
            {
                var notes = DatabaseHelper.Read<Note>().Where(n => n.NotebookId == SelectedNotebook.Id).ToList();

                Notes.Clear();
                foreach (var rit in notes)
                {
                    Notes.Add(rit);
                }
            }
        }
        public void CreateNotebook()
        {
            Notebook newNotebook = new()
            {
                Name = "New Notebook"
            };
            DatabaseHelper.Insert(newNotebook);
            GetNotebooks();
        }

        public void CreateNote(int notebookID)
        {
            Note newNote = new()
            {
                NotebookId = notebookID,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = $"Note for {DateTime.Now.ToString()}"
            };
            DatabaseHelper.Insert(newNote);
            GetNotes();
        }
        
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        
    }
}
