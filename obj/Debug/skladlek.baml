   M S B A M L   `   `   `  ����D  @praktika5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:praktika5	praktika5  5   	       praktika5.skladlek   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:praktika5     5   	     � Title$  skladlek��5   	   $	��450��6   $	��800��6'   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��1* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   .+�5   
   �� $1��+Таблица СкладЛекарство��6   $��2��62   $��Center=�6F   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dg1��5      $��1��6    $��2��6-      
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Лекарство��6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Medicines.mediciness+6N     5      $ Номер заказа��6P    6%   �� *Stock.WerehouseAddress+6P     5      5      �� 5    
   $)��#Выберите лекарство��6   $��2��6.   �� 5!   
   $!��Выберите склад��6   $��2��6*   $��1��67   �� 5"   
   -   5        	 ��Name$	 vyborlek��5"      $��3��6J   $��0��6W   �� 5#   
   -   5        $	 vyborskl��5#      $��3��6J   $��1��6W   �� 5$   
   -   5        
 ��Name$	
 dob��5$      $��добавить��6   $��4��6@   $��2��6M   �� 5%   
   -   5        $	
 izm��5%      $��изменить��6   $��5��6?   $��2��6L   �� 5&   
   -   5        $	
 uda��5&      $��удалить��6   $��6��6=   $��2��6J   �� 5'   
   -   5        $	
 vyh��5'      $��
выйти��6   $��7��6<   $��2��6I   5(      5)      