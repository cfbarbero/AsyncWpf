using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindingList<string> log { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            log = new BindingList<string>();
            lbDialog.ItemsSource = log;
           
        }

        private async Task GetAlert(int alertID)
        {
            log.Add("Enter GetAlert: "+alertID.ToString());

            //Get settings
            await Task.Delay(100);

            log.Add("Gotten Stuff: " + alertID.ToString());

            // simulate getting alert from webservice
            await Task.Delay(1000);
            log.Add("Gotten alert details: " + alertID.ToString());

            //Thread.Sleep(100);
            await Task.Run(() => Thread.Sleep(1000));
            log.Add("after processing: " + alertID.ToString());

            log.Add("Exit GetAlert: " + alertID.ToString());
        }

        private void Start()
        {
            log.Add("Starting");

            Task.WhenAll(from i in Enumerable.Range(1, 20)
                         select GetAlert(i));

            log.Add("End of main");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            log.Clear();
            Start();
        }
    }
}
