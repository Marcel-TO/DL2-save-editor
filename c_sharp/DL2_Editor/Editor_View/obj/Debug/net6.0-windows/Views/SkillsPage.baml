   M S B A M L   `   `   `  ����F  BEditor_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Editor_View.ViewsEditor_View.Views  5      K GEditor_ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:Editor_ViewModel;assembly=Editor_ViewModelEditor_ViewModel 5      ?$clr-namespace:Editor_View.ConvertersEditor_View.Converters  5      "    Editor_View.Views.SkillsPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Editor_View.Views     5      Gvm8clr-namespace:Editor_ViewModel;assembly=Editor_ViewModel     5      :	converter$clr-namespace:Editor_View.Converters     5        N� Title$  
SkillsPage��5       � DataContext 5      $  Editor_ViewModel.MainViewModel  5   
    � 	Resources 5      .   (Editor_View.Converters.HexValidationRule   hexValidationRule)   #Editor_View.Converters.HexConverter  hexConverter6   0Editor_View.Converters.ChangedDataValueConverter  changedValueConverter  ValidationTemplate  TextBoxInError �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value	 �� Self
 �� RelativeSource �� Path��%�  &	        &	      &	 &     &	 9     &	 �       5   
   6&     5   
   6!     5   
   6.   �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��20(�6-   !6>   �� 5      5      5      �� 5   
   " ��6'    5      P� 5       �@=�HasError$
 true��69   . �5       ��  �@�ToolTip 5!      �� #
 Z	 $) #(Validation.Errors)[0].ErrorContent�5#      5%      5&      .��5)      � .+�5*   
   �� ���	#80000000���#e9eecd���#e9eecd$	��0.5q�6�   ��6*   �� *SelectedLanguage.SkillLabel+.��5,      �� 
������  5-       �� 
TargetType �� CornerRadius �� Triggers��%?  '��       �� 5/      " ��6   .�50      ��  � �� �#e9eecd68   �� 51       � �� �#e9eecd67   �� 52       � ��
 ���� 67   �� 53       �@�Cursor$
 Hand��63   �� 54       � �� 55      �� 56   "   " ��62   .R�57   &   � #��z��6+   .+�58   *   �� $��1q�61   #��z��6E   $ 5,5,0,0��6q   ._�59   .   �� $��Header��6?   $��Center=�6V   $��Center=�6s   $��10, 5, 10, 5q�6�   5:   +   5;   '    5<   &   P� 5>   *    �@J�IsMouseOver$
 True��6I   . �5?   .   ��  � �� �#4554506K   �� 5@   .    � �� �#e9eecd6K   5A   +   P� 5C   *    �@��
IsSelected$
 True��6H   . �5D   .   ��  � �� �#e9eecd6K   �� 5E   .    � ��
 �   �6K   �� 5F   .    � ��
 ���� 6L   5G   +   5I   #   5K      5L      5M      .@�5P      �� ��6   �� *" SelectedLanguage.BaseSkillsLabel+.��5Q      �� -   5        $��baseSkillItems��5R      $��10q�5S      $
��Auto��5T      
������ ���#e9eecd���#e9eecd��5X      �� *SaveFile.Skills.BaseSkills+ �� UpdateSourceTrigger$ PropertyChanged=� �� View 5Y      �� 5Z       �� AllowsColumnReorder$
 true��6'    �� ColumnHeaderToolTip$ Skill Information��6B   ! �� ColumnHeaderContainerStyle 5[   "   �� 5\   &   " ��6,   .�5]   *   ��  � �� �#e9eecd6G   �� 5^   *    � ��
 �   �6G    5_   *   P� 5a   .    �@J�IsMouseOver$
 True��6M   . �5b   2   ��  � �� �#4554506O   �� 5c   2    � ��$
 Bold"�6O   5d   /   5f   '   .P�5i   "   ��  �� Width$	 250��6W    �� DisplayMemberBinding 61   �� *Name+$
��Name��5j   X    �� CellTemplate 5k   &   �� 5l   *   .R�5m   .   �� $��Center=�6N   $��Center=�6k   ��68   �� *Name+6k   5n   +   5p   #   �� 5q   "   $��Value��61   $	 150��6@    5r   &   �� 5s   *   .R�5t   .   ��  �� Orientation$ 
Horizontal=�69   $��Center=�6R   .+�5u   2   �� $��Stretch=�6Z   $��Center=�6x   $��50��6�   ��6<   �� *PointsString+6�   d� 5v   2    d�Name$ ChangeValue��6?    � Cursor$
 Hand��5w   ?   $��Stretch=�5y   ?   $	��5 0q�5z   ?   $��5q�5{   ?   ���#e9eecd
���   ���5x   ?   �� $. (DataContext.SelectedLanguage.ChangeLabel�
 ��  �� AncestorType 
TabControl 5~   6   ��%^   '��       �� 5   :   " ��6@   .�5�   >   ��  �@��CornerRadius$ 5��6]   5�   ;   5�   7   5�   3   � 5�   2    �Name$ ChangeValuePopUp��68    � 	StaysOpen$ False��6�   ��6R   �� *	IsChecked+ �� ElementName$ ChangeValue�� � PlacementTarget 6�   �� $ ChangeValue��.��5�   6   �  � RowDefinitions 5�   :   �� 5�   >   $��50 �6L   �� 5�   >   $��50 �6L     � ColumnDefinitions  5�   :   �� 5�   >   $	��100 �6O   �� 5�   >   $	��100 �6O   .+�5�   :   �� $��2��6A   $��2��6U   $ 5��6f   
���   ����#e9eecd6�   �� 5�   :   ! ��Name$! ValueChangerTextBox��6B   $��0��6�   $��0��6�   ��6_   �� *PointsString+" �� Mode$" OneWay=�$ Explicit=�6�   �� 5�   :   $��Change Here��6A   $��1��6W   $��2��6d   ��5�   A   �� $) #DataContext.ChangeSkillValueCommand�
 ��  
TabControl��5�   >   `� 5�   B   # `� 	Converter## [ 6O   .1�5�   F   �� $ Index�6N   �� 5�   F   $
 Name�6N   �� 5�   F   $ PointsString�6N   �� 5�   F   $
 Text�6N   $ ValueChangerTextBox��6Z   �� 5�   F   $
 Size�6N   5�   C   5�   ;   5�   7   5�   3   5�   /   5�   +   5�   #   �� 5�   "   $��Index��61   $	 100��6@    5�   &   �� 5�   *   .R�5�   .   �� $��Stretch=�6O   $��Center=�6m   ��68   �� *Index+6m   5�   +   5�   #   �� 5�   "   $
