   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5      �� .+�5   
   � .+�5      �� .@�5      �� $��Customer Management��6   .��5      �  � RowDefinitions 5      �� 5      $��* �6,   �� 5      $
��Auto �6,    � ColumnDefinitions 5      �� 5      $
��175* �6/   �� 5      $
��336* �6/   �� 5      $
��283* �6/   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgCustomer��5   #      AutoGenerateColumns$ False��67   $��3��6S   $��	0,0,0,170q�6g   $��2��6z      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   "   ,  &System.Windows.Controls.DataGridColumn   Header$ 
CustomerId��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *
CustomerId+  5    "   $ CustomerFullName��65    6O   �� *CustomerFullName+  5!   "   $ 	Telephone��65    6H   �� *	Telephone+  5"   "   $ EmailAddress��65    6K   �� *EmailAddress+  5#   "   $ CustomerBirthday��65    6O   �� *CustomerBirthday+  5$   "   $ CustomerStatus��65    6M   �� *CustomerStatus+5&      �� 5'       �� Orientation$ Vertical=�6%   $��Center=�6<   $��1��6Y   $	��336��6f   $��1��6r   .+�5(      �� -   5        	 ��Name$	 txtId��5(   &   $��Id��65   ${�False��6?   �� 5)      -   5        $	 txtName��5)   &   $
��Name��67   �� 5*      -   5        $	 txtPhone��5*   &   $��Phone��68   �� 5+      -   5        $	 txtEmail��5+   &   $��Email��68   �� 5,      -   5        $	 txtBirthday��5,   &   $��Birthday��6;   �� 5-      -   5        $	 	txtStatus��5-   &   $��Status��69   5.      �� 5/      $ Vertical=�6%   $
��Left=�6<   $��1��6W   $��	0,10,0,10q�6d   $	��150��6w   .+�50      �� -	   5        
 ��Name$
 btAddCustomer��50   %   $��Add Customer��6<   $
��0,10q�6S      
AddBtStyle#��[  6a   $	��150��6�   6�   �� 51      -
   5        $
 btEditCustomer��51   %   $��Edit Customer��6=   $
��0,10q�6U     EditBtStyle#��[ 6c   $	��150��6�   6�   �� 52      -   5        $
 btDeleteCustomer��52   %   $��Delete Customer��6?   $
��0,10q�6Y     DeleteBtStyle#��[ 6g   $	��150��6�   6�   53      �� 54      $ Vertical=�6%   $
��Left=�6<   $��1��6W   $��
24,10,0,10q�6d   $��2��6x   $	��249��6�   .+�55      �� -   5        $
 btSearchCustomer��55   %   $��Search��6?   $
��0,10q�6P   #��[  6^   $	��150��6�   6�   �� 56      $ 
Horizontal=�6)   .+�57   "   �� $
��Name��6(   $��50��67   �� 58   "   -   5        $	 txtSName��58   *   $	��160��6<   59      �� 5:      $ 
Horizontal=�6)   .+�5;   "   �� $��Status:��6(   $��50��6:   �� 5<   "   -   5        $	 
txtSStatus��5<   *   $	��160��6>   $��1 or 0 (Default: 1)��6J   5=   I   5>      �� 5?      -   5        $
 btLogout��5?   %   $��Logout��67   $
