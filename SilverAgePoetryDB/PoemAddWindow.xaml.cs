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
    /// Interaction logic for PoemAddWindow.xaml
    /// </summary>
    public partial class PoemAddWindow : Window
    {
        public ObservableCollection<string> AuthorsListBox { get; set; }
        public Author selectedAuthor { get; set; }
        public Poem PoemToAdd { get; set; }

        public PoemAddWindow()
        {
            InitializeComponent();
            AuthorsListBox = new ObservableCollection<string>();
            PoemToAdd = new SilverAgePoetryDB.Poem();

            foreach (Author author in DB.Authors)
            {
                AuthorsListBox.Add(author.Surname + " " + author.Name + " " + author.MiddleName);
            }
            authorsBox.DataContext = AuthorsListBox;
        }

        private void authorsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAuthor = DB.Authors.Find(x => x.Surname + " " + x.Name + " " + x.MiddleName == authorsBox.SelectedItem.ToString());
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            writingStartBox.Background = Brushes.White;
            writingEndBox.Background = Brushes.White;
            publicationBox.Background = Brushes.White;
            textBlock1.Background = Brushes.White;

            bool check = true;
            if (writingStartBox.Text != null)
            {
                if (!writingStartBox.Text.All(x => char.IsDigit(x)) || (writingStartBox.Text.Count() > 4))
                {
                    writingStartBox.Background = Brushes.Red;
                    check = false;
                }
            }

            if (publicationBox.Text != null)
            {
                if (!publicationBox.Text.All(x => char.IsDigit(x)) || (publicationBox.Text.Count() > 4))
                {
                    publicationBox.Background = Brushes.Red;
                    check = false;
                }
            }

            if (writingStartBox.Text != null)
            {
                if (!writingEndBox.Text.All(x => char.IsDigit(x)) || (writingEndBox.Text.Count() > 4))
                {
                    writingEndBox.Background = Brushes.Red;
                    check = false;
                }
            }

            if (nameBox.Text == null)
            {
                check = false;
            }

            if (PoemToAdd.Author == null)
            {
                check = false;
                textBlock1.Background = Brushes.Red;
            }

            if (check)
            {
                PoemToAdd.Name = nameBox.Text;
                PoemToAdd.WritingStartDate = writingStartBox.Text;
                PoemToAdd.WritingEndDate = writingEndBox.Text;
                PoemToAdd.PublicationDate = publicationBox.Text;
                PoemToAdd.Text = poemTextBox.Text;
                DB.AddPoem(PoemToAdd);

                this.Close();
            }
        }
    }
}
