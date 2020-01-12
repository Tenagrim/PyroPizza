using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Staff
    {
        List<Worker> workers;
        public Staff()
        {
            workers = new List<Worker>();
        }
    }
}
