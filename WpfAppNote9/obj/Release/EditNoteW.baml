   M S B A M L   `   `   `  ���� F  BWpfAppNote9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppNote9WpfAppNote9      WpfAppNote9.EditNoteW   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:WpfAppNote9     S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#���     � Title$  Note9��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=�.��� .+��� $��UniformToFill=�  BackgroundImage#���  ��   MaterialDesignPaper#���  $��50q� �� CornerRadius$ 10�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 50Q�  	Accent100   Color# �     ShadowDepth$ 0Q�._�� $��20q� � RowDefinitions �� $
��auto ��� $��* ��� $
��auto �.+��� -    ��Name$ 	TBHeading��$
��0 20q�$��24(�$
��Bold"�$)��#Добавление заметки��$��Center=�� $��1��	 � ColumnDefinitions	 �� �� $��75 �.+�� $��5 0 25 0q� �� $
��auto ��� .+��� -   
 ��Name$
 TBTitle��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Заголовок��$��16(� % !MaterialDesignFloatingHintTextBox#��[ $	��0 5q��� -   $
 TBText��$��1��$��14(� * &MaterialDesignOutlinedTextFieldTextBox#��[ $ 
Текст�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $ �� HorizontalScrollBarVisibility$ Disabled=�" �� VerticalScrollBarVisibility$
 Auto=�$��0 25 0 0q�� $��1�� �� �� �� .+��� -    ��Name$ BAlarm��$��0q�  MaterialDesignFlatButton#��[ $��55��$��55��$��10q����#bd0000.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Alarm=�$
��auto��$
��auto���� -   $
 BMap��$��1��$��0q�#��[ $��55��$��55��$��10q����#bd0000.��  $	 Map=�$
��auto��$
��auto���� -   $ BHistory��$��2��$��0q�#��[ $��55��$��55��$��10q�{�.  ���#bd0000.��  $ History=�$
��auto��$
��auto���� -   $ BExit��$��0 10 0 0q�$��2��$
��Left=�$��Отмена���� -	   $	 BGo��$��0 10 0 0q�$��2��$��Right=�$��Добавить��