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
using System.Data.Entity;
using System.ComponentModel;

namespace Kursovaya1
{
    /// <summary>
    /// Логика взаимодействия для Global.xaml
    /// </summary>
    public partial class Global : Window
    {
        public Global()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshTechnoServiceDataGrid();
           // ComboStatus.ItemsSource = DBKursovayaEntities.GetContext().Status.ToList();//сортировка по статусу заказа
           // Box.Text = DBKursovayaEntities.GetContext().Status.Count(r => r.StatusID == 3).ToString();
            Vis();
        }

        private void RefreshTechnoServiceDataGrid()
        {
            var context = DBKursovayaEntities.GetContext();
            var requestsWithRelations = context.Order_
            .Include(r => r.Clients)
            .Include(r => r.Jeweler)
            //.Include(r => r.Item)
            .Include(r => r.Status)
            .ToList();
            TechnoService.ItemsSource = requestsWithRelations;
        }
        private void Vis()
        {
            switch (Authorization.authorizationRole)
            {
                case "Админ":
                    BtnOrder_.Visibility = Visibility.Collapsed;
                    break;
                case "Модер":
                    BtnDelet.Visibility = Visibility.Collapsed;
                    BtnOrder_.Visibility = Visibility.Collapsed;
                    break;
                case "Юзер":
                    BtnEditVisible.Visibility = Visibility.Collapsed;
                    BtnDelet.Visibility = Visibility.Collapsed;
                    BtnAdd.Visibility = Visibility.Collapsed;
                    break;
                default:
                    return;
            }

        }



        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = (sender as Button)?.DataContext as Order_;
            if (selectedRequest != null)
            {
                RefreshWindow addEditWindow = new RefreshWindow(selectedRequest);
                if (addEditWindow.ShowDialog() == true)
                {
                    RefreshTechnoServiceDataGrid();
                }
            }
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow addEditWindow = new AddEditWindow();
            if (addEditWindow.ShowDialog() == true)
            {
                RefreshTechnoServiceDataGrid();
            }
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            TechnoService.ItemsSource = DBKursovayaEntities.GetContext().Order_.ToList();
            RefreshTechnoServiceDataGrid();
        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            var servisForRemoving = TechnoService.SelectedItems.Cast<Order_>().ToList();
            if (servisForRemoving.Any()
            && MessageBox.Show($"Вы точно хотите удалить следующий {servisForRemoving.Count()} элемент ? ", "Внимание",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //изначально было так
                //var context = lr17MyEntities.GetContext();
                //context.Order_.RemoveRange(servisForRemoving);
                //context.SaveChanges();
                //MessageBox.Show("Данные удалены");
                //RefreshTechnoServiceDataGrid();

                //удаляем элементы по одному в цикле foreach
                var context = DBKursovayaEntities.GetContext();
                foreach (var order in servisForRemoving)
                {
                    context.Order_.Remove(order);
                }
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                RefreshTechnoServiceDataGrid();
                
            }
        } 
        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow authorizationWindow = new MainWindow();
            authorizationWindow.Show();
            this.Close();
        }

        
    }
}
