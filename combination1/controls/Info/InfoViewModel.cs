using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows;

namespace combination1.controls
{
    class infoViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private infoModel m;
        public infoViewModel(infoModel m)
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

        public double VM_RectTop
        {
            get
            {
                return m.RectTop;
            }

        }

        public double VM_RectLeft
        {
            get
            {
                return m.RectLeft;
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

        public double VM_Rect3Top
        {
            get
            {
                return m.Rect3Top;
            }

        }

        public double VM_Rect3Left
        {
            get
            {
                return m.Rect3Left;
            }

        }

        public string VM_Test
        {
            get
            {
                return m.Test;
            }
        }

        public string VM_SpeedValue
        {
            get
            {
                return this.m.SpeedValue;
            }
        }

        public string VM_HeightValue
        {
            get
            {
                return this.m.HeightValue;
            }
        }

        public Thickness VM_PitchSlider
        {
            get
            {
                return this.m.PitchSlider;

            }
           
        }

        public Thickness VM_RollSlider
        {
            get
            {
                return this.m.RollSlider;

            }

        }

        public Thickness VM_YawSlider
        {
            get
            {
                return this.m.YawSlider;

            }

        }

        public Thickness VM_Circle
        {
            get
            {
                return this.m.Circle;
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

        public void start()
        {
            this.m.start();
        }

        public void setTimeSliderModel(timeSliderModel o)
        {
            this.m.setTimeSliderModel(o);
        }
    }
}
