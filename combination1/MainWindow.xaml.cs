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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
          
            //setting the models
            this.Info.setTimeSliderModel(this.timeSlider.getTimeSliderModel());
            this.Joystick.setTimeSliderModel(this.timeSlider.getTimeSliderModel());
            this.Graph.setTimeSliderModel(this.timeSlider.getTimeSliderModel());
            this.FGC.setTimeSliderModel(this.timeSlider.getTimeSliderModel());
        }

        //exit from the program
        private void ExitButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.FGC.exit();
            Environment.Exit(0);
        }
    }
}
