   M S B A M L   `   `   `  ����D  @praktika5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:praktika5	praktika5  5   	       praktika5.logins   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:praktika5     5   	     � Title$  logins��5   	   $	��450��6   $	��800��6%   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��2* �6   �� 5      $
��auto �6   �� 5      $
��0.5* �6   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $#��Таблица логинов��6   $��1��6+   $��Center=�6;   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dg1��5         
IsReadOnly .    AutoGenerateColumns .  $��3��6w   $��1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Логин��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	loginvhod+6C     5      $ Роль��6M    6%   �� *Roles.DentistryRole+6M   5      �� 5    
   $��Введите логин��6   $��2��6)   �� 5!   
   $!��Введите пароль��6   $��2��6*   $��1��67   �� 5"   
   $��Выберите роль��6   $��2��6)   $��2��66   �� 5#   
   -   5        	 ��Name$	 login��5#      $��3��6!   6J   �� 5$   
   -   5        $	 parol��5$      $��3��6!   $��1��6.   6Z   �� 5%   
   -   5        $��vybor��5%      $��3��6    $��2��6-   6=   �� 5&   
   -   5        $��4��5&      $��3��6   $��Добавить��62   6E   �� 5'   
   -   5        $��5��5'      $��3��6   $��Изменить��62   6E   �� 5(   
   -   5        $��6��5(      $��3��6   $��Удалить��62   6D   �� 5)   
   -   5        $��7��5)      $��3��6   $��
Выйти��62   6B   5*      5+      