using DAL.Enities;
using Repositories.Repositories;
using Services.IServices;
using Services.Services;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAdminAccountService _adminAccountService;
        private readonly ICustomerService _customerService;

        
        public LoginWindow()
        {
            InitializeComponent();
            _adminAccountService = new AdminAccountService();
            _customerService = new CustomerService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string key = txtKey.Text.Trim();
            string pass = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please, full fill all infomation!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_adminAccountService.ValidateAccount(key, pass))
            {
                MessageBox.Show("Login as administrator", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                new MainWindow().Show();
                Close();
                return;
            }

            var customer = _customerService.LoginCustomer(key, pass);
            if (customer != null)
            {
                MessageBox.Show("Login as customer", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                new CustomerWindow { _account = customer }.Show();
                Close();
                return;
            }

            MessageBox.Show("Wrong email or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
