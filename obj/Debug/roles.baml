   M S B A M L   `   `   `  ����D  @praktika5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:praktika5	praktika5  5   	       praktika5.roles   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:praktika5     5   	     � Title$  roles��5   	   $	��450��6   $	��800��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Таблица ролей��6   $��0��6)   $��1��66   $��Center=�6F   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dg1��5   M   $��1��6   $��3��6Z      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Роль��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *DentistryRole+6G   5       �� 5!   
   $��Введите роль��6   $��2��6(   �� 5"   
   -   5        	 ��Name$		 rol��5"      $��3��6   $��3��6,   6W   �� 5#   
   -   5        
 ��Name$
 dobavl��5#   2   $��5��6   $��3��6   $��Добавить��6B   6U   �� 5$   
   -   5        $
 izmen��5$   2   $��6��6   $��3��6   $��Изменить��6A   6T   �� 5%   
   -   5        $
 udalen��5%   2   $��7��6   $��3��6   $��Удалить��6B   6T   �� 5&   
   -   5        $	
 vyh��5&   2   $��8��6   $��3��6   $��
Выйти��6?   6O   5'      5(      