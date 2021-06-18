using System;
using System.Windows;
using System.Windows.Controls;
using DesktopContactsApp.Classes;

namespace DesktopContactsApp.Control
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        //private Contact contact;

        //public Contact Contact
        //{
        //    get { return contact; }
        //    set { 
        //        contact = value;
        //        NameText.Text = contact.Name;
        //        Email.Text = contact.Email;
        //        PhoneNumber.Text = contact.PhoneNumber;
        //    }
        //}

        public Contact Contact
        {
            get => (Contact)GetValue(ContactProperty);
            set => SetValue(ContactProperty, value);
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact() { Name = "Name", Email = "example@example.com", PhoneNumber = "801-411-1111" }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            if(control!= null)
            {
                control.NameText.Text = (e.NewValue as Contact).Name;
                control.Email.Text = (e.NewValue as Contact).Email;
                control.PhoneNumber.Text = (e.NewValue as Contact).PhoneNumber;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
