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
using System.Threading;

namespace combination1.controls
{
    /// <summary>
    /// Interaction logic for timeSlider.xaml
    /// </summary>
    /// 
    public partial class timeSlider : UserControl
    {
        timeSliderViewModel vm;
        public timeSlider()
        {
            InitializeComponent();

            vm = new timeSliderViewModel(new timeSliderModel());
            DataContext = this.vm;

            /*Binding myBinding = new Binding();
            myBinding.Source = vm;
            myBinding.Path = new PropertyPath("VM_PauseButtonBackground");
            BindingOperations.SetBinding(this.prb, Button.BackgroundProperty, myBinding);*/

        }

       /* private void updateTime()
        {
            //num of lines(2174)/lines per second(20)
            double maxSecs = 108.7;
            double ratio = (this.sb.Value / 10.0);
            int totalSec = (int)(ratio * maxSecs);
            currMin = (int)(totalSec / 60);
            currSec = totalSec - (currMin * 60);
            string fmt = "00";
            string secStr = currSec.ToString();

            this.Dispatcher.Invoke(() =>
            {
                this.tl.Content = currMin.ToString() + ":" + currSec.ToString(fmt);
            });
        }*/

        /* private void dispatcherTimer_Tick(object sender, EventArgs e)
         {
             this.tl.Content = updatedTime();
         }*/

       /* private void pause()
        {
            isPaused = true;
            this.prb.Background = ibr;
        }

        private void resume()
        {
            isPaused = false;
            this.prb.Background = ibp;
        }*/

        private void d_l(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vm.handleSliderMovement(this.sb.Value);
        }

       /* private void c()
        {
            try
            {
                this.Dispatcher.Invoke(() => {
                    this.sb.Value = 0.0;
                });

                while (true)
                {
                    if (isPaused == false)
                    {
                        this.Dispatcher.Invoke(() => {
                            this.sb.Value += (double)nextIndexFactor;
                        });
                        System.Threading.Thread.Sleep((int)(regularSpeed / speedFactor));
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                //supporting a closing of the window
            }

        }*/

        private void Scb_DropDownClosed(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() => {
                string selectedVal = (string)this.scb.SelectedItem;
                this.vm.handleSpeedFactorChanged(Convert.ToDouble(selectedVal.Substring(1, selectedVal.Length - 1)));
            });
        }

        private void Rb_Click(object sender, RoutedEventArgs e)
        {
            this.vm.restart();
        }

        /*private void B_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(c));
            t.Start();
        }*/

       /* private void Eb_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }*/

        private void Prb_Click(object sender, RoutedEventArgs e)
        {
            vm.handlePauseResumeClick();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //the images in the form.
            //ImageBrush ibp = new ImageBrush();
            // ibp.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString("C:/Users/magshimim/source/repos/scrollBar/scrollBar/pause.png");
            //ImageBrush ibr = new ImageBrush();
            //ibr.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString("C:/Users/magshimim/source/repos/scrollBar/scrollBar/resume.jpg");
            ImageBrush ibrestart = new ImageBrush();
            ibrestart.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString(@"restart.jpg");
            this.rb.Background = ibrestart;

            //the regular speed - 20 lines per second
            this.scb.ItemsSource = new String[] { "X0.5", "X1", "X2" };

            Thread t = new Thread(new ThreadStart(this.vm.start));
            t.Start();
        }

        public timeSliderModel getTimeSliderModel()
        {
            return this.vm.getTimeSliderModel();
        }
    }
}
