   M S B A M L   `   `   `  ����F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9  5   	       WpfAppNote9.ProfileW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppNote9     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	     � Title$  Note9��5
   	   $	��680��6   $	��560��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F   .��5      � .+�5   
   ��   BackgroundImage#���  6   $��UniformToFill=�6;   �� 5   
     MaterialDesignPaper#���  6    �� CornerRadius$ 15��6D   $	��360��6V   $	��480��6b   $	��480��6o   $	��360��6    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 50Q�6#     	Accent100   Color# �  63      ShadowDepth$ 0Q�6W   ._�5      � $��20q�6    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   �� 5      $
��auto �6$   .+�5      �� $
��0 20q�6   $��24(�6*   $
��Bold"�68   $!��Личный кабинет��6J   $��Center=�6`   �� 5      $	��Top=�6   $��Stretch=�65   $��1��6S   .+�5      � $��20q�6   	 � ColumnDefinitions	 5      �� 5      $
��auto �6/   �� 5       $��* �6/   .+�5"      �� -   5        
 ��Name$
 BAvatar��5"   !   $��0��62   $	��100��6B   $	��100��6N   $
��Left=�6[   $ 50��6v   ���#ffc107$��2q�6�   ��5#      �� 5$   "     	Accent400 �� Color# �  62   ._�5&      �� $ 50��6%   ��5'   "   �� 5(   &   -   5        IBAvatar�� j� Stretch$ UniformToFill=�5(   C   5*      5+      �� 5-      $��1��6%   $��Center=�65    �� Orientation$ 
Horizontal=�6P   $��Center=�6i   .+�5.      �� $��20(�6(   $��	Тема:��66   $��Center=�6C   �� 5/      $��15 5 0 5q�6)   .+�50   "   	� -   5         	�Name$ RBLight��50   :   
 � Tag$ Light��6.   $��14(�6K    	� 	GroupName$ Theme��6Y   $��Светлая��6k   $��Bottom=�6}   $��Bottom=�6�   $��0 0 0 5q�6�   	� 51   "   -   5        $ RBDark��51   9   $
 Dark��6.   $��14(�6I   $ Theme��6W   $��Тёмная��6i   $��Bottom=�6z   $��Bottom=�6�   52      53      54      �� 56      $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   $
��0 10q�6r   .+�57      �� -   5         ��Name$ 	TBSurname��57   .   $	 SNL��6$   $��19(�6A   $��Center=�6O   $��CharacterEllipsis=�6�   �� 58      -   5        $ TBName��58   .   $	 SNL��6$   $��19(�6>   $��Center=�6L   $	��7 0q�6�   $��CharacterEllipsis=�6�   �� 59      -   5        $ 
TBLastname��59   .   $	 SNL��6$   $��19(�6B   $��Center=�6P   $��CharacterEllipsis=�6�   �� 5:      -	   5        $ 	TBWarning��5:   .   $	 SNL��6$   $��19(�6A   $ ��ФИО не указано��6O   
�������$��Center=�6w   $y�	Collapsed=�6�   5;      �� 5=      $ 
Horizontal=�6!   $��Center=�6:   .+�5>      �� $��18(�6$   $'��!Дата регистрации: ��62   $��Center=�6L   �� 5?      -
   5        $ TBDateRegValue��5?   ?   $��Bottom=�6$   $��17(�6W   5@      �� 5A      $ 
Horizontal=�6!   $��Center=�6:   $	��0 5q�6U   .+�5B      �� -   5        $ TBDateBirthText��5B   4   $ 	DateBirth��6$   $��18(�6M   $!��Дата рождения: ��6[   $��Center=�6r   6�   �� 5C      -   5        $ TBDateBirthValue��5C   4   $ 	DateBirth��6$   $��Bottom=�6N   $��17(�6i   6w   �� 5D      -   5        $ TBBirthWarning��5D   4   $ 	DateBirth��6$   $��18(�6L   $"��Дата не указана��6Z   
�������$��Center=�6�   $y�	Collapsed=�6�   5E      �� 5F      $ 
Horizontal=�6!   $��Center=�6:   .+�5G      �� -   5        $ TBLoginText��5G   0   $ Login��6$   $��18(�6E   $��Логин: ��6S   $��Center=�6b   6}   �� 5H      -   5        $ TBLoginValue��5H   0   $ Login��6$   $��18(�6F   $��Center=�6T   $��CharacterEllipsis=�6�   5I      �� 5J      $	��0 5q�6!   .+�5K      � 	 5L      �� 5M   "   $
��auto �63   �� 5N   "   $��* �63   �� 5O   "   $
��auto �63   .+�5R      �� -   5        $ 
TBPassText��5R   C   $��0��6(   $
 Pass��68   $��18(�6W   $��Пароль: ��6e   $��Center=�6u   6�   �� 5T      -   5        $ TBPassValue��5T   ^   $
��Left=�6(   $��1��6C   $
 Pass��6S   $��18(�6s   $��Center=�6�   $��CharacterEllipsis=�6�   �� 5V      -   5         ��Name$ 	BViewPass��5V   5   $��2��6%     MaterialDesignFlatButton#��[ 6H   #���   6z   $��0q�6�   $��1q�6�   $��10 0 0 0q�6�   $��20��6�   $��20��6�   .��5W   "   '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ PIIcon��5W   :      Kind$ EyeOff=�6J   $
��auto��6X   $
��auto��6e   5X      5Y      5Z      5[      � 5]      $��2��6   $
��0 10q�6$   .+�5^      �� -   5        $ BBack��5^      $
 Exit��6,   $
��Left=�67   $��
Назад��6R   6b   �� 5_      -   5        $ BChange��5_      $
 Save��6.   $��Right=�69   $��Изменить��6U   6h   5`      5a      5b      5c      5d      