using DesktopContactsApp.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();

        }

        public void ReadDatabase()
        {
            using (SQLite.SQLiteConnection connection = new(App.databasePath))
            {
                connection.CreateTable<Contact>();
                //Orders list alphabetically
                contacts = connection.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
            }
            if (contacts != null)
            {
                ContactListView.ItemsSource = contacts;
            }
        }

        private void NewContactWindow_Click(object sender, RoutedEventArgs e)
        {
            //Adds new contact to the database
            NewContactWindow newContact = new();
            _ = newContact.ShowDialog();
            //Update the contact list with just created contact.
            ReadDatabase();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchText = sender as TextBox;
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchText.Text.ToLower())).ToList();
            ContactListView.ItemsSource = filteredList;
        }

        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)ContactListView.SelectedItem;
            if(selectedContact != null)
            {
                ContactWindow contactWindow = new(selectedContact);
                _ = contactWindow.ShowDialog();
            }
            ReadDatabase();
        }
    }
}
