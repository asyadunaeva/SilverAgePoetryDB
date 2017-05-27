using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SilverAgePoetryDB
{
    /// <summary>
    /// Interaction logic for PoemsWindow.xaml
    /// </summary>
    public partial class PoemsWindow : Window
    {
        public ObservableCollection<string> NamesListBox { get; set; }
        public Poem selectedPoem { get; set; }

        public PoemsWindow()
        {
            InitializeComponent();

            NamesListBox = new ObservableCollection<string>();

            foreach (Poem poem in DB.Poems)
            {
                NamesListBox.Add(poem.Name);
            }
            listBox.DataContext = NamesListBox;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NamesListBox.Clear();
            List<Poem> searchPoems = new List<Poem>();
            foreach (Poem poem in DB.Poems)
            {
                if (poem.Name.Contains(textBox.Text))
                {
                    searchPoems.Add(poem);
                }
            }
            foreach (Poem poem in searchPoems)
            {
                NamesListBox.Add(poem.Name);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedPoemName = listBox.SelectedItem.ToString();
            selectedPoem = DB.Poems.Find(x => x.Name == selectedPoemName);

            poemNameField.Text = selectedPoem.Name;
            authorNameField.Text = selectedPoem.Author.Name;
            writingDateField.Text = selectedPoem.WritingStartDate.ToShortDateString() + "-" + selectedPoem.WritingEndDate.ToShortDateString();
            publicationDateField.Text = selectedPoem.PublicationDate.ToShortDateString();


        }
    }
}
