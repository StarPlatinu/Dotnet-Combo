using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_Slot03
{
    public class Program
    {
       public static void Main(string[] args)
        {
            Kid k;
            k = new Kid();
            k.PrintMessage();
            k = new Artistic();
            k.PrintMessage();
            k= new Disobedient();
            k.PrintMessage();
        }
    }
}
