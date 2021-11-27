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

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ListOfRecipes.ItemsSource = infos;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListOfRecipes.ItemsSource);
            view.Filter = UserFilter;
        }
        int ID = 0;

        List<RecipeInfo> infos = new List<RecipeInfo>();
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(FilterBox.Text))
                return true;
            else
                return ((item as RecipeInfo).Ingridients.IndexOf(FilterBox.Text,StringComparison.OrdinalIgnoreCase)>=0);
        }

        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListOfRecipes.ItemsSource).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            addWindow.recipe.id = ID;
            ID++;
            infos.Add(addWindow.recipe);
            this.ListOfRecipes.ItemsSource = infos;
            this.ListOfRecipes.Items.Refresh();
            //ListBoxItem listBoxItem = new ListBoxItem();
            // listBoxItem.Content = addWindow.recipe.name;     
            // listBoxItem.Name = $"{ID}";
            // ID++;

            //ListOfRecipes.Items.Add(listBoxItem);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            infos.RemoveAt(this.ListOfRecipes.Items.IndexOf(this.ListOfRecipes.SelectedItem));
            this.ListOfRecipes.Items.Refresh();
        }
    }

    public class RecipeInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string Ingridients { get; set; }
        public string Country { get; set; }
        public string Recipe { get; set; }

        public override string ToString()
        {
            return this.name;
        }
    }
}
