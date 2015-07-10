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
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

namespace StopWatch
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //  DispatcherTimer setup
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();
        }

        Stopwatch stopWatch = new Stopwatch();
        string elapsedTime;
        TimeSpan ts;
       
        private void StartTimer(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ts = stopWatch.Elapsed;
            FormatTime();

            TimeLabel.Content = elapsedTime;
        }

        private void StopTimer(object sender, RoutedEventArgs e)
        {
            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            FormatTime();

            TimeLabel.Content = elapsedTime;
        }

        private void FormatTime()
        {
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:0}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 100);
        }
    }
}
