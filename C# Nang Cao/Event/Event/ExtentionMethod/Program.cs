using System;

namespace extention_method
{
    class Prrogram
    {
       public static void Main(String[] args)
        {
            List<int> list = new List<int>() { 1,2,3,4,5};
            list = list.Where(x => x > 3).ToList();
            foreach (int x in list) {
                Console.WriteLine(x);
            }
        }
    }
}