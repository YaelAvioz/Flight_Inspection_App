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
    //Joystick view
    public partial class joystick : UserControl
    {
        private joystickViewModel vm;
        public joystick()
        {
            this.vm = new joystickViewModel(new joystickModel());
            DataContext = vm;

            InitializeComponent();
        }

        public void setTimeSliderModel(timeSliderModel o)
        {
            this.vm.setTimeSliderModel(o);
        }
    }
}
