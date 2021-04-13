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
    class infoModel : INotifyPropertyChanged
    {
        private Thickness pitchSlider;
        private Thickness rollSlider;
        private Thickness yawSlider;
        private Thickness circle;
        private int currentIndex;
        CSVReader csvr = new CSVReader();

        //all the numbers in the class are starting the values according to the screen 

        public infoModel()
        {
            currentIndex = 0;

            //setting the starting values
            this.pitchSlider = new Thickness();
            pitchSlider.Bottom = 0;
            pitchSlider.Left = 168;
            pitchSlider.Right = 0;
            pitchSlider.Top = 269;

            this.rollSlider = new Thickness();
            rollSlider.Bottom = 0;
            rollSlider.Left = 168;
            rollSlider.Right = 0;
            rollSlider.Top = 294;

            this.yawSlider = new Thickness();
            yawSlider.Bottom = 0;
            yawSlider.Left = 168;
            yawSlider.Right = 0;
            yawSlider.Top = 320;

            this.circle = new Thickness();
            circle.Bottom = 0;
            circle.Left = 95;
            circle.Right = 0;
            circle.Top = 105;
        }

        //current line - from the slider
        public int CurrentIndex
        {
            get
            {
                return this.currentIndex;
            }
            set
            {
                if (this.currentIndex != value)
                {
                    this.currentIndex = value;
                    NotifyPropertyChanged("CurrentIndex");

                    //updates according to the updated data
                    setSpeed();
                    setHeight();
                    movePitch();
                    moveRoll();
                    moveYaw();
                    moveCircle();
                }
            }
        }

        private string speedValue = "";
        public string SpeedValue
        {
            get
            {

                return speedValue;

            }
            set
            {
                if (this.speedValue != value)
                {
                    speedValue = value;
                    NotifyPropertyChanged("SpeedValue");
                }
            }
        }

        private string heightValue = "";
        public string HeightValue
        {
            get
            {

                return heightValue;

            }
            set
            {
                if (this.heightValue != value)
                {
                    heightValue = value;
                    NotifyPropertyChanged("HeightValue");
                }
            }
        }

        public Thickness PitchSlider
        {
            get
            {
                return pitchSlider;
            
            }
            set
            {
                if (this.pitchSlider.Left != value.Left)
                {
                    pitchSlider.Left = 168 + value.Left;
                    NotifyPropertyChanged("PitchSlider");
                }
            }
        }

        public Thickness RollSlider
        {
            get
            {
                return rollSlider;

            }
            set
            {
                if (this.rollSlider.Left != value.Left)
                {
                    rollSlider.Left = 168 + value.Left;
                    NotifyPropertyChanged("RollSlider");
                }
            }
        }

        public Thickness YawSlider
        {
            get
            {
                return yawSlider;

            }
            set
            {
                if (this.yawSlider.Left != value.Left)
                {
                    yawSlider.Left = 168 + value.Left;
                    NotifyPropertyChanged("YawSlider");
                }
            }
        }

        public Thickness Circle
        {
            get
            {
                return this.circle;

            }
            set
            {
                if (this.circle.Left != value.Left || this.circle.Top != value.Top)
                {
                    this.circle.Left = 95 + value.Left;
                    this.circle.Top = 105 + value.Top;
                    NotifyPropertyChanged("Circle");
                }
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

        public void movePitch()
        {
            Thickness t = new Thickness();
            t.Bottom = 0;
            //for propoution on the slider
            t.Left = 5*csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/orientation/pitch-deg")];
            if(t.Left > 92)
            {
                t.Left = 92;
            }

            else if (t.Left < -92)
            {
                t.Left = -92;
            }
            t.Right = 0;
            t.Top = 269;
            this.PitchSlider = t;
        }

        public void moveRoll()
        {
            Thickness t = new Thickness();
            t.Bottom = 0;
            //for propoution on the slider
            t.Left = 2 * csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/orientation/roll-deg")];
            if (t.Left > 92)
            {
                t.Left = 92;
            }

            else if (t.Left < -92)
            {
                t.Left = -92;
            }
            t.Right = 0;
            t.Top = 303;
            this.RollSlider = t;
        }

        public void moveYaw()
        {
            Thickness t = new Thickness();
            t.Bottom = 0;
            //for propoution on the slider
            t.Left = 2 * csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/orientation/side-slip-deg")];
            if (t.Left > 92)
            {
                t.Left = 92;
            }

            else if (t.Left < -92)
            {
                t.Left = -92;
            }
            t.Right = 0;
            t.Top = 336;
            this.YawSlider = t;
        }

        public void moveCircle()
        {
            Thickness t = new Thickness();
            t.Bottom = 0;
            //for propoution on the slider
            double deg = (csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/orientation/heading-deg")])/(180/Math.PI);
          
            t.Left = (45 * Math.Sin(deg));
            t.Top = (45 * Math.Cos(deg));
           
            t.Right = 0;
            this.Circle = t;
        }

        public void setHeight()
        {
            this.HeightValue = csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/position/altitude-ft")].ToString();
        }

        public void setSpeed()
        {
            this.SpeedValue = csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/velocities/airspeed-kt")].ToString();
        }

        public void setTimeSliderModel(timeSliderModel o)
        {
            o.updateIndex += delegate (int index) {
                this.CurrentIndex = index;
            };
        }
    }
}
