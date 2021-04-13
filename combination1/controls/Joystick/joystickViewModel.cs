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
    class joystickViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private joystickModel m;
        public joystickViewModel(joystickModel m)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///

            this.m = m;

            this.m.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };

            //List<string> cols = cSV.getFieldsNodes();
            //foreach (var item in cols)
            //{
            //    List<string> rows=cSV.
            //}
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

        public string VM_Test
        {
            get
            {
                return m.Test;
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
