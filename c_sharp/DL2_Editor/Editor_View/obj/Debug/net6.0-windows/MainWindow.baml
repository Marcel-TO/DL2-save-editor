   M S B A M L   `   `   `  ����F  BEditor_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Editor_ViewEditor_View  5   	   K GEditor_ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:Editor_ViewModel;assembly=Editor_ViewModelEditor_ViewModel 5   	   Y>clr-namespace:Editor_ViewModel.Logic;assembly=Editor_ViewModelEditor_ViewModel.Logic 5   	       Editor_View.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Editor_View     5   	   Gvm8clr-namespace:Editor_ViewModel;assembly=Editor_ViewModel     5   	   Plogic>clr-namespace:Editor_ViewModel.Logic;assembly=Editor_ViewModel     5   	     � WindowStyle$
  None=�5
   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ 	CanResize=�5   	    � Title$ Dying Light Editor��5   	   $	��800��6$   $
��1000��61   
������  � Icon$ Pictures/icon.ico��6W    � DataContext 5      $  Editor_ViewModel.MainViewModel  5   
    � 	Resources 5         NavbarButtons �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6&   .�5      ��  � ��
	 ���� 6+   �� 5       � ��	 �#e9eecd6,   �� 5       � ��$		 1.5q�60   �� 5       � ��	 �#e9eecd6+   �� 5       � ��$	 15(�6)   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� $ Border��6!   $ 5��61   #��z��6B   #��z��6l   #��z��6�   ._�5      �� $��Center=�6/   $��Center=�6L   5       5       P� 5!       �@J�IsMouseOver$
 True��6=   . �5"   "   �� $ Border��6M    � ��
	 �   ��� 5#   "    �@J�Opacity$		 0.6Q�6<   �� 5$   "    � ��$	 2q�6D   5%      5'      5)      5*      5+      .��5-      � 
������ .+�5.   
   � 
�������$��5q�6"   � 5/   
   $��5q�6    � RowDefinitions 51      �� 52      $��40 �6    �� 53      $��* �6    �� 54      $��8* �6     � ColumnDefinitions 57      �� 58      $
��Auto �6#   �� 59      $��* �6#   �� 5:      $
��Auto �6#   ��5=      �� 5>       �� ImageSource$ Pictures/Background.jpg��6    �� Opacity$	 0.7Q�6C   .+�5B      �� -   5        $��3��5B      ���#e9eecd$��1q�6?   ��5D      �� 5E      $ Pictures/Background.jpg��6!    j� Stretch$ UniformToFill=�6G    j� TileMode$ FlipY=�6_   ._�5G      � $��Stretch=�6   .+�5H      �� $��Pictures/icon.jpg��6   $��50��67   $
��Left=�6B   �� 5O       �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $��Center=�6V   .+�5Q      �� -   5        $��25��5Q   !   $��25��6,   $��0,0,5,0q�68    � Cursor$
 Hand��5R   !   ���#e9eecd���#e9eecd
������ )  #Editor_ViewModel.Logic.PageNameEnum   InfoPage
 � Tag# Z 5W   !   .��5X      �� $��Pictures/zombie.png��6$    � ToolTip 5Z      _� 5[   "   $��Information��6*   5]      d� 5`      -   5         d�Name$ LanguageSelectionPopUp��5`   '   $��25��6G   $��25��6R   $��0,0,5,0q�6^   $
 Hand��6o   
������ ���#e9eecd.��5a      �� $��Pictures/language.png��6$    5c      _� 5d   "   $��Language Selection��6*   5f      � 5i      -   5         �Name$  OpenLanguageSelectionPopUp��5i        � 	StaysOpen$ False��6�   ��6D   �� *	IsChecked+ �� ElementName$ LanguageSelectionPopUp��.��5j      �� ��6+   �� *SupportedLanguages+��5k   "   �� 5l   &   .R�5m   *   �� $��5q�61   $
 Hand��5n   -   ���#e9eecd���#e9eecd
������ ��5r   -   �� *LanguageName+��6N   ��   �� Path$%  DataContext.SelectingNewLanguge�! �� RelativeSource! �� " �� AncestorType" ItemsControl��6�   �� 5s   '   5u      5v      �� 5z      -   5        $��25��5z   !   $��25��6,   $��0,0,5,0q�68   $
 Hand��5{      ���#e9eecd���#e9eecd
������ .��5�      �� $��Pictures/resize.png��6$    5�      _� 5�   "   $��Resize Window��6*   5�      �� 5�      $��25��6!   $��25��6,   $��0,0,5,0q�68   $��X��5�      $
 Hand��5�      ���#e9eecd���#e9eecd
������ ��5�      �� *ExitApplicationCommand+ 5�      _� 5�   "   $��Exit Application��6*   5�      5�      5�      5�      �� 5�      $��3��6   $ 
Horizontal=�6-   $��Center=�6F   $��Center=�6a   $��1��6~   $��50��6�   .+�5�      �� -   5        $	��100��5�   I   $
 Hand��6U   #   	SkillPage# Z# 6x   #��[  6�   ��6   �� *SelectedLanguage.SkillLabel+6�   �� 5�      -   5        $	��100��5�   N   $
 Hand��6Z   $   ExperiencePage# Z$ 6}   #��[  6�   ��6   �� *" SelectedLanguage.ExperienceLabel+6�   �� 5�      -   5        $	��100��5�   M   $
 Hand��6Y   %   InventoryPage# Z% 6|   #��[  6�   ��6   �� *!SelectedLanguage.InventoryLabel+6�   �� 5�      -	   5        $	��100��5�   L   $
 Hand��6X   &   BackpackPage# Z& 6{   #��[  6�   ��6   �� * SelectedLanguage.BackpackLabel+6�   �� 5�      -
   5        $	��100��5�   L   $
 Hand��6X   '   CampaignPage# Z' 6{   #��[  6�   ��6   �� * SelectedLanguage.CampaignLabel+6�   �� 5�      -   5        $	��100��5�   J   $
 Hand��6V   (   
PlayerPage# Z( 6y   #��[  6�   ��6   �� *SelectedLanguage.PlayerLabel+6�   �� 5�      -   5        $	��100��5�   F   $
 Hand��6R   )   IdOverviewPage# Z) 6u   #��[  6�   ��6   �� *SelectedLanguage.IdLabel+6�   5�      d� 5�      -   5        $ FileInformation��5�      $
 Hand��64   
������ 
������ $��1��6u   $��0��6�   $	��150��6�   ��5�      �� 5�      " d�6   .�5�      ��  � ��
	 ���� 67   �� 5�       � ��	 �#e9eecd68   �� 5�       � ��$		 1.5q�6<   �� 5�       � ��	 �#e9eecd67   �� 5�       � ��$	 15(�65   �� 5�       � ��	 5�      �� 5�   "   "
 d�62   .R�5�   &   �� $ Border��6-   $ 5��6=   #��z��6N   #��z��6x   #��z��6�   ._�5�   *   �� $��Center=�6;   $��Center=�6X   5�   '    5�   &   P� 5�   *    �@J�IsMouseOver$
 True��6I   . �5�   .   �� $ Border��6Y    � ��
	 �   ��� 5�   .    �@J�Opacity$		 0.6Q�6H   �� 5�   .    � ��$	 2q�6P   5�   +   5�   #   5�      5�      .��5�      �� .+�5�      �� $��Pictures/file.png��6   $��30��67   �� 5�      ���#e9eecd$
��Wrap=�6l   * �� TextAlignment$* Center=�6�   ��6    �� *'%SelectedLanguage.FileInformationLabel+6�   5�       5�      _� 5�      $��File information��6   5�      � 5�      -   5        $ FileInformationPopUp��5�      $ False��6l   ��62   �� *	IsChecked+$ FileInformation��+ � PlacementTarget+ 6~   �� $ FileInformation��.��5�      �� $
��Auto��6   .+�5�      �� ���#e9eecd$��5q�65   ��6@   �� *&$SelectedLanguage.FileInformationText+�� 5�      ���#e9eecd$��5q�65   ��5�      `� 5�      , �� StringFormat$, 	 {0}: {1}��6+   .1�5�   "   �� $   SelectedLanguage.FileLabel�6*   �� 5�   "   $  SaveFile.Path�6*   5�      5�      �� 5�      ���#e9eecd$��5q�65   ��5�      `� 5�      $, 	 {0}: {1}��6+   .1�5�   "   �� $   SelectedLanguage.SizeLabel�6*   �� 5�   "   $  SaveFile.FileData.Length�6*   5�      5�      � 5�       5�      �� 5�      $��* �6/   �� 5�      $��* �6/   .+�5�      �� -   5        $��0��5�   !   #��[  6F   $��	Open File��6m   $��5q�6�   $��5q�6�   $
 Hand��6�   $��Stretch=�6�   �� 5�      $��1��6!   #��[  6Z   $��Reset��6�   $��5q�6�   $��5q�6�   $
 Hand��6�   $��Stretch=�6�   ��61   �� *ResetCurrentSaveFile+6�   5�      5�      5�       � 5�      -   5        -  �Name$- pageContent��5�   5   $��2��6   $��3��6!   .  � NavigationUIVisibility$. Hidden=�6J   5�      5�      5�      