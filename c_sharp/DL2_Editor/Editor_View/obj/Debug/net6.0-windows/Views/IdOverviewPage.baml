   M S B A M L   `   `   `  ����F  BEditor_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Editor_View.ViewsEditor_View.Views  5      K GEditor_ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:Editor_ViewModel;assembly=Editor_ViewModelEditor_ViewModel 5      &     Editor_View.Views.IdOverviewPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Editor_View.Views     5      Gvm8clr-namespace:Editor_ViewModel;assembly=Editor_ViewModel     5        N� Title$  IdOverviewPage��5
       � DataContext 5      $  Editor_ViewModel.MainViewModel  5   
   .��5      � .+�5   
   �� ���	#80000000���#e9eecd���#e9eecd$	��0.5q�6�   ��6*   �� *SelectedLanguage.IdLabel+.��5      �� 
������ ��62   �� *IdData+ � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value��%?  '��       �� 5      " ��6   .�5      ��  � �� �#e9eecd68   �� 5       � �� �#e9eecd67   �� 5       � ��
 ���� 67   �� 5       �@�Cursor$
 Hand��63   �� 5       � �� 5      �� 5   "   " ��62   .R�5   &   � #��z��6+   .+�5   *   �� $��1q�61   #��z��6E   $ 5,5,0,0��6q   ._�5   .   �� $��Header��6?   $��Center=�6V   $��Center=�6s   $��10, 5, 10, 5q�6�   5    +   5!   '    5"   &   P� 5$   *   	 �@J�IsMouseOver$

 True��6I   . �5%   .   ��  � �� �#4554506K   �� 5&   .    � �� �#e9eecd6K   5'   +   P� 5)   *   	 �@��
IsSelected$

 True��6H   . �5*   .   ��  � �� �#e9eecd6K   �� 5+   .    � ��
 �   �6K   �� 5,   .    � ��
 ���� 6L   5-   +   5/   #   51      52      53      ��55      �� 56      .R�57      �� ��6$   �� *Name+58       �� ContentTemplate 5:      �� 5;      .R�5<      �� $��onlockableItems��5=      $��10q�5>      $
��Auto��5?      
���   ����#e9eecd J� Opacity$	 0.5Q�5B      ���#e9eecd��5D      �� *IDs+ �� View 5E      �� 5F   "   .P�5G   &   �� $��ID��65    �� Width$	 250��6A    �� CellTemplate 5H   *   �� 5I   .   .R�5J   2   �� ��6<   �� 5K   /   5M   '   5N   #   ��5P      �� 5Q   "   " ��6(   .�5R   &   ��  � ��$ Stretch=�6L    �� Triggers 5S   &   P� 5T   *   	 �@J�IsMouseOver$

 True��6I   . �5U   .   ��  � ��
 �   �6K   5V   +   P� 5W   *   	 �@��
IsSelected$

 True��6H   . �5X   .   ��  � �� �#4554506K   5Y   +   5[   #   5]      5^      5`      5a      5b      5c      