using DAL.Enities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using Repositories.IRepositories;
using Repositories.Repositories;
using Services.IServices;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml;

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
            var roomInfoList = _roomService.GetRoomInformations()
                                           .Where(r => r.RoomStatus == 1)
                                           .ToList();
            var roomTypeList = LoadRoomType();

            foreach (var room in roomInfoList)
            {
                room.RoomType = roomTypeList.FirstOrDefault(rt => rt.RoomTypeId == room.RoomTypeId);
            }

            return roomInfoList;
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadroomTypeCombox();
            //LoadcapacityCombox();

        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void taskBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }



        private void ViewHomePage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            homeTable.Visibility = Visibility.Visible;
            bookingTable.Visibility = Visibility.Collapsed;
            reservationTable.Visibility = Visibility.Collapsed;
            profileTable.Visibility = Visibility.Collapsed;
        }

        private void ViewBooking_MouseDown(object sender, MouseButtonEventArgs e)
        {
            homeTable.Visibility = Visibility.Collapsed;
            bookingTable.Visibility = Visibility.Collapsed;
            reservationTable.Visibility = Visibility.Visible;
            profileTable.Visibility = Visibility.Collapsed;
        }

        private void ViewSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            homeTable.Visibility = Visibility.Collapsed;
            bookingTable.Visibility = Visibility.Visible;
            reservationTable.Visibility = Visibility.Collapsed;
            profileTable.Visibility = Visibility.Collapsed;

            roomList.ItemsSource = LoadRooms();
        }

        private void ViewProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            homeTable.Visibility = Visibility.Collapsed;
            reservationTable.Visibility = Visibility.Collapsed;
            bookingTable.Visibility = Visibility.Collapsed;
            profileTable.Visibility = Visibility.Visible;

            LoadProfile();
        }

        private void logoutBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận",
                                         MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                LoginWindow lgWindow = new LoginWindow();
                this.Close();
                lgWindow.Show();
            }
        }


        //------------------------ Customer Table --------------------------

        private void LoadroomTypeCombox()
        {
            try
            {
                var rtList = _roomService.GetRoomTypes();
                roomTypeCB.Items.Clear();
                roomTypeCB.ItemsSource = rtList;
                roomTypeCB.DisplayMemberPath = "RoomTypeName";
                roomTypeCB.SelectedValue = "RoomTypeId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lỗi load RoomTypes");
            }
        }
        private void LoadcapacityCombox()
        {
            try
            {
                var rtList = _roomService.GetRoomInformations();
                capacityCB.Items.Clear();
                capacityCB.ItemsSource = rtList;
                capacityCB.DisplayMemberPath = "RoomMaxCapacity";
                capacityCB.SelectedValue = "RoomId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lỗi load Room");
            }
        }

        /// <summary>
        /// thanh tìm kiếm trong bookingTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txtSearchBar.Text.IsNullOrEmpty())
            {
                return;
            }
            roomList.ItemsSource = LoadRooms()
                .Where(r => r.RoomDetailDescription.ToLower().Contains(txtSearchBar.Text.ToLower())
                    || r.RoomType.TypeDescription.ToLower().Contains(txtSearchBar.Text.ToLower())
                    || r.RoomType.RoomTypeName.ToLower().Contains(txtSearchBar.Text.ToLower())
                    || r.RoomNumber.ToString() == txtSearchBar.Text)
                .ToList();
        }


        private void textSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtSearchBar.Focus();
        }
        private void txtSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchBar.Text) && txtSearchBar.Text.Length > 0)
            {
                textSearch.Visibility = Visibility.Collapsed;
            }
            else
            {
                textSearch.Visibility = Visibility.Visible;
            }
        }

        //đang làm
        private void bookRoom_Click(object sender, RoutedEventArgs e)
        {
            checkInWarntext.Visibility = Visibility.Collapsed;
            checkOutWarntext.Visibility = Visibility.Collapsed;

            string inDate = checkInDate.Text;
            string outDate = checkOutDate.Text;

            if (string.IsNullOrEmpty(inDate))
            {
                checkInWarntext.Visibility = Visibility.Visible;
            }
            if (string.IsNullOrEmpty(outDate))
            {
                checkOutWarntext.Visibility = Visibility.Visible;
            }
            else if (roomList.SelectedItem is RoomInformation roomInfo)
            {
                _reservationService.CreateBookingReservation(_account.CustomerId);


            }

        }


        private void roomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roomList.SelectedItem is RoomInformation roomInfo)
            {
                txtRoomNumber.Text = roomInfo.RoomNumber ?? string.Empty;
                txtRoomType.Text = roomInfo.RoomType.RoomTypeName ?? string.Empty;
                txtRoomCapacity.Text = roomInfo.RoomMaxCapacity.ToString() ?? string.Empty;
                txtRoomDetail.Text = roomInfo.RoomType.TypeDescription ?? string.Empty;
                txtRoomDescription.Text = roomInfo.RoomDetailDescription ?? string.Empty;
            }
        }


        //----------------------- Profile Table --------------------------

        private void LoadProfile()
        {
            txtFullName.Text = _account.CustomerFullName;
            txtPhoneNumber.Text = _account.Telephone;
            txtProfileEmail.Text = _account.EmailAddress;
            calbirthDate.Text = _account.CustomerBirthday.ToString();

        }


        private bool isEditing = false;
        private void editAccountbtn_Click(object sender, RoutedEventArgs e)
        {
            if (!isEditing)
            {
                txtFullName.IsEnabled = true;
                txtPhoneNumber.IsEnabled = true;
                txtProfileEmail.IsEnabled = true;
                calbirthDate.IsEnabled = true;
            }
            else
            {
                UpdateCustomerData(txtFullName.Text, txtPhoneNumber.Text, txtProfileEmail.Text, calbirthDate.Text);
                txtFullName.IsEnabled = false;
                txtPhoneNumber.IsEnabled = false;
                txtProfileEmail.IsEnabled = false;
                calbirthDate.IsEnabled = false;
            }
            isEditing = !isEditing;
        }

        private void UpdateCustomerData(string? name, string? phone, string? email, string? birthday)
        {
            Customer cus = new Customer()
            {
                CustomerId = _account.CustomerId,
                CustomerFullName = txtFullName.Text,
                EmailAddress = txtProfileEmail.Text,
                Telephone = txtPhoneNumber.Text,
                CustomerBirthday = DateOnly.FromDateTime(calbirthDate.SelectedDate ?? DateTime.Now),
            };
            _customerService.UpdateCustomer(cus);

        }


        private void CloseAllWarning()
        {
            pwWarning.Visibility = Visibility.Collapsed;
            confirmPassWarning.Visibility = Visibility.Collapsed;
            confirmPassNotice.Visibility = Visibility.Collapsed;
            emptyPassNotice.Visibility = Visibility.Collapsed;
            emptyConfirmNotice.Visibility = Visibility.Collapsed;
        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            txtNewPass.Clear();
            txtConfirmPass.Clear();
            txtPassword.Clear();
            changePass.Visibility = Visibility.Hidden;
            txtOldPassword.Visibility = Visibility.Hidden;

            CloseAllWarning();
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            CloseAllWarning();
            if (txtNewPass.Password.IsNullOrEmpty())
            {
                emptyPassNotice.Visibility = Visibility.Visible;
            }
            else if (txtConfirmPass.Password.IsNullOrEmpty())
            {
                emptyConfirmNotice.Visibility = Visibility.Visible;
            }
            else if (txtNewPass.Password.Equals(txtConfirmPass.Password))
            {
                confirmPassNotice.Visibility = Visibility.Visible;
                _customerService.ChangePassword(_account.CustomerId, txtNewPass.Password);
            }
            else
            {
                confirmPassWarning.Visibility = Visibility.Visible;
            }

        }


        private void changePassbtn_Click(object sender, RoutedEventArgs e)
        {
            CloseAllWarning();
            if (!PasswordBoxHandler()) { return; }
            else if (checkPassword())
            {
                changePass.Visibility = Visibility.Visible;
                pwWarning.Visibility = Visibility.Hidden;
            }
            else
            {
                changePass.Visibility = Visibility.Hidden;
                pwWarning.Visibility = Visibility.Visible;
            }

        }


        private void DeleteAccont_Click(object sender, RoutedEventArgs e)
        {
            if (!PasswordBoxHandler()) { return; }

            if (checkPassword())
            {
                pwWarning.Visibility = Visibility.Hidden;
                var result = MessageBox.Show($"Are you sure you want to delete this account? this account can only be active by                         Admin",
                                    "Confirm Deletion",
                                    MessageBoxButton.YesNo,
                                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {

                    _customerService.DisableCustomer(_account);
                    LoginWindow lgWindow = new LoginWindow();
                    lgWindow.Show();
                    this.Close();
                }
            }
            else
            {
                pwWarning.Visibility = Visibility.Visible;
            }
        }

        //------------------------ Interacting handler------------------------

        private bool checkPassword()
        {
            bool result = false;
            var cus = _customerService.GetCustomerById(_account.CustomerId);
            if (cus.Password == txtPassword.Password.ToString())
            {
                result = true;
            }
            return result;
        }


        private bool PasswordBoxHandler()
        {
            if (txtOldPassword.Visibility == Visibility.Hidden)
            {
                txtOldPassword.Visibility = Visibility.Visible;
                return false;
            }
            else if (txtOldPassword.Visibility == Visibility.Visible && txtPassword.Password.IsNullOrEmpty())
            {
                txtOldPassword.Visibility = Visibility.Hidden;
                pwWarning.Visibility = Visibility.Hidden;
                return false;
            }

            return true;
        }


        private void PasswordText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }
        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = Visibility.Collapsed;
        }
        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.IsNullOrEmpty())
            {
                PasswordText.Visibility = Visibility.Visible;
            }

        }



        private void NewPassText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtNewPass.Focus();
        }
        private void txtNewPass_GotFocus(object sender, RoutedEventArgs e)
        {
            NewPassText.Visibility = Visibility.Collapsed;
        }
        private void txtNewPass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNewPass.Password.IsNullOrEmpty())
            {
                NewPassText.Visibility = Visibility.Visible;
            }

        }


        private void ConfirmPassText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtConfirmPass.Focus();
        }
        private void txtConfirmPass_GotFocus(object sender, RoutedEventArgs e)
        {
            ConfirmPassText.Visibility = Visibility.Collapsed;
        }
        private void txtConfirmPass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtConfirmPass.Password.IsNullOrEmpty())
            {
                ConfirmPassText.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                myImage.Source = new BitmapImage(new System.Uri(openFileDialog.FileName));
            }
        }
    }
}