��Size��61   $ 50��6?    5�   &   �� 5�   *   .R�5�   .   � $��Center=�63   .+�5�   2   �� $��Stretch=�6R   $��Center=�6p   ��6<   �� *Size+6p   5�   /   5�   +   5�   #   �� 5�   "   $��SGD Data��6\   $
 Auto��6n    61   �� *	SgdString+ 5�   &   �� 5�   *   .R�5�   .   �� $��Center=�6S   $��Center=�6p   ��68   �� *	SgdString+6p   5�   +   5�   #   5�      ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��$ Stretch=�6H   �� 5�   "    � �� �#e9eecd6@   �� 5�   "    � �� �#e9eecd6?   �� 5�   "    � ��
 ���� 6?   �� 5�   "    �@�Cursor$
 Hand��6;    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   ��  � �� �#4554506G   �� 5�   *    � �� �#e9eecd6G   5�   '   P� 5�   &    �@��
IsSelected$
 True��6D   . �5�   *   ��  � �� �#e9eecd6G   �� 5�   *    � ��
 �   �6G   �� 5�   *    � ��
 ���� 6H   5�   '   5�      5�      5�      �� 5      ��6   �� *$"SelectedLanguage.LegendSkillsLabel+.��5     �� -   5        $��legendSkillItems��5     $��10q�5     $
��Auto��5     
���   ����#e9eecd���#e9eecd��5     �� *SaveFile.Skills.LegendSkills+ 5	     �� 5
     $
 true��6'   $ Skill Information��6B   .P�5  "   �� $
��Name��6W   $	 250��6e    61   �� *Name+ 5  &   �� 5  *   .R�5  .   �� $��Center=�6N   $��Center=�6k   ��68   �� *Name+6k   5  +   5  #   �� 5  "   $��Index��61   $	 100��6@    5  &   �� 5  *   .R�5  .   �� $��Stretch=�6O   $��Center=�6m   ��68   �� *Index+6m   5  +   5  #   �� 5  "   $
��Size��61   $ 50��6?    5  &   �� 5  *   .R�5  .   � $��Center=�63   .+�5  2   �� $��Stretch=�6R   $��Center=�6p   ��6<   �� *Size+6p   5  /   5   +   5"  #   �� 5#  "   $��SGD Data��6\   $
 Auto��6n    61   �� *	SgdString+ 5$  &   �� 5%  *   .R�5&  .   �� $��Center=�6S   $��Center=�6p   ��68   �� *	SgdString+6p   5'  +   5)  #   5*     ��5,     �� 5-     " ��6$   .�5.  "   ��  � ��$ Stretch=�6H   �� 5/  "    � ��$ 10��6;   �� 50  "    � ��$	 Top=�6F    51  "   P� 52  &    �@J�IsMouseOver$
 True��6E   . �53  *   ��  � �� �#e9eecd6G   �� 54  *    � ��
 �   �6G   55  '   P� 56  &    �@��
IsSelected$
 True��6D   . �57  *   ��  � �� �#4554506G   58  '   5:     5=     5>     5?     5@     5A     5B     