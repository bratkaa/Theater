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
using Theater.Core;
using Theater.Model;
using Theater.View;

namespace Theater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if(System.IO.File.Exists("key.key"))
            {
                string res = Core.CreateKey.GetDataFromKey(File.ReadAllText("key.key"));
                string[] data = res.Split(".*(spliter)*.");
                if(data.Length > 1)
                {
                    LoginTextBox.Text = data[0];
                    PasswordBox.Password = data[1];
                }
            }
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //UserModel userModel = new()
            //{
            //    Login = "Admin",
            //    Password = "Admin",
            //    FullName = "Admin Adminovich Adminov",
            //    Role = "Admin",
            //    PhoneNumber = "dasodas"
            //};

            //Model.DB.UserDbWorker.CreateNewUser(userModel);



            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            UserModel model = new();
            
            if (new Model.DB.UserDbWorker().AutorizeUser(login, password, ref model))
            {
                if (CheckBox.IsChecked != null && (bool)CheckBox.IsChecked)
                    File.WriteAllText("key.key", Core.CreateKey.Generate(model.Login, model.Password));

                Core.Current.User = model;
                //Generator.GenerateTicket(10);
                //Generator.GeneratePiece(10);
                //Generator.GenerateClient(10);
                MainWindowView mainWindowView = new MainWindowView();
                mainWindowView.Show();
                this.Close();
            }
            else MessageBox.Show("Invalide data!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Для восстановления пароля свяжитесь с администратором");
        }

        private void LeftMouseDown (object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
