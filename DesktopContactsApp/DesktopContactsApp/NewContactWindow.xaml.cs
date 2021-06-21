﻿using System;
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
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void SaveContact_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                //TODO: Save the Contact
                Contact contact = new()
                {
                    Name = nameTextBox.Text,
                    Email = emailTextBox.Text,
                    PhoneNumber = phoneTextBox.Text
                };
                
                using (SQLiteConnection connection = new(App.databasePath))
                {
                    //Insert the contact into the table
                    connection.CreateTable<Contact>();
                    connection.Insert(contact);
                }

                //Close the window 
                Close();
            }
        }
    }
}
