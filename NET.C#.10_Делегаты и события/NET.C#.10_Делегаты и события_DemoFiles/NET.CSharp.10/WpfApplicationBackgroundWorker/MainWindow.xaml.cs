using System.ComponentModel;
using System.Windows;

namespace BackgroundWorkerClassViaWPF
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            // Alternatively you can omit the parameter types.
            bw.DoWork += ((object doWorkSender, DoWorkEventArgs doWorkArgs) =>
            {
                for (int i = 1; i <= 10; i++)
                {
                        System.Threading.Thread.Sleep(50);
                        bw.ReportProgress(i * 10);
                }
            });
            bw.ProgressChanged += ((object progressChangedSender,
            ProgressChangedEventArgs progressChangedArgs) =>
            {
                // Update label in UI with progress.
                statusBox.Content = progressChangedArgs.ProgressPercentage.ToString() + "%";
            });
            bw.RunWorkerCompleted += ((object runWorkerCompletedSender,
            RunWorkerCompletedEventArgs runWorkerCompletedArgs) =>
            {
                // Alternatively update the user interface.
                MessageBox.Show("Complete");
            });
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync();
        }
    }
}
