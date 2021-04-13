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

namespace combination1
{
    // king ido
    //try
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            
          // ImageBrush ibrestart = new ImageBrush();
           // ibrestart.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString("C:/Users/magshimim/source/repos/combination1/combination1/flight.jpg");
           // this.Background = ibrestart;

            this.Info.setTimeSliderModel(this.timeSlider.getTimeSliderModel());
            this.Joystick.setTimeSliderModel(this.timeSlider.getTimeSliderModel());
            this.Graph.setTimeSliderModel(this.timeSlider.getTimeSliderModel());
            this.FGC.setTimeSliderModel(this.timeSlider.getTimeSliderModel());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //close everything
        }
    }
}
