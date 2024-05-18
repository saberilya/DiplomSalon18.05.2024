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

namespace Salon.AdminCategory
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminCategory.AdminFrames.OrdersPage());
        }

        private void BtnAddEditAuto_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminCategory.AdminFrames.AddEditAuto());
        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminCategory.AdminFrames.NewOrder());
        }

        private void BtnDocumentWriter_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminCategory.AdminFrames.DocumentWriter());
        }
    }
}
