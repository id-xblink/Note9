   M S B A M L   `   `   `  ���� F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9      WpfAppNote9.ProfileW   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WpfAppNote9     S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#���     � Title$  Note9��$	��680��$	��560�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� .+���   BackgroundImage#���  $��UniformToFill=���   MaterialDesignPaper#���   �� CornerRadius$ 15��$	��360��$	��480��$	��480��$	��360�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 50Q�  	Accent100   Color# �     ShadowDepth$ 0Q�._�� $��20q� � RowDefinitions �� $
��auto ��� $��* ��� $
��auto �.+��� $
��0 20q�$��24(�$
��Bold"�$!��Личный кабинет��$��Center=��� $	��Top=�$��Stretch=�$��1��.+�� $��20q�	 � ColumnDefinitions	 �� $
��auto ��� $��* �.+��� -   
 ��Name$
 BAvatar��$��0��$	��100��$	��100��$
��Left=�$ 50�����#ffc107$��2q�����   	Accent400 �� Color# �  ._��� $ 50������ -   IBAvatar�� j� Stretch$ UniformToFill=��� $��1��$��Center=� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��20(�$��	Тема:��$��Center=��� $��15 5 0 5q�.+�	� -    	�Name$ RBLight��
 � Tag$ Light��$��14(� 	� 	GroupName$ Theme��$��Светлая��$��Bottom=�$��Bottom=�$��0 0 0 5q�	� -   $ RBDark��$
 Dark��$��14(�$ Theme��$��Тёмная��$��Bottom=�$��Bottom=��� $ 
Horizontal=�$��Center=�$��Center=�$
��0 10q�.+��� -    ��Name$ 	TBSurname��$	 SNL��$��19(�$��Center=�$��CharacterEllipsis=��� -   $ TBName��$	 SNL��$��19(�$��Center=�$	��7 0q�$��CharacterEllipsis=��� -   $ 
TBLastname��$	 SNL��$��19(�$��Center=�$��CharacterEllipsis=��� -	   $ 	TBWarning��$	 SNL��$��19(�$ ��ФИО не указано��
�������$��Center=�$y�	Collapsed=��� $ 
Horizontal=�$��Center=�.+��� $��18(�$'��!Дата регистрации: ��$��Center=��� -
   $ TBDateRegValue��$��Bottom=�$��17(��� $ 
Horizontal=�$��Center=�$	��0 5q�.+��� -   $ TBDateBirthText��$ 	DateBirth��$��18(�$!��Дата рождения: ��$��Center=��� -   $ TBDateBirthValue��$ 	DateBirth��$��Bottom=�$��17(��� -   $ TBBirthWarning��$ 	DateBirth��$��18(�$"��Дата не указана��
�������$��Center=�$y�	Collapsed=��� $ 
Horizontal=�$��Center=�.+��� -   $ TBLoginText��$ Login��$��18(�$��Логин: ��$��Center=��� -   $ TBLoginValue��$ Login��$��18(�$��Center=�$��CharacterEllipsis=��� $	��0 5q�.+�� 	 �� $
��auto ��� $��* ��� $
��auto �.+��� -   $ 
TBPassText��$��0��$
 Pass��$��18(�$��Пароль: ��$��Center=��� -   $ TBPassValue��$
��Left=�$��1��$
 Pass��$��18(�$��Center=�$��CharacterEllipsis=��� -    ��Name$ 	BViewPass��$��2��  MaterialDesignFlatButton#��[ #���   $��0q�$��1q�$��10 0 0 0q�$��20��$��20��.��'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ PIIcon��   Kind$ EyeOff=�$
��auto��$
��auto��� $��2��$
��0 10q�.+��� -   $ BBack��$
 Exit��$
��Left=�$��
Назад���� -   $ BChange��$
 Save��$��Right=�$��Изменить��