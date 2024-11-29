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
    /// Логика взаимодействия для RefreshWindow.xaml
    /// </summary>
    public partial class RefreshWindow : Window
    {
        private Order_ _currentOrder;
        public RefreshWindow(Order_ order)
        {
            InitializeComponent();
            _currentOrder = order;

            ClientComboBox.ItemsSource = DBKursovayaEntities.GetContext().Clients.ToList();//Клиент
            JewelerComboBox.ItemsSource = DBKursovayaEntities.GetContext().Jeweler.ToList();//Ювелир
            ItemsComboBox.ItemsSource = DBKursovayaEntities.GetContext().Item.ToList();//Заказ
            StatusComboBox.ItemsSource = DBKursovayaEntities.GetContext().Status.ToList();//Статус
            MaterialComboBox.ItemsSource = DBKursovayaEntities.GetContext().Material.ToList();//Материал

            // Презагрузкаданных
            ClientComboBox.SelectedItem = order.Clients;
            JewelerComboBox.SelectedItem = order.Jeweler;

            ItemsComboBox.SelectedItem = order.Jeweler.ItemID;
            SizeTextBox.Text = order.Jeweler.Item.ItemSize.ToString();//

            StatusComboBox.SelectedItem = order.Status;
            MaterialComboBox.SelectedItem = order.Jeweler.Item.Material.MaterialName;/////////!!!!!!!!!!!1
            //Vis();//этот метод уже не нужен так как мы выключили кнопку для того, кто заходит под user еще в глобальном окне.

        }
        //private void Vis()
        //{
        //    switch (Authorization.authorizationRole)
        //    {
        //        case "Админ":
        //            break;
        //        case "Модер":
        //            break;
        //        case "Юзер":
        //            UpdateButton.Visibility = Visibility.Collapsed;
        //            break;
        //        default:
        //            return;
        //    }

        //}
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Здесь код для обновления данных в базе
            var context = DBKursovayaEntities.GetContext();
            _currentOrder.ClientID = ((Clients)ClientComboBox.SelectedItem).ClientID;//клиент

            _currentOrder.JewelerID = ((Jeweler)JewelerComboBox.SelectedItem).JewelerID;//ювелир

            _currentOrder.Jeweler.ItemID = ((Item)ItemsComboBox.SelectedItem).ItemID;//украшение

            _currentOrder.Item = SizeTextBox.Text;//размер украшения

            _currentOrder.Jeweler.Item.ItemMaterial= ((Material)MaterialComboBox.SelectedItem).MaterialID;//материал изделия       

            _currentOrder.StatusID = ((Status)StatusComboBox.SelectedItem).StatusID;//статус
 
            context.SaveChanges();
            MessageBox.Show("Данные заявки обновлены");
            this.Close();
        }
    }
}
