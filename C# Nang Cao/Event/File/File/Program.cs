using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    internal class Program
    {
        public static void getDriversInfo()
        {
            DriveInfo[] allDrivers = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrivers)
            {
                Console.WriteLine("Drive {0}"+d.Name);
                Console.WriteLine("Drive type: {0}",d.DriveType);
                if(d.IsReady == true)
                {
                    Console.WriteLine("Volume label: {0}",d.VolumeLabel);
                    Console.WriteLine("File system: {0}", d.DriveFormat);
                    Console.WriteLine("DriverFormat: " + d.DriveFormat);
                    Console.WriteLine("AvailableFreeSpace to current user {0,15} bytes: ", d.AvailableFreeSpace);
                    Console.WriteLine("TotalFreeSpace: {0,15} bytes ",d.TotalFreeSpace);
                    Console.WriteLine("Total Size: {0,15} bytes "+d.TotalSize);
                }
            }
        }

        public static void Main(string[] args)
        {
            getDriversInfo();
        }
    }
}
