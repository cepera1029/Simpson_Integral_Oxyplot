using OxyPlot;
using OxyPlot.Series;
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
using System.Windows.Shapes;
using System.Diagnostics;

namespace Simpson_Integral_Oxyplot {
    /// <summary>
    /// Interaction logic for graph_single.xaml
    /// </summary>
    public partial class graph_single : Window {
        public graph_single() {
            InitializeComponent();
        }
        public void culc() {
            (graph1.Model.Series[0] as LineSeries).Points.Clear();
            Stopwatch timer = new Stopwatch();
            int n = 100000;
            int nn = n;
            double In1 = 0;
            int kol = 7;
            double a = 1;
            double b = 100000;
            Random rnd = new Random();
            simpson integ = new simpson();
            for (int k = 0; k < kol; k++) {


                timer.Start();
                In1 = integ.calcPosl(n, a, b, x => x - Math.Log(2 * x) + 234);
                timer.Stop();
                (graph1.Model.Series[0] as LineSeries).Points.Add(new DataPoint(timer.ElapsedMilliseconds, n / nn));
                timer.Reset();

                //graph2.InvalidatePlot();
                // MessageBox.Show(In1 + "  " + In2);
                n *= 2;
            }
            graph1.InvalidatePlot();
        }
    }
}
