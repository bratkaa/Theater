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
using Theater.Model;

namespace Theater.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPieceWindowPage.xaml
    /// </summary>
    public partial class AddPieceWindowPage : Page
    {
        public AddPieceWindowPage()
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
                double price = double.Parse(PricePox.Text);
                string pieceName = PieceBox.Text;
                string fio = FIOBox.Text;
                DateTime start = (DateTime)StartBox.SelectedDate!;
                string desc = DescBox.Text;

                PieceModel piece = new PieceModel()
                {
                    Name = pieceName,
                    AuthorName = fio,
                    Description = desc,
                    StartTime = start,
                    Price = price
                };

                new Model.DB.PieceDbWorker().CreateNewPiece(piece);
                MessageBox.Show("Succes");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
