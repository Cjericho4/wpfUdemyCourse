using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLite;
using DesktopContactsApp.Classes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        void ReadDatabase()
        {
            var contacts = connection.Table<Contact>().ToList();
            using (SQLite.SQLiteConnection connection = new(App.databasePath))
            {
                connection.CreateTable<Contact>();
                
            }
        }

        private void NewContactWindow_Click(object sender, RoutedEventArgs e)
        {
            //Adds new contact to the database
            NewContactWindow newContact = new NewContactWindow();
            newContact.ShowDialog();
            //Update the contact list with just created contact.
            ReadDatabase();
        }


    }
}
