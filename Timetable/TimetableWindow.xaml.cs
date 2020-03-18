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
using Timetable.Model;

namespace Timetable
{
    /// <summary>
    /// TimetableWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TimetableWindow : Page
    { 
        public TimetableWindow()
        {
            InitializeComponent();
            this.Loaded += Load_Timetable;
        }

        private void Load_Timetable(object sender, RoutedEventArgs e)
        {
            lstWork.ItemsSource = App.workList.works;
            DataContext = App.timetableViewModel;
        }

        private void FrameworkElement_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window main = Application.Current.MainWindow;
            Window setTime = null;
            Work work = (sender as ListViewItem).Content as Work;

            main.IsEnabled = false;
            setTime = new SetTimeWindow(work);
            setTime.Show();
        }
    }
}
