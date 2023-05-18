using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyMembers
{
    public class Gamer : FamilyMember
    {
        public Gamer(int height, int weight) : base(height, weight)
        {
        }

        public override void HaveFun()
        {
            Console.WriteLine("I am playing game");
        }
    }
}

