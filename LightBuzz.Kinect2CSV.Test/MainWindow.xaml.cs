using Microsoft.Kinect;
using Microsoft.Win32;
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

namespace LightBuzz.Kinect2CSV.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor _sensor = null;
        KinectCSVManager _recorder = null;
        BodyFrameReader _reader = null;
        IList<Body> _bodies = null;
        private MessageBoxResult result;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _sensor = KinectSensor.GetDefault();

            if (_sensor != null)
            {
                _sensor.Open();

                _bodies = new Body[_sensor.BodyFrameSource.BodyCount];

                _reader = _sensor.BodyFrameSource.OpenReader();
                _reader.FrameArrived += BodyReader_FrameArrived;

                _recorder = new KinectCSVManager();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (_reader != null)
            {
                _reader.Dispose();
                _reader = null;
            }

            if (_sensor != null)
            {
                _sensor.Close();
                _sensor = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (_recorder.IsRecording)
            {
                _recorder.Stop();

                button.Content = "Start";

                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Excel files|*.csv"
                };

                dialog.ShowDialog();

                if (!string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    System.IO.File.Copy(_recorder.Result, dialog.FileName);
                }
            }
            else
            {
                _recorder.Start();

                button.Content = "Stop";
            }
        }

        void BodyReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            using (var frame = e.FrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    frame.GetAndRefreshBodyData(_bodies);

                    Body body = _bodies.Where(b => b != null && b.IsTracked).FirstOrDefault();

                    if (body != null)
                    {
                        _recorder.Update(body);
                    }
                }
            }
        }

        //Time for the results to be delayed. How long does the user have to wait until he gets his next window?
        async Task PutTaskDelay()
        {
            await Task.Delay(60000);
         
        }


        private async void button_Click_1(object sender, RoutedEventArgs e)
        {
            // Canvas cnv = this.nsmr
            //popUpCanvas.Visibility = Visibility.Visible;

            //Create an infinite loop for the popups to show up periodically
            while (true)
            {

                result = MessageBox.Show("Do you want to see how you are doing?", "Your results are ready to go");

                if (result == MessageBoxResult.OK)
                {
                   //Show the user his results
                   System.Diagnostics.Process.Start("https://www.wolframcloud.com/objects/user-a6c115d7-85ff-457a-89d2-1ebdd5a377db/input%20stream/bin/Debug/Input.csv");
                    Console.WriteLine("python predict.py");
                }
                if (result == MessageBoxResult.Cancel)
                {
                    break;
                }
                //Delay the loop
                await PutTaskDelay();
            }
                
            // The await causes the handler to return immediately.
           /////////////// await System.Threading.Tasks.Task.Run(() => ComputeNextMove()).
        }


        private async System.Threading.Tasks.Task ComputeNextMove()
        {
            while (true)
            {
                MessageBox.Show("mimjiksdsadas");
                //await Task.Delay(TimeSpan.FromSeconds(10));
                Task.Delay(10);

            }

            // Perform background work here.
            // Don't directly access UI elements from this method.
        }
    }
}
