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
            string key = txtKey.Text;
            string pass = txtPassword.Password;

            var listCustomer = _customerService.GetCustomer();

            if (_adminAccountService.ValidateAccount(key, pass))
            {
                MessageBox.Show("Login as administrator ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else if (_customerService.ValidateCustomer(key, pass))
            {
                MessageBox.Show("Login as customer ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Hide();
                CustomerWindow customerWindow = new CustomerWindow();
                customerWindow.Show();
            }
            else
            {
                throw new Exception("không tìm thấy tài khoản");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
