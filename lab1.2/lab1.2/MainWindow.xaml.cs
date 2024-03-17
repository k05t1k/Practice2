using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static System.Net.Mime.MediaTypeNames;

namespace lab1._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        public int list = 0;
        private PizzeriaEntities context = new PizzeriaEntities();
        TextBox[] text;
        public MainWindow()
        {
            InitializeComponent();
            text = new TextBox[1] { NameTbx };
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
                    text[0].Text = "Название пиццы";
                    PizzaDataGrid.ItemsSource = context.Pizza.ToList();
                    break;
                case 1:
                    text[0].Text = "Тип оплаты";
                    PizzaDataGrid.ItemsSource = context.Client.ToList();
                    break;
                case 2:
                    text[0].Text = "Должность";
                    PizzaDataGrid.ItemsSource = context.Personal.ToList();
                    break;
                case 3:
                    text[0].Text = "Цена заказа";
                    PizzaDataGrid.ItemsSource = context.Orders.ToList();
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
                    text[0].Text = "Название пиццы";
                    PizzaDataGrid.ItemsSource = context.Pizza.ToList();
                    break;
                case 1:
                    text[0].Text = "Тип оплаты";
                    PizzaDataGrid.ItemsSource = context.Client.ToList();
                    break;
                case 2:
                    text[0].Text = "Должность";
                    PizzaDataGrid.ItemsSource = context.Personal.ToList();
                    break;
                case 3:
                    text[0].Text = "Цена заказа";
                    PizzaDataGrid.ItemsSource = context.Orders.ToList();
                    break;
            }
        }

        // add
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            switch (list)
            {
                case 0:
                    Pizza pizza = new Pizza();
                    pizza.PizzaName = text[0].Text;
                    context.Pizza.Add(pizza);

                    context.SaveChanges();
                    PizzaDataGrid.ItemsSource = context.Pizza.ToList();
                    break;
                case 1:
                    Client client = new Client();
                    client.TypeOfPay = text[0].Text;
                    context.Client.Add(client);

                    context.SaveChanges();
                    PizzaDataGrid.ItemsSource = context.Client.ToList();
                    break;
                case 2:
                    Personal personal = new Personal();
                    personal.Post = text[0].Text;
                    context.Personal.Add(personal);

                    context.SaveChanges();
                    PizzaDataGrid.ItemsSource = context.Personal.ToList();
                    break;
                case 3:
                    Orders order = new Orders();
                    order.Price = decimal.Parse(text[0].Text);
                    context.Orders.Add(order);

                    context.SaveChanges();
                    PizzaDataGrid.ItemsSource = context.Orders.ToList();
                    break;
            }
        }

        // edit
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            switch (list)
            {
                case 0:
                    if (PizzaDataGrid.SelectedItem != null)
                    {
                        var selected = PizzaDataGrid.SelectedItem as Pizza;
                        selected.PizzaName = NameTbx.Text;

                        context.SaveChanges();
                        PizzaDataGrid.ItemsSource = context.Pizza.ToList();
                    }
                    break;
                case 1:
                    if (PizzaDataGrid.SelectedItem != null)
                    {
                        var selected = PizzaDataGrid.SelectedItem as Client;
                        selected.TypeOfPay = NameTbx.Text;

                        context.SaveChanges();
                        PizzaDataGrid.ItemsSource = context.Client.ToList();
                    }
                    break;
                case 2:
                    if (PizzaDataGrid.SelectedItem != null)
                    {
                        var selected = PizzaDataGrid.SelectedItem as Personal;
                        selected.Post = NameTbx.Text;

                        context.SaveChanges();
                        PizzaDataGrid.ItemsSource = context.Personal.ToList();
                    }
                    break;
                case 3:
                    if (PizzaDataGrid.SelectedItem != null)
                    {
                        var selected = PizzaDataGrid.SelectedItem as Orders;
                        selected.Price = decimal.Parse(NameTbx.Text);

                        context.SaveChanges();
                        PizzaDataGrid.ItemsSource = context.Orders.ToList();
                    }
                    break;
            }
        }

        // del
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            switch (list)
            {
                case 0:
                    if (PizzaDataGrid.SelectedItem != null)
                    {
                        context.Pizza.Remove(PizzaDataGrid.SelectedItem as Pizza);

                        context.SaveChanges();
                        PizzaDataGrid.ItemsSource = context.Pizza.ToList();
                    }
                    break;
                case 1:
                    if (PizzaDataGrid.SelectedItem != null)
                    {
                        context.Client.Remove(PizzaDataGrid.SelectedItem as Client);

                        context.SaveChanges();
                        PizzaDataGrid.ItemsSource = context.Client.ToList();
                    }
                    break;
                case 2:
                    if (PizzaDataGrid.SelectedItem != null)
                    {
                        context.Personal.Remove(PizzaDataGrid.SelectedItem as Personal);

                        context.SaveChanges();
                        PizzaDataGrid.ItemsSource = context.Personal.ToList();
                    }
                    break;
                case 3:
                    if (PizzaDataGrid.SelectedItem != null)
                    {
                        context.Orders.Remove(PizzaDataGrid.SelectedItem as Orders);

                        context.SaveChanges();
                        PizzaDataGrid.ItemsSource = context.Orders.ToList();
                    }
                    break;
            }

        }
    }
}
