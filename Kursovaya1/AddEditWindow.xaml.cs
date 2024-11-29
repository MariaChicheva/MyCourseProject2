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

namespace Kursovaya1
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private Order_ order = new Order_();

        private Clients client = new Clients();// клиент
        private Item item = new Item();//заказанный предмет

        public AddEditWindow()
        {
            InitializeComponent();
            DataContext = order;
            ComboStatus_.ItemsSource = DBKursovayaEntities.GetContext().Jeweler.ToList();//&
            ComboStatus_1.ItemsSource = DBKursovayaEntities.GetContext().Item.ToList();
            ComboStatus.ItemsSource = DBKursovayaEntities.GetContext().Status.ToList();
        }

        private void BtnSave_Click(Object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (order.OrderNumber == null)
                error.AppendLine("Введите номер заявки!");
            else if (!int.TryParse(order.OrderNumber.ToString(), out int applicationNumber) || applicationNumber <= 0)
                error.AppendLine("Номер заявки должен иметь положительное и не отрицательное значение!");
            else if (DBKursovayaEntities.GetContext().Order_.Any(row => row.OrderNumber == order.OrderNumber))
                error.AppendLine("Номер заявки уже существует!");

            if (order.DateAndTime_ == null || order.DateAndTime_ == DateTime.MinValue)
                error.AppendLine("Укажите дату!");

            if (string.IsNullOrWhiteSpace(ClientTextBox.Text))
                error.AppendLine("Укажите свое ФИО!");

            if (ComboStatus_.SelectedItem != null && ComboStatus_.SelectedItem is Jeweler selectedRest)
                order.JewelerID = selectedRest.JewelerID;
            else error.AppendLine("Выберите ювелира!");

            if (ComboStatus_.SelectedItem != null && ComboStatus_.SelectedItem is Item selectedItem)
                order.Item = selectedItem.ItemName;
            else error.AppendLine("Выберите ювелира!");

            //if (string.IsNullOrWhiteSpace(order.Item))
            //    error.AppendLine("Укажите что бы вы хотели заказать!"); //....

            if (string.IsNullOrWhiteSpace(ItemSizeBox.Text))
                error.AppendLine("Укажите размер заказанного украшения!");

            if (ComboStatus.SelectedItem != null && ComboStatus.SelectedItem is Status selectedStatus)
                order.StatusID = selectedStatus.StatusID;
            else error.AppendLine("Выберите статус!");


            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Предупреждение!", MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;
            }
            try
            {
                var context = DBKursovayaEntities.GetContext();
                client.ClientName = ClientTextBox.Text;//имя клиента

                context.Clients.Add(client);
                context.SaveChanges();

                var ClientId = client.ClientID;

                order.ClientID = ClientId;

                context.Order_.Add(order);
                context.SaveChanges();

                MessageBox.Show("Информация сохранена");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
