   M S B A M L   `   `   `  ����R  NContentManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ContentManagementSystem.FramesContentManagementSystem.Frames  5      *    $ContentManagementSystem.Frames.Table   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:ContentManagementSystem.Frames     5        N� Title$  TabelaAdmin��5
      .��5      �� 
�������
�������$��0q�64    �� CornerRadius$ 20 20 20 20��6H   $��50 20 50 30q�6c    �� Padding$ 30 10q�6x   ._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   6/    � RowDefinitions 5      �� 5      $��0.06* �6    61   �� 5      $
��0.1* �6    60   �� 5      $��* �6    6-   �� 5      $
��0.1* �6    60   .+�5      �� -   5         ��Name$ dugmeOdjava��5      $��0��5      $��0��6%   $
��Left=�5   *   $��Одјави се��5         loginBtn#��[  5      $��Regular"�5      $��12(�6*   $��4 0 0 0q�5      $��5 1 5 3q�6&   5       �� 5#      -   5        $��naslov��5$      $��1��5#      $��0��6!   $7��1Приказ свих матичних плоча��5$      $��24(�5%      $
��Bold"�6   $��5q�5&      $��0q�6   $��Center=�5'      $��Center=�6.   5(      &   System.Windows.Controls.DataGrid  5+      -   5          Name$ dataGridSveMaticnePloce��5+   4   $��2��6   $��0��6$   $��14(�5,      $��Medium"�6%   $��4q�5-         SelectionMode$ Single=�5.         CanUserResizeColumns .  	   CanUserResizeRows	 .  
   AutoGenerateColumns
 .  ��.    CanUserReorderColumns .     CanUserAddRows .  $
��Auto=�51      $��Hidden=�6G   ��5+   U   �� *	Skladiste+   Columns 52      4  .System.Windows.Controls.DataGridCheckBoxColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Бриши��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 12* 6<   -   5        izborZaBrisanje��   IsThreeState .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 56   -   �� *
Brisanje+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�58      5  /System.Windows.Controls.DataGridHyperlinkColumn  5;      $* $Модел матичне плоче��6.   -   5        	model��$	 70* 5;   Z      
IsReadOnly .  6f   �� *Naziv+   ElementStyle 5<      �� 5=       �� 
TargetType" ��6$   .�5>   "   -   5        5?      5A      4  .System.Windows.Controls.DataGridTemplateColumn  5D      $ 
Слика��6-   $	 30* 6<    .    CellTemplate 5E      �� 5F      .R�5G   "   �� $��80��6D   ��6(   �� *
UrlSlike+6D   5H      5J      0  *System.Windows.Controls.DataGridTextColumn  5M      $! Датум додавања��6)   $	 30* 6A    .  5N   )   �� *DatumDodavanja+ �� StringFormat$ {0:dd/MM/yy}��5P      5R      �� 5U      -   5         ��Name$ 
adminPanel��5U      $��3��6-   $��0��6:   $��0q�6J    �� Orientation$ 
Horizontal=�6U   $��Center=�6n   .+�5V      �� -   5        $ dugmeBrisanje��5V        	deleteBtn#��[ 5W      $#��Обриши изабрано��5X      $��14(�63   $
��10 0q�5Y      $��	0 5 280 5q�6)   5Z      �� 5\      -	   5        $ dugmeDodavanje��5\       
 addBtn#��[ 5]      $��Додај ново��5^      $��14(�6.   $
��10 0q�5_      $��	280 5 0 5q�6(   5`      5a      5c      5d      5f      