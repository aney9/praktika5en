   M S B A M L   `   `   `  ����D  @praktika5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:praktika5	praktika5  5   	       praktika5.lekforvrach   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:praktika5     5   	     � Title$  lekforvrach��5   	   $	��450��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      �� 5      $
��0.3* �6   .+�5   
   �� $%��Таблица лекарств��6   $��Center=�6,   $��2��6I   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dg1��5   a   $��1��6   $��2��6       
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$) #Название лекарства��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
mediciness+6D     5      $! Цена лекарства��6H    6%   �� *PriceMedicines+6H   5      �� 5   
   -   5        	 ��Name$		 vyh��5   @   $��2��6   $��2��6   $��
Выйти��6M   5      5      