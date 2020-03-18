using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Model
{
    interface Day
    {
        List<Work> Works
        {
            get;
            set;
        }
    }
    public class Monday : BindableBase , Day
    {
        private List<Work> _works;
        public List<Work> Works { get=>_works; set => SetProperty(ref _works,value); }
    }
    public class Tuesday : BindableBase, Day
    {
        private List<Work> _works;
        public List<Work> Works { get => _works; set => SetProperty(ref _works, value); }
    }
    public class Wednesday : BindableBase, Day
    {
        private List<Work> _works;
        public List<Work> Works { get => _works; set => SetProperty(ref _works, value); }
    }
    public class Thursday : BindableBase, Day
    {
        private List<Work> _works;
        public List<Work> Works { get => _works; set => SetProperty(ref _works, value); }
    }
    public class Friday : BindableBase, Day
    {
        private List<Work> _works;
        public List<Work> Works { get => _works; set => SetProperty(ref _works, value); }
    }
    public class Saturday : BindableBase, Day
    {
        private List<Work> _works;
        public List<Work> Works { get => _works; set => SetProperty(ref _works, value); }
    }
    public class Sunday : BindableBase, Day
    {
        private List<Work> _works;
        public List<Work> Works { get => _works; set => SetProperty(ref _works, value); }
    }
}
