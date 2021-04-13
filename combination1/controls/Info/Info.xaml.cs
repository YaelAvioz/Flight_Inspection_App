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
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : UserControl
    {
        private infoViewModel vm;
        public Info()
        {
            vm = new infoViewModel(new infoModel());
            DataContext = vm;

            InitializeComponent();
        }


        public void setTimeSliderModel(timeSliderModel o)
        {
            this.vm.setTimeSliderModel(o);
        }
    }
}
