   M S B A M L   `   `   `  ����>  :Zoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ZooZoo  5   	   1clr-namespace:Zoo.ValidationFZoo.ValidationF  5   	       Zoo.Employees   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Zoo     5   	   0local1clr-namespace:Zoo.ValidationF     5   	     � Title$  	Employees��5	   	   $	��350��6   $	��500��6(   
�����w� � 	Resources 5       �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader&   System.Windows.Controls.DataGrid   RowStyle)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value �� RelativeSource	 �� Path��%r  '��       '  �     '  �    &	      �� 5   
   " ��6   .�5      ��  � ��
 ��İ�6D   �� 5       � ��$ Comic Sans MS)�6+   6C   �� 5       � ��$ 2q�60   6<   �� 5       � ��
 �   �6<   5      �� 5   
   "  6   .�5      ��  � ��
 ��·�6B   �� 5       � ��$ 1q�60   6<   �� 5       � ��
 �   �6<   �� 5       � ��$ 23��6'   64   5      �� 5   
   "  6   .�5      ��  � ��
 ���w�6D   �� 5       � ��$ century gothic)�6+   6D   5      �� 5   
   "  6!   .�5      ��  � ��
 ��İ�6D    5       P� 5!       �@=�HasError . . �5"      ��  � ��$ 1q�68   �� 5#       � ��
 �  ��64   �� 5$       �@�ToolTip 5&      ��  �� *Self+$)	 #(Validation.Errors)[0].ErrorContent�5(      5*      5,      .��5-      � 
 � RowDefinitions
 5.   
   �� 5/      $��25 �6   �� 50      �� 51      $��50 �6   .+�53   
     -   5          Name$ EmployeesGrid��53   /      AutoGenerateColumns .  $��1��6F      HeadersVisibility$ Column=�6T      RowStyle# [  6q   $��	-2,3,2,47q�6�   $��2��6�      RowValidationRules 54      /   )Zoo.ValidationF.RowDataInfoValidationRule  55      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ CommittedValue=�63   6U      Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6K      Width5  /System.Windows.Controls.DataGridLengthConverter$ 20 6W   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6%   �� *IDOfCertification+6W     59      $ Имя��6>   $	 120 6K    6%   �� *Name+6K     5:      $ Должность��6B   $ 90 6U    6%   �� *
Position+6U     5;      $ Стаж��6D   $ 50 6R    6%   �� *
Experience+6R     5<      $ Дата Рождения��6V   $ 95 6m    6%   �� *BDAY+ �� StringFormat$ 
dd.MM.yyyy��6m     5=      $! Номер телефона��6E   $	 110 6]    6%   �� *PhoneNumber+6]   5?      �� 5@   
   -   5         ��Name$ updateButton��5@      $��2��6   $��Обновить��64   $��272,0,146,0q�6b   �� 5A   
   -   5        $ deleteButton��5A      $��2��6   $��Удалить��65   $��120,0,296,0q�6b   �� 5B   
   -   5         ��Name$ 
searchtext��5B   Y   $��0��6   $��Right=�6   $	��150��6;   $��0,0,70,0q�6G   6Y   �� 5C   
   -   5        $ Clearbtn��5C   V   $��20��6   $��Right=�6   $��X��68   $��0,0,70,0q�6D   6�   �� 5D   
   -   5        $ 	Searchbtn��5D   I   $��70��6   $��Right=�6   $��Найти!��68   6v   5E      5F      