﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace combination1.controls
{
    class GraphModel : INotifyPropertyChanged
    {

        //members
        public event PropertyChangedEventHandler PropertyChanged;
        CSVReader reader;
        List<double> graphCol;
        List<double> correlativeGraphCol;
        Line regLine;
        pearsonCalc PearsCalc;
        // add anomaly detector 

        // properties
        // values to generate a chosen graph.
        public List<double> GraphCol
        {
            get { return this.graphCol; }
            // value needs to be a list of doubels
            set
            {
                if (this.graphCol != value)
                {
                    this.graphCol = value;
                    this.NotifyPropertyChanged("GraphCol");
                }

            }
        }

        // values to generate a  Correlate graph.
        public List<double> CorrelativeGraphCol
        {
            get { return this.correlativeGraphCol; }
            // value needs to be a list of doubels
            set
            {
                if (this.correlativeGraphCol != value)
                {
                    this.correlativeGraphCol = value;
                    this.NotifyPropertyChanged("CorrelativeGraphCol");
                }

            }
        }

        
        public Line RegLine
        {
            get { return this.regLine; }

            set
            {
                if (this.regLine == null || !this.regLine.cmp(value))
                {
                    this.regLine = value;
                    this.NotifyPropertyChanged("RegLine");
                }
            }
        }


        //constructor
        public GraphModel()
        {
            this.reader = new CSVReader();
            // add anomaly detector init
            this.PearsCalc = new pearsonCalc();

        }

        // methods
        public void NotifyPropertyChanged(string PropName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropName));
            }
        }

        // csvreader methods

        // return twice every colmun (84 names for 42 columns)
        public List<string> getFeildsNames()
        {
            return this.reader.getFieldsNames();
        }

        public List<string> getFeildsNode()
        {
            return this.reader.getFieldsNodes();
        }

        public List<double> getColumn(int index)
        {
            return this.reader.getColumn(index);
        }

        public List<double> getColumn(string node)
        {
            return this.reader.getColumn(node);
        }

        public List<double> getRow(int index)
        {
            return this.reader.getRow(index);
        }


        // indicate the currnet line's index.
        private int currentIndex = 0;
        public int CurrentIndex
        {
            get { return this.currentIndex; }
            set
            {
                if (this.currentIndex != value)
                {
                    this.currentIndex = value;
                    this.NotifyPropertyChanged("CurrentIndex");
                }
            }
        }

        //setting the Graphcol to the current, and domino affect setting the correlated graph and the reg line
        public void setGraphCol(int indexCol)
        {
            this.GraphCol = this.reader.getSubCol(indexCol, this.CurrentIndex);
            setCorrelativeGraphCol(indexCol, this.CurrentIndex);
            setRegLine();
        }

        // index col is the index of the selected graph col
        public void setCorrelativeGraphCol(int indexCol, int Limit)
        {
            int correlativeIndex = this.PearsCalc.maxPearson(indexCol, this.reader, Limit);
            this.CorrelativeGraphCol = this.reader.getSubCol(correlativeIndex, Limit);
        }

        public void setGraphCol(string col)
        {
            setGraphCol(reader.getFieldsNames().IndexOf(col));
        }

        // index col is the index of the selected graph col
        public void setCorrelativeGraphCol(string col, int Limit)
        {
            setCorrelativeGraphCol(reader.getFieldsNames().IndexOf(col), Limit);
        }

        // line reg methods
        public void setRegLine()
        {
            List<Point> PList = this.PearsCalc.columnToPoints(this.GraphCol, this.CorrelativeGraphCol);
            this.RegLine = this.PearsCalc.linear_reg(PList, this.GraphCol.Count());
        }
    }
}
