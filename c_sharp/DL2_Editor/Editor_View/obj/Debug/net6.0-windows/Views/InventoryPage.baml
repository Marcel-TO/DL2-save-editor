   M S B A M L   `   `   `  ����F  BEditor_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Editor_View.ViewsEditor_View.Views  5      K GEditor_ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:Editor_ViewModel;assembly=Editor_ViewModelEditor_ViewModel 5      %    Editor_View.Views.InventoryPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Editor_View.Views     5      Gvm8clr-namespace:Editor_ViewModel;assembly=Editor_ViewModel     5        N� Title$  InventoryPage��5
       � DataContext 5      $  Editor_ViewModel.MainViewModel  5   
   .��5      � .+�5   
   �� ���	#80000000���#e9eecd���#e9eecd$	��0.5q�6�   ��6*   �� *!SelectedLanguage.InventoryLabel+.��5      �� 
������ ��62   �� *SaveFile.Items+ � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value��%?  '��       �� 5      " ��6   .�5      ��  � �� �#e9eecd68   �� 5       � �� �#e9eecd67   �� 5       � ��
 ���� 67   �� 5       �@�Cursor$
 Hand��63   �� 5       � �� 5      �� 5   "   " ��62   .R�5   &   � #��z��6+   .+�5   *   �� $��1q�61   #��z��6E   $ 5,5,0,0��6q   ._�5   .   �� $��Header��6?   $��Center=�6V   $��Center=�6s   $��10, 5, 10, 5q�6�   5    +   5!   '    5"   &   P� 5$   *   	 �@J�IsMouseOver$

 True��6I   . �5%   .   ��  � �� �#4554506K   �� 5&   .    � �� �#e9eecd6K   5'   +   P� 5)   *   	 �@��
IsSelected$

 True��6H   . �5*   .   ��  � �� �#e9eecd6K   �� 5+   .    � ��
 �   �6K   �� 5,   .    � ��
 ���� 6L   5-   +   5/   #   51      52      53      ��55      �� 56      .R�57      �� $��Items��6$   58       �� ContentTemplate 5:      �� 5;      .R�5<      �� $��onlockableItems��5=      $��10q�5>      $
��Auto��5?      
���   ����#e9eecd J� Opacity$	 0.5Q�5B      ���#e9eecd��5D      ��  �� View 5E      �� 5F   "    �� AllowsColumnReorder$
 true��6+    �� ColumnHeaderToolTip$ Item Information��6F   .P�5G   &   �� $
��Name��6[    �� Width$	 250��6i    �� DisplayMemberBinding 65   �� *Name+ �� CellTemplate 5H   *   �� 5I   .   .R�5J   2   �� $��Center=�6R   $��Center=�6o   ��6<   �� *Name+6o   5K   /   5M   '   �� 5N   &   $��Index��65   $	 100��6D    5O   *   �� 5P   .   .R�5Q   2   �� $��Stretch=�6S   $��Center=�6q   ��6<   �� *Index+6q   5R   /   5T   '   �� 5U   &   $
��Size��65   $ 50��6C    5V   *   �� 5W   .   .R�5X   2   � $��Center=�67   .+�5Y   6   �� $��Stretch=�6V   $��Center=�6t   ��6@   �� *Size+6t   5Z   3   5\   /   5^   '   �� 5_   &   $��SGD Data��6`   $
 Auto��6r    65   �� *	SgdString+ 5`   *   �� 5a   .   .R�5b   2   �� $��Center=�6W   $��Center=�6t   ��6<   �� *	SgdString+6t   5c   /   5e   '   5f   #   ��5h      �� 5i   "   " ��6(   .�5j   &   ��  � ��$ Stretch=�6L    �� Triggers 5k   &   P� 5l   *   	 �@J�IsMouseOver$

 True��6I   . �5m   .   ��  � ��
 �   �6K   5n   +   P� 5o   *   	 �@��
IsSelected$

 True��6H   . �5p   .   ��  � �� �#4554506K   5q   +   5s   #   5u      5v      5x      5y      5z      5{      