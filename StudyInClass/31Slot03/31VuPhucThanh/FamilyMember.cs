using System;

namespace FamilyMembers { 
    public class FamilyMember
    {
        #region Fields
        int height;
        int weight;

        #endregion

        #region Consructor
        public FamilyMember(int height, int weight)
        {
            this.height = height;
            this.weight = weight;
        }
        #endregion

        public virtual void HaveFun()
        {
            Console.WriteLine("I am writing code!");
        }
    }
}
