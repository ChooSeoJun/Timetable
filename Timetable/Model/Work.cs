using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Model
{
    public class Work
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Duration { get; set; }
        public string ColorHex { get; set; }
    }
}
