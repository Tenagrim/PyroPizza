using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Staff
    {
        public List<Worker> Workers { get; }
        //public List<string> Positions { get; }
        public int Count { get { return Workers.Count; } }
        private int count;
        public Staff()
        {
            Workers = new List<Worker>();
            count = 0;
        }
        public void Add()
        {
            Worker w = new Worker();
            w.SetIndex(count);
            count++;
            Workers.Add(w);
        }
        public void Add(Worker w)
        {
            w.SetIndex(count);
            count++;
            Workers.Add(w);
        }
        public void DismissWorker(int ind)
        {
            //count--;
            //Workers.RemoveAt(ind);
            Workers.RemoveAt(Workers.FindIndex(p => p.Index == ind));
        }
    }
}
