using DAL.Enities;
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
        private readonly IRoomInformationService _roomService;

        public Customer _account { get; set; }
        public CustomerWindow()
        {
            InitializeComponent();
            _reservationService = new BookingReservationService();
            _bookingDetailService = new BookingDetailService();
            _customerService = new CustomerService();
            _roomService = new RoomInformationService();

            _account = new Customer();
        }

        private List<RoomType> LoadRoomType()
        {
            var roomTypeList = _roomService.GetRoomTypes();
            return roomTypeList;
        }
        private List<RoomInformation> LoadRooms()
        {
            var roomInfoList = _roomService.GetRoomInformations();
            var roomTypeList = LoadRoomType();

            foreach (var room in roomInfoList)
            {
                room.RoomType = roomTypeList.FirstOrDefault(r => r.RoomTypeId == room.RoomTypeId);
            }

            return roomInfoList;
        }


        private void LoadBooking()
        {

        }

        private void LoadCustomerInfo()
        {

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgRoom.ItemsSource = LoadRooms();
            

        }

        private void dgRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
