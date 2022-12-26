using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using System.Windows.Shapes;
using Theater.View.Pages;

namespace Theater.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            if(!Core.Current.User.IsAdmin)
                AdmItem.Visibility= Visibility.Collapsed;
        }

        private void MouseLeftButtonUp_1 (object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Page1());
        }

        private void MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            Page page2 = new Page2();
            MainFrame.Navigate(page2);
        }

        private void MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            Page page3 = new Page3();
            MainFrame.Navigate(page3);
        }
        private void MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            Page page4 = new Page4();
            MainFrame.Navigate(page4);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
