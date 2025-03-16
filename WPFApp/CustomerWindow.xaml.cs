using Repositories.IRepositories;
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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly IBookingReservationService _reservationService;
        private readonly IBookingDetailService _bookingDetailService;
        private readonly ICustomerService _customerService;
        public CustomerWindow()
        {
            InitializeComponent();
            _reservationService = new BookingReservationService();
            _bookingDetailService = new BookingDetailService();
            _customerService = new CustomerService();
        }




    }
}
