using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Salon.OtherWindows
{
    /// <summary>
    /// Логика взаимодействия для ClientOrderWindow.xaml
    /// </summary>
    public partial class ClientOrderWindow : Window
    {
        public DealershipEntities1 dbContext; // Контекст базы данных

        public ClientOrderWindow()
        {
           
            InitializeComponent();
            dbContext = new DealershipEntities1();
            var model = DealershipEntities1.GetContext().Cars.ToList();
            model.Insert(0, new Cars() { Brand = "Нет" });
            ComboAutoModel.ItemsSource = model;

            var credit = DealershipEntities1.GetContext().Creditor.ToList();
            credit.Insert(0, new Creditor() { CreditorName = "Нет" });
            CreditorComboBox.ItemsSource = credit;
            
        }
        private void ExitClick_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboAutoModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboAutoModel.SelectedItem is Cars carmodel)
            {
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
        }

        private void OrderClick_Click(object sender, RoutedEventArgs e)
        {
            int zerocred;
            string name = ClientName.Text;
            string surname = ClientSurname.Text;
            string phone = ClientPhone.Text;
            string seria = ClientSerial.Text;
            string passport = ClientPassport.Text;
            var getStatus = Classes.Context._context.Cars.Where(i => i.StatusID == 3).Any();

            try
            {
                if (name.Length < 4)
                {
                    ClientName.ToolTip = "Введите минимум 4 символа ";
                    ClientName.Background = Brushes.LightPink;
                }
                if (surname.Length < 3)
                {
                    ClientName.ToolTip = "Введите минимум 3 символа ";
                    ClientName.Background = Brushes.LightPink;
                }
                if (phone.Length < 11 && phone.Length > 12)
                {
                    ClientName.ToolTip = "Номер введен некорректно ";
                    ClientName.Background = Brushes.LightPink;
                }
                if (seria.Length < 4)
                {
                    ClientName.ToolTip = "Введите минимум 4 символа ";
                    ClientName.Background = Brushes.LightPink;
                }
                if (passport.Length < 8)
                {
                    ClientName.ToolTip = "Введите минимум 8 символов ";
                    ClientName.Background = Brushes.LightPink;
                }
                if (ComboAutoModel.SelectedIndex == 0)
                {
                    MessageBox.Show("Выберите интересующий вас автомобиль");
                }
                if (CreditorComboBox.SelectedIndex == 0)
                {
                    zerocred = 0;
                }
                //if (getStatus)
                //{
                //    MessageBox.Show("Извините выбранная вами машина уже занята!");
                //}

                
                else
                {


                    
                    zerocred = CreditorComboBox.SelectedIndex;
                    Order order = new Order() {

                        ClientName = ClientName.Text,
                        ClientSurname = ClientSurname.Text,
                        ClientPhone = ClientPhone.Text,
                        ClientSerial = ClientSerial.Text,
                        ClientPasswordNubmer = ClientPassport.Text,
                        CarID = ComboAutoModel.SelectedIndex,
                        Status = 1,
                        CreditorID = zerocred,                
                    };
                    DealershipEntities1.GetContext().Order.Add(order);
                    DealershipEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Поздравляем с покупкой, мы с вами свяжемся по номеру, который был указан");
                    try
                    {
                        if (ComboAutoModel.SelectedIndex != -1)
                        {
                            int selectedCarId = ComboAutoModel.SelectedIndex;
                            var car = dbContext.Cars.FirstOrDefault(c => c.ID == selectedCarId);
                            if (car != null)
                            {

                                var newStatus = dbContext.Status.FirstOrDefault(s => s.StatusName == "На удержани");
                                if (newStatus != null)
                                {
                                    car.StatusID = newStatus.ID;
                                    dbContext.SaveChanges();
                                    MessageBox.Show("Статус изменен");
                                }
                                else { MessageBox.Show("Новый статус не найден"); }


                            }
                            else { MessageBox.Show("Не удалось найти выбранный авто в БД"); }
                        }
                        else
                        {
                            MessageBox.Show("Выбериьте авто из комбобокс");
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Чтото не так");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что пошло не так! {ex} ");
                
            }
        }
    }
}
