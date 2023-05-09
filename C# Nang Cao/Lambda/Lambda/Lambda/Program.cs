using System;


namespace Lambda
{
    class Lambda_Method
    {
        public delegate int Sum(int a, int b);
        public static void Main(string[] args)
        {
            Sum sum = (int x, int y) =>
            {
                return x + y;
            };
            int kq = sum(1, 2);
            Console.WriteLine(kq);

            Console.WriteLine("------------------");
            //Lambda cho Func
            Func<int, int, int> sum1 = (x, y) => x + y;
           
            int kq1 = sum1(1, 22);
            

            //Lambsa cho Action
            Action<int> alert = (int v1) =>
            {
                Console.WriteLine(v1);
            };


            alert(kq1);
        }
    }
}