   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf   System_monitor   SystemMonitor.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     R NOxyPlot.Wpf, Version=2.2.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0Y UOxyPlot.Wpf.Shared, Version=2.2.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0"oxyhttp://oxyplot.org/wpf   @lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf   =av2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006     � Title$  System Monitor��$	��710��$	��650��   BackgroundBrush#���    � 	Resources  �� MergedDictionaries �� Source��  �� $ Themes.xaml?�%    .���� #��[  .@���   DarkTabItemStyle#��[ ���#42387B���#42387B  	TextBrush#��[ $��Ogólnie��.���� $��10q�.+��� $��Total��$��25(�$
��Bold"���  �� Orientation$ 
Horizontal=�$��5q�.+��� $
��CPU:��$��14(�$
��Bold"��� $��20��� -    �Name$ CPU_progress��$	��200��$��15�� � Minimum$ 0Q� � Maximum$	 100Q����#42387B���#1D2131$	��2pxq�  Progress_color#��[ �� -    ��Name$ CPU_usagetext��$��50��$��0%���� $ 
Horizontal=�$��5q�.+��� $ ��Użycie karty graficznej: ��$��14(�$
��Bold"��� $��20��� -   $ GPU_progress��$	��200��$��15��$ 0Q�$	 100Q����#42387B���#1D2131$	��2pxq�#��[ �� -   $ GPU_usagetext��$��0%���� $ 
Horizontal=�$��5q�.+��� $��Użycie Pamięi RAM:��$��14(�$
��Bold"��� $��20��� -   $ RAM_progress��$	��200��$��15��$ 0Q�$	 100Q����#42387B���#1D2131$	��2pxq�#��[ �� -   $ RAM_usagetext��$��50��$��0%���� $ 
Horizontal=�$��5q�.+��� $��Użycie dysku: ��$��14(�$
��Bold"��� $��20��� -   $ Disk_progress��$	��200��$��15��$ 0Q�$	 100Q����#42387B���#1D2131$	��2pxq�#��[ �� -   $ Disk_usagetext��$��50��$��0%���� $ 
Horizontal=�$��5q�.+��� $��Użycie sieci: ��$��14(�$
��Bold"��� -	   $ 	typ_sieci��$�� ��$��14(�$
��Bold"��� $��20���� .+��� -
   $ web_sendedtext��$��0��$��Center=��� Wysyłane pakiety�� �� .+��� -   $ web_recivedtext��$��0��$��Center=��� Odbierane pakiety�� �� -   	 ��Name$	 charts1���� � 
 � ColumnDefinitions
 �� $��* ��� $��* � � RowDefinitions �� $��* ��� $��* ��� $��* �.+��� -   $��0��$��0��  DarkButtonStyle#��[ .��#!Optymalizacja cache DNS(internet)�� -   $��1��$��0��#��[ .��!Usunięcie plików tymczasowych�� -   $��0��$��1��#��[ .��Usunięcie plików z kosza�� -   $��1��$��1��#��[ .��)'Czyszczenie folderu tymczasowego %TEMP%�� -   $��0��$��2��#��[ $��2��.��&$Zwolnienie nieużywanej pamięci RAM�� $��5��$y�Hidden=��� #��[ ���#42387B���#42387B#��[ $	��CPU��.���� .+���   BorderStyle#���  ._��� .+���   HeaderStyle#���  $
��Bold"�$��20(�" Szczegóły dotyczące procesora�� -   $ 	name_proc��  	TextStyle#���  $��Center=��� �� -   $ 
usage_proc��#���  $��Center=��� �� �� �� �� A�  A� Columns$ 2�� A� Rows$ 1��.+��� .+��� #���  $
��Bold"�Czas pracy CPU:�� -   $ time_cpu��#���  $��Center=��� #���  $
��Bold"�Liczba rdzeni:�� -   $ cores_of_cpu��#���  $��Center=��� #���  $
��Bold"�Liczba wątków:�� -   $ ammount_of_threats��#���  $��Center=��� .+��� #���  $
��Bold"�.,Jak dużo przeskoków między zadaniami/sec:�� -   $ speed_of_jumping_cpu��#���  $��Center=��� #���  $
��Bold"�Liczba przerwań na sekundę:�� -   $ 	proc_temp��#���  $��Center=��� #���  $
��Bold"�Liczba procesów:�� -   $ ammount_of_processes_cpu��#���  $��Center=��� �� �� -   $	 charts2���� $��5��$y�Hidden=��� #��[ $	��GPU�����#42387B���#42387B#��[ .���� .+��� #���  ._��� .+��� #���  $
��Bold"�$��20(�.,Szczegóły dotyczące procesora graficznego�� -   $ GPU_name��#���  $��Center=��� �� -   $ 	usage_GPU��#���  $��Center=��� �� �� �� �� A� $ 2��.+��� .+��� #���  $
��Bold"�$"Wersja zainstalowanego sterownika:�� -   $ GPU_driver_version��#���  $��Center=��� �� #���  $
��Bold"�Pamięć wbudowana:�� -   $ GPU_memory_available��#���  $��Center=��� �� .+��� #���  $
��Bold"�Temperatura GPU:�� -   $ GPU_temp��#���  $��Center=��� �� #���  $
��Bold"�Status urządzenia:�� -    $ 
GPU_status��#���  $��Center=��� �� �� �� -!   $	 charts3���� $��5��$y�Hidden=��� #��[ $	��RAM�����#42387B���#42387B#��[ .���� .+��� #���  ._��� .+��� $
��Bold"�$��20(�#���  %#Szczegóły dotyczące pamięci RAM�� -"   $	 kosci_pamieci��$ 
Horizontal=�$��Center=�.+��� ���� *
RamModules+���� .R��� $ 
Horizontal=����� .R���   RamModuleStyle#���  ._��� .+��� $
��Bold"�$��Center=����� *
capacity+�� $��Center=�#���  ���� *manufacturer+�� $��Center=�#���  ���� *speed+�� $��Center=�#���  ���� *type+�� $��Center=�#���  ���� *serial_number+�� $��Center=�#���  ���� *slot+�� �� A� .+��� .+��� #���  $
��Bold"�%#Ilość wolnej pamięci wirtualnej:�� -#   $ Free_virtual��#���  $��Center=��� �� #���  $
��Bold"�Ilość wolnej pamięci RAM:�� -$   $ Free_RAM��#���  $��Center=��� �� .+��� #���  $
��Bold"�*(Ilość całkowitej pamięci wirtualnej:�� -%   $ Virtual_all��#���  $��Center=��� �� #���  $
��Bold"�.,Wolna stronnicowana pamięć jądra Windows:�� -&   $ Free_core_memory��#���  $��Center=��� �� $��5��$y�Hidden=��� #��[ $��Punkty wyd.�����#42387B���#42387B#��[ .���� .+��� #���  ._��� .+��� $
��Bold"�$��20(�#���  '%Szczegóły punktów wydajnościowych�� $��40��� 
 �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* � �� $��* �.+��� $��0��$��0��.+�� -'   $ VerticalProgress_cpu�����#42387B���#1D2115$	��2pxq�#��[ $ 0Q�$ 18Q� � Value$ 50Q�$��30��$	��200�� � Orientation$ Vertical=�$��Center=�$��Center=� J� RenderTransformOrigin$ 0.5,0.5&�z���  �� Angle$	 360Q��� �� $��Center=�$	��CPU��$��15(�$
��Bold"��� -(   $ CPU_points_text��$��Center=�$��15(�$
��Bold"��� $��1��$��0��.+�� -)   $ VerticalProgress_gpu�����#42387B���#1D2115$	��2pxq�#��[ $ 0Q�$ 18Q�$ 50Q�$��30��$	��200��$ Vertical=�$��Center=�$��Center=�$ 0.5,0.5&�z��� $	 360Q��� �� $��Center=�$	��GPU��$��15(�$
��Bold"��� -*   $ GPU_points_text��$��Center=�$��15(�$
��Bold"��� $��2��$��0��.+�� -+   $ VerticalProgress_ram�����#42387B���#1D2115$	��2pxq�#��[ $ 0Q�$ 18Q�$ 50Q�$��30��$	��200��$ Vertical=�$��Center=�$��Center=�$ 0.5,0.5&�z��� $	 360Q��� �� $��Center=�$	��RAM��$��15(�$
��Bold"��� -,   $ RAM_points_text��$��Center=�$��15(�$
��Bold"��� $��3��$��0��.+�� --   $ VerticalProgress_disk�����#42387B���#1D2115$	��2pxq�#��[ $ 0Q�$ 18Q�$ 50Q�$��30��$	��200��$ Vertical=�$��Center=�$��Center=�$ 0.5,0.5&�z��� $	 360Q��� �� $��Center=�$
��Disk��$��15(�$
��Bold"��� -.   $ Disk_points_text��$��Center=�$��15(�$
��Bold"��� $��4��$��0��.+�� -/   $ VerticalProgress_temp�����#42387B���#1D2115$	��2pxq�#��[ $ 0Q�$ 18Q�$ 50Q�$��30��$	��200��$ Vertical=�$��Center=�$��Center=�$ 0.5,0.5&�z��� $	 360Q��� �� $��Center=�$��Temp GPU��$��15(�$
��Bold"��� -0   $ temp_points_text��$��Center=�$��15(�$
��Bold"��� $��5��$��0��.+�� -1   $ VerticalProgress_process�����#42387B���#1D2115$	��2pxq�#��[ $ 0Q�$ 18Q�$ 30Q�$��30��$	��200��$ Vertical=�$��Center=�$��Center=�$ 0.5,0.5&�z��� $	 360Q��� �� $��Center=�$��	Processes��$��15(�$
��Bold"��� -2   $ Processes_points_text��$��Center=�$��15(�$
��Bold"��� �� .+��� #���  ._���  	 InfoTextStyle#��[	 $\��VTe testy mierzą średnie zużycie CPU i RAM pod obciążeniem(pełny) lub bez(szybki)���� �� �� $ 
Horizontal=�$��Center=�.+��� -3   #��[ .��Szybki test wydajności�� $��50���� -4   #��[ .��Pełny test wydajności�� �� 