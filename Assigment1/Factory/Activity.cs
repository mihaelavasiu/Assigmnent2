using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment1.Factory
{
    public class Activity
    {
        public int id;
        public DateTime d1;
        public DateTime d2;

        public Activity(int id, DateTime d1, DateTime d2)
        {
            // TODO: Complete member initialization
            this.id = id;
            this.d1 = d1;
            this.d2 = d2;
        }
    }
}
