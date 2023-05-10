using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Trong C# đồng thời nó thêm vào hai từ khóa là async và await

namespace Async_Await
{
    internal class Program
    {
        static void DoSomeThing(int seconds, string msg, ConsoleColor color)
        {

            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,10} ... Start");
            }


            string a = "hehehehehhehe";


            for (int i = 0; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{msg,10} {i,2}");
                    Console.ResetColor();
                }
                Thread.Sleep(1000);
            }

            lock (Console.Out)
            {
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{msg,10} ... End");
                }


            }
          
        }

        //async/await

        //asynchronous (multi thread)
         static async Task Task2()
        {
            Task t2 = new Task(

                () =>
                {
                    DoSomeThing(10, "T2", ConsoleColor.Green);
                }
            );

            t2.Start();
            await t2;
            //t2.Wait();
            Console.WriteLine("T2 Completed!");
            //return t2;
        }
        static async Task Task3()
        {
            Task t3 = new Task((Object ob) =>

            {
                string taskName = (string)ob;
                DoSomeThing(5, taskName, ConsoleColor.Red);
            }, "T3");
            t3.Start();
            await t3;

            //t3.Wait();
            Console.WriteLine("T3 Completed");
            //return t3;
        }

        static async Task<Object> GetWeb(string url)
        {
            //Task<Object> task = new Task<Object>(
            //    () =>
            //    {
            //        //cac tac vu
            //        return new Object();

            //    });
            //task.Start();
            //var kq = await task;
            //return kq;



            HttpClient httpClient = new HttpClient();
            Console.WriteLine("Start Dowload");
            HttpResponseMessage kq =   await httpClient.GetAsync(url);
            Console.WriteLine("Start Read");
            string content = await  kq.Content.ReadAsStringAsync();
            Console.WriteLine("Completed");
            return content;

        }




        static async Task Main(string[] args)
        {

            var task = GetWeb("https://www.py4e.com/");

            var content = await task;
            Console.WriteLine(content);
            Console.ReadKey();

        }
    }
}
