﻿using System.Diagnostics;
using System.Management;
using System.Windows;
using System.Windows.Threading;
using NvAPIWrapper.GPU;
using NvAPIWrapper.Native.Interfaces.GPU;
using System.Net.NetworkInformation;
using System.IO;
using System.Runtime.InteropServices;
using NvAPIWrapper;
using System.Collections.ObjectModel;
using System_monitor;
using System.Text;




namespace SystemMonitor
{
    
    public partial class MainWindow : Window
    {
        public ObservableCollection<Kosc_ram> RamModules { get; set; } = new ObservableCollection<Kosc_ram>();
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _cpuCounter2;
        private PerformanceCounter _cputhreads;
        private PerformanceCounter _cpuprocess;
        private PerformanceCounter _cputime;
        private PerformanceCounter _cpuinterr;
        private PerformanceCounter _ramCounter;                 // _ ze względu na prywatność zmiennych
        private PerformanceCounter _diskCounter;
        private PerformanceCounter _pagedPoolCounter;
        private DispatcherTimer _timer;

        private float _totalMemory;
        private long previousReceived = 0;
        private long previousSent = 0;

        public MainWindow()
        {
            NVIDIA.Initialize();
            InitializeComponent();
            InitializePerformanceCounters();
            StartMonitoring();
            GetGPUInfo();
            SetObjects();
            DataContext = this;
        }
        private void SetObjects() {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT DeviceLocator, Capacity, Manufacturer, SerialNumber, Speed, MemoryType FROM Win32_PhysicalMemory");
            foreach (ManagementObject obj in searcher.Get())
            {
                RamModules.Add(new Kosc_ram(
                    obj["Capacity"] != null ? $"{Convert.ToUInt64(obj["Capacity"]) / (1024 * 1024 * 1024)} GB" : "Nieznane",
                    obj["Manufacturer"]?.ToString() ?? "Nieznane",
                    obj["DeviceLocator"]?.ToString() ?? "Nieznane",
                    obj["SerialNumber"]?.ToString() ?? "Nieznane",
                    obj["Speed"] != null ? $"{obj["Speed"]} MHz": "Nieznane",
                    GetMemoryType(Convert.ToUInt16(obj["MemoryType"]))));
            }
            
        }
        private void InitializePerformanceCounters()
        {
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _cpuCounter2 = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _cputime = new PerformanceCounter("System", "System Up Time");
            _cputhreads = new PerformanceCounter("System", "Threads");
            _cpuprocess = new PerformanceCounter("System", "Processes");
            _cpuinterr = new PerformanceCounter("Processor", "Interrupts/sec", "_Total");
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            _diskCounter = new PerformanceCounter("PhysicalDisk", "% Disk time", "_Total");
            _pagedPoolCounter = new PerformanceCounter("Memory", "Pool Paged Bytes");
            _totalMemory = GetTotalMemory();
        }

