using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Dj
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DJId { get; set; }
        public double Duration { get; set; }

        public virtual DJ DJ { get; set; }
    }
}
