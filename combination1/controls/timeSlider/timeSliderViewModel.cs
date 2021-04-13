using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Media;


namespace combination1.controls
{
    class timeSliderViewModel : INotifyPropertyChanged
    {
        private timeSliderModel m;

        public timeSliderViewModel(timeSliderModel m)
        {
            this.m = m;
            this.m.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        public double VM_CurrentSliderValue
        {//add set, its two way
            get { return m.CurentSliderValue; }
            set { this.m.CurentSliderValue = value; }
        }

        public int VM_CurrentIndex
        {
            get { return m.CurrentIndex; }
        }

        public string VM_CurrentTime
        {
            get { return m.CurrentTime; }
        }

        public double VM_CurentSpeedFactor
        {
            get { return m.CurrentSpeedFactor; } 
        }

        public bool VM_IsPaused
        {
            get { return m.IsPaused; }
        }

        public ImageBrush VM_PauseButtonBackground
        {
            get { return m.PauseButtonBackground; }
        }

        public void start()
        {
            m.start();
        }

        public void pause()
        {
            m.pause();
        }

        public void resume()
        {
            m.resume();
        }

        public void restart()
        {
            m.restart();
        }

        public void handleSliderMovement(double newValue)
        {
            this.m.handleSliderMovement(newValue);
        }

        public void handleSpeedFactorChanged(double newSpeedFactor)
        {
            this.m.CurrentSpeedFactor = newSpeedFactor;
        }

        public void handlePauseResumeClick()
        {
            this.m.handlePauseResumeClick();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public timeSliderModel getTimeSliderModel()
        {
            return this.m.getTimeSliderModel();
        }
    }
}
