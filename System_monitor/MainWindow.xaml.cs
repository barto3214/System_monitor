using System;
using System.Diagnostics;
using System.Management; 
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using NvAPIWrapper.GPU;
using NvAPIWrapper;
using NvAPIWrapper.Native.Interfaces.GPU;
using NvAPIWrapper.Native;


namespace SystemMonitor
{
    public partial class MainWindow : Window
    {
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;                 // _ ze względu na prywatność zmiennych
        private PerformanceCounter _diskCounter;
        private PerformanceCounter _web_recived_Counter;
        private PerformanceCounter _web_sended_Counter;
        private DispatcherTimer _timer;
        private float _totalMemory; 

        public MainWindow()
        {
            InitializeComponent();
            InitializePerformanceCounters();
            StartMonitoring();
            GetGPUInfo();
        }

        private void InitializePerformanceCounters()
        {
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            _diskCounter = new PerformanceCounter("PhysicalDisk", "% Disk time", "_Total");
            _web_recived_Counter = new PerformanceCounter("Network Interface", "Bytes Sent/sec");
            _web_sended_Counter = new PerformanceCounter("Network Interface", "Bytes Received/sec");
            _totalMemory = GetTotalMemory(); 
        }

        private void StartMonitoring()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += UpdatePerformanceData;
            _timer.Start();
            _cpuCounter.NextValue();
            _ramCounter.NextValue();
            _diskCounter.NextValue();
            _web_recived_Counter.NextValue();
            _web_sended_Counter.NextValue();

        }

        private void UpdatePerformanceData(object sender, EventArgs e)
        {
            
            float cpuUsage = _cpuCounter.NextValue();
            float diskUsage = _diskCounter.NextValue();
            float webrecived = _web_recived_Counter.NextValue();
            float websended = _web_sended_Counter.NextValue();
            
            float availableMemoryInMb = _ramCounter.NextValue();
            float usedMemoryInMb = _totalMemory - availableMemoryInMb; 
            float ramUsagePercentage = (usedMemoryInMb / _totalMemory) * 100;

            


            CPU_usagetext.Text = $"{cpuUsage:F1}%";
            RAM_usagetext.Text = $"{ramUsagePercentage:F1}%";
            Disk_usagetext.Text = $"{diskUsage:F1}%";
            web_usagetext.Text = $"{webrecived}";


            CPU_progress.Value = cpuUsage;
            RAM_progress.Value = ramUsagePercentage;
            Disk_progress.Value = diskUsage;
            
            GetGPUInfo();
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
        private void GetGPUInfo2() {
            var searcher = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (var obj in searcher.Get())
            {
                //GPU_usagetext.Text = "GPU: " + obj["Name"];                               //tu działa
            }

        }
        private void GetGPUInfo()
        {
            foreach (var gpu in PhysicalGPU.GetPhysicalGPUs())
            {
                string gpu_usage = gpu.DynamicPerformanceStatesInfo.GPUDomain.ToString();
                GPU_usagetext.Text = $"{gpu_usage}";
                gpu_usage = gpu_usage.Replace("%", "");
                int.TryParse(gpu_usage, out int gpu_usage_int);
                GPU_progress.Value = gpu_usage_int;


                //Console.WriteLine($"🎮 GPU: {gpu}");

            }
            
        }
        private void GetGPUTermalInfo() {
            var gpus = NvAPIWrapper.GPU.PhysicalGPU.GetPhysicalGPUs();
            foreach (var gpu in gpus)
            {
                IThermalSensor[] sensors = gpu.ThermalSensors;

                foreach (var sensor in sensors)
                {
                    if (sensor != null)
                    {
                        for (int i = 5; i < 10; i++)
                        {
                            GPU_usagetext.Text = $"Temperatura: {sensor.CurrentTemperature} °C";
                        }
                        Console.WriteLine($"GPU: {gpu.FullName}");

                    }
                }
            }
        }

    }
}
