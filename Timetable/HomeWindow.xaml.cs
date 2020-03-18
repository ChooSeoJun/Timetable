using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Timetable
{
    /// <summary>
    /// HomeWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HomeWindow : Page
    {
        public HomeWindow()
        {
            InitializeComponent();
            this.Loaded += Home_Init;
        }

        private void Home_Init(object sender, RoutedEventArgs e)
        {
            timeLoading();
        }
        
        private void timeLoading()
        {
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += timer_Tick;
            t.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string currentTime = now.ToString("HH:mm:ss"); //yyyy년 MM월 dd일

            Timer.Text = currentTime;
        }
    }
}
