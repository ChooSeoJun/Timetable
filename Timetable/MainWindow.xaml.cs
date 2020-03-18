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

namespace Timetable
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += Init_Window;
        }

        private void Init_Window(object sender, RoutedEventArgs e)
        {
            CurrentPage.Source = new Uri("HomeWindow.xaml",UriKind.Relative);
        }

        private void TabItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string pageName = (sender as TabItem).Header.ToString() + "Window.xaml";
            Uri pageUri = new Uri(pageName,UriKind.Relative);
            CurrentPage.Source = pageUri;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.fileManager.saveWorkData();
        }
    }
}