��0,10q�6H     LogoutBtStyle#��[ 6V   $	��150��6}   6�   5@      5C      5D      �� 5G      $��Room Management��6   .��5H      �  5I      �� 5J      $��* �6,   �� 5K      $
��Auto �6,    5M      �� 5N      $
��174* �6/   �� 5O      $
��337* �6/   �� 5P      $
��283* �6/   .+�5R        -   5        $ dgRoom��5R   #   $ False��63   $��3��6O    5S        5T   "   $ RoomId��65    6E   �� *RoomId+  5U   "   $ 
RoomNumber��65    6I   �� *
RoomNumber+  5V   "   $ RoomType��65    6G   �� *RoomType.RoomTypeName+  5W   "   $ RoomDetailDescription��65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 263 6~    6T   �� *RoomDetailDescription+6~     5X   "   $ RoomMaxCapacity��65    6N   �� *RoomMaxCapacity+  5Y   "   $ RoomPricePerDay��65    6N   �� *RoomPricePerDay+  5Z   "   $ 
RoomStatus��65    6I   �� *
RoomStatus+5\      �� 5]      $ Vertical=�6%   $��Center=�6<   $��1��6Y   $	��336��6f   $��1��6r   .+�5^      �� -   5        $	 	txtRoomId��5^   &   $��RoomId��69   ${�False��6G   �� 5_      -   5        $	 	txtNumber��5_   &   $��
RoomNumber��69   �� 5`      -   5        $	 	txtDetail��5`   &   $��Detail description��69   �� 5a      -   5        $	 txtCapacity��5a   &   $��Capacity��6;   �� 5b      -   5        $	 txtPrice��5b   &   $��Price per day��68   �� 5c      -   5        $	 txtRoomStatus��5c   &   $��Status��6=   �� 5d      -   5         ��Name$ 
cbRoomType��5d   '    �� Text$ RoomType��6;   5e      �� 5f      $ Vertical=�6%   $
��Left=�6<   $��1��6W   $��	0,10,0,10q�6d   $	��150��6w   .+�5g      �� -   5        $
 	btAddRoom��5g   %   $��Add New Room��68   $
��0,10q�6O   #��[  6]   $	��150��6�   6�   �� 5h      -   5        $
 
btEditRoom��5h   %   $��	Edit Room��69   $
��0,10q�6M   #��[ 6[   $	��150��6�   6�   �� 5i      -   5        $
 btDeleteRoom��5i   %   $��Delete Room��6;   $
��0,10q�6Q   #��[ 6_   $	��150��6�   6�   5j      �� 5k      $ Vertical=�6%   $
��Left=�6<   $��1��6W   $��
24,10,0,10q�6d   $��2��6x   $	��249��6�   .+�5l      �� -   5        $
 btSearchRoom��5l   %   $��Search��6;   $
��0,10q�6L   #��[  6Z   $	��150��6~   6�   �� 5m      $ 
Horizontal=�6)   .+�5n   "   �� $��Price��6(   $��50��68   �� 5o   "   -   5        $	 txtSRoomPrice��5o   *   $	��160��6A   5p      �� 5q      $ 
Horizontal=�6)   .+�5r   "   �� $
��Type��6(   $��50��67   �� 5s   "   -   5        $ cbSRoomType��5s   +   $	��160��6@   5t      �� 5u      $ 
Horizontal=�6)   .+�5v   "   �� $��Status:��6(   $��50��6:   �� 5w   "   -   5        $	 txtSRoomStatus��5w   *   $	��160��6B   $��1 or 0 (Default: 1)��6N   5x   M   5y      �� 5z      -   5        $��Logout��5z   %   $
��0,10q�66   #��[ 6D   $	��150��6k   6w   5{      5|      5}      �� 5�      $��Booking Management��6   .��5�      �  5�      �� 5�      $��* �6,   �� 5�      $
��Auto �6,    5�      �� 5�      $
��174* �6/   �� 5�      $
��337* �6/   �� 5�      $
��283* �6/   .+�5�        -    5        $ 	dgBooking��5�   #   $ False��66   $��3��6R    5�        5�   "   $ BookingReservationId��65    6S   �� *BookingReservationId+  5�   "   $ CustomerFullName ��65    6P   �� *Customer.CustomerFullName+  5�   "   $ BookingDate��65    6J   �� *BookingDate+  5�   "   $ 
TotalPrice��65    6I   �� *
TotalPrice+  5�   "   $ BookingStatus��65    6L   �� *BookingStatus+4  .System.Windows.Controls.DataGridTemplateColumn  5�   "   $ Booking Details��69      CellTemplate 5�   &   �� 5�   *   .R�5�   .   9� $��View Details��67   .��5�   2     $ False��6b   ��6;   �� *BookingDetails+ 5�   6     5�   :   $ 
RoomNumber��6M    6a   �� *Room.RoomNumber+  5�   :   $ 	StartDate��6M    6`   �� *	StartDate+  5�   :   $ EndDate��6M    6^   �� *	EndDate+  5�   :   $ ActualPrice��6M    6b   �� *ActualPrice+5�   3   5�   /   5�   +   5�   #   5�      �� 5�      $ 
Horizontal=�6%   $��Center=�6>   $��3��6[   $��1��6o   $
��0,10q�6|   .+�5�      �� $��Search Room��6%   $
��25,0q�6;   #��[  6I   �� 5�      $��Logout��6%   $
��25,0q�66   #��[ 6D   5�      5�      5�      �� 5�      $��Report��6   .��5�      � .+�5�      �� $��Start Date:��6    $
��Left=�66   (  "System.Windows.Controls.DatePicker  5�      -!   5          Name$ StartDatePicker��5�   %   $
��Left=�6>   �� 5�      $��	End Date:��6    $��Center=�64     5�      -"   5        $ EndDatePicker��5�   %   $��Center=�6<   �� 5�      $��Generate Report��6!   $��Right=�6;     5�      -#   5        $ dgReport��5�   #   $ False��65   5�      5�      5�      5�      5�      5�      