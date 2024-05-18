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

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для ProductCardWindow.xaml
    /// </summary>
    public partial class ProductCardWindow : Window
    {
        public ProductCardWindow(Cars carmodel)
        {
            InitializeComponent();
            DataContext = carmodel;
            ProductNameLabel.Content = carmodel.Brand;
            ProductModelNameLabel.Content = carmodel.Model;
            ProductYearLabel.Content = carmodel.Year + " год выпуска";
            ProductHPLabel.Content = carmodel.HP + " Л.С";
            ProductPriceLabel.Content = carmodel.Price + " рублей";
            ProductKilometreLabel.Content = carmodel.KM + " км";
            ProductBodyLabel.Content = carmodel.BodyType;
            ProductCompLabel.Content = carmodel.Complectation;
            ProductPTSOwnersLabel.Content = carmodel.PTS;
            ProductVINLabel.Content = carmodel.VIN;
            ProductCountryLabel.Content = carmodel.Country;
           


           
        }

        private void ExitClick_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GoToOrer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
