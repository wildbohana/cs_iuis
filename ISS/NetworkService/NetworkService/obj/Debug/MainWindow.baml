   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NetworkServiceNetworkService  5   	   C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5   	   ;"clr-namespace:NetworkService.ViewsNetworkService.Views  5   	       NetworkService.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NetworkService     5   	   <	viewModel&clr-namespace:NetworkService.ViewModel     5   	   4views"clr-namespace:NetworkService.Views     5   	     � Title$  Nadzor reaktora��5   	    � Icon$ Assets/icon.ico��5   	   $	��900��5   	   $
��1500��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � DataContext 5      2   ,NetworkService.ViewModel.MainWindowViewModel  5   
    � 	Resources 5       �� DataType,   &NetworkService.ViewModel.HomeViewModel#   NetworkService.Views.HomeView7   1NetworkService.ViewModel.NetworkEntitiesViewModel.   (NetworkService.Views.NetworkEntitiesView6   0NetworkService.ViewModel.NetworkDisplayViewModel-   'NetworkService.Views.NetworkDisplayView8   2NetworkService.ViewModel.MeasurementGraphViewModel/	   )NetworkService.Views.MeasurementGraphView��%,  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5!      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5       �� 5!   
   "  6   .R�5"      	  5#      5$      .��5'      �  � RowDefinitions 5(   
   �� 5)      $	��10* �6   �� 5*      $
��100* �6   .+�5.   
   �� $��0��6   $��150 10q�6   
������� �� CornerRadius$ 20��6A   ._�5/      � $��10(�6   $��Roboto)�6+   	 �� TextAlignment$	 Center=�6I   
 � ColumnDefinitions
 50      �� 51      $��2* �6'   �� 52      $��* �6'   �� 53      $��* �6'   �� 54      $��* �6'   �� 55      $��* �6'   �� 56      $��2* �6'   .+�5:      �� $��5��6   
������ 
������ $��Right=�6|   ��6\   �� *UndoCommand+.��5;      �� .+�5<      �� $��Assets/empty.png��6    $��Uniform=�6:   $��36��6L   $��5q�6W   �� 5=      $��OPOZOVI��6$   5>      5?      �� 5B      $��1��6   
������ 
������ $
��home��6{   ��6\   �� *
NavCommand+.��5C      �� .+�5D      �� $��Assets/home.png��6    $��Uniform=�69   $��26��6K   $��5q�6V   �� 5E      $��POČETNA��6$   5F      5G      �� 5J      $��2��6   
������ 
������ $��entities��6|   ��6]   �� *
NavCommand+.��5K      �� .+�5L      �� $��Assets/table.png��6    $��Uniform=�6:   $��26��6L   $��5q�6W   �� 5M      $��TABELA��6$   5N      5O      �� 5R      $��3��6   
������ 
������ $��display��6|   ��6]   �� *
NavCommand+.��5S      �� .+�5T      �� $��Assets/view.png��6    $��Uniform=�69   $��26��6K   $��5q�6V   �� 5U      $��MREŽA��6$   5V      5W      �� 5Z      $��4��6   
������ 
������ $��graphs��6|   ��6]   �� *
NavCommand+.��5[      �� .+�5\      �� $��Assets/graphs.png��6    $��Uniform=�6;   $��26��6M   $��5q�6X   �� 5]      $��GRAFIK��6$   5^      5_      5`      5a      � 5d   
   $��1��6   $��0��6   ��5e      �� 5f       �� ImageSource$ /Assets/bg1.png��6    j� Stretch$ UniformToFill=�6;   5h      �� 5i   
   $��1��6   $��0��6&   $��10q�6[   ��66   �� *CurrentViewModel+6[   5j      5k      