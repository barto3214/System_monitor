   M S B A M L   `   `   `  ����   System_monitor    SystemMonitor.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     R NOxyPlot.Wpf, Version=2.2.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0Y UOxyPlot.Wpf.Shared, Version=2.2.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0"oxyhttp://oxyplot.org/wpf   =av2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006     � Title$  System Monitor��$	��400��$	��600��   BackgroundBrush#���    � 	Resources  �� MergedDictionaries �� Source��  �� $ Themes.xaml?�%    .���� #��[  .@���   DarkTabItemStyle#��[ ���#42387B���#42387B  	TextBrush#��[ $��Ogólnie��.���� $��10q�.+��� $��Total��$��25(�$
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
   $ web_sendedtext��$��0��$��Center=��� Wysyłane pakiety�� �� .+��� -   $ web_recivedtext��$��0��$��Center=��� Odbierane pakiety�� � 	 � ColumnDefinitions	 �� $��* ��� $��* �
 � RowDefinitions
 �� $��* ��� $��* ��� $��* �.+��� -   $��0��$��0��  DarkButtonStyle#��[ .��#!Optymalizacja cache DNS(internet)�� -   $��1��$��0��#��[ .��!Usunięcie plików tymczasowych�� -   $��0��$��1��#��[ .��Usunięcie plików z kosza�� -   $��1��$��1��#��[ .��)'Czyszczenie folderu tymczasowego %TEMP%�� -   $��0��$��2��#��[ $��2��.��&$Zwolnienie nieużywanej pamięci RAM�� $��5��$y�Hidden=��� #��[ ���#42387B���#42387B#��[ $	��CPU��.���� .+��� $
��Bold"�$��20(�" Szczegóły dotyczące procesora�� -   $ 	name_proc��$��Center=��� �� -   $ 
usage_proc��$��Center=��� A� .+��� .+��� $
��Bold"�Czas pracy CPU:�� -   $ time_cpu��$��Center=��� $
��Bold"�Liczba rdzeni:�� -   $ cores_of_cpu��$��Center=��� $
��Bold"�Liczba wątków:�� -   $ ammount_of_threats��$��Center=��� .+��� $
��Bold"�" Szacowana prędkość procesora:�� -   $ speed_of_cpu��$��Center=��� $
��Bold"�Liczba przerwań na sekundę:�� -   $ 	proc_temp��$��Center=��� $
��Bold"�Liczba procesów:�� -   $ ammount_of_processes_cpu��$��Center=��� $��5��$y�Hidden=��� #��[ $	��GPU�����#42387B���#42387B#��[ .���� .+��� $
��Bold"�$��20(�.,Szczegóły dotyczące procesora graficznego�� -   $ GPU_name��$��Center=��� -   $ 	usage_GPU��$��Center=��� �� �� �� �� A� .+��� .+��� $
��Bold"�$"Wersja zainstalowanego sterownika:�� -   $ GPU_driver_version��$��Center=��� �� $
��Bold"�Pamięć wbudowana:�� -   $ GPU_memory_available��$��Center=��� �� .+��� $
��Bold"�Temperatura GPU:�� -   $ GPU_temp��$��Center=��� �� $
��Bold"�Status urządzenia:�� -   $ 
GPU_status��$��Center=��� �� $��5��$y�Hidden=��� #��[ $	��RAM�����#42387B���#42387B#��[ .���� .+��� $
��Bold"�$��20(�%#Szczegóły dotyczące pamięci RAM�� -    ��Name$ kosci_pamieci��$ 
Horizontal=�$��Center=�.+��� ���� *
RamModules+���� .R��� $ 
Horizontal=����� .R��� 
���   �$��3q� �� CornerRadius$ 10��
��� d �$	��200��$��5q�._��� .+��� $
��Bold"�$��Center=����� *
capacity+�� $��Center=����� *manufacturer+�� $��Center=����� *speed+�� $��Center=����� *type+�� $��Center=����� *serial_number+�� $��Center=����� *slot+�� �� A� .+��� .+��� $
��Bold"�%#Ilość wolnej pamięci wirtualnej:�� -    $ Free_virtual��$��Center=��� �� $
��Bold"�Ilość wolnej pamięci RAM:�� -!   $ Free_RAM��$��Center=��� �� .+��� $
��Bold"�*(Ilość całkowitej pamięci wirtualnej:�� -"   $ Virtual_all��$��Center=��� �� $
��Bold"�86Ilość wolnej stronnicowanej pamięci jądra Windows:�� -#   $ Free_core_memory��$��Center=��� 