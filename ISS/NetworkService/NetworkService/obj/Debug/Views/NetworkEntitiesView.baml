   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NetworkService.ViewsNetworkService.Views  5      C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5      .    (NetworkService.Views.NetworkEntitiesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:NetworkService.Views     5      <	viewModel&clr-namespace:NetworkService.ViewModel     5      .��5      �   � ColumnDefinitions  5   
   �� 5      $	��220 �6   6-   �� 5      $��* �6   6+   �� 5      $	��220 �6   6-   .+�5   
   � $��0��6   .+�5      ��  �� CornerRadius$ 20��6   $��1q�6'   
���   �
�������$��	10 10 0 0q�6b   $	��200��6u   $	��Top=�6�   ._�5      �  � RowDefinitions 5      �� 5      6*   �� 5      6*   �� 5      6*   �� 5      6*   .+�5      �� $��0��6    $��Pretraga entiteta:��6-   
�������$��Center=�6Y   $��20(�6v   $
��0 10q�6�   �� 5       $��1��6!    �� Orientation$ 
Horizontal=�6.   $��Center=�6G   .+�5!      	� $
��Left=�6&   $��Center=�6A   $��	10 0 10 0q�6\   
�������$��Naziv��6�    d� 	IsChecked 6�   �� *PretragaPoNazivu+ �� Mode$ TwoWay=�6�   	� 5"      $��Right=�6&   $��Center=�6B   $��	10 0 10 0q�6]   
�������$	��Tip��6�    6�   �� *PretragaPoTipu+$ TwoWay=�6�   5#      �� 5%      $��2��6   $	��140��6+   $��24��67   $��28,13,40,12q�6C   $��16(�6X   ��6f   �� *KriterijumPretrage+6�   �� 5'      $��3��6!   $ 
Horizontal=�6.   $��Center=�6G   .+�5(      �� $��80��6!   $��24��6,   $��Center=�68   $��Center=�6U   $
��5 10q�6p   ��6~   �� *PretragaCommand+.��6�   	Pretraži6�   �� 5)      $��80��6!   $��24��6,   $��Center=�68   $��Center=�6U   $
��5 10q�6p   ��6~   �� *RemovePretragaCommand+.��6�   	Resetuj6�   5*      5+      5,      5-      �� 5/   
   $��1��6   .+�51      �� $ 20��6   $��1q�6'   
���   �
�������$��10q�6b   ._�52      &   System.Windows.Controls.DataGrid  $	��500��6   $��16(�6(      
IsReadOnly . $��15q�6H      AutoGenerateColumns .     CanUserAddRows .  ��6T   �� *ReaktoriPretraga+	 �� SelectedItem	 6�   �� *SelectedDevice+
   Columns
 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6-      Header$ ID entiteta��68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *Id+6f     55      $ 8* 6-   $ Ime entiteta��68    6N   �� *Ime+6h     56      $ 5* 6-   $ Tip entiteta��68    6N   �� *Tip.NazivTipa+6r     57      $ 6* 6-   $! Poslednja izmerena vrednost��68    6]   �� *
Vrednost+6|   59      5:      �� 5=      $ 20��6   $��1q�6'   
���   �
�������$��200 10q�6b   ._�5>      � $��100 20q�6    5?      �� 5@      $��40 �6(   �� 5A      $��40 �6(   �� 5B      $��40 �6(     5D      �� 5E      $��3* �6+   �� 5F      $��* �6+   .+�5I      �� $��0��6   $��0��6)   $��20(�69   $
��Left=�6G   $��Center=�6b   
�������.��6�   ID Entiteta:6�   �� 5J      $��1��6   $��0��6)   $��20(�69   $
��Left=�6G   $��Center=�6b   
�������.��6�   Ime Entiteta:6�   �� 5K      $��2��6   $��0��6)   $��20(�69   $
��Left=�6G   $��Center=�6b   
�������.��6�   Tip entiteta:6�   �� 5M      $��0��6   $��0��6+   $	��140��6;   $��18(�6G   $��2 0 0 2q�6U   $��26��6g   $��Right=�6s   $��0 0 10 0q�6�   ��6�   �� *CurrentDevice.TextId+6�   �� 5N      $��0��6   $��0��6)   $��Right=�69   $��Bottom=�6U   
���  ��$��0 0 30 0q�6�   ��6�   �� *$"CurrentDevice.ValidationErrors[Id]+6�   �� 5O      $��1��6   $��0��6+   $	��140��6;   $��18(�6G   $��2 0 0 2q�6U   $��26��6g   $��Right=�6s   $��0 0 10 0q�6�   ��6�   �� *CurrentDevice.Ime+6�   �� 5P      $��1��6   $��0��6)   $��Right=�69   $��Bottom=�6U   
���  ��$��0 0 30 0q�6�   ��6�   �� *%#CurrentDevice.ValidationErrors[Ime]+6�   �� 5Q      $��2��6   $��0��6,   $	��140��6<   $��18(�6H   $��26��6V   $��Right=�6b   $��0 0 10 0q�6~   ��6�   �� *Tipovi+	 6�   �� *CurrentDeviceType.NazivTipa+6�   �� 5R      $��2��6   $��0��6)   $��Right=�69   $��Bottom=�6U   
���  ��$��0 0 30 0q�6�   ��6�   �� **(CurrentDeviceType.ValidationErrors[Type]+6�   �� 5T      $��2��6   $��1��6*   $��Center=�6:   $��Center=�6W   $��24��6r   $��80��6~   ��6�   �� *
AddCommand+.��6�   Dodaj6�   �� 5U      $��1��6   $��Center=�6-   $��Center=�6J   $��24��6e   $��80��6q   ��6|   �� *DeleteCommand+.��6�   	Obriši6�   5V      5W      5X      �� 5[   
   $��2��6   $ 20��6!   $��1q�63   
���   �
�������$��
0 10 10 10q�6n   $	��200��6�   $	��Top=�6�   ._�5\      �� .+�5]      ��  �� Padding$ 	10 10 0 0q�6   $��Moguće komande:��60   $��14(�6G   
���   �6U   �� 5^      $ 10 0 0 0q�6   $��promenipogled [0,1,2,3]��6/   $��12(�6N   
���   �6\   �� 5_      $ 	10 0 0 10q�6   $��opozovi��60   $��12(�6?   
���   �6M   �� 5a      -   5         ��Name$ KomandaTerminala��5a      66   5b      5c      5d      5f      