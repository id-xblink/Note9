   M S B A M L   `   `   `  ���� F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9      WpfAppNote9.DashboardW   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WpfAppNote9     S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#���     � Title$  Note9��$	��600��$	��600��$	��900��$	��900�� � WindowStartupLocation$ CenterScreen=�.���   MaterialDesignPaper#���   � RowDefinitions �� $��50 ���  � ColumnDefinitions �� $	��250 ��� .+��� $��UniformToFill=�  BackgroundImage#���  $��2��$��2�� J� Opacity$
 0.25Q�� $��2��.+��� $��2��$��Right=�����   
Primary400 �� Color# �  �� .+��� -    ��Name$ SPCheck��.+��  �� $
��auto ��� .+��� -    ��Name$ IAvatar��$��10q�$��75��$��75��$��Center=�$��Center=��� $��1��$��Note9��$
��Bold"�$��Center=�$��Center=�$��25(��� $��2��$	��Top=����� # �  � $��0 10 0 0q�.+�?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -     Name$ TransitioningContentSlide��C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase	   OpeningEffect	 D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+
   Duration$
 0:0:0.2X�.��� -    �Name$ GCursor��$��10��$
��Left=�$��60��$	��Top=�����   	Accent400# �  �� -    ��Name$ LVMenu��$��17(�.@��� $��60��.����  �� Orientation$ 
Horizontal=�$��5 0 0 0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Note=�$��25��$��25��$��Center=�$��5q��� $��Заметки��$��Center=�$
��20 0q��� $��60��.���� $ 
Horizontal=�$��5 0 0 0q�.+�  $	 Map=�$��25��$��25��$��Center=�$��5q��� $��
Карта��$��Center=�$
��20 0q��� $��60��.���� $ 
Horizontal=�$��5 0 0 0q�.+�  $ Person=�$��25��$��25��$��Center=�$��5q��� $��Профиль��$��Center=�$
��20 0q��� $��60��.���� $ 
Horizontal=�$��5 0 0 0q�.+�  $ 
PowerSleep=�$��25��$��25��$��Center=�$��5q��� $��Фоновый режим��$��Center=�$
��20 0q��� $��60��.���� $ 
Horizontal=�$��5 0 0 0q�.+�  $ 	ExitToApp=�$��25��$��25��$��Center=�$��5q��� $��
Выйти��$��Center=�$
��20 0q��� $��60��.���� $ 
Horizontal=�$��5 0 0 0q�.+�  $ Power=�$��25��$��25��$��Center=�$��5q��� $��Выключить��$��Center=�$
��20 0q�� $��1��.+��� $ 
Horizontal=�$��Center=�.+��� $��Note9��$��Center=�$��20(�
�������$
��20 0q��� $��2��$��Bottom=����� # �  � -   $ GMainContent��$��1��$��1��