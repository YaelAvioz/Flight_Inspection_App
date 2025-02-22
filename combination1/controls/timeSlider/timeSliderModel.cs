﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace combination1.controls
{
    //Time Slider model
    public class timeSliderModel : INotifyPropertyChanged
    {
        bool maxSliderValue = false;
        private const double nextIndexFactor = 5.0 / 1087.0;
        private const double regularSpeed = 50.0;

        public delegate void timeSliderDelgate(int index);
        public event timeSliderDelgate updateIndex;

        private ImageBrush pauseButtonBackground = null;
        public ImageBrush PauseButtonBackground
        {
            get { return this.pauseButtonBackground; }
            set
            {
                if (this.pauseButtonBackground != value)
                {
                    this.pauseButtonBackground = value;
                    this.NotifyPropertyChanged("PauseButtonBackground");
                }
            }
        }
        
        private bool isPaused = false;
        public  bool IsPaused
        {
            get { return this.isPaused; }
            set
            {
                if (this.isPaused != value)
                {
                    this.isPaused = value;
                    this.NotifyPropertyChanged("IsPaused");

                    //updating when pausing/resuming - changing the image of the button
                    ImageBrush ib = new ImageBrush();

                    if (value == true)
                    {
                        ib.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString(@"resume.jpg");
                    }

                    else if (value == false)
                    {
                        ib.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString(@"pause.png");
                    }

                    ib.Freeze();
                    PauseButtonBackground = ib;
                }
            }
        }

        private double curentSliderValue = 0.0;
        public double CurentSliderValue
        {
            get { return this.curentSliderValue; }
            set
            {
                if (this.curentSliderValue != value)
                {
                    this.curentSliderValue = value;
                    this.NotifyPropertyChanged("CurrentSliderValue");
                }
            }
        }

        private int currentIndex = 0;
        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set
            {
                if(this.currentIndex != value)
                {
                    this.currentIndex = value;
                    this.NotifyPropertyChanged("CurrentIndex");

                    //notify all models
                    if(updateIndex != null)
                    {
                        updateIndex(this.currentIndex);
                    }
                }
            }
        }

        private string currentTime = "0:00";
        public string CurrentTime
        {
            get { return this.currentTime; }
            set
            {
                if (!(String.Equals(this.currentTime, value)))
                {
                    this.currentTime = String.Copy(value);
                    this.NotifyPropertyChanged("CurrentTime");
                }
            }
        }

        private double currentSpeedFactor = 1;
        public double CurrentSpeedFactor
        {
            get { return this.currentSpeedFactor; }
            set
            {
                if (currentSpeedFactor != value)
                {
                    this.currentSpeedFactor = value;
                    this.NotifyPropertyChanged("CurrentSpeedFactor");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        //the starting method
        public void start()
        {
            //pauses at the start
            pause();
            try
            {
                //handeling the slider - and counting pauses/changing of speed
                while (true)
                {
                    
                    if (IsPaused == false)
                    {
                        this.CurentSliderValue += (double)nextIndexFactor;
                        updateTime();
                        System.Threading.Thread.Sleep((int)(regularSpeed / this.CurrentSpeedFactor));
                    }

                }
            }

            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                //supporting a closing of the window
            }

        }

        //updating the presented time according to the slider value
        public void updateTime()
        {
            double maxSecs = 108.7;
            double ratio = (this.curentSliderValue / 10.0);
            int totalSec = (int)(ratio * maxSecs);
            double currMin = (int)(totalSec / 60);
            double currSec = totalSec - (currMin * 60);
            string fmt = "00";
            string secStr = currSec.ToString();

            this.CurrentTime = currMin.ToString() + ":" + currSec.ToString(fmt);
        }

        public void pause()
        {
            this.IsPaused = true;
        }

        public void resume()
        {
            this.IsPaused = false;
        }

        public void restart()
        {
            this.CurentSliderValue = 0.0;
            pause();
        }

        public void handleSliderMovement(double newValue)
        {
            updateTime();

            if (newValue < 10 && maxSliderValue == true)
            {
                maxSliderValue = false;
            }

            //calculate the new line, sending the new line
            double currentIndex = newValue * 217.4;
            int ind = (int)currentIndex;
            if (ind == 2174)
            {
                ind--;
                maxSliderValue = true;
                pause();
            }

            this.CurrentIndex = ind;
        }

        public void handlePauseResumeClick()
        {
            if(this.IsPaused == true)
            {
                resume();
            }

            else if (this.IsPaused == false)
            {
                pause();
            }
        }

        public timeSliderModel getTimeSliderModel()
        {
            return this;
        }
    }
}
