using Kudashova320.DB;
using Microsoft.Win32;
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

namespace Kudashova320.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewAnimalPage.xaml
    /// </summary>
    public partial class NewAnimalPage : Page
    {
        public static List<Animal> animals { get; set; }

        public static Animal animal = new Animal();
        public NewAnimalPage()
        {
            InitializeComponent();
            animals = new List<Animal>
             (DBConnection.catDogEntities.Animal.ToList());
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            var dcvd = DescribeTb.Text;

            if (MessageBox.Show(dcvd, "Проверьте корректность введенных данных", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {


                var t = AnimalCB.SelectedItem as Animal;
                animal.Name = t.Name;


                DBConnection.catDogEntities.Animal.Add(animal);
                DBConnection.catDogEntities.SaveChanges();

                NavigationService.Navigate(new RaListPage());
            }

        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                animal.Photo = File.ReadAllBytes(openFileDialog.FileName);
                TestImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }

        }
    }
}