        private void StartMonitoring()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += UpdatePerformanceData;
            _timer.Tick += UpdateNetworkStats;
            _timer.Start();
            _cpuCounter.NextValue();
            _cpuCounter2.NextValue();
            _cputime.NextValue();
            _cputhreads.NextValue();
            _cpuprocess.NextValue();
            _cpuinterr.NextValue();
            _ramCounter.NextValue();
            _diskCounter.NextValue();
            _pagedPoolCounter.NextValue();

        }   
        public void UpdatePerformanceData(object sender, EventArgs e)
        {

            float pagedPool = _pagedPoolCounter.NextValue();
            float cpuUsage = _cpuCounter.NextValue();
            float cputime = _cputime.NextValue();
            float cputhreads = _cputhreads.NextValue();
            float cpuprocess = _cpuprocess.NextValue();
            float cpuinterr = _cpuinterr.NextValue();
            float diskUsage = _diskCounter.NextValue();

            float availableMemoryInMb = _ramCounter.NextValue();
            float usedMemoryInMb = _totalMemory - availableMemoryInMb;
            float ramUsagePercentage = (usedMemoryInMb / _totalMemory) * 100;

            TimeSpan uptime = TimeSpan.FromSeconds(cputime);
            time_cpu.Text = $"{uptime.Hours}h {uptime.Minutes}m {uptime.Seconds}s";

            pagedPool = pagedPool / (1024 * 1024 * 1024);
            int procenty_cpu = (int)cpuUsage;
            CPU_usagetext.Text = $"{procenty_cpu}%";
            usage_proc.Text = $"{procenty_cpu}%";
            ammount_of_threats.Text = $"{cputhreads}";
            ammount_of_processes_cpu.Text = $"{cpuprocess}";
            proc_temp.Text = $"{cpuinterr:F0}";
            RAM_usagetext.Text = $"{ramUsagePercentage:F1}%";
            Disk_usagetext.Text = $"{diskUsage:F1}%";
            Free_core_memory.Text = $"{pagedPool:F2} GB";



            CPU_progress.Value = cpuUsage;
            RAM_progress.Value = ramUsagePercentage;
            Disk_progress.Value = diskUsage;


            GetGPUInfo();
            GetGPUInfo3();
            GetCPUInfo();
            GetCPUSpeed();
            GetMemoryInfo();
        }

