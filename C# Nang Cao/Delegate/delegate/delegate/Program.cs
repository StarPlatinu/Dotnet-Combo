using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

//delegate bạn có thể gán vào nó một, nhiều hàm (phương thức) có sự tương thích về tham số,
//kiểu trả về, sau đó dùng nó để gọi hàm (giống con trỏ trong C++)
namespace cs_delegate
{
    public class Logs
    {
        public delegate void showLog(string message);

        static public void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Info: {0}", s));
            Console.ResetColor();
        }
        static public void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("Warning : {0}", s));
            Console.ResetColor();
        }

        public  void TestSgowLog()
        {
            showLog showLog;
            showLog = Info;
            showLog("Warning");

            showLog = Warning;
            showLog("Warning");

            Console.WriteLine("-------------------------");

            //Gán nhiều phương thức vào delegate
            showLog = null;
            showLog += Warning;
            showLog += Info;
            showLog += Warning;

            //showLog("Test Alert"); 
            showLog?.Invoke("Test Log"); //if (showLog != null) showLog("Mgs")
            Console.WriteLine("--------------------------");
            showLog += (x) => Console.WriteLine(string.Format("====>{0}<===", x));
            showLog?.Invoke("Test Log");
        }

    }
    public class Program
    {
      
        static public void Main(string[] args)
        {
            Logs logs = new Logs();
            logs.TestSgowLog();
        }
    }
}