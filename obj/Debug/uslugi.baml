   M S B A M L   `   `   `  ����D  @praktika5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:praktika5	praktika5  5   	       praktika5.uslugi   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:praktika5     5   	     � Title$  uslugi��5   	   $	��450��6   $	��800��6%   .��5	      �  � ColumnDefinitions 5
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
   �� $��Таблица услуг��6   $��2��6)   $��Center=�6=   $
��Wrap=�6Z   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dg1��5      $��1��6    $��2��6-      
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Услуга��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
servicesss+6D     5      $ Цена услуги��6F    6%   �� *PriceService+6F   5      �� 5   
   $!��Введите услугу��6   $��2��6*   $��2��67   $
��Wrap=�6K   �� 5    
   $*��$Введите цену услуги��6   $��2��6/   $��2��6<   $
��Wrap=�6L   �� 5!   
   -   5        	 ��Name$		 usl��5!      $��3��6   6,   �� 5"   
   -   5        $	 price��5"      $��3��6!   $��1��6.   6?   �� 5#   
   -   5        
 ��Name$	
 dob��5#      $��добавить��6   $��4��6@   $��2��6M   �� 5$   
   -   5        $	
 izm��5$      $��изменить��6   $��5��6?   $��2��6L   �� 5%   
   -   5        $	
 uda��5%      $��удалить��6   $��6��6=   $��2��6J   �� 5&   
   -   5        $	
 vyh��5&      $��
выйти��6   $��7��6<   $��2��6I   5'      5(      