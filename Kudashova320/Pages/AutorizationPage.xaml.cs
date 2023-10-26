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


            //if (login == "1234")
            //    NavigationService.Navigate(new RaListPage());
            //else if (login == "123")
            //    NavigationService.Navigate(new NubiListPage());
            //else
            //    MessageBox.Show(" Введите данные корректно!");

            Human human = new Human();
            humans = new List<Human>(DBConnection.catDogEntities.Human.ToList());
            Human currenrUser = humans.FirstOrDefault(i => i.Login == login && i.Password == password);


            if (currenrUser != null && currenrUser.ID == 1)
            {
                NavigationService.Navigate(new RaListPage());
                MessageBox.Show("1");

            }
            else if (currenrUser != null && currenrUser.ID == 2)
            {  NavigationService.Navigate(new NubiListPage());
            MessageBox.Show("2"); }
            else
                MessageBox.Show(" Введите данные корректно!");
        }
    }
}
