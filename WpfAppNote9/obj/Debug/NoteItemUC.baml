   M S B A M L   `   `   `  ����F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9  5          WpfAppNote9.NoteItemUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WpfAppNote9     5      S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � -   5          �Name$  MainGrid��5
       � ColumnDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   � $��5q�6    � RowDefinitions 5      �� 5      �� 5       5      �� 5      �� 5      $
��auto �6#   .+�5      �� -   5         ��Name$ TBTitle��5      $
��Bold"�6)   $��22(�6;   $��Center=�6I   $��CharacterEllipsis=�6d   �� 5      -   5        $ TBDate��5      $��1��6(   $)��#Создана: 00-00-2019 18:10:12��68   $��16(�6\   $	��Top=�6j   �� 5      -   5        $ TBText��5      $��14(�6(   $��1��66   $��2��6C   $��Bottom=�6W   $
��Left=�6r   $
��Wrap=�6�   $��CharacterEllipsis=�6�   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6%   $��15q�6>   .+�5      �� -   5         ��Name$ BShow��5      $��0q�6$      MaterialDesignFlatButton#��[  60   .��5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Eye=�6*   $
��auto��65   $
��auto��6B   ���#00bd326P   5!      �� 5"      -   5        $ BEdit��5"      $
��15 0q�6$   $��0q�62   #��[  6>   .��5#        $
 Edit=�6*   $
��auto��66   $
��auto��6C   5$      �� 5%      -   5        $ BErase��5%      $��0q�6%   #��[  61   .��5&        $ Eraser=�6*   $
��auto��68   $
��auto��6E   ���#bd00006S   5'      5(      �� 5*   
   $��2��6   $��2��6%   $��2��69   $��Bottom=�6D   ��5+      �� 5,        
Primary400 �� Color# �  6"   5.      5/      50      