using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Model;

namespace Timetable.ViewModel
{
    public class TimetableViewModel
    {
        public Monday MondayPlan 
        {
            get;
            set;
        }
        public Tuesday TuesdayPlan
        {
            get;
            set;
        }
        public Wednesday WednesdayPlan
        {
            get;
            set;
        }
        public Thursday ThursdayPlan
        {
            get;
            set;
        }
        public Friday FridayPlan
        {
            get;
            set;
        }
        public Saturday SaturdayPlan
        {
            get;
            set;
        }
        public Sunday SundayPlan
        {
            get;
            set;
        }
    }
}
