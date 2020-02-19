using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Wallet
    {
        public double GetOverall  { get { return incoming - spending; } }
        private double incoming;
        private double spending;
        private int[] salaries;
        public double GetInc { get { return incoming; } }
        public double GetSpen { get { return spending; } }
        public void Spend(double spe)
        {
            spending += spe;
        }
        public void Income(double inc)
        {
            incoming += inc;
        }
        public Wallet()
        {
            salaries = new int[] { 15000, 25000, 12000 };
            incoming = 0;
            spending = 0;
        }
        public int GetSalary(int ind)
        {
            return salaries[ind];
        }
        public void SetSalary(int ind,int sal)
        {
            salaries[ind] = sal;
        }
    }
}
