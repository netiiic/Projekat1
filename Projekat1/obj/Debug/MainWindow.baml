   M S B A M L   `   `   `  ����D  @Projekat1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Projekat1	Projekat1  5   	       Projekat1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Projekat1     5   	   -   5          � Title$  Piano��5   	    � WindowStyle$
 None=�6H    � AllowsTransparency . 
������ $	��750��5	   "   $	��800��6/   .��5      �� $	��800��6   $	��600��6   .+�5   
   F� -   5        $��UIPath��5   2   
���   �$��2��6   ��5      �� 5       �� ImageSource$; 5https://wallpaperplay.com/walls/full/9/a/b/200764.jpg��6   ��5      B� 5      .��5      E�  E� 
StartPoint$ 40,20&�6!   .��5      ��  �� Point$ 40,520&�6&   �� 5      $ 80,520&�6&   �� 5      $ 80,580&�6&   �� 5      $ 700,580&�6&   �� 5      $ 700,520&�6&   �� 5      $ 720,520&�6&   �� 5      $ 740,520&�6&   �� 5      $ 740,400&�6&   � 5       � Point1$ 730,250&�61    � Point2$ 570,250&�6B   � 5      $ 455,250&�61   $ 350,120&�6B   � 5      $ 230,0&�61   $ 40,20&�6@   5       5!      5#      � 5%   
    � ColumnDefinitions 5&      �� 5'      $��* �6#   .+�5*      �� -   5        	 ��Name$	 Naslov��5*      $��Piano��6$   $��Italic$�64   ���	#FFCD3D8F$��35(�6^   $��Microsoft JhengHei)�6l   $��
115,90,0,0q�6�   �� 5+      -   5        $	 Naslov1��5+      $��manufactures��6%   $��Italic$�6<   ���	#FFCD3D8F$��35(�6f   $��Microsoft JhengHei)�6t   $��
70,125,0,0q�6�   &   System.Windows.Controls.DataGrid  5-      -   5        
  Name$
 
tablePiano��5-      $��0q�6I   $��Center=�6]   $	��240��6z   $	��Top=�6�      AutoGenerateColumns .     SelectionMode$ Single=�6�      
IsReadOnly . $	��600��6�   $��
50,270,0,0q�6�    J� RenderTransformOrigin$ 0.674,0.484&�6  ���#970670��6+   �� *Piano+��6(  Z�  � 	Resources 51      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn   WrapText��%s  '        '  �     7 &	  �     �� 52      "  6    53      P� 54       �@ 
IsSelected . . �55   "   ��  � �� 6?   Z� 56      58      �� 5:      8   "  6U   .�5;      ��  � �� �#ECB8DE67   5=      �� 5?      " ��6   .�5@      ��  � ��$
 Wrap=�69   �� 5A       � ��$ Center=�6>   �� 5B       � ��$ Center=�6@   �� 5C       � ��$ 12(�65   �� 5D       �@��TextAlignment$ Center=�6:   �� 5E       � ��$ Goudy Old Style)�67   �� 5F       � ��$ 3,1,3,1q�63   �� 5G       � ��$ DemiBold"�67   5H      5I         Columns 5K      4  .System.Windows.Controls.DataGridTemplateColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$
 Logo��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6;      
IsReadOnly .    CellTemplate 5M      �� 5N      .R�5O   "   �� $��50��6A   $��50��6M   $��0,5,0,5q�6X   $��Uniform=�6i   $��Center=�6{   $��Center=�6�   ��6)   �� *Logo+6�   5P      5R      0  *System.Windows.Controls.DataGridTextColumn  5S      $
 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  6P   $ * 6y      
Foreground �	#FFCD3D8F   Binding 67   �� *Name+6�     5T      $ Production(yearly)��6)   # [  6d   $ * 6�    �	#FFCD3D8F 6E   �� *
Production+6�     5U      $ Founded��6)   # [  6u   $ * 6�    �	#FFCD3D8F 6:   �� *	Founded+ �� StringFormat$ {0:dd.MM.yyyy}��6�     5V      $  ��6-   $ * 68    5W      �� 5X      .R�5Y   "   �� $��Center=�6.   $��Center=�6K   .+�5Z   &   ��   ��Name$  button_procitaj��6-   -   5        $
��Read��5Z   F   $��55��6U   $��17��6`   $��Goudy Old Style)�6l   $
��Bold"�6�   ���	#FFCD3D8F$��14(�6�   $��0,2,0,2q�6�   6�   �� 5[   &   $  button_izmeni��6-   -   5        $��Change��5[   D   $��55��6U   $��17��6`   $��Goudy Old Style)�6m   $
��Bold"�6�   ���	#FFCD3D8F$��14(�6�   $��0,2,0,2q�6�   6�   �� 5\   &   $  button_obrisi��6-   -   5        $��Delete��5\   D   $��55��6U   $��17��6`   $��Goudy Old Style)�6m   $
��Bold"�6�   ���	#FFCD3D8F$��14(�6�   $��0,2,0,2q�6�   6�   5]   #   5^      5`      5b      �� 5d      -	   5        $  close��5d      $��Close��6$   $
��Left=�64   $��630,550,0,23q�6O   $��Center=�6e   $��60��6�   $��20��6�   
���   �$
��Bold"�6�   ���	#FFCD7BB6! � Cursor$
! Hand��6�   $ 0.246,0.476&�6�   �� 5e      -
   5        $	  add��5e      $	��Add��6"   $
��Left=�60   $��90,550,0,23q�6K   $��Center=�6`   $��70��6{   $��20��6�   
���   �$
��Bold"�6�   ���	#FFCD7BB6$
! Hand��6�   6�   5g      5h      5j      