   M S B A M L   `   `   `  ����F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9  5   	       WpfAppNote9.ChangeFieldW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppNote9     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	     � Title$  Note9��5
   	   $	��190��6   $	��400��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6l   .��5      �   MaterialDesignPaper#���  6   .+�5   
   � $��20q�6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� .+�5      �� -   5         ��Name$ 
TBlockHint��5      $��16(�60   �� 5      -   5         ��Name$ TBText��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6*   $��14(�6Q    % !MaterialDesignFloatingHintTextBox#��[ 6_   $	��0 5q�6�   $y�	Collapsed=�6�   6�   G� 5      -   5         G�Name$ PBPass��5      $ Пароль��6.   $��14(�6V    ) %MaterialDesignFloatingHintPasswordBox#��[ 6d   $	��0 5q�6�   $y�	Collapsed=�6�   6�   �� 5      -   5         ��Name$ SPSNL��5      	 �� Orientation$	 
Horizontal=�6,   $
��0 25q�6E   $��Center=�6S   $y�	Collapsed=�6p   .+�5      	� -   5        
 	�Name$
 	RBSurname��5   "    	� 	GroupName$ RBSNL��65   $��Фамилию��6G   $��14(�6Y   $��Bottom=�6g   $��Bottom=�6�   6�   	� 5      -   5        $
 RBName��5   "   $ RBSNL��62   $��Имя��6D   $��14(�6R   $��Bottom=�6`   $��Bottom=�6{   $
��40 0q�6�   6�   	� 5      -   5        $
 
RBLastname��5   "   $ RBSNL��66   $��Отчество��6H   $��14(�6[   $��Bottom=�6i   $��Bottom=�6�   6�   5      (  "System.Windows.Controls.DatePicker  5      -	   5          Name$ DPBirth��5      $ Дата рождения��6.   $��14(�6]    ( $MaterialDesignFloatingHintDatePicker#��[ 6k   $
��0 10q�6�   $y�	Collapsed=�6�   5      �� 5      -
   5         ��Name$
 Exit��5   "   $��1��6   $
��Left=�60   $��Отмена��6K   6\   �� 5      -   5        $ BChange��5   "   $��1��6   $��Right=�63   $��Изменить��6O   6b   5      5       5!      