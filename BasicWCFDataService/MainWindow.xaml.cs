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
using System.Windows.Navigation;
using System.Windows.Shapes;


using System.Data.Services.Client;
using BasicWCFDataService.NorthwindWCFDataService;
namespace BasicWCFDataService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NorthwindEntities context = null;
        Customer customer = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context = new NorthwindEntities(new Uri("http://localhost:47163/NorthwindWCFDataService.svc/"));
            var customersQuery =
                from cust in context.Customers
                select cust;
            customersListBox.ItemsSource = customersQuery.ToList();
        }

        private void customersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customer = (Customer)customersListBox.SelectedItem;
            customersTextBlock.Text = string.Format(
                "This is customer {0}, in {1}, {2}", customer.CustomerID, customer.City, customer.Country);
        }

       
    }
}
