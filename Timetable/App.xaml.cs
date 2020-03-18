﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Timetable.Common;
using Timetable.Model;
using Timetable.ViewModel;

namespace Timetable
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static WorkList workList = new WorkList();
        public static FileManager fileManager = new FileManager();
        public static TimetableViewModel timetableViewModel = new TimetableViewModel();
        public App()
        {
            App.workList.Load();
            App.fileManager.checkFile();
            
        }
    }
}
