   M S B A M L   `   `   `  ����S  OWpfApp_ADO_NET_LinqToSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WpfApp_ADO_NET_LinqToSQLWpfApp_ADO_NET_LinqToSQL  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0899    3WpfApp_ADO_NET_LinqToSQL.ConverterEmployeesToString   ConverterEmployeesToString8   2WpfApp_ADO_NET_LinqToSQL.ConverterProjectsToString  ConverterProjectsToString  dataGridProjects  �� 
TargetType&   System.Windows.Controls.DataGrid  dataGridBase �� BasedOn �� Property �� Value �� 
TargetType   AutoGenerateColumns �� 
GroupStyle(  "System.Windows.Controls.GroupStyle  GroupHeaderStyle   ContainerStyle   RowHeaderTemplate	 �� RelativeSource
 �� AncestorType  RowToIndexConv �� 	Converter   RowDetailsTemplate �� Orientation �� StringFormat �� Path   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   
IsReadOnly   Header1  +System.Windows.Controls.DataGridBoundColumn   Binding   Width5  /System.Windows.Controls.DataGridLengthConverter �� UpdateSourceTrigger  dataGridEmployees�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0local&clr-namespace:WpfApp_ADO_NET_LinqToSQL  5      %�
  &	        &	      &	 &     7  7  7  7  7   &	 z    7  7  7  7  7     5      6'     5      6&   �� 5	      "   6%   8   .�5   
   ��  � �� 5      �� 5      "  6"   .R�5         .  #��z��5      8��  5        5      8  5       5      �� 5      .R�5   "   �� $��2q�6,   
����  ���6I   �� 	 �� $
 DataGridRowL�8  5       5      �� 5       .R�5!   "   �� $ 
Horizontal=�6-   .+�5"   &   �� $9��3Дополнительная информация: ��60   �� 5#   &   ��5$   *   `� 5%   .   $ {0} {1}��6;   .1�5&   2   �� $ Title�6:   �� 5'   2   $ Description�6:   5(   /   5*   '   5+   #   5,       5/        50       . $ Id��6C    6O   �� $ 	ProjectId�  51       . $ Title��6C   $
 Auto 6�    6R   �� $ Title�$ PropertyChanged=�6�     53       . $ 	Employees��6C   $
 Auto 6�    6V   �� *	Employees+8  $ PropertyChanged=�6�     5D       . $ 
Start Date��6C   $	 150 6�    6W   �� $ 	StartDate�$! {0:yyyy-MM-dd HH:mm:ss.fff}��$ PropertyChanged=�6�     5E       . $ End Date��6C   $	 150 6�    6U   �� $ EndDate�$! {0:yyyy-MM-dd HH:mm:ss.fff}��$ PropertyChanged=�6�     5F       . $ Description��6C   $	 150 6�    6X   �� $ Description�$ PropertyChanged=�6�   5P      5Q      5S      5U      �� 5W      "   6&   8   .�5Y   
   ��  � �� 5Z      �� 5[      "  6"   .R�5\         .  #��z��6;   8��  5^        5_      8  5`       5c      �� 5d      .R�5e   "   �� $��2q�6,   
����  ���6I   �� 	 �� $
 DataGridRowL�8  5f       5i      �� 5j      .R�5k   "   �� $ 
Horizontal=�6-   .+�5l   &   �� $9��3Дополнительная информация: ��60   �� 5m   &   $��50��6,   $��50��68   $��Uniform=�6C   ��6U   �� *
FotoPath+5n   #   5o       5r        5s       . $ Id��6C    6O   �� $ 
EmployeeId�  5t       . $ 
First Name��6C   $
 Auto 6�    6W   �� $ 	FirstName�$ PropertyChanged=�6�     5u       . $ 	Last Name��6C   $	 150 6�    6V   �� $ LastName�$ PropertyChanged=�6�     5w       . $ Projects��6C   $
 Auto 6�    6U   �� *
Projects+8  $ PropertyChanged=�6�     5y       . $	 Age��6C   $ 50 6�    6P   �� $	 Age�$ PropertyChanged=�6�     5z       . $ Address��6C   $	 150 6�    6T   �� $ Address�$ PropertyChanged=�6�   5�      5�      5�      5�      5�      