using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var currentCars = DealershipEntities1.GetContext().Cars.ToList();
            ListOfModels.ItemsSource = currentCars;         
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            OtherWindows.StartupWindowLogin startupWindowLogin = new OtherWindows.StartupWindowLogin();
            startupWindowLogin.Show();
            this.Close();
        }

        private void ProductTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2 && sender is TextBlock textBlock && textBlock.DataContext is Cars selectedProduct)
            {
                ProductCardWindow cardWindow = new ProductCardWindow(selectedProduct);
                cardWindow.ShowDialog();
            }
        }

        private void TboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListOfModels.ItemsSource = DealershipEntities1.GetContext().Cars.Where(item => item.Brand == TboxSearch.Text || item.Brand.Contains(TboxSearch.Text)).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Не работает");

            }
        }
        private void ComboBodyKit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnGoToOrder_Click(object sender, RoutedEventArgs e)
        {
            OtherWindows.ClientOrderWindow clientOrderWindow = new OtherWindows.ClientOrderWindow();
            clientOrderWindow.Show();
        }

        private void BtnSolve_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SummaBox.Text)&&string.IsNullOrEmpty(SrokBox.Text)&&string.IsNullOrEmpty(StavkaBox.Text))
            {
                MessageBox.Show("Заполните поля 'Сумма', 'Срок', 'Ставка'");

            }
            
            else
            {
                ulong summa = Convert.ToUInt64(SummaBox.Text);
                ushort srok = Convert.ToUInt16(SrokBox.Text);
                double stavka = Convert.ToDouble(StavkaBox.Text);
                double plata = (summa + summa * stavka * srok / 100) / (srok * 12);
                PlataBox.Text = "" + Math.Round(plata, 2);
            }
        }
    }
}
