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
    /// Логика взаимодействия для SellTicketWindowPage.xaml
    /// </summary>
    public partial class SellTicketWindowPage : Page
    {
        PieceModel? selected;
        public ObservableCollection<PieceModel> Pieces { get; set; } = new();
        public DateTime Date { get; set; }
        double totalPrice;
        public SellTicketWindowPage(int ticketsValue, double ticketPrice)
        {
            DataContext = this;

            var pieces = new Model.DB.PieceDbWorker().GetAllPieces();
            foreach(var p in pieces) Pieces.Add(p);

            totalPrice = ticketsValue * ticketPrice;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Билет(ы) на пьесу {selected!.Name} Успешно проданы за {totalPrice} рублей");
        }

        private void ChangeSelection(object sender, SelectionChangedEventArgs e)
        {
            // TimePicker
            selected = ComboBox1.SelectedItem as PieceModel;
            if(selected != null)
            {
                TimePicker.SelectedDate = selected.StartTime;
                TimePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateTarget();
            }
        }
    }
}
