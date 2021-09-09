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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        public RecipeInfo recipe = new RecipeInfo();

        private void Share_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "Фото(*.JPG;*.PNG;*.BMP)|*.JPG;*.PNG;*.BMP";
            Dialog.CheckFileExists = true;
            if (Dialog.ShowDialog() == true)
            {
                ImagePath.Text = Dialog.FileName;
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            recipe.name = Naming.Text;
            recipe.path = ImagePath.Text;
            recipe.Ingridients = Ingredients.Text;
            recipe.Country = Culture.Text;
            recipe.Recipe = new TextRange(RecipeBox.Document.ContentStart,RecipeBox.Document.ContentEnd).Text;
            MessageBox.Show("Recipe Added");
            this.Close();
        }
    }
}
