   M S B A M L   `   `   `  ����S  OWpfApp_ADO_NET_CodeFirst, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:WpfApp_ADO_NET_CodeFirst.StylesWpfApp_ADO_NET_CodeFirst.Styles  5      C&clr-namespace:WpfApp_ADO_NET_CodeFirstWpfApp_ADO_NET_CodeFirst  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0899    3WpfApp_ADO_NET_CodeFirst.ConverterEmployeesToString   ConverterEmployeesToString8   2WpfApp_ADO_NET_CodeFirst.ConverterProjectsToString  ConverterProjectsToString  dataGridProjects  �� 
TargetType&   System.Windows.Controls.DataGrid  dataGridBase �� BasedOn �� Property �� Value �� 
TargetType   AutoGenerateColumns �� 
GroupStyle(  "System.Windows.Controls.GroupStyle  GroupHeaderStyle   ContainerStyle   RowHeaderTemplate	 �� RelativeSource
 �� AncestorType  RowToIndexConv �� 	Converter   RowDetailsTemplate �� Orientation �� StringFormat �� Path   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   
IsReadOnly   Header1  +System.Windows.Controls.DataGridBoundColumn   Binding   Width5  /System.Windows.Controls.DataGridLengthConverter �� UpdateSourceTrigger  dataGridEmployees�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      7local-clr-namespace:WpfApp_ADO_NET_CodeFirst.Styles  5      4	localBase&clr-namespace:WpfApp_ADO_NET_CodeFirst  5      %�
  &	        &	      &	 &     7  7  7  7  7   &	 v    7  7  7  7  7     5      6+     5      6*   �� 5
      "   6%   8   .�5   
   ��  � �� 5      �� 5      "  6"   .R�5         .  #��z��6;   8��  5        5      8  5       5      �� 5      .R�5   "   �� $��2q�6,   
����  ���6I   �� 	 �� $
 DataGridRowL�8  5       5      �� 5      .R�5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $9��3Дополнительная информация: ��60   �� 5    &   ��5!   *   `� 5"   .   $ {0} {1}��6;   .1�5#   2   �� $ Title�6:   �� 5$   2   $ Description�6:   5%   /   5'   '   5(   #   5)       5,        5-       . $ Id��6C    6O   �� $ 	ProjectId�  5.       . $ Title��6C   $
 Auto 6�    6R   �� $ Title�$ PropertyChanged=�6�     50       . $ 	Employees��6C   $
 Auto 6�    6V   �� *	Employees+8  $ PropertyChanged=�6�     5A       . $ 
Start Date��6C   $	 150 6�    6W   �� $ 	StartDate�$! {0:yyyy-MM-dd HH:mm:ss.fff}��$ PropertyChanged=�6�     5B       . $ End Date��6C   $	 150 6�    6U   �� $ EndDate�$! {0:yyyy-MM-dd HH:mm:ss.fff}��$ PropertyChanged=�6�     5C       . $ Description��6C   $	 150 6�    6X   �� $ Description�$ PropertyChanged=�6�   5M      5N      5P      5R      �� 5T      "   6&   8   .�5V   
   ��  � �� 5W      �� 5X      "  6"   .R�5Y         .  #��z��6;   8��  5[        5\      8  5]       5`      �� 5a      .R�5b   "   �� $��2q�6,   
����  ���6I   �� 	 �� $
 DataGridRowL�8  5c       5f      �� 5g      .R�5h   "   �� $ 
Horizontal=�6-   .+�5i   &   �� $9��3Дополнительная информация: ��60   �� 5j   &   $��50��6,   $��50��68   $��Uniform=�6C   ��6U   �� *
FotoPath+5k   #   5l       5o        5p       . $ Id��6C    6O   �� $ 
EmployeeId�  5q       . $ 
First Name��6C   $
 Auto 6�    6W   �� $ 	FirstName�$ PropertyChanged=�6�     5r       . $ 	Last Name��6C   $	 150 6�    6V   �� $ LastName�$ PropertyChanged=�6�     5t       . $ Projects��6C   $
 Auto 6�    6U   �� *
Projects+8  $ PropertyChanged=�6�     5v       . $	 Age��6C   $ 50 6�    6P   �� $	 Age�$ PropertyChanged=�6�     5w       . $ Address��6C   $	 150 6�    6T   �� $ Address�$ PropertyChanged=�6�   5�      5�      5�      5�      5�      