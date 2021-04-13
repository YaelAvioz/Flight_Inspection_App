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
    class FGCommunicationModel : INotifyPropertyChanged
    {
        private const int columnNum = 42;
        private const int rowNum = 2174;
        private CSVReader csvr;
        private int currentIndex = 0;
        Process fgp;
        Socket fgs;
        IPAddress ips;
        IPEndPoint ipes;

        public FGCommunicationModel()
        {
            csvr = new CSVReader();
            currentIndex = 0;
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
            }            this.StatusText = "Welcome to our Flight Inspection App!\nPress 'Fly!' on the FlightGear window to start loading.\nStarting the inspection WHILE LOADING won't display the flight simulation!";

            Thread thr = new Thread(new ThreadStart(FG_Loading_Status));
            thr.Start();            //connect to fg
            ips = IPAddress.Parse("127.0.0.1");
            ipes = new IPEndPoint(ips, 5400);
            /*fgs = new Socket(ips.AddressFamily, SocketType.Stream, ProtocolType.Tcp);*/

        }

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

        public void sendFlightData()
        {
            //connect to fg
            IPAddress ips = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipes = new IPEndPoint(ips, 5400);
            Socket fgs = new Socket(ips.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                fgs.Connect(ipes);

                // Release the socket.  
                fgs.Shutdown(SocketShutdown.Both);
                fgs.Close();
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected exception : {0}", ex.ToString());
            }
        }

        public void FG_Loading_Status()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipe = new IPEndPoint(ip, 6400);
            Socket fg = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                fg.Bind(ipe);
                fg.Listen(10);

                //Waiting connection ...
                Socket clientSocket = fg.Accept();

                // Data buffer
                byte[] bytes = new Byte[1024];
                string data = null;

                //the property "vertical-speed-indicator"
                //negative when it loaded
                double d = 0.0;
                while (d >= 0)
                {
                    //Console.WriteLine("connected");
                    int numByte = clientSocket.Receive(bytes);

                    data = Encoding.ASCII.GetString(bytes,
                                               0, numByte);

                    string[] tokens = data.Split(',');
                    d = Convert.ToDouble(tokens[40]);
                }

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //FG loaded
            this.StatusText = "Flightgear loaded\nThe flight simulation can be seen at the FlightGear window!";
        }

        public void start()
        {
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

            //UNABLE THE START BUTTON ON SLIDER
            //this.StatusText = "Press 'Fly!' on the FlightGear window to start loading";
            this.StatusText = "Welcome to our Flight Inspection App!\nPress 'Fly!' on the FlightGear window to start loading.\nStarting the inspection WHILE LOADING won't display the flight simulation!";

            Thread thr = new Thread(new ThreadStart(FG_Loading_Status));
            thr.Start();
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
                        /*bool part1 = fgs.Poll(1000, SelectMode.SelectRead);
                        bool part2 = (fgs.Available == 0);
                        if (part1 && part2)
                        {
                            fgs = new Socket(ips.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                            fgs.Connect(ipes);
                        }*/

                        int b = fgs.Send(Encoding.ASCII.GetBytes(csvr.getRowString(this.currentIndex) + "\n"));
                    }
                    catch (Exception e) {
                        if(messageTimeout == false)
                        {
                            this.StatusText = "Note:Press 'Fly!' on the FlightGear window to start loading the flight simulation.";
                            messageTimeout = true;//wait 10 seconds and then show later
                            Thread thr = new Thread(new ThreadStart(messageShowingTimeout));
                            thr.Start();
                        }
                    }
                }
            }
        }

        public void messageShowingTimeout()
        {
            System.Threading.Thread.Sleep(10000);
            messageTimeout = false;
        }

        public void exit()
        {
            if (fgs != null)
            {
                //closing the connection with the FG
                fgs.Shutdown(SocketShutdown.Both);
                fgs.Close();
            }

            //closing the main window and the FG window
            fgp.Kill();
        }

        public void setTimeSliderModel(timeSliderModel o)
        {
            o.updateIndex += delegate (int index) {
                this.CurrentIndex = index;
            };
        }
    }
}
