   M S B A M L   `   `   `  ����W  SWpfApp_ADO_NET_SQLDataReader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WpfApp_ADO_NET_SQLDataReaderWpfApp_ADO_NET_SQLDataReader  5   	   2    ,WpfApp_ADO_NET_SQLDataReader.Window_DataGrid   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:WpfApp_ADO_NET_SQLDataReader     5   	     � Title$  Window_DataGrid��5   	   $	��450��6!   $	��800��6.    � 	Resources 5	         GroupHeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType 9�Name 9� 
IsExpanded1   +WpfApp_ADO_NET_SQLDataReader.RowToIndexConv  RowToIndexConv��%!  &	        &	 �     �� 5   
   " ��6)   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      9� $	 exp��6#    . 
�������
���   ���5      �� 5   "   ��6,   �� *Name+.��5      �� 5      5      5      5        5   
   6   5      .��5      � .+�5    
   &   System.Windows.Controls.DataGrid  -   5        $��dataGrid_MainPresenter��5#   	   $��
0, 0, 0, 0q�5!   	   
�������   HorizontalGridLinesBrush
 �����	   RowBackground
	 �����
   AlternatingRowBackground

 �����   CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  �� 
GroupStyle 5*      (  "System.Windows.Controls.GroupStyle  5+         ContainerStyle# [  6   5,         RowHeaderTemplate 5/      �� 50      .R�51      �� $��2q�6    
����  ���6=   ��  �� RelativeSource ��  �� AncestorType$ DataGridRowL� �� 	Converter# [ 52      55      57      58      