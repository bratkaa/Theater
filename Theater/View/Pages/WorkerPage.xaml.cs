using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Theater.Model;

namespace Theater.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static ObservableCollection<UserModel> Workers { get; set; } = new();
        public Page1()
        {
            DataContext= this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindowPage addWorkerWindowPage = new();
            MainPageFrame.Navigate(addWorkerWindowPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Workers.Clear();
            var res = new Model.DB.UserDbWorker().GetAllWorkers();
            foreach (var worker in res) 
            {
                Workers.Add(worker);
            }
            WorkersList.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UserModel? selected = WorkersList.SelectedItem as UserModel;
            if (selected != null)
            {
                Workers.Remove(selected);
                new Model.DB.UserDbWorker().DeleteUser(selected);
            }
        }
    }
}
