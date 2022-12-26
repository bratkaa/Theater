using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Theater.Model;

namespace Theater.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerWindowPage.xaml
    /// </summary>
    public partial class AddWorkerWindowPage : Page
    {
        public AddWorkerWindowPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = LoginBox.Text;
                string password = PasswordBox.Password;
                string fio = FioBox.Text;
                string address = AddresBox.Text;
                string phone = PhoneBox.Text;
                DateTime? birthday = DateBox.SelectedDate;
                bool isAdmin = (bool)AdminBox.IsChecked!;

                UserModel user = new UserModel()
                {
                    Login = login,
                    Password = password,
                    FullName = fio,
                    Adress = address,
                    IsAdmin = isAdmin,
                    PhoneNumber = phone
                };

                new Model.DB.UserDbWorker().CreateNewUser(user);
                MessageBox.Show("Succes!");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
