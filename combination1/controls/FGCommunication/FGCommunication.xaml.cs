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
    //FG communication view
    public partial class FGCommunication : UserControl
    {
        private FGCommunicationViewModel vm;

        public FGCommunication()
        {
            InitializeComponent();

            vm = new FGCommunicationViewModel(new FGCommunicationModel());
            this.DataContext = this.vm;
        }
        
        public void setTimeSliderModel(timeSliderModel o)
        {
            this.vm.setTimeSliderModel(o);
        }

        //closes the FG window
        public void exit()
        {
            this.vm.exit();
        }
    }
}
