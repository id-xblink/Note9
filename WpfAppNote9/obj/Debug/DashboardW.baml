   M S B A M L   `   `   `  ����F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9  5   	       WpfAppNote9.DashboardW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppNote9     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	     � Title$  Note9��5
   	   $	��600��6   $	��600��6'   $	��900��64   $	��900��6C    � WindowStartupLocation$ CenterScreen=�6O   .��5      �   MaterialDesignPaper#���  6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      .+�5   
   �� $��UniformToFill=�6     BackgroundImage#���  6(   $��2��6S   $��2��6d    J� Opacity$
 0.25Q�6x   � 5   
   $��2��6   .+�5      �� $��2��6   $��Right=�6"   ��5      �� 5        
Primary400 �� Color# �  6&   5      �� 5      .+�5      �� -   5         ��Name$ SPCheck��5      .+�5      �  5      �� 5       $
��auto �6/   �� 5!      .+�5#      �� -   5         ��Name$ IAvatar��5#       $��10q�61   $��75��6=   $��75��6H   $��Center=�6T   $��Center=�6q   6�   �� 5$      $��1��6$   $��Note9��64   $
��Bold"�6A   $��Center=�6S   $��Center=�6n   $��25(�6�   5%      �� 5&      $��2��6    $	��Top=�6+   ��5'      �� 5(      # �  6.   5*      5+      � 5,      $��0 10 0 0q�6   .+�5-      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TransitioningContentSlide��5-   :   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase	   OpeningEffect	 6]   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+
   Duration$
 0:0:0.2X�.��5.      � -   5         �Name$ GCursor��5.      $��10��60   $
��Left=�6;   $��60��6V   $	��Top=�6b   ��5/      �� 50   "     	Accent400# �  62   52      53      �� 54      -   5         ��Name$ LVMenu��54      $��17(�6Z   .@�55      �� $��60��6'   .��56      ��  �� Orientation$ 
Horizontal=�6)   $��5 0 0 0q�6B   .+�57   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Note=�6:   $��25��6F   $��25��6Q   $��Center=�6]   $��5q�6x   �� 58   "   $��Заметки��6,   $��Center=�6;   $
��20 0q�6V   59      5:      �� 5;      $��60��6'   .��5<      �� $ 
Horizontal=�6)   $��5 0 0 0q�6B   .+�5=   "     $	 Map=�6:   $��25��6E   $��25��6P   $��Center=�6\   $��5q�6w   �� 5>   "   $��
Карта��6,   $��Center=�69   $
��20 0q�6T   5?      5@      �� 5A      $��60��6'   .��5B      �� $ 
Horizontal=�6)   $��5 0 0 0q�6B   .+�5C   "     $ Person=�6:   $��25��6H   $��25��6S   $��Center=�6_   $��5q�6z   �� 5D   "   $��Профиль��6,   $��Center=�6;   $
��20 0q�6V   5E      5F      �� 5G      $��60��6'   .��5H      �� $ 
Horizontal=�6)   $��5 0 0 0q�6B   .+�5I   "     $ 
PowerSleep=�6:   $��25��6L   $��25��6W   $��Center=�6c   $��5q�6~   �� 5J   "   $��Фоновый режим��6,   $��Center=�6A   $
��20 0q�6\   5K      5L      �� 5M      $��60��6'   .��5N      �� $ 
Horizontal=�6)   $��5 0 0 0q�6B   .+�5O   "     $ 	ExitToApp=�6:   $��25��6K   $��25��6V   $��Center=�6b   $��5q�6}   �� 5P   "   $��
Выйти��6,   $��Center=�69   $
��20 0q�6T   5Q      5R      �� 5S      $��60��6'   .��5T      �� $ 
Horizontal=�6)   $��5 0 0 0q�6B   .+�5U   "     $ Power=�6:   $��25��6G   $��25��6R   $��Center=�6^   $��5q�6y   �� 5V   "   $��Выключить��6,   $��Center=�6=   $
��20 0q�6X   5W      5X      5Y      5Z      5[      5\      � 5^   
   $��1��6   .+�5_      �� $ 
Horizontal=�6   $��Center=�62   .+�5`      �� $��Note9��6   $��Center=�6)   $��20(�6D   
�������$
��20 0q�6d   5a      �� 5b      $��2��6   $��Bottom=�6#   ��5c      �� 5d      # �  6&   5f      5g      � 5i   
   -   5        $ GMainContent��5i   ,   $��1��6   $��1��6   5k      5l      5m      