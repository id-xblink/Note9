   M S B A M L   `   `   `  ���� F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9      WpfAppNote9.ShowNoteW   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WpfAppNote9     S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#���     � Title$  Note9��$	��550��$	��800�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� .+��� $��UniformToFill=�  BackgroundImage#���  ��   MaterialDesignPaper#���  $��50q� �� CornerRadius$ 10�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 50Q�  	Accent100   Color# �     ShadowDepth$ 0Q�._�� $��20q� � RowDefinitions �� $��* ��� $
��auto �.+��  �� $
��auto ��� .+�� 	 � ColumnDefinitions	 �� $
��auto ��� �� $
��auto ��� $
��auto ��� $
��auto �.+�'  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$

 Note=�$��75��$��75��$��1q�#���   ����   
Primary400 �� Color# �  �� -    ��Name$ TBTitle��$��1��$
��Bold"�$��20(�$��Center=�$��CharacterEllipsis=�$
��10 0q��� -   $ TBDate��$��2��$��3��$+��%Создана 00-00-2019 в 18:10:12��$��13(�$	��Top=�  -     Name$ IAlarm��$��5q�$��2��$
 Alarm=�$��50��$��50�����#bd0000$��Bottom=�$��Right=�  -   $
 IMap��$��5q�$��3��$	
 Map=�$��50��$��50�����#bd0000$��Bottom=�$��Right=�  -   $ IHistory��$��5q�$��4��$
 History=�$��50��$��50�����#bd0000$��Bottom=�$��Right=�� $��1��.+��� $��1q�$��0 -1 0 0q�#���   �� -    ��Name$ TBText�� �� 
IsReadOnly . $��1��$��14(� * &MaterialDesignOutlinedTextFieldTextBox#��[ )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Текст�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�" �� VerticalScrollBarVisibility$
 Auto=�$��10q��� -    ��Name$
 Exit��$��0 10 0 0q�$��1��$
��Left=�$��Закрыть���� -	   $	 BGo��$��0 10 0 0q�$��1��$��Right=�$��Изменить��