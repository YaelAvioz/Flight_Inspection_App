using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.ComponentModel;


namespace combination1.controls
{
    //FG communication model
    class FGCommunicationModel : INotifyPropertyChanged
    {
        private const int columnNum = 42;
        private const int rowNum = 2174;
        private CSVReader csvr;
        private int currentIndex;
        Process fgp;
        Socket fgs;
        IPAddress ips;
        IPEndPoint ipes;

        public FGCommunicationModel()
        {
            csvr = new CSVReader();
            currentIndex = 0;                       //FG connection info
            ips = IPAddress.Parse("127.0.0.1");
            ipes = new IPEndPoint(ips, 5400);

            //opens the FG(from the desktop)
            fgp = new Process();
            try
            {
                //check with the user for other path(assumed that it is on the Desktop
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                fgp.StartInfo.FileName = path + "/FlightGear 2020.3.6.lnk";
                fgp.Start();
            }

            catch (Exception ex)
            {
                Console.WriteLine("excep: " + ex.Message);
            }

            this.StatusText = "Welcome to our Flight Inspection App!\nPress 'Fly!' on the FlightGear window to start loading.\nStarting the inspection WHILE LOADING won't display the flight simulation!";
        }

        //the data in the textbox
        private string statusText = "";
        public string StatusText
        {
            get
            {
                return this.statusText;
            }
            set
            {
                if (!(String.Equals(this.statusText, value)))
                {
                    this.statusText = String.Copy(value);
                    NotifyPropertyChanged("StatusText");

                    if (!(String.Equals(value, "")))
                    {
                        Thread t = new Thread(new ThreadStart(textHandler));
                        t.Start();
                    }
                }
            }
        }

        //displays the text for 10 seconds
        private void textHandler()
        {
            System.Threading.Thread.Sleep(10000);
            this.StatusText = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        bool open = false, messageTimeout = false;

        //current line - from the slider
        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set
            {
                if (this.currentIndex != value)
                {
                    this.currentIndex = value;
                    this.NotifyPropertyChanged("CurrentIndex");

                    try
                    {
                        if (open == false)
                        {
                            fgs = new Socket(ips.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                            fgs.Connect(ipes);

                            open = true;
                        }
                        
                        //sends the line to FG
                        int b = fgs.Send(Encoding.ASCII.GetBytes(csvr.getRowString(this.currentIndex) + "\n"));
                    }
                    catch (Exception e) {
                        if(messageTimeout == false)
                        {
                            this.StatusText = "Note:Press 'Fly!' on the FlightGear window to start loading the flight simulation.";
                            messageTimeout = true;
                            //wait 10 seconds and then show later
                            Thread thr = new Thread(new ThreadStart(messageShowingTimeout));
                            thr.Start();
                        }
                    }
                }
            }
        }
        
        //if the error message is already dispayed - won't display again
        public void messageShowingTimeout()
        {
            System.Threading.Thread.Sleep(10000);
            messageTimeout = false;
        }

        public void exit()
        {
            if (fgs != null)
            {
                try
                {
                    //closing the connection with the FG
                    fgs.Shutdown(SocketShutdown.Both);
                    fgs.Close();
                }
                catch(Exception e) { Console.WriteLine(rowNum.ToString()); }
            }

            //closing the FG window
            fgp.Kill();
        }

        //setting the observable - the slider
        public void setTimeSliderModel(timeSliderModel o)
        {
            o.updateIndex += delegate (int index) {
                this.CurrentIndex = index;
            };
        }
    }
}
