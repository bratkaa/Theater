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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public static ObservableCollection<PieceModel> Pieces { get; set; } = new();
        public Page2()
        {
            DataContext= this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPieceWindowPage addPieceWindowPage = new();
            MainPageFrame.Navigate(addPieceWindowPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pieces.Clear();
            var res = new Model.DB.PieceDbWorker().GetAllPieces();
            foreach (var piece in res)
            {
                Pieces.Add(piece);
            }
            PiecesList.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PieceModel? selected = PiecesList.SelectedItem as PieceModel;
            if (selected != null)
            {
                Pieces.Remove(selected);
                new Model.DB.PieceDbWorker().DeletePiece(selected);
            }
        }
    }
}
