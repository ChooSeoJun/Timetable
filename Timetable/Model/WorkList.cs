using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Model
{
    public class WorkList
    {
        public bool isLoaded = false;
        public List<Work> works = null;
        public List<Work> timetable = null;

        public void Load()
        {
            if (isLoaded) return;

            works = new List<Work>()
            {
                new Work(){Name = "과제하기" ,ColorHex="#0000FF" },
                new Work(){Name = "운동하기" ,ColorHex="#00FF00" },
                new Work(){Name = "식사하기" ,ColorHex="#FF0000" }
            };

            timetable = new List<Work>();
            App.fileManager.readWorkData();

            isLoaded = true;    
        }
    }
}
