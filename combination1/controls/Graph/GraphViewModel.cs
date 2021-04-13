using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace combination1.controls
{
    class GraphViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //members
        GraphModel model;
        int graphIndex;
        //int time = 2100;//sposed to be global time variable
        FunctionSeries originalFs;
        FunctionSeries corelFs;
        FunctionSeries regFs;

        //constructor
        public GraphViewModel()
        {
            this.model = new GraphModel();
            this.MyModel = new PlotModel { Title = "original" };
            // original graph design
            this.MyModel.TitleColor = OxyColors.Green;
            this.MyModel.PlotAreaBackground = OxyColors.LightGray;
            this.CorelatedModel = new PlotModel { Title = "correlated" };
            // Corelate graph design
            this.CorelatedModel.TitleColor = OxyColors.Green;
            this.CorelatedModel.PlotAreaBackground = OxyColors.LightGray;
            this.RegModel = new PlotModel { Title = "regline" };
            // reg line graph design
            this.RegModel.TitleColor = OxyColors.Green;
            this.RegModel.PlotAreaBackground = OxyColors.LightGray;
            //zoom in inside the reg graph for values between -500:500
            this.RegModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = -500, Maximum = 500 });
            this.RegModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -500, Maximum = 500 });
            this.model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

        }

        //properties - GraphCol, CorrelativeGraphCol, RegLine
        public PlotModel MyModel { get; private set; }
        public PlotModel CorelatedModel { get; private set; }
        public PlotModel RegModel { get; private set; }
        public List<double> VM_GraphCol
        {
            get { return this.model.GraphCol; }
        }
        public List<double> VM_CorrelativeGraphCol
        {
            get { return this.model.CorrelativeGraphCol; }
        }

        public Line RegLine
        {
            get { return this.model.RegLine; }
        }
        
        public int VM_CurrentIndex
        {
            get { return this.model.CurrentIndex; }
            set
            {
                if (this.model.CurrentIndex != value)
                {
                    this.model.CurrentIndex = value;

                    this.model.setGraphCol(VM_GraphIndex);
                    originalGraphUpdate();
                    correlatedGraphUpdate();
                    regLineGraphUpdate();
                }
            }
        }

        public int VM_GraphIndex
        {
            get { return this.graphIndex; }
            set
            {
                if (this.graphIndex != value)
                {
                    this.graphIndex = value;
                    this.model.setGraphCol(value);

                    originalGraphUpdate();
                    correlatedGraphUpdate();
                    regLineGraphUpdate();
                }
            }
        }

        // methods
        public void NotifyPropertyChanged(string PropName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropName));
            }
        }

        public List<string> getComboboxNames()
        {
            return this.model.getFeildsNames().GetRange(0, 42);
        }

        //filling the data of the graph
        public void addDataFirstGraph()
        {
            if (this.originalFs != null)
            {
                this.originalFs.Points.Clear();
            }

            for (int i = 0; i < this.VM_CurrentIndex; i++)
            {
                this.originalFs.Points.Add(new DataPoint(i, VM_GraphCol[i]));
            }
        }

        public void addDataCorelatedGraph()
        {
            if (this.corelFs != null)
            {
                this.corelFs.Points.Clear();
            }

            for (int i = 0; i < this.VM_CurrentIndex; i++)
            {
                this.corelFs.Points.Add(new DataPoint(i, VM_CorrelativeGraphCol[i]));
            }
        }

        public void addPointsRegGraph()
        {
            int colSize = this.VM_GraphCol.Count();
            //int colSize = 2;
            if (colSize >= 30)
            {
                for (int i = colSize - 30; i < colSize; i++)
                {
                    this.RegModel.Annotations.Add(new OxyPlot.Annotations.EllipseAnnotation
                    {
                        X = VM_GraphCol[i],
                        Y = VM_CorrelativeGraphCol[i],
                        Width = 60,
                        Height = 60,
                        Fill = OxyColors.Transparent,
                        Stroke = OxyColors.Blue,
                        StrokeThickness = 2
                    });
                }
            }
            else
            {
                for (int i = 0; i < colSize; i++)
                {
                    this.RegModel.Annotations.Add(new OxyPlot.Annotations.EllipseAnnotation
                    {
                        X = VM_GraphCol[i],
                        Y = VM_CorrelativeGraphCol[i],
                        Width = 60,
                        Height = 60,
                        Fill = OxyColors.Transparent,
                        Stroke = OxyColors.Blue,
                        StrokeThickness = 2
                    });
                }
            }
        }

        void originalGraphUpdate()
        {
            //original change
            if (this.originalFs != null)
            {
                this.MyModel.Series.Remove(this.originalFs);
            }

            this.originalFs = new FunctionSeries();
            addDataFirstGraph();
            this.MyModel.Series.Add(this.originalFs);
            this.MyModel.InvalidatePlot(true);
        }

        void correlatedGraphUpdate()
        {
            if (this.corelFs != null)
            {
                this.CorelatedModel.Series.Remove(this.corelFs);
            }
            this.corelFs = new FunctionSeries();
            addDataCorelatedGraph();
            this.CorelatedModel.Series.Add(this.corelFs);
            this.CorelatedModel.InvalidatePlot(true);
        }

        void regLineGraphUpdate()
        {
            if (this.regFs != null)
            {
                this.RegModel.Series.Remove(this.regFs);
                this.RegModel.Annotations.Clear();
            }
            this.regFs = new FunctionSeries(x => this.model.RegLine.getA() * x + this.model.RegLine.getB(), -10000, 10000, 0.5);
            this.RegModel.Series.Add(this.regFs);
            //points annotation
            addPointsRegGraph();
            this.RegModel.InvalidatePlot(true);
        }

        public void setTimeSliderModel(timeSliderModel o)
        {
            o.updateIndex += delegate (int index) {
                this.VM_CurrentIndex = index;
            };
        }
    }
}
