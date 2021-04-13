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
    class infoModel : INotifyPropertyChanged
    {
        private Thickness pitchSlider;
        private Thickness rollSlider;
        private Thickness yawSlider;
        private Thickness circle;
        private int currentIndex;
        CSVReader csvr = new CSVReader();

        public infoModel()
        {
            currentIndex = 0;

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

                    setSpeed();
                    setHeight();
                    movePitch();
                    moveRoll();
                    moveYaw();
                    moveCircle();
                }
            }
        }

        private double elipseTop = 1;
        public double ElipseTop
        {
            get
            {

                return elipseTop;

            }
            set
            {
                if (this.elipseTop != value)
                {
                    elipseTop = value;
                    NotifyPropertyChanged("ElipseTop");
                }
            }
        }

        private double elipseLeft = 1;
        public double ElipseLeft
        {
            get
            {

                return elipseLeft;

            }
            set
            {
                if (this.elipseLeft != value)
                {
                    elipseLeft = value;
                    NotifyPropertyChanged("ElipseLeft");
                }
            }
        }

        private double rectTop = 192;
        public double RectTop
        {
            get
            {

                return rectTop;

            }
            set
            {
                if (this.rectTop != value)
                {
                    rectTop = value;
                    NotifyPropertyChanged("RectTop");
                }
            }
        }

        private double rectLeft = 122;
        public double RectLeft
        {
            get
            {

                return rectLeft;

            }
            set
            {
                if (this.rectLeft != value)
                {
                    rectLeft = value;
                    NotifyPropertyChanged("RectLeft");
                }
            }
        }

        private double rect2Top = 542;
        public double Rect2Top
        {
            get
            {

                return rect2Top;

            }
            set
            {
                if (this.rect2Top != value)
                {
                    rect2Top = value;
                    NotifyPropertyChanged("Rect2Top");
                }
            }
        }

        private double rect2Left = 400;
        public double Rect2Left
        {
            get
            {

                return rect2Left;

            }
            set
            {
                if (this.rect2Left != value)
                {
                    rect2Left = value;
                    NotifyPropertyChanged("Rect2Left");
                }
            }
        }

        private double rect3Top = 542;
        public double Rect3Top
        {
            get
            {

                return rect3Top;

            }
            set
            {
                if (this.rect3Top != value)
                {
                    rect3Top = value;
                    NotifyPropertyChanged("Rect3Top");
                }
            }
        }

        private double rect3Left = 400;
        public double Rect3Left
        {
            get
            {

                return rect3Left;

            }
            set
            {
                if (this.rect3Left != value)
                {
                    rect3Left = value;
                    NotifyPropertyChanged("Rect3Left");
                }
            }
        }

        private string test;
        public string Test
        {
            get
            {
                return test;
            }
            set
            {
                if (this.test != value)
                {
                    test = value;
                    NotifyPropertyChanged("Test");
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

        public void moveRoll() //TODO : update location
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

        //compass
        public void moveSN()
        {
            this.ElipseTop = 1 + ((60.0) * csvr.getRow(CurrentIndex)[1]);
        }

        public void moveWE()
        {
            this.ElipseLeft = 1 + ((60.0) * csvr.getRow(CurrentIndex)[0]);
        }

        //compass
        public void setHeight()
        {
            this.HeightValue = csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/position/altitude-ft")].ToString();
        }

        public void setSpeed()
        {
            this.SpeedValue = csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/velocities/airspeed-kt")].ToString();
        }

        public void start()
        {
            for(int i = 0; i < 2174; i++)
            {
                this.CurrentIndex = i;
                System.Threading.Thread.Sleep(20);
            }
        }

        public void setTimeSliderModel(timeSliderModel o)
        {
            o.updateIndex += delegate (int index) {
                this.CurrentIndex = index;
            };
        }
    }
}
