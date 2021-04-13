using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace combination1.controls
{
    //Joystick model
    class joystickViewModel : INotifyPropertyChanged
    {
        private joystickModel m;
        public joystickViewModel(joystickModel m)
        {
            this.m = m;

            this.m.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        public double VM_ElipseTop
        {
            get
            {
                return m.ElipseTop;

            }
        }

        public double VM_ElipseLeft
        {
            get
            {
                return m.ElipseLeft;
            }
            
        }

        public double VM_Rect1Top
        {
            get
            {
                return m.Rect1Top;
            }
            
        }

        public double VM_Rect1Left
        {
            get
            {
                return m.Rect1Left;
            }
           
        }

        public double VM_Rect2Top
        {
            get
            {
                return m.Rect2Top;
            }
           
        }

        public double VM_Rect2Left
        {
            get
            {
                return m.Rect2Left;
            }
          
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void setTimeSliderModel(timeSliderModel o)
        {
            this.m.setTimeSliderModel(o);
        }
    }
}
