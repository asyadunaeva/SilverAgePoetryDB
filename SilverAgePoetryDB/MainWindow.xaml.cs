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
            DB.Poems = new List<Poem>();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Poem poem = new SilverAgePoetryDB.Poem();
            poem.Name = "AAA";
            poem.Text = "BBB";
            DB.AddPoem(poem);
        }

        private void PoemssButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            DB.DeletePoem(DB.Poems[0]);
        }
    }
}
