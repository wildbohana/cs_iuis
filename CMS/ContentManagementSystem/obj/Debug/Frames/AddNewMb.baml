   M S B A M L   `   `   `  ����R  NContentManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ContentManagementSystem.FramesContentManagementSystem.Frames  5      -    'ContentManagementSystem.Frames.AddNewMb   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:ContentManagementSystem.Frames     5        N� Title$  AddNewMb��5
      .��5      �� 
�������
�������$��0q�64    �� CornerRadius$ 20 20 20 20��6H   $��50 20 50 30q�6c    �� Padding$ 30 10q�6x   ._�5   
   �  � ColumnDefinitions 5      �� 5      $��3* �6#   60   �� 5      $��3* �6#   60    � RowDefinitions 5      �� 5      $��0.15* �6    61   �� 5      $��0.15* �6    61   �� 5      $��* �6    6-   �� 5      $
��0.1* �6    60   �� 5      $��0.08* �6    61   .+�5      �� $��0��6   $��0��6!   $��2��61   $��Center=�5      $��Center=�6/   $9��3Додавање нове матичне плоче��5      $��24(�5      $
��Bold"�6"   $��5q�5       $��0q�6    5!      �� 5$      $��0��6   $��1��6)    �� Orientation$ 
Horizontal=�66   $��10q�6O   .+�5%      �� $��Right=�6   $��Center=�68   $+��%Модел матичне плоче:��5&      $	��160��5'      $��24��6(   $��14(�5(      $��SemiBold"�6*   5)      �� 5*      -   5         ��Name$ model��5+      $
��Left=�5*      $��Center=�65   $	��232��5,      $��28��6&   $��1 1 1 3q�5-      $��14(�5.      .��6(   5/      50      �� 53      $��1��6   $��1��6)   $ 
Horizontal=�66   $��10q�6O   .+�54      �� $��10 0 0 0q�6   $(��"Година производње:��55      $��Right=�56      $��Center=�68   $��14(�57      $��SemiBold"�6*   $	��140��58      $��24��6(   59      �� 5:      -   5        $ godina��5:      $
��Left=�5;      $��Center=�67   $��14(�5<      $��Regular"�6*   $	��100��5=      $��24��6(   .��64   5>      �� 5?      $
��Left=�6   $��Bottom=�67   $��14��5@      $��8(�6(   $��Regular"�65   
�������$��(1980-2023)��5B      $��5 0 0 0q�5C      5D      5E      �� 5H      -   5         ��Name$ 
okvirSlike��5H   �   $��0��6   $��2��6%   
�����w�$��1q�6O   $��
10 10 10 4q�6c   $ 4q�6w   ._�5I      �� -   5         ��Name$ slika��5I      $��/Images/placeholder.png��6'   5J      �� 5K      -   5        	 ��Name$	 
dodajSliku��5L      $��0��5K      $��3��6%   $��4q�5M      $	��100��5N         loginBtn#��[  6!   $��Избор слике��5O      5P      �� 5S      $��1��6   $��2��6)   $��2��66   $��10q�6G   .+�5U      �� -   5        
 ��Name$
 unosRTB��5U      $
��10 0q�5W      $��10q�6,   $	��295��5X      
�����w�5Z      c� 5\      $��1q�6   
�����w�$	��380��6K   $��32��6W   $��Center=�6c   $��0 10 0 0q�6~   .@�5^      d� -   5         d�Name$ tglButtonItalic��5^   J   $"��EditingCommands.ToggleItalic��6#   $	��2 0q�6c   .��5_      �� $��/Images/italic.png��6    5`      d� 5a      -   5        $ tglButtonBold��5a   H   $ ��EditingCommands.ToggleBold��6#   $	��2 0q�6_   .��5b      �� $��/Images/bold.png��6    5c      d� 5d      -	   5        $ tglButtonUnderline��5d   M   $%��EditingCommands.ToggleUnderline��6#   $	��2 0q�6i   .��5e      �� $��/Images/underline.png��6    5f      �� 5h      $��5q�6    �� 5j      -
   5         ��Name$ ComboBoxFamily��5j      $��60��67   $	��3 0q�6B   6O   �� 5k      -   5        $ ComboBoxSize��5k      $��60��65   $	��3 0q�6@   6M   �� 5l      -   5        $ ComboBoxColor��5l      $��60��66   $	��3 0q�6A   6N   �� 5n      $��5q�6    �� 5p      $��1q�6    
���   �$��30��6H   $��20��6S   $��Right=�6_   $	��5 0q�6{   .@�5q      �� -   5         ��Name$ brojReci��5q   $    �� Padding$ 1 1 3 1q�5r   $   $��20��5s   $   $��12��6/    �� TextAlignment$ Center=�5t   $   $��Center=�5u   $   $��Center=�6A   $��10(�5v   $   5w      5x      5y      5z      �� 5}      -   5        $	 
dugmeNazad��5~      $��1��5}      $��4��6%   $
��Left=�5~   )   $��Одустани��5        	deleteBtn#��[ 5�      $��Regular"�5�      $��14(�6*   $��20 0 0 0q�5�      $��7 1 7 3q�6'   5�      �� 5�      -   5        $	 	dugmeKraj��5�      $��1��5�      $��4��6%   $��Right=�5�   (   $��
Додај��5�       
 addBtn#��[ 5�      $��Regular"�5�      $��14(�6*   $��0 0 20 0q�5�      $��7 1 7 3q�6'   5�      5�      5�      5�      