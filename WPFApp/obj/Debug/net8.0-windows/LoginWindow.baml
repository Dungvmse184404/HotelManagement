   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  LoginWindow��5   	   $	��450��6   $	��800��6*    � 	Resources 5	      -  'System.Windows.Media.Effects.BlurEffect   
BlurEffect   Radius  
LabelStyle �� 
TargetType �� Property �� Value��%#  &	        &	        5
   
   $ 10Q�6(   �� 5   
   " ��6#   .�5      ��  �@��Padding$ 0,2,0,0q�6(   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Medium"�6+   �� 5       � ��$ 
Montserrat)�6+   5      5      .��5      � .+�5   
   ��  �� CornerRadius$ 10��6   $��2q�6#    J� Opacity$
 0.95Q�67   $
��Left=�6F   $	��800��6a   ��5      �� 5       �� 
StartPoint$	 0,0&�6&   	 �� EndPoint$		 1,1&�67   .��5      � 
 � Color$
 #0099FF��6#    � Offset$ 0Q�63   � 5      $
 #DA34AE��6#   $
 0.75Q�63   � 5      $
 	#FF60B1E7��6#   $ 1Q�65   � 5      $
 	#FF596FDD��6#   $ 0.309Q�65   � 5      $
 	#FF8C57CA��6#   $ 0.484Q�65   5      ��5!      �� 5"      $	 0,1&�6&   $		 1,0&�67   .��5#      � $
 #4A90E2��6#   $	 0.0Q�63   � 5$      $
 #f542c2��6#   $	 1.0Q�63   5%      ._�5(      � ��5)      !� 5*       !� Visual 5+      �� 5,      
���   �$	 0.5Q�68    J� Effect 5-   "     5.   &   $ 10Q�61   50      52      .+�54      �� $	��270��6   $ 15��6%   
�������$��248,10,248,10q�6J     FloatContainer#��[ 6b   ._�55      ��  �� Orientation$ Vertical=�6!   $��Center=�68   $��Center=�6U   $	��250��6p   .+�57      �� $��LOGIN��6$   
�������$��24(�6G   $��Light"�6U   $��
Montserrat)�58       �� TextAlignment$ Center=�65   $��	0,10,0,20q�6L   �� 5:      $ 
Horizontal=�6%   $��Center=�6>   .+�5;      �� $��/Icons/mail.png��6$   $��16��6=   $��16��6H   $��0,0,5,0q�6T   �� 5<      $��Email��6(   #��[ 65   5=      �� 5>      -   5         ��Name$ txtKey��5>   "   $��12(�62   
������� �� 
CaretBrush
 �����$��
Montserrat)�6f   
�������$��0,0,0,2q�5?   4   $��0 8 0 0q�6N   $��18��6_   
������ 6k   �� 5A      $ 
Horizontal=�6%   $��Center=�6>   $��0,15,0,0q�6Y   .+�5B      �� $��/Icons/lock.png��6$   $��16��6=   $��16��6H   $��0,0,5,0q�6T   �� 5C      $��Password��6(   #��[ 68   5D      G� 5E      -   5         G�Name$ txtPassword��5E   &   $��14(�6;   
������� G� 
CaretBrush
 �����$��
Montserrat)�6r   
�������$��0,0,0,2q�5F   8   $��0 8 0 0q�6R   $��18��6c   
������ 6o   �� 5I      -   5         ��Name$ btnLogin��5I   !   $��LOGIN��63   $��	0,20,0,10q�6D     ButtonShadow#��[ 5J      ���#0099FF5L      �� 5N      -   5        $ 	btnCancel��5N   !   $��CANCEL��64   $��0,0,0,10q�6E   #��[ 5O      ���#DA34AE5Q      5T      5U      5V      5W      5X      5Y      