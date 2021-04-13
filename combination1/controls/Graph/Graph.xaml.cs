using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.IO;

namespace combination1.controls
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : UserControl
    {
        GraphViewModel Gvm;
        //dll dynamic linking declerations
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void findAnomalies();
        public Graph()
        {
            InitializeComponent();
            this.Gvm = new GraphViewModel();
            DataContext = Gvm;
        }

        //anomaly report class
        public class Anomalyreport
        {
            public string time { get; set; }
            public string feature1 { get; set; }
            public string feature2 { get; set; }

        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> l = Gvm.getComboboxNames();
            var combo = sender as ComboBox;
            combo.ItemsSource = l;
            combo.SelectedIndex = 1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = sender as ComboBox;
            Gvm.VM_GraphIndex = selectedItem.SelectedIndex;
        }

        private void dllButton_Click(object sender, RoutedEventArgs e)
        {
            //loading dynamicaly the dll file
            IntPtr pDll = NativeMethods.LoadLibrary(@dllTextBox.Text);

            //if (pDll == IntPtr.Zero)

            //setting pointer to the method in the dll according to interface
            IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, "findAnomalies");

            //if(pAddressOfFunctionToCall == IntPtr.Zero)

            //creating the function from the dll
            findAnomalies fa = (findAnomalies)Marshal.GetDelegateForFunctionPointer(
            pAddressOfFunctionToCall,
            typeof(findAnomalies));

            fa();

            bool result = NativeMethods.FreeLibrary(pDll);

            //showing the content of the output file
            string algorithmName = System.IO.Path.GetFileName(dllTextBox.Text);
            algorithmName = algorithmName.Substring(0, algorithmName.IndexOf('.'));
            //algorithmName = "DLL name: " + algorithmName;
            algoTextBox.Text = algorithmName;
            string[] lines = System.IO.File.ReadAllLines(@"output.txt");
            string time = "";
            string feature1 = "";
            string feature2 = "";
            int dollarIndex;
            int spaceIndex;
            int lastSpaceIndex;

            if (!(dllDataGrid.Items.IsEmpty))
            {
                dllDataGrid.Items.Clear();
            }

            foreach (string line in lines)
            {
                if (line.CompareTo("Done.") != 0)
                {
                    dollarIndex = line.IndexOf('$');
                    spaceIndex = line.IndexOf(' ');
                    lastSpaceIndex = line.LastIndexOf(" ");
                    time = line.Substring(0, spaceIndex);
                    
                    //converting row index to time
                    double timeDouble = Convert.ToDouble(time);
                    timeDouble = timeDouble / 217.4;
                    double maxSecs = 108.7;
                    double ratio = (timeDouble / 10.0);
                    int totalSec = (int)(ratio * maxSecs);
                    double currMin = (int)(totalSec / 60);
                    double currSec = totalSec - (currMin * 60);
                    string fmt = "00";
                    string secStr = currSec.ToString();
                    time = currMin.ToString() + ":" + currSec.ToString(fmt);

                    feature1 = line.Substring(spaceIndex + 1, dollarIndex - spaceIndex - 1);
                    feature2 = line.Substring(dollarIndex + 1);
                    Anomalyreport ar = new Anomalyreport();
                    ar.time = time;
                    ar.feature1 = feature1;
                    ar.feature2 = feature2;
                    dllDataGrid.Items.Add(ar);
                }
            }

            foreach (DataGridColumn col in dllDataGrid.Columns)
            {
                col.Width = new DataGridLength(1.0, DataGridLengthUnitType.Auto);
            }

        }

        private void algoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            algoTextBox.Background = Brushes.LightGreen;
        }

        public void setTimeSliderModel(timeSliderModel o)
        {
            this.Gvm.setTimeSliderModel(o);
        }
    }
}
