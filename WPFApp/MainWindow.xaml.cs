using DAL.Enities;
using Repositories.Repositories;
using Services.IServices;
using Services.Services;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IRoomInformationService _roomInformationService;
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IBookingReservationService _bookingReservationService;
        public MainWindow()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _roomInformationService = new RoomInformationService();
            _bookingDetailService = new BookingDetailService();
            _bookingReservationService = new BookingReservationService();

        }

        private List<Customer> LoadCustomers()
        {
            var customerList = _customerService.GetCustomer();
            return customerList;
        }

        private List<RoomType> LoadRoomType()
        {
            var roomTypeList = _roomInformationService.GetRoomTypes();
            return roomTypeList;
        }

        private List<BookingReservation> LoadBookings()
        {
            var bookingResList = _bookingReservationService.GetBookingReservations();
            var bookingDetails = _bookingDetailService.GetBookingDetails();
            var customerList = _customerService.GetCustomer();
            foreach (var br in bookingResList)
            {
                br.Customer = customerList.FirstOrDefault(c => c.CustomerId == br.CustomerId);
                br.BookingDetails = bookingDetails
                    .Where(bd => bd.BookingReservationId == br.BookingReservationId)
                    .ToList();

                foreach (var bd in br.BookingDetails)
                {
                    bd.Room = _roomInformationService.GetRoomInformations()
                        .FirstOrDefault(r => r.RoomId == bd.RoomId);
                }
            }

            return bookingResList;
        }

        private List<RoomInformation> LoadRooms()
        {
            var roomInfoList = _roomInformationService.GetRoomInformations();
            var roomTypeList = _roomInformationService.GetRoomTypes();

            foreach (var room in roomInfoList)
            {
                room.RoomType = roomTypeList.FirstOrDefault(r => r.RoomTypeId == room.RoomTypeId);
            }

            return roomInfoList;
        }
        //-------------------- Main Window --------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgCustomer.ItemsSource = LoadCustomers();
            dgBooking.ItemsSource = LoadBookings();
            dgRoom.ItemsSource = LoadRooms();

            LoadRoomTypeComboBox();
            LoadSearchTypeComboBox();

        }
        //-----------------------------------------------------
        public int GetNextCustomerId()
        {
            var cusList = _customerService.GetCustomer();

            if (cusList.Count == 0) return 1;

            return cusList.Max(c => c.CustomerId) + 1;
        }

        //======================Customer======================
        private void btAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte status;
                if (!byte.TryParse(txtStatus.Text, out status))
                {
                    MessageBox.Show("Trạng thái phải là số hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var cus = new Customer
                {
                    CustomerFullName = txtName.Text,
                    Telephone = txtPhone.Text,
                    EmailAddress = txtEmail.Text,
                    CustomerBirthday = DateOnly.Parse(txtBirthday.Text),
                    CustomerStatus = status
                };
                _customerService.SaveCustomer(cus);

                dgCustomer.ItemsSource = LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte status;
                if (!byte.TryParse(txtStatus.Text, out status))
                {
                    MessageBox.Show("Trạng thái phải là số hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var customer = new Customer
                {
                    CustomerId = int.Parse(txtId.Text),
                    CustomerFullName = txtName.Text,
                    Telephone = txtPhone.Text,
                    EmailAddress = txtEmail.Text,
                    CustomerBirthday = DateOnly.Parse(txtBirthday.Text),
                    CustomerStatus = status
                };

                _customerService.UpdateCustomer(customer);
                dgCustomer.ItemsSource = LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgCustomer.SelectedItem is Customer cus)
                {
                    _customerService.DeleteCustomer(cus);
                    dgCustomer.ItemsSource = LoadCustomers();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("return to login page ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            LoginWindow loginWD = new LoginWindow();
            loginWD.Show();
            this.Close();
        }

        //-------------------- Search Customer --------------------
        private void txtSStatus_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSStatus.Text == "1 or 0 (Default: 1)")
            {
                txtSStatus.Text = "";
            }
        }

        private void txtSStatus_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSStatus.Text))
            {
                txtSStatus.Text = "1 or 0 (Default: 1)";
            }
        }
        private void tbSearchCustomer_Click(object sender, RoutedEventArgs e)
        {

            string name = txtSName.Text;
            byte status = 1;

            if (!string.IsNullOrWhiteSpace(txtSStatus.Text) && txtSStatus.Text != "1 or 0 (Default: 1)")
            {
                if (!byte.TryParse(txtSStatus.Text, out status))
                {
                    MessageBox.Show("Trạng thái phải là số hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            var searchList = _customerService.SearchCustomer(name, status);
            dgCustomer.ItemsSource = searchList;
        }
        //---------------------------------------------------------
        private void dgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCustomer.SelectedItem is Customer cus)
            {
                txtId.Text = cus.CustomerId.ToString() ?? string.Empty;
                txtName.Text = cus.CustomerFullName ?? string.Empty;
                txtPhone.Text = cus.Telephone ?? string.Empty;
                txtEmail.Text = cus.EmailAddress ?? string.Empty;
                txtBirthday.Text = cus.CustomerBirthday.HasValue ? cus.CustomerBirthday.ToString() : string.Empty;
                txtStatus.Text = cus.CustomerStatus.HasValue ? cus.CustomerStatus.ToString() : string.Empty;
            }
        }

        private void dgRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgRoom.SelectedItem is RoomInformation room)
            {
                txtRoomId.Text = room.RoomId.ToString() ?? string.Empty;
                txtNumber.Text = room.RoomNumber ?? string.Empty;
                txtDetail.Text = room.RoomDetailDescription ?? string.Empty;
                txtCapacity.Text = room.RoomMaxCapacity.ToString() ?? string.Empty;
                txtPrice.Text = room.RoomPricePerDay.HasValue ? room.RoomPricePerDay.ToString() : string.Empty;
                txtRoomStatus.Text = room.RoomStatus.HasValue ? room.RoomStatus.ToString() : string.Empty;
                cbRoomType.SelectedValue = room.RoomTypeId.ToString() ?? string.Empty;
            }
        }


        //======================== ROOM ==========================

        private void LoadRoomTypeComboBox()
        {
            var roomTypeList = LoadRoomType();
            cbRoomType.ItemsSource = roomTypeList;
            cbRoomType.DisplayMemberPath = "RoomTypeName";
            cbRoomType.SelectedValuePath = "RoomTypeId";

        }
        private void LoadSearchTypeComboBox()
        {
            var roomTypeList = LoadRoomType();
            cbSRoomType.ItemsSource = roomTypeList;
            cbSRoomType.DisplayMemberPath = "RoomTypeName";
            cbSRoomType.SelectedValuePath = "RoomTypeId";
        }


        private RoomInformation? CreateRoomInfo()
        {
            byte status;
            if (!byte.TryParse(txtRoomStatus.Text, out status))
            {
                MessageBox.Show("Trạng thái phải là số hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            return new RoomInformation
            {
                //RoomId = int.Parse(txtRoomId.Text),
                RoomNumber = txtNumber.Text,
                RoomTypeId = int.Parse(cbRoomType.SelectedValue.ToString() ?? "0"),
                RoomDetailDescription = txtDetail.Text,
                RoomMaxCapacity = int.Parse(txtCapacity.Text),
                RoomPricePerDay = decimal.Parse(txtPrice.Text),
                RoomStatus = status
            };
        }


        private void btAddRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var room = CreateRoomInfo();
                if (room == null) return;

                _roomInformationService.SaveRoomInformation(room);
                dgRoom.ItemsSource = LoadRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btEditRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation room;
               
                room = CreateRoomInfo();
                room.RoomId = int.Parse(txtRoomId.Text);
                if (room == null) return;

                if (dgRoom.SelectedItem is RoomInformation ro)
                {
                    _roomInformationService.UpdateRoomInformation(ro);
                    dgRoom.ItemsSource = LoadRooms();
                    return;
                }

                _roomInformationService.UpdateRoomInformation(room);
                dgRoom.ItemsSource = LoadRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgRoom.SelectedItem is RoomInformation room)
                {
                    _roomInformationService.DeleteRoomInformation(room);
                    dgRoom.ItemsSource = LoadRooms();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        //-------------------- Search Room --------------------
        private void txtSRoomStatus_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSStatus.Text == "1 or 0 (Default: 1)")
            {
                txtSStatus.Text = "";
            }
        }
        private void txtSRoomStatus_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSStatus.Text))
            {
                txtSStatus.Text = "1 or 0 (Default: 1)";
            }
        }
        private void btSearchRoom_Click(object sender, RoutedEventArgs e)
        {
            decimal? price = null;
            int? roomNumber = null;
            byte? status = null;

            if (!string.IsNullOrWhiteSpace(txtSRoomPrice.Text) && decimal.TryParse(txtSRoomPrice.Text, out decimal parsedPrice))
            {
                price = parsedPrice;
            }

            if (cbSRoomType.SelectedValue != null && int.TryParse(cbSRoomType.SelectedValue.ToString(), out int parsedRoomNumber))
            {
                roomNumber = parsedRoomNumber;
            }

            if (!string.IsNullOrWhiteSpace(txtSRoomStatus.Text) && txtSRoomStatus.Text != "1 or 0 (Default: 1)")
            {
                if (byte.TryParse(txtSRoomStatus.Text, out byte parsedStatus))
                {
                    status = parsedStatus;
                }
                else
                {
                    MessageBox.Show("Trạng thái phải là số hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            var searchList = _roomInformationService.SearchRooms(price, roomNumber, status);
            dgRoom.ItemsSource = searchList;
        }



    }
}