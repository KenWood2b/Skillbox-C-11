using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DeepDiveintoOOP.Part3WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Bank bank;
        private ObservableCollection<Client> clients;

        public MainWindow()
        {
            InitializeComponent();
            bank = new Bank();
            clients = new ObservableCollection<Client>(bank.Clients);
            ClientsGrid.ItemsSource = clients;
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow();
            if (addClientWindow.ShowDialog() == true)
            {
                var newClient = new Client(addClientWindow.ClientId, addClientWindow.ClientName);
                bank.AddClient(newClient);
                clients.Add(newClient);
            }
        }

        private void ManageAccounts_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsGrid.SelectedItem is Client selectedClient)
            {
                var manageAccountsWindow = new ManageAccountsWindow(selectedClient);
                manageAccountsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите клиента для управления счетами.");
            }
        }

        private void TransferFunds_Click(object sender, RoutedEventArgs e)
        {
            var transferWindow = new TransferFundsWindow(bank);
            transferWindow.ShowDialog();
        }
    }
}

