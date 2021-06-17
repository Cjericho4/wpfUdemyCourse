using System;
using System.Linq;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string V = "Contacts.db";
        static readonly string dataBaseName = V;
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string databasePath = System.IO.Path.Combine(folderPath, dataBaseName);
    }
}
