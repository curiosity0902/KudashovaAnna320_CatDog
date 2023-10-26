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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {

        public List <Human> humans { get; set; }
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text.Trim();
            string password = PasswordTB.Password.Trim();

            humans = new List
            <Human>(DBConnection.catDogEntities.Human.ToList());
            

            if (login == "1234")
                if (password == "12345")
                NavigationService.Navigate(new RaListPage());
                else
                    MessageBox.Show(" Введите данные корректно!");
            if (login == "123")
                if (password == "1234")
                    NavigationService.Navigate(new NubiListPage());
            else 
             MessageBox.Show(" Введите данные корректно!");
        }
    }
}
