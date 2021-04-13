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
    //Time Slider view
    public partial class timeSlider : UserControl
    {
        Thread t;
        timeSliderViewModel vm;

        public timeSlider()
        {
            InitializeComponent();

            vm = new timeSliderViewModel(new timeSliderModel());
            DataContext = this.vm;
        }

        private void d_l(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vm.handleSliderMovement(this.sb.Value);
        }
        
        //picking speed
        private void Scb_DropDownClosed(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() => {
                string selectedVal = (string)this.scb.SelectedItem;
                this.vm.handleSpeedFactorChanged(Convert.ToDouble(selectedVal.Substring(1, selectedVal.Length - 1)));
            });
        }

        //restart button
        private void Rb_Click(object sender, RoutedEventArgs e)
        {
            this.vm.restart();
        }

        //pause/resume click
        private void Prb_Click(object sender, RoutedEventArgs e)
        {
            vm.handlePauseResumeClick();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //the image of the background button
            ImageBrush ibrestart = new ImageBrush();
            ibrestart.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString(@"restart.jpg");
            this.rb.Background = ibrestart;

            //the regular speed - 20 lines per second
            this.scb.ItemsSource = new String[] { "X0.5", "X1", "X2" };

            //starting the slider action
            t = new Thread(new ThreadStart(this.vm.start));
            t.Start();
        }

        public timeSliderModel getTimeSliderModel()
        {
            return this.vm.getTimeSliderModel();
        }
    }
}
