   M S B A M L   `   `   `  ����F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9  5   	       WpfAppNote9.EditNoteW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppNote9     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	     � Title$  Note9��5
   	   $	��600��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�60   .��5      � .+�5   
   �� $��UniformToFill=�6     BackgroundImage#���  6(   �� 5   
     MaterialDesignPaper#���  6   $��50q�6D    �� CornerRadius$ 10��6P    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 50Q�6#     	Accent100   Color# �  63      ShadowDepth$ 0Q�6W   ._�5      � $��20q�6    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   �� 5      $
��auto �6$   .+�5      �� -   5         ��Name$ 	TBHeading��5      $
��0 20q�6/   $��24(�6=   $
��Bold"�6K   $)��#Добавление заметки��6]   $��Center=�6w   � 5      $��1��6   	 � ColumnDefinitions	 5      �� 5      �� 5      $��75 �6+   .+�5"      � $��5 0 25 0q�6    5#      �� 5$      $
��auto �6,   �� 5%      .+�5(      �� -   5        
 ��Name$
 TBTitle��5(   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Заголовок��63   $��16(�6^    % !MaterialDesignFloatingHintTextBox#��[ 6l   $	��0 5q�6�   6�   �� 5)      -   5        $
 TBText��5)   "   $��1��62   $��14(�6?    * &MaterialDesignOutlinedTextFieldTextBox#��[ 6M   $ 
Текст��6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6  $��0 25 0 0q�6)  6;  5*      � 5,      $��1��6    5-      �� 5.      �� 5/      �� 50      .+�53      �� -   5         ��Name$ BAlarm��53   !   $��0q�61     MaterialDesignFlatButton#��[ 6=   $��55��6o   $��55��6z   $��10q�6�   ���#bd0000.��54      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Alarm=�66   $
��auto��6C   $
��auto��6P   55      �� 57      -   5        $
 BMap��57   !   $��1��6/   $��0q�6<   #��[ 6H   $��55��6z   $��55��6�   $��10q�6�   ���#bd0000.��58        $	 Map=�66   $
��auto��6A   $
��auto��6N   59      �� 5;      -   5        $ BHistory��5;   !   $��2��63   $��0q�6@   #��[ 6L   $��55��6~   $��55��6�   $��10q�6�   {�.  ���#bd0000.��5<        $ History=�66   $
��auto��6E   $
��auto��6R   5=      5>      5?      �� 5A      -   5        $ BExit��5A   8   $��0 10 0 0q�6   $��2��6+   $
��Left=�6G   $��Отмена��6b   6s   �� 5B      -	   5        $	 BGo��5B   8   $��0 10 0 0q�6   $��2��6+   $��Right=�6E   $��Добавить��6a   6t   5C      5D      5E      5F      