   M S B A M L   `   `   `  ���� F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9      WpfAppNote9.HelpHistoryW   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WpfAppNote9     S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#���     � Title$  Note9��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=�.��� .+��   MaterialDesignPaper#���  $��1�� � RowDefinitions �� �� $��67 �.+��� $
��Auto=�.��� -    �Name$ GList�� �� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 ��� $��70 �� $��5�� � ColumnDefinitions �� $
��auto ��� �� $
��auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$��Center=�$��15q�$��Center=�.+��� -    ��Name$ BLeave��$
��15 0q�$��0q�.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=�$
��auto��$
��auto���� $��1��$��2q�$��38��$��12q�����   
Primary400 �� Color# �  ._�� $��2q� �� $
��auto ��� �� $
��auto �.+�  $ Magnify=�$��Center=�$
��auto��$
��auto���� -   	 ��Name$	 TBFind��$��1��)  #MaterialDesignThemes.Wpf.HintAssist
   Hint$(
 "Поиск по заголовку��$��14(�$
��10 0q��� -   $ 
BClearFind��$��2��$
��auto��$��0q�$
��auto��  MaterialDesignFlatButton#��[ $��Right=�.��  $ Clear=�$
��auto��$
��auto���� $��2��$ 
Horizontal=�$��Center=�$��15q�$��Center=�.+��� -   $ BStart��
 � Tag$ Start��$��<<���� -   $ 	BPrevious��$ Previous��$��<��$
��15 0q��� -    ��Name$ TBPage��$��0 из 0��$��14(�$��Center=��� -	   $ BNext��$
 Next��$��>��$
��15 0q��� -
   $
 BEnd��$	 End��$��>>���� -   $ BRefresh��$ Refresh��$��15 0 0 0q�$��0q�.��  $ Refresh=�$
��auto��$
��auto��