   M S B A M L   `   `   `  ����D  @praktika5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:praktika5	praktika5  5   	       praktika5.orders   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:praktika5     5   	     � Title$  orders��5   	   $	��450��6   $	��800��6%   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   .+�5   
   �� $#��Таблица заказов��6   $��2��6+   $
��Wrap=�6;   $��Center=�6O   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dg1��5   @      AutoGenerateColumns .     
IsReadOnly . $��1��6{   $��5��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата заказа��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
DateOrders+6D     5      $ Номер заказа��6H    6%   �� *NumberOfOrders+6H     5       $ Логин клиента��6Y    6%   �� *!Clients.LoginPassword.loginvhod+6Y     5!      $ Статус заказа��6J    6%   �� *Statuss.statusss+6J   5#      �� 5$   
   $��Выберите дату��6   $��2��6)   $��2��66   $
��Wrap=�6J   �� 5%   
   $,��&Введите номер заказа��6   $��2��60   $��2��6=   $
��Wrap=�6M   �� 5&   
   $!��Выберите логин��6   $��2��6*   $��3��67   $
��Wrap=�6G   �� 5'   
   $#��Выберите статус��6   $��2��6+   $��4��68   $
��Wrap=�6H   (  "System.Windows.Controls.DatePicker  5(   
   -   5        	  Name$
	 data��5(   q   $��3��6   $��2��6#   
   DisplayDateStart$
 
2023-01-01X�67      DisplayDateEnd$ 
2025-01-01X�6U      IsTodayHighlighted .     SelectedDate 6   �� *SelectedDate+ �� Mode$ TwoWay=�6�   �� 5)   
   -   5         ��Name$ nomer��5)      $��3��6!   $��2��6.   6>   �� 5*   
   -   5         ��Name$ 
vyborlogin��5*   U   $��3��6   $��3��6    6U   �� 5+   
   -   5        $ vyborstatus��5+   V   $��3��6   $��4��6    6V   �� 5,   
   -   5         ��Name$	 dob��5,      $��добавить��6   $��4��6@   $��5��6M   �� 5-   
   -   5        $	 izm��5-      $��изменить��6   $��5��6?   $��5��6L   �� 5.   
   -   5        $	 uda��5.      $��удалить��6   $��6��6=   $��5��6J   �� 5/   
   -	   5        $	 vyh��5/      $��
выйти��6   $��7��6<   $��5��6I   50      51      