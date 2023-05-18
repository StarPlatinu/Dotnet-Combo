using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FamilyMembers
{
    internal class Program
    {
       public static void Main(string[] args)
        {
            FamilyMember member;
           
            List<FamilyMember> familyMembers = new List<FamilyMember>();
            member = new FamilyMember(70, 165);
            familyMembers.Add(member);
            member = new Gamer(80, 170);
            familyMembers.Add(member);
            member = new Geek(82, 175);      
            familyMembers.Add(member);

            foreach (FamilyMember familyMember in familyMembers)
            {
                familyMember.HaveFun();
            }
        }
    }
}
