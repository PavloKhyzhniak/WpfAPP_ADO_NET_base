   M S B A M L   `   `   `  ����W  SWpfApp_ADO_NET_DatabaseFirst, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WpfApp_ADO_NET_DatabaseFirstWpfApp_ADO_NET_DatabaseFirst  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089=    7WpfApp_ADO_NET_DatabaseFirst.ConverterEmployeesToString   ConverterEmployeesToString<   6WpfApp_ADO_NET_DatabaseFirst.ConverterProjectsToString  ConverterProjectsToString  dataGridProjects  �� 
TargetType&   System.Windows.Controls.DataGrid  dataGridBase �� BasedOn �� Property �� Value �� 
TargetType   AutoGenerateColumns �� 
GroupStyle(  "System.Windows.Controls.GroupStyle  GroupHeaderStyle   ContainerStyle   RowHeaderTemplate	 �� RelativeSource
 �� AncestorType  RowToIndexConv �� 	Converter   RowDetailsTemplate �� Orientation �� StringFormat �� Path   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   
IsReadOnly   Header1  +System.Windows.Controls.DataGridBoundColumn   Binding   Width5  /System.Windows.Controls.DataGridLengthConverter �� UpdateSourceTrigger  dataGridEmployees�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      4local*clr-namespace:WpfApp_ADO_NET_DatabaseFirst  5      %�
  &	        &	      &	 &     7  7  7  7  7   &	 v    7  7  7  7  7     5      6'     5      6&   �� 5	      "   6%   8   .�5   
   ��  � �� 5      �� 5      "  6"   .R�5         .  #��z��6;   8��  5        5      8  5       5      �� 5      .R�5   "   �� $��2q�6,   
����  ���6I   �� 	 �� $
 DataGridRowL�8  5       5      �� 5      .R�5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $9��3Дополнительная информация: ��60   �� 5   &   ��5    *   `� 5!   .   $ {0} {1}��6;   .1�5"   2   �� $ Title�6:   �� 5#   2   $ Description�6:   5$   /   5&   '   5'   #   5(       5+        5,       . $ Id��6C    6O   �� $ 	ProjectId�  5-       . $ Title��6C   $
 Auto 6�    6R   �� $ Title�$ PropertyChanged=�6�     5/       . $ 	Employees��6C   $
 Auto 6�    6V   �� *	Employees+8  $ PropertyChanged=�6�     5@       . $ 
Start Date��6C   $	 150 6�    6W   �� $ 	StartDate�$! {0:yyyy-MM-dd HH:mm:ss.fff}��$ PropertyChanged=�6�     5A       . $ End Date��6C   $	 150 6�    6U   �� $ EndDate�$! {0:yyyy-MM-dd HH:mm:ss.fff}��$ PropertyChanged=�6�     5B       . $ Description��6C   $	 150 6�    6X   �� $ Description�$ PropertyChanged=�6�   5L      5M      5O      5Q      �� 5S      "   6&   8   .�5U   
   ��  � �� 5V      �� 5W      "  6"   .R�5X         .  #��z��6;   8��  5Z        5[      8  5\       5_      �� 5`      .R�5a   "   �� $��2q�6,   
����  ���6I   �� 	 �� $
 DataGridRowL�8  5b       5e      �� 5f      .R�5g   "   �� $ 
Horizontal=�6-   .+�5h   &   �� $9��3Дополнительная информация: ��60   �� 5i   &   $��50��6,   $��50��68   $��Uniform=�6C   ��6U   �� *
FotoPath+5j   #   5k       5n        5o       . $ Id��6C    6O   �� $ 
EmployeeId�  5p       . $ 
First Name��6C   $
 Auto 6�    6W   �� $ 	FirstName�$ PropertyChanged=�6�     5q       . $ 	Last Name��6C   $	 150 6�    6V   �� $ LastName�$ PropertyChanged=�6�     5s       . $ Projects��6C   $
 Auto 6�    6U   �� *
Projects+8  $ PropertyChanged=�6�     5u       . $	 Age��6C   $ 50 6�    6P   �� $	 Age�$ PropertyChanged=�6�     5v       . $ Address��6C   $	 150 6�    6T   �� $ Address�$ PropertyChanged=�6�   5      5�      5�      5�      5�      