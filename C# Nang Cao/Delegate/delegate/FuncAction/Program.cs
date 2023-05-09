using System;

//Func là mẫu delegate có kiểu trả về.
namespace func_action
{
    class FuncAction
    {
        static int Sum(int x,int y)
        {
            return x + y;
        }

        public static void TestFunc(int x, int y)
        {
            Func<int, int, int> calculate;
            calculate = Sum;

            var result = calculate(x, y);
            Console.WriteLine(result);
        }

        public static void Success(string s)
        {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine(string.Format("Success: {0}", s));
         Console.ResetColor();
        }

        public static void Warn(string s)
        {Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format("Warn: {0}", s));
            Console.ResetColor();

        }

        static void Sum2(int a,int b, Action callback)
        {
            int c = a + b;
            callback?.DynamicInvoke(c.ToString());

        }

        public static void Main(string[] args) { 
            TestFunc(5,7);

            Action<string> showLog = null;

            showLog += Success;
            showLog += Warn;
            showLog += Success;

            showLog("Test");

            //Sum2(5, 6, (x) => Console.WriteLine($"Tổng hai số là: {x}"));
            //Sum2(1, 3, Success);
        }
    }
}