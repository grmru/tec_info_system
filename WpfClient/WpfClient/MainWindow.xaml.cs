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

namespace WpfClient
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

        private void butLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow wnd = new LoginWindow();
            wnd.ShowDialog();
            if (wnd.isOK)
            {
                MessageBox.Show("Нажали ОК");
            }
        }

        private void butShowProduct_Click(object sender, RoutedEventArgs e)
        {
            AllProductsView prodView = new AllProductsView();
            prodView.Show();
        }

        private void butShowDocuments_Click(object sender, RoutedEventArgs e)
        {
            AllDocumentsView docsView = new AllDocumentsView();
            docsView.Show();
        }

        private void butShowClients_Click(object sender, RoutedEventArgs e)
        {
            AllClientsView clientsView = new AllClientsView();
            clientsView.Show();
        }

        private void butShowService_Click(object sender, RoutedEventArgs e)
        {
            AllServicesView servicesView = new AllServicesView();
            servicesView.Show();
        }
    }
}
