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
using System.Threading;


namespace combination1.controls
{
    /// <summary>
    /// Interaction logic for FGCommunication.xaml
    /// </summary>
    public partial class FGCommunication : UserControl
    {
        private FGCommunicationViewModel vm;

        public FGCommunication()
        {
            InitializeComponent();

            vm = new FGCommunicationViewModel(new FGCommunicationModel());
            this.DataContext = this.vm;
        }

        private void b_click(object sender, RoutedEventArgs e)
        {
            Thread thr = new Thread(new ThreadStart(this.vm.sendFlightData));
            thr.Start();

        }

        public void setTimeSliderModel(timeSliderModel o)
        {
            this.vm.setTimeSliderModel(o);
        }

        public void exit()
        {
            this.vm.exit();
        }
    }
}
