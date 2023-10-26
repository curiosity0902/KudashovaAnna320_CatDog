using Kudashova320.DB;
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

namespace Kudashova320.Pages
{
    /// <summary>
    /// Логика взаимодействия для NubiListPage.xaml
    /// </summary>
    public partial class NubiListPage : Page
    {
        public static List<Animal> animals { get; set; }


        //new List<AnimalCat> animalCats { get; set; } 

        public NubiListPage()
        {
            InitializeComponent();
            animals = new List<Animal>(DBConnection.catDogEntities.Animal.ToList());

            this.DataContext = this;
            NubiLv.ItemsSource = new List<Animal>(DBConnection.catDogEntities.Animal.ToList());
        }


        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutorizationPage());
        }

        private void Refresh()
        {
            var filtred = DBConnection.catDogEntities.Animal.ToList();

            var name = TypeFilterCB.SelectedItem as Animal;
            var surchText = SearchTB.Text.ToLower();

            //if (TypeFilterCB.SelectedIndex != 0 && name != null)
            filtred = filtred.Where(x => x.Name == name.Name).ToList();


            //if (!string.IsNullOrWhiteSpace(surchText))
            //    filtred = filtred.Where(x => x.Describe.ToLower().Contains(surchText)).ToList();
            NubiLv.ItemsSource = filtred.ToList();
        }

        private void TypeFilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTB.Text.Length > 0)
                NubiLv.ItemsSource = DBConnection.catDogEntities.Animal.Where(i => i.Describe.Contains(SearchTB.Text.Trim())).ToList();
            else
                NubiLv.ItemsSource = new List<Animal>(DBConnection.catDogEntities.Animal.ToList());
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewAnimalPage());
        }
    }


}

