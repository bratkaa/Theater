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
    /// Логика взаимодействия для Page4.xaml
    /// </summary>

    public partial class Page4 : Page
    {
        public static ObservableCollection<TicketModel> Tickets { get; set; } = new();

        public Page4()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TicketModel? selected = TicketList.SelectedItem as TicketModel;
            if (selected != null)
            {
                Tickets.Remove(selected);
                new Model.DB.TicketDbWorker().DeleteTicket(selected);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tickets.Clear();
            var res = new Model.DB.TicketDbWorker().GetAllTicket();
            foreach (var ticket in res)
            {
                Tickets.Add(ticket);
            }
            TicketList.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
        }
    }
}
