   M S B A M L   `   `   `  ���� F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9      WpfAppNote9.ChangeFieldW   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WpfAppNote9     S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#���     � Title$  Note9��$	��190��$	��400�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.���   MaterialDesignPaper#���  .+�� $��20q� � RowDefinitions �� $��* ��� $
��auto �.+��� .+��� -    ��Name$ 
TBlockHint��$��16(��� -    ��Name$ TBText��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��$��14(� % !MaterialDesignFloatingHintTextBox#��[ $	��0 5q�$y�	Collapsed=�G� -    G�Name$ PBPass��$ Пароль��$��14(� ) %MaterialDesignFloatingHintPasswordBox#��[ $	��0 5q�$y�	Collapsed=��� -    ��Name$ SPSNL��	 �� Orientation$	 
Horizontal=�$
��0 25q�$��Center=�$y�	Collapsed=�.+�	� -   
 	�Name$
 	RBSurname�� 	� 	GroupName$ RBSNL��$��Фамилию��$��14(�$��Bottom=�$��Bottom=�	� -   $
 RBName��$ RBSNL��$��Имя��$��14(�$��Bottom=�$��Bottom=�$
��40 0q�	� -   $
 
RBLastname��$ RBSNL��$��Отчество��$��14(�$��Bottom=�$��Bottom=�(  "System.Windows.Controls.DatePicker  -	     Name$ DPBirth��$ Дата рождения��$��14(� ( $MaterialDesignFloatingHintDatePicker#��[ $
��0 10q�$y�	Collapsed=��� -
    ��Name$
 Exit��$��1��$
��Left=�$��Отмена���� -   $ BChange��$��1��$��Right=�$��Изменить��