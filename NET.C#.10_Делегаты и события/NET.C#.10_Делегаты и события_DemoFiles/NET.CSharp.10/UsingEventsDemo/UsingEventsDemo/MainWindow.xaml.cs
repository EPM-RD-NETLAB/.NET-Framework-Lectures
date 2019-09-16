using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UsingEventsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        Heartbeat beat;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            beat = new Heartbeat();
            beat.Beat += new BeatDelegate(beat_Beat);
            beat.Start();
        }

        void beat_Beat(object sender, HeartbeatEventArgs e)
        {
            MessageBox.Show(String.Format("Hearbeat recieved: {0}", e.Count));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (beat != null)
            {
                beat.Stop();
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (beat != null)
            {
                beat.Stop();
            }
            base.OnClosing(e);
        }
    }
}
