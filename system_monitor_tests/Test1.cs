using Microsoft.VisualStudio.TestTools.UnitTesting;
using System_monitor;
using SystemMonitor;

namespace system_monitor_tests
{


    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void performance_counter_test()
        {
            int wynik = MainWindow.performance_counter_points(32);
            Assert.AreEqual(6, wynik);
        }

        [TestMethod]
        public void performance_counter_test_lower_than_0()
        {
            int wynik = MainWindow.performance_counter_points(-5);
            Assert.AreEqual(0, wynik);
        }

        [TestMethod]
        public void performance_counter_test_higher_than_100()
        {
            int wynik = MainWindow.performance_counter_points(150);
            Assert.AreEqual(0, wynik);
        }

        [TestMethod]
        public void get_memory_type_test()
        {
            string wynik = MainWindow.GetMemoryType(26);
            Assert.AreEqual("DDR4", wynik);
        }

        [TestMethod]
        public void get_memory_type_test_0()
        {
            string wynik = MainWindow.GetMemoryType(0);
            Assert.AreEqual("Nieznane", wynik);
        }

        [TestMethod]
        public void get_memory_type_test_higher_than_32()
        {
            string wynik = MainWindow.GetMemoryType(40);
            Assert.AreEqual("Nieznane", wynik);
        }

    }
}
