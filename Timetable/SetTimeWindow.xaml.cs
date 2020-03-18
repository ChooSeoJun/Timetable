using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Timetable.Common;
using Timetable.Model;
using Xceed.Wpf.Toolkit;

namespace Timetable
{
    /// <summary>
    /// SetTimeWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SetTimeWindow : Window
    {
        private bool isRunning;
        Work curWork = null;
        
        public SetTimeWindow()
        {
            InitializeComponent();
        }
        public SetTimeWindow(Work inputWork)
        {
            InitializeComponent();
            curWork = inputWork;
            this.Loaded += SetTime_Loaded;
        }
        private void SetTime_Loaded(object sender, RoutedEventArgs e)
        {
            DurationTimePicker.Value = DateTime.Now.Date.AddHours(1);
            StartTimePicker.Value = DateTime.Now.Date;
            StartDatePicker.DisplayDateStart = DateTime.Now.Date;
            StartDatePicker.DisplayDateEnd = DateTime.Now.Date.AddDays(6);
            StartDatePicker.SelectedDate = DateTime.Now;
            WorkName.Text = curWork.Name;
        }
        private void TimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var timePicker = sender as TimePicker;
            if (isTimeNull(timePicker))
            {
                int hour = 0;
                if (timePicker == DurationTimePicker) hour++;
                timePicker.Value = DateTime.Now.Date.AddHours(hour);
            }

            if (!isRunning)
            {
                timePicker.Format = DateTimeFormat.ShortTime;
                isRunning = true;
                DateTime curTime = (DateTime)timePicker.Value;

                if (curTime.Minute % 10 != 0) 
                {
                    double diff = 10 - int.Parse((curTime.Minute % 10).ToString());
                    timePicker.Value += TimeSpan.FromMinutes(diff);
                }
                isRunning = false;
                timePicker.Format = DateTimeFormat.Custom;
                timePicker.FormatString = "HH:mm";
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window main = System.Windows.Application.Current.MainWindow;

            main.IsEnabled = true;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate == null || StartDatePicker.SelectedDate < DateTime.Now)
                StartDatePicker.SelectedDate = DateTime.Now;

            else if (StartDatePicker.SelectedDate > DateTime.Now.AddDays(6))
                StartDatePicker.SelectedDate = DateTime.Now.AddDays(6); 

            if (System.Windows.MessageBox.Show("저장하시겠습니까?", "저장", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //StartTimePicker.Format = DateTimeFormat.ShortTime;
                //DurationTimePicker.Format = DateTimeFormat.ShortTime;
                curWork.StartDate = (DateTime)StartDatePicker.SelectedDate.Value;
                curWork.StartTime = (DateTime)StartTimePicker.Value;
                curWork.Duration = (DateTime)DurationTimePicker.Value;
                App.fileManager.writeWorkData(curWork);
                
                this.Close();
            }
        }
        private bool isTimeNull(object sender)
        {
            TimePicker time = sender as TimePicker;
            if(time.Value == null) return true;
            return false;
        }
        private bool isOverTime()
        {
            //StartTimePicker.Format = DateTimeFormat.ShortTime;
            //DurationTimePicker.Format = DateTimeFormat.ShortTime;

            DateTime sTime = (DateTime)StartTimePicker.Value;
            DateTime dTime = (DateTime)DurationTimePicker.Value;
            TimeSpan resultTime = new TimeSpan(0, 0, 0);
            resultTime = dTime.Date.TimeOfDay;
            sTime.Add(resultTime);
            Console.WriteLine(resultTime);
            //StartTimePicker.Format = DateTimeFormat.Custom;
            //DurationTimePicker.Format = DateTimeFormat.Custom;
            //StartTimePicker.FormatString = "HH:mm";
            //DurationTimePicker.FormatString = "HH:mm";
            return false;
        }
    }
}
