using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Journal
    {
        public List<JournalEntry> entries;
        public Journal() 
        {
            entries = new List<JournalEntry>();
        }
    }
}
