using EvernoteClone_.Model;
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

namespace EvernoteClone.View.UserControls
{
    /// <summary>
    /// Interaction logic for NoteUI.xaml
    /// </summary>
    public partial class NoteUI : UserControl
    {


        public Note NoteUC
        {
            get { return (Note)GetValue(NoteUCProperty); }
            set { SetValue(NoteUCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteUCProperty =
            DependencyProperty.Register("NoteUC", typeof(Note), typeof(NoteUI), new PropertyMetadata(null, SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NoteUI noteUC = d as NoteUI;
            
            if(noteUC != null)
            {
                noteUC.DataContext = noteUC.NoteUC;
            }
        }

        public NoteUI()
        {
            InitializeComponent();
            

        }
    }
}
