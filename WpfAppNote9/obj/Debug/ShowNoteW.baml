   M S B A M L   `   `   `  ����F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9  5   	       WpfAppNote9.ShowNoteW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppNote9     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	     � Title$  Note9��5
   	   $	��550��6   $	��800��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F   .��5      � .+�5   
   �� $��UniformToFill=�6     BackgroundImage#���  6(   �� 5   
     MaterialDesignPaper#���  6   $��50q�6D    �� CornerRadius$ 10��6P    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 50Q�6#     	Accent100   Color# �  63      ShadowDepth$ 0Q�6W   ._�5      � $��20q�6    � RowDefinitions 5      �� 5      $��* �6$   �� 5      $
��auto �6$   .+�5      �  5      �� 5      $
��auto �6(   �� 5      .+�5      � 	 � ColumnDefinitions	 5       �� 5!      $
��auto �6/   �� 5"      �� 5#      $
��auto �6/   �� 5$      $
��auto �6/   �� 5%      $
��auto �6/   .+�5*      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$

 Note=�62   $��75��6>   $��75��6I   $��1q�6U   #���   6i   ��5+      �� 5,   "     
Primary400 �� Color# �  62   5.      �� 50      -   5         ��Name$ TBTitle��50   4   $��1��6$   $
��Bold"�6E   $��20(�6W   $��Center=�6e   $��CharacterEllipsis=�6�   $
��10 0q�6�   �� 52      -   5        $ TBDate��52   H   $��2��6$   $��3��64   $+��%Создана 00-00-2019 в 18:10:12��6X   $��13(�6}   $	��Top=�6�     54      -   5          Name$ IAlarm��54   =   $��5q�62   $��2��6M   $
 Alarm=�6]   $��50��6j   $��50��6u   ���#bd0000$��Bottom=�6�   $��Right=�6�     55      -   5        $
 IMap��55   =   $��5q�62   $��3��6K   $	
 Map=�6[   $��50��6f   $��50��6q   ���#bd0000$��Bottom=�6�   $��Right=�6�     56      -   5        $ IHistory��56   =   $��5q�62   $��4��6O   $
 History=�6_   $��50��6n   $��50��6y   ���#bd0000$��Bottom=�6�   $��Right=�6�   57      � 59      $��1��6   .+�5:      �� $��1q�6!   $��0 -1 0 0q�65   #���   6G   �� 5;      -   5         ��Name$ TBText��5;   4    �� 
IsReadOnly . $��1��6D   $��14(�6Q    * &MaterialDesignOutlinedTextFieldTextBox#��[ 6_   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Текст��6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6  $��10q�6;  5<      5=      �� 5?      -   5         ��Name$
 Exit��5?   8   $��0 10 0 0q�6   $��1��6+   $
��Left=�6F   $��Закрыть��6a   6s   �� 5@      -	   5        $	 BGo��5@   8   $��0 10 0 0q�6   $��1��6+   $��Right=�6E   $��Изменить��6a   6t   5A      5B      5C      5D      