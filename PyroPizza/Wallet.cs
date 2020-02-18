using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    class Wallet
    {
        public double GetOverall  { get { return incoming - spending; } }
        private double incoming;
        private double spending;

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
            incoming = 0;
            spending = 0;
        }
    }
}
