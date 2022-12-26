using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Theater.Model;

namespace Theater.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public ObservableCollection<PieceModel> Pieces { get; set; } = new();
        public Page3()
        {
            DataContext = this;

            var pieces = new Model.DB.PieceDbWorker().GetAllPieces();
            foreach (var p in pieces) Pieces.Add(p);

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ticketsValue = int.Parse(ComboBox.Text);

                PieceModel? selected = WorkersList.SelectedItem as PieceModel;
                if (selected != null)
                {
                    SellTicketWindowPage sellTicketWindowPage = new(ticketsValue, selected.Price);
                    MainPageFrame.Navigate(sellTicketWindowPage);
                }
            }
            catch { MessageBox.Show("Error"); }
        }
    }
}
