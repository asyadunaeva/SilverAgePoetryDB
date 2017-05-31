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
            if (listBox.SelectedItem != null)
            {
                string selectedPoemName = listBox.SelectedItem.ToString();
                selectedPoem = DB.Poems.Find(x => x.Name == selectedPoemName);
            }

            poemNameField.Text = selectedPoem.Name ?? null;
            if (DB.Authors.Contains(selectedPoem.Author))
            {
                authorNameField.Text = selectedPoem.Author.Name;
            }
            else
            {
                authorNameField.Text = "Автор не указан";
            }
            if (selectedPoem.WritingStartDate != null && selectedPoem.WritingEndDate != null)
            {
                writingDateField.Text = selectedPoem.WritingStartDate + "-" + selectedPoem.WritingEndDate;
            }
            else
            {
                writingDateField.Text = "Дата написания не указана";
            }
            if (selectedPoem.PublicationDate != null)
            {
                publicationDateField.Text = selectedPoem.PublicationDate;
            }
            else
            {
                publicationDateField.Text = "Дата публикации не указана";
            }
            poemText.Text = selectedPoem.Text ?? "Текст стиха отсутствует в базе!";

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PoemAddWindow poemAddWindow = new PoemAddWindow();
            poemAddWindow.Show();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPoem != null)
            {
                DB.DeletePoem(DB.Poems.Find(x => x.Name == selectedPoem.Name));

                NamesListBox.Clear();

                foreach (Poem poem in DB.Poems)
                {
                    NamesListBox.Add(poem.Name);
                }
                listBox.DataContext = NamesListBox;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            PoemAddWindow poemChangeWindow = new PoemAddWindow(selectedPoem);
            poemChangeWindow.Show();
        }
    }
}
