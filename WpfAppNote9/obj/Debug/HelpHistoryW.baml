   M S B A M L   `   `   `  ����F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9  5   	       WpfAppNote9.HelpHistoryW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppNote9     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	     � Title$  Note9��5
   	   $	��450��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�60   .��5      � .+�5   
   �   MaterialDesignPaper#���  6   $��1��6B    � RowDefinitions 5      �� 5      �� 5      $��67 �6    .+�5      �� $
��Auto=�6   .��5      � -   5         �Name$ GList��5       5      �� 5      $��70 �6(   �� 5      $��70 �6(   �� 5      $��70 �6(   �� 5      $��70 �6(   �� 5      $��70 �6(   �� 5      $��70 �6(   �� 5      $��70 �6(   �� 5      $��70 �6(   �� 5      $��70 �6(   �� 5      $��70 �6(   �� 5!      $��70 �6(   �� 5"      $��70 �6(   �� 5#      $��70 �6(   �� 5$      $��70 �6(   �� 5%      $��70 �6(   5'      5(      � 5+      $��5��6    � ColumnDefinitions 5,      �� 5-      $
��auto �6'   �� 5.      �� 5/      $
��auto �6'   .+�52      �� $��0��6    �� Orientation$ 
Horizontal=�6-   $��Center=�6F   $��15q�6a   $��Center=�6m   .+�53      �� -   5         ��Name$ BLeave��53      $
��15 0q�6-   $��0q�6P   .��54      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=�62   $
��auto��6C   $
��auto��6P   55      56      �� 58      $��1��6   $��2q�6)   $��38��6=   $��12q�6I   ��59      �� 5:        
Primary400 �� Color# �  6*   ._�5<      � $��2q�6    5=      �� 5>      $
��auto �6/   �� 5?      �� 5@      $
��auto �6/   .+�5B        $ Magnify=�62   $��Center=�6A   $
��auto��6\   $
��auto��6i   �� 5C      -   5        	 ��Name$	 TBFind��5C   2   $��1��6"   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$(
 "Поиск по заголовку��6B   $��14(�6v   $
��10 0q�6�   6�   �� 5D      -   5        $ 
BClearFind��5D   !   $��2��65   $
��auto��6E   $��0q�6R   $
��auto��6^     MaterialDesignFlatButton#��[ 6l   $��Right=�6�   .��5E        $ Clear=�66   $
��auto��6C   $
��auto��6P   5F      5G      5H      �� 5J      $��2��6   $ 
Horizontal=�6-   $��Center=�6F   $��15q�6a   $��Center=�6m   .+�5K      �� -   5        $ BStart��5K      
 � Tag$ Start��6-   $��<<��69   6L   �� 5L      -   5        $ 	BPrevious��5L      $ Previous��60   $��<��6?   $
��15 0q�6N   6\   �� 5M      -   5         ��Name$ TBPage��5M       $��0 из 0��60   $��14(�6>   $��Center=�6L   �� 5N      -	   5        $ BNext��5N      $
 Next��6,   $��>��67   $
��15 0q�6F   6T   �� 5O      -
   5        $
 BEnd��5O      $	 End��6+   $��>>��65   6H   �� 5P      -   5        $ BRefresh��5P      $ Refresh��6/   $��15 0 0 0q�6=   $��0q�6f   .��5Q        $ Refresh=�62   $
��auto��6A   $
��auto��6N   5R      5S      5T      5U      5V      5W      