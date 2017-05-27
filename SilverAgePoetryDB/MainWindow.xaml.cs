using System;
using System.Collections.Generic;
using System.IO;
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

namespace SilverAgePoetryDB
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DB.ReadPoems();
            DB.ReadAuthors();

            if (DB.Poems.Any())
            {
                string randomPoemText;
                Random rnd = new Random();
                Poem randomPoem = DB.Poems[rnd.Next(DB.Poems.Count)];
                randomPoemText = randomPoem.Name + "\n" + randomPoem.Author.Name + "\n" + randomPoem.Text;
                randomPoem.Text = randomPoemText;
            }
            else
            {
                textBlock1.Text = "Похоже, в базе пока нет ни одного стиха!";
            }
        }

        private void PoemsButton_Click(object sender, RoutedEventArgs e)
        {
            PoemsWindow poemsWindow = new PoemsWindow();
            poemsWindow.Show();
        }

        private void AuthorsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