        private float GetTotalMemory()
        {

            float totalMemory = 0;
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject obj in searcher.Get())
            {

                totalMemory = Convert.ToSingle(obj["TotalVisibleMemorySize"]) / 1024;
            }
            return totalMemory;
        }

        private void GetMemoryInfo()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

            foreach (ManagementObject obj in searcher.Get())
            {
                Free_RAM.Text = obj["FreePhysicalMemory"] != null ?
                    $"{Convert.ToUInt64(obj["FreePhysicalMemory"]) / 1024} MB" : "Nieznane";

                Free_virtual.Text = obj["FreeVirtualMemory"] != null ?
                    $"{Convert.ToUInt64(obj["FreeVirtualMemory"]) / 1024} GB" : "Nieznane";

                Virtual_all.Text = obj.Properties["TotalVirtualMemorySize"] != null ?                ///////To nie działa
                    $"{Convert.ToUInt64(obj["TotalVirtualMemorySize"]) / 1024} GB" : "Nieznane";


            }
            
        }
        private string GetMemoryType(ushort type)
        {
            
            return type switch
            {
                20 => "DDR",
                21 => "DDR2",
                22 => "DDR2 FB-DIMM",
                24 => "DDR3",
                26 => "DDR4",
                27 => "DDR5",
                19 => "SDRAM",
                23 => "DDR2 FB-DIMM (ECC)",
                28 => "LPDDR",
                29 => "LPDDR2",
                30 => "LPDDR3",
                31 => "LPDDR4",
                32 => "LPDDR5",
                33 => "WIDE-IO",
                34 => "HMC",
                35 => "HBM",
                0 => "Nieznane",
                _ => "Nieznane"
            };
        }

        private void GetCPUInfo()
        {

            var searcher = new ManagementObjectSearcher("SELECT Name, NumberOfCores, CurrentClockSpeed FROM Win32_Processor");

            foreach (var item in searcher.Get())
            {
                name_proc.Text = item["Name"].ToString();
                cores_of_cpu.Text = item["NumberOfCores"]?.ToString();
            }
        }

        private void GetCPUSpeed()
        {

            float cpuUsage = _cpuCounter2.NextValue();
            float procenty = (float)cpuUsage;
            int maxSpeed = 3301;
            float estimatedSpeed = (procenty / 100) * maxSpeed;
            estimatedSpeed = estimatedSpeed / 100;
            estimatedSpeed = (float)System.Math.Round(estimatedSpeed, 2);

            if(estimatedSpeed < 4.5)
            {
                speed_of_cpu.Text = $"{estimatedSpeed} GHz";
            }
            
        }
        private void GetGPUInfo3()
        {
            using (var searcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    GPU_name.Text = "" + obj["Name"] ;
                    GPU_status.Text = obj["Status"]?.ToString();
                    GPU_driver_version.Text = obj["DriverVersion"]?.ToString();
                }
            }
        }
        private void GetGPUInfo()
        {
            foreach (var gpu in PhysicalGPU.GetPhysicalGPUs())
            {
                IThermalSensor[] sensors = gpu.ThermalSensors;
                IDisplayDriverMemoryInfo displayDriverMemoryInfo = gpu.MemoryInfo;
                string gpu_usage = gpu.DynamicPerformanceStatesInfo.GPUDomain.ToString();
                GPU_usagetext.Text = $"{gpu_usage}";
                usage_GPU.Text = $"{gpu_usage}";
                gpu_usage = gpu_usage.Replace("%", "");
                if (int.TryParse(gpu_usage, out int gpu_usage_int))
                {
                    GPU_progress.Value = gpu_usage_int;
                }
                foreach (var sensor in sensors)
                {
                    if (sensor != null)
                    {
                        for (int i = 5; i < 10; i++)
                        {
                            GPU_temp.Text = $"{sensor.CurrentTemperature} °C";
                            GPU_memory_available.Text = $"{displayDriverMemoryInfo.AvailableDedicatedVideoMemory / 1000000} GB";
                        }  
                    }
                }
            }

        }
        private async void UpdateNetworkStats(object sender, EventArgs e)
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    IPv4InterfaceStatistics stats = ni.GetIPv4Statistics();
                    typ_sieci.Text = $"({ni.Name})";
                    web_recivedtext.Text = $"{stats.UnicastPacketsReceived}";
                    web_sendedtext.Text = $"{stats.UnicastPacketsSent}";
                }
            }


            await Task.Delay(1000); // Odczekaj 1 sekundę przed następnym pomiarem
        }
        private void DNS_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("ipconfig", "/flushdns")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("Cache DNS został wyczyszczony.");
                        Console.WriteLine(output);
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas czyszczenia cache DNS:");
                        Console.WriteLine(error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message);
            }
        }

        private void Deleting_Click(object sender, RoutedEventArgs e)
        {
            string tempPath = Path.GetTempPath();
            DirectoryInfo tempDir = new DirectoryInfo(tempPath);
            int skipped = 0;
            int skipped_folders = 0;
            int crusial_skipped = 0;


            string[] excludedFiles = { "ntuser.dat", "ntuser.ini", "thumbs.db", "desktop.ini" };
            string[] excludedExtensions = { ".log", ".dat", ".sys" };

            MessageBoxResult userInput = MessageBox.Show("Czy chcesz usunąć WSZYSTKIE pliki tymczasowe?", "Potwierdzenie", MessageBoxButton.YesNo);

            if (userInput == MessageBoxResult.No)
            {
                MessageBox.Show("Anulowano czyszczenie katalogu tymczasowego.");
                return;
            }

            foreach (FileInfo file in tempDir.GetFiles())
            {

                if (excludedFiles.Contains(file.Name.ToLower()) || excludedExtensions.Contains(file.Extension.ToLower()))
                {
                    crusial_skipped++;
                }


                if (file.CreationTime < DateTime.Now.AddDays(-7))
                {
                    file.Delete();
                }
                else
                {
                    skipped++;
                }


            }

            foreach (DirectoryInfo dir in tempDir.GetDirectories())
            {


                if (dir.CreationTime < DateTime.Now.AddDays(-7))
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch
                    {
                        skipped_folders++;
                    }
                }
                else
                {
                    skipped_folders++;
                }

            }

            MessageBox.Show($"Czyszczenie zakończone.Pominięto plików: {skipped}, pominięto ważnych plików: {crusial_skipped}, " +
                $"pominięto folderów: {skipped_folders}");
        }

        private void Trash_Click(object sender, RoutedEventArgs e)
        {

            [DllImport("shell32.dll")]
            static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, uint dwFlags);

            const uint SHERB_NOCONFIRMATION = 0x00000001;
            const uint SHERB_NOPROGRESSUI = 0x00000002;
            const uint SHERB_NOSOUND = 0x00000004;

            SHEmptyRecycleBin(IntPtr.Zero, null, SHERB_NOCONFIRMATION | SHERB_NOPROGRESSUI | SHERB_NOSOUND);
            MessageBox.Show("Kosz został opróżniony.");

        }

        private void TEMP_delete_Click(object sender, RoutedEventArgs e)
        {

            int skipped_files = 0, skipped_files_of_dirs = 0, deleted_files = 0, deleted_dirs = 0;
            string tempPath = Path.GetTempPath();
            var tempDir = new DirectoryInfo(tempPath);
            string[] protected_files = { "DONTDELETE.tmp", "system_cache.dat", "Thumbs.db", "desktop.ini" };
            string[] protected_companys = { "MicrosoftEdge", "Google", "Mozilla", "Adobe", "Windows" };


            MessageBoxResult userinput = MessageBox.Show("Czy chcesz usunąć WSZYSTKIE pliki w folderze %TEMP%?", "Potwierdzenie", MessageBoxButton.YesNo);

            if (userinput == MessageBoxResult.No)
            {
                MessageBox.Show("Anulowano czyszczenie katalogu tymczasowego.");
                return;
            }

            foreach (var file in tempDir.GetFiles())
            {
                if (protected_files.Contains(file.Name, StringComparer.OrdinalIgnoreCase) || Is_in_use(file) || Was_in_use(file, 7))
                {
                    skipped_files++;
                }
                else
                {
                    try
                    {
                        file.Delete();
                        deleted_files++;
                    }
                    catch
                    {
                        skipped_files++;
                    }
                }
            }

            foreach (var dir in tempDir.GetDirectories())
            {
                if (protected_companys.Contains(dir.Name, StringComparer.OrdinalIgnoreCase))
                {
                    skipped_files_of_dirs++;
                }
                else
                {
                    try
                    {
                        dir.Delete(true);
                        deleted_dirs++;
                    }
                    catch
                    {
                        skipped_files_of_dirs++;
                    }
                }
            }

            MessageBox.Show($"Usunięto: {deleted_files} plików, {deleted_dirs} folderów. Pominięto: {skipped_files} plików," +
                $" {skipped_files_of_dirs} folderów.");
        }
        private bool Is_in_use(FileInfo file)
        {
            try
            {
                using (file.Open(FileMode.Open, FileAccess.Read, FileShare.None)) { }
                return false;
            }
            catch
            {
                return true;
            }

        }

        private bool Was_in_use(FileInfo file, int seconds)
        {
            DateTime lastWriteTime = file.LastWriteTime;
            return (DateTime.Now - lastWriteTime).TotalSeconds < seconds;
        }

        private void RAM_Click(object sender, RoutedEventArgs e)
        {
            int successCount = 0;
            int failureCount = 0;

            [DllImport("psapi.dll", SetLastError = true)]
            static extern bool EmptyWorkingSet(IntPtr hProcess);

            foreach (Process proc in Process.GetProcesses())
            {

                if (proc.Id <= 4)
                {
                    continue;
                }

                try
                {
                    if (EmptyWorkingSet(proc.Handle))
                    {
                        successCount++;
                    }
                    else
                    {

                        failureCount++;
                    }
                }
                catch
                {
                    failureCount++;
                }
            }

            MessageBox.Show($"Operacja zakończona. Pomyślnie zwolniono pamięć dla {successCount} procesów. Wystąpiły błędy dla {failureCount} procesów.");
        }
    }
}

