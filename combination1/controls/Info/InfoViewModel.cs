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
    //Flight information model
    class infoViewModel : INotifyPropertyChanged
    {
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

        public void setTimeSliderModel(timeSliderModel o)
        {
            this.m.setTimeSliderModel(o);
        }
    }
}
