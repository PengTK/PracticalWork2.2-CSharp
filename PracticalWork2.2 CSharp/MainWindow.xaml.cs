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

namespace PracticalWork2._2_CSharp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int idSelected;
        List<Note> notes;
        List<Note> selectedNotes = new List<Note>();
        public MainWindow()
        {
            InitializeComponent();
            notes = SaveLoad.Load();
            DatePicker.Text = DateTime.Now.ToString();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(DatePicker.Text);
            List<string> noteNames = new List<string>();
            foreach (Note note in notes)
            {
                if (note.Date == date)
                {
                    selectedNotes.Add(note);
                    noteNames.Add(note.Name);
                }
            }
            Menu.ItemsSource = noteNames;
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < notes.Count; i++)
            {

                if (Menu.SelectedItem == notes[i].Name)
                {
                    Name.Text = notes[i].Name;
                    Text.Text = notes[i].Description;
                    idSelected = i;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            notes.RemoveAt(idSelected);
            UpDate();
            SaveLoad.Save(notes);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            notes.Add(new Note(Name.Text, Text.Text, Convert.ToDateTime(DatePicker.Text)));
            UpDate();
            SaveLoad.Save(notes);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            notes.RemoveAt(idSelected);
            notes.Add(new Note(Name.Text, Text.Text, Convert.ToDateTime(DatePicker.Text)));
            UpDate();
            SaveLoad.Save(notes);
        }

        private void UpDate()
        {
            DateTime date = Convert.ToDateTime(DatePicker.Text);
            List<string> noteNames = new List<string>();
            foreach (Note note in notes)
            {
                if (note.Date == date)
                {
                    selectedNotes.Add(note);
                    noteNames.Add(note.Name);
                }
            }
            Menu.ItemsSource = noteNames;
        }
    }
}
