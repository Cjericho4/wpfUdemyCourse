using EvernoteClone.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EvernoteClone.ViewModel.Helpers;
using System.IO;
using EvernoteClone_;

namespace EvernoteClone.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        NoteVM viewModel;
        public NotesWindow()
        {
            InitializeComponent();

            viewModel = Resources["vm"] as NoteVM;
            viewModel.SelectedNoteChanged += ViewModel_SelectedNoteChanged;

            //Initialize the Font Selection.
            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            FontFamilyComboBox.ItemsSource = fontFamilies;

            List<double> fontSizes = new() { 8, 9, 10, 12, 14, 16, 18, 20, 24, 32, 48, 72 };
            FontSizeComboBox.ItemsSource = fontSizes;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (string.IsNullOrEmpty(App.UserID))
            {
                LoginWindow login = new();
                login.ShowDialog();
            }
        }

        private void ViewModel_SelectedNoteChanged(object sender, EventArgs e)
        {
            notepadContent.Document.Blocks.Clear();
            if(viewModel.SelectedNote != null)
            {
                if (!string.IsNullOrEmpty(viewModel.SelectedNote.FileLocation))
                {
                    FileStream fileStream = new(viewModel.SelectedNote.FileLocation, FileMode.Open);
                    var contents = new TextRange(notepadContent.Document.ContentStart, notepadContent.Document.ContentEnd);
                    contents.Load(fileStream, DataFormats.Rtf);
                    fileStream.Close();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void notepadContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            int charsWritten = new TextRange(notepadContent.Document.ContentStart, notepadContent.Document.ContentEnd).Text.Trim().Length;

            StatusTextBlock.Text = $"Character written: {charsWritten}";

            FontFamilyComboBox.SelectedItem = notepadContent.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
            FontSizeComboBox.Text = notepadContent.Selection.GetPropertyValue(TextElement.FontSizeProperty).ToString();
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked = (sender as ToggleButton).IsChecked ?? false;
            if (isChecked)
            {
                notepadContent.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                notepadContent.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
            }
        }

        private void NotepadContent_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var seledtedWeight = notepadContent.Selection.GetPropertyValue(FontWeightProperty);
            boldButton.IsChecked = (seledtedWeight != DependencyProperty.UnsetValue) && seledtedWeight.Equals(FontWeights.Bold);
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FontFamilyComboBox.SelectedItem != null)
            {
                notepadContent.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, FontFamilyComboBox.SelectedItem);

            }
        }

        private void FontSizeComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            notepadContent.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, FontSizeComboBox.Text);
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string rtfFile = System.IO.Path.Combine(Environment.CurrentDirectory, $"{viewModel.SelectedNote.Id}.rtf");
            viewModel.SelectedNote.FileLocation = rtfFile;
            viewModel.SelectedNote.UpdatedAt = DateTime.Now;
            _ = DatabaseHelper.Update(viewModel.SelectedNote);

            FileStream file = new(rtfFile, FileMode.Create);
            var contents = new TextRange(notepadContent.Document.ContentStart, notepadContent.Document.ContentEnd);
            contents.Save(file, DataFormats.Rtf);
            file.Close();
        }
    }
}
