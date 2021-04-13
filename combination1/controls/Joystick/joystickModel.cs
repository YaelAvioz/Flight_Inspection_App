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
    class joystickModel : INotifyPropertyChanged
    {
        CSVReader csvr = new CSVReader();

        /* test for the joystick
        //2174 = numOfRows
        for(int i = 0; i < 2174; i++){
            this.CurrentTime = i;
            moveThrottle();
            moveRudder()
            moveVertically()
            moveHorizontally()
            
            //sleep 20 miliseconds
        }
        */

        private int currentIndex = 0;
        public int CurrentIndex
        {
            get
            {
                return currentIndex;
            }
            set
            {
                if (this.currentIndex != value)
                {
                    this.currentIndex = value;
                    NotifyPropertyChanged("CurrentIndex");

                    moveHorizontally();
                    moveRudder();
                    moveThrottle();
                    moveVertically();
                }
            }
        }

        private double elipseTop = 107;
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

        private double elipseLeft = 143;
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

        private double rect1Top = 156;
        public double Rect1Top
        {
            get
            {

                return rect1Top;

            }
            set
            {
                if (this.rect1Top != value)
                {
                    rect1Top = value;
                    NotifyPropertyChanged("Rect1Top");
                }
            }
        }

        private double rect1Left = 340;
        public double Rect1Left
        {
            get
            {

                return rect1Left;

            }
            set
            {
                if (this.rect1Left != value)
                {
                    rect1Left = value;
                    NotifyPropertyChanged("Rect1Left");
                }
            }
        }

        private double rect2Top = 264;
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

        private double rect2Left = 448;
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void moveThrottle()//check if not top
        {
            this.Rect1Top = 87 + ((138.0) * csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/controls/engines/engine[0]/throttle")]);
        }

        public void moveRudder()
        {
            this.Rect2Left = 368 + ((80.0) * csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/controls/flight/rudder")]);
        }

        public void moveVertically()
        {
            this.ElipseTop = 107 + ((-50.0) * csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/controls/flight/elevator")]);
        }

        public void moveHorizontally()
        {
            this.ElipseLeft = 143 + ((50.0) * csvr.getRow(CurrentIndex)[csvr.getFieldsNodes().IndexOf("/controls/flight/aileron[0]")]);
        }

        public void start()
        {
            for (int i = 0; i < 2174; i++)
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
