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
using System.Windows.Shapes;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        private Contact contact;
        public ContactWindow(Contact c)
        { 
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            contact = c;
            Nametb.Text = contact.Name;
            Emailtb.Text = contact.Email;
            PhoneNumbertb.Text = contact.PhoneNumber;
        }

        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new(App.databasePath))
            {
                //Insert the contact into the table
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }
            Close();
        }

        private void UpdateContact_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = Nametb.Text;
            contact.Email = Emailtb.Text;
            contact.PhoneNumber = PhoneNumbertb.Text;
            using (SQLiteConnection connection = new(App.databasePath))
            {
                //Insert the contact into the table
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }
            Close();
        }
    }
}
