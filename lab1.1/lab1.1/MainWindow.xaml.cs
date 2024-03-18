using System;
using System.Collections.Generic;
using System.Data;
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

using lab1._1.PizzeriaDataSetTableAdapters;

namespace lab1._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int list = 1;

        PizzaTableAdapter pizza = new PizzaTableAdapter();
        ClientTableAdapter clientTable = new ClientTableAdapter();
        PersonalTableAdapter personalTable = new PersonalTableAdapter();
        OrdersTableAdapter ordersTable = new OrdersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            if (!(sender as Button).IsEnabled)
            {
                if (list == 0)
                    list = 4;

                list--;
            }
                 (sender as Button).IsEnabled = true;

            switch (list)
            {
                case 0:
                    NameTbx.Text = "Название пиццы";
                    NameTbx_1.Text = "Размер";
                    PizzaDataGrid.ItemsSource = pizza.GetData();
                    break;
                case 1:
                    NameTbx.Text = "Фамилия";
                    NameTbx_1.Text = "Имя";
                    NameTbx_2.Text = "Отчество";
                    NameTbx_2.Text = "Тип оплаты";
                    PizzaDataGrid.ItemsSource = clientTable.GetData();
                    break;
                case 2:
                    NameTbx.Text = "Фамилия";
                    NameTbx_1.Text = "Имя";
                    NameTbx_2.Text = "Отчество";
                    NameTbx_2.Text = "Должность";
                    PizzaDataGrid.ItemsSource = personalTable.GetData();
                    break;
                case 3:
                    NameTbx.Text = "Цена";
                    NameTbx_1.Text = "ID Клиента";
                    NameTbx_2.Text = "ID Персонала";
                    NameTbx_2.Text = "ID Пиццы";
                    PizzaDataGrid.ItemsSource = ordersTable.GetData();
                    break;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            if (!(sender as Button).IsEnabled)
            {
                if (list == 3)
                    list = -1;

                list++;
            }
            (sender as Button).IsEnabled = true;

            switch (list)
            {
                case 0:
                    NameTbx.Text = "Название пиццы";
                    NameTbx_1.Text = "Размер";
                    NameTbx_2.Text = " ";
                    NameTbx_3.Text = " ";
                    PizzaDataGrid.ItemsSource = pizza.GetData();
                    break;
                case 1:
                    NameTbx.Text = "Фамилия";
                    NameTbx_1.Text = "Имя";
                    NameTbx_2.Text = "Отчество";
                    NameTbx_3.Text = "Тип оплаты";
                    PizzaDataGrid.ItemsSource = clientTable.GetData();
                    break;
                case 2:
                    NameTbx.Text = "Фамилия";
                    NameTbx_1.Text = "Имя";
                    NameTbx_2.Text = "Отчество";
                    NameTbx_3.Text = "Должность";
                    PizzaDataGrid.ItemsSource = personalTable.GetData();
                    break;
                case 3:
                    NameTbx.Text = "Цена";
                    NameTbx_1.Text = "ID Клиента";
                    NameTbx_2.Text = "ID Персонала";
                    NameTbx_3.Text = "ID Пиццы";
                    PizzaDataGrid.ItemsSource = ordersTable.GetData();
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            switch (list)
            {
                case 0:
                    pizza.InsertQuery(NameTbx.Text, int.Parse(NameTbx_1.Text));
                    PizzaDataGrid.ItemsSource = pizza.GetData();
                    break;
                case 1:
                    clientTable.InsertQuery(NameTbx.Text, NameTbx_1.Text, NameTbx_2.Text, NameTbx_3.Text);
                    PizzaDataGrid.ItemsSource = clientTable.GetData();
                    break;
                case 2:
                    personalTable.InsertQuery(NameTbx.Text, NameTbx_1.Text, NameTbx_2.Text, NameTbx_3.Text);
                    PizzaDataGrid.ItemsSource = personalTable.GetData();
                    break;
                case 3:
                    ordersTable.InsertQuery(decimal.Parse(NameTbx.Text), int.Parse(NameTbx_1.Text), int.Parse(NameTbx_2.Text), int.Parse(NameTbx_3.Text));
                    PizzaDataGrid.ItemsSource = ordersTable.GetData();
                    break;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            switch (list)
            {
                case 0:
                    object id = (PizzaDataGrid.SelectedItem as DataRowView).Row[0];
                    pizza.UpdateQuery(NameTbx.Text, int.Parse(NameTbx_1.Text), Convert.ToInt32(id));
                    PizzaDataGrid.ItemsSource = pizza.GetData();
                    break;
                case 1:
                    object id_1 = (PizzaDataGrid.SelectedItem as DataRowView).Row[0];
                    clientTable.UpdateQuery(NameTbx_3.Text, NameTbx_1.Text, NameTbx_2.Text, NameTbx.Text, Convert.ToInt32(id_1));
                    break;
                case 2:
                    object id_2 = (PizzaDataGrid.SelectedItem as DataRowView).Row[0];
                    personalTable.UpdateQuery(NameTbx_3.Text, NameTbx_1.Text, NameTbx_2.Text, NameTbx.Text, Convert.ToInt32(id_2));
                    PizzaDataGrid.ItemsSource = personalTable.GetData();
                    break;
                case 3:
                    object id_3 = (PizzaDataGrid.SelectedItem as DataRowView).Row[0];
                    ordersTable.UpdateQuery(decimal.Parse(NameTbx.Text), int.Parse(NameTbx_1.Text), int.Parse(NameTbx_2.Text), int.Parse(NameTbx_3.Text), Convert.ToInt32(id_3));
                    PizzaDataGrid.ItemsSource = ordersTable.GetData();
                    break;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            switch (list)
            {
                case 0:
                    object id = (PizzaDataGrid.SelectedItem as DataRowView).Row[0];
                    pizza.DeleteQuery(Convert.ToInt32(id));
                    PizzaDataGrid.ItemsSource = pizza.GetData();
                    break;
                case 1:
                    object id_1 = (PizzaDataGrid.SelectedItem as DataRowView).Row[0];
                    clientTable.DeleteQuery(Convert.ToInt32(id_1));
                    PizzaDataGrid.ItemsSource = clientTable.GetData();
                    break;
                case 2:
                    object id_2 = (PizzaDataGrid.SelectedItem as DataRowView).Row[0];
                    personalTable.DeleteQuery(Convert.ToInt32(id_2));
                    PizzaDataGrid.ItemsSource = personalTable.GetData();
                    break;
                case 3:
                    object id_3 = (PizzaDataGrid.SelectedItem as DataRowView).Row[0];
                    ordersTable.DeleteQuery(Convert.ToInt32(id_3));
                    PizzaDataGrid.ItemsSource = ordersTable.GetData();
                    break;
            }
        }
    }
}
