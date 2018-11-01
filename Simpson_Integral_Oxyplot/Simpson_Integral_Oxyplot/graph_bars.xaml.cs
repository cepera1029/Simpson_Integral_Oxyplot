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
    /// Interaction logic for graph_bars.xaml
    /// </summary>
    public partial class graph_bars : Window {
        public graph_bars() {
            InitializeComponent();
        }

        public void culc() {

            Stopwatch timer = new Stopwatch();
            int n = 100000;
            int nn = n;
            double a = 1;
            double b = 100000;
            double In1 = 0;
            int kol = 7;
            simpson integ = new simpson();
            (graph3.Model.Series[0] as ColumnSeries).Items.Clear();
            (graph3.Model.Series[1] as ColumnSeries).Items.Clear();
            for (int k = 0; k < kol; k++) {


                timer.Start();
                In1 = integ.calcParallel(n, a, b, x => x - Math.Log(2 * x) + 234);
                timer.Stop();
                (graph3.Model.Series[0] as ColumnSeries).Items.Add(new ColumnItem(timer.ElapsedMilliseconds, n / nn - 1));
                timer.Reset();

                // graph3.InvalidatePlot();

                timer.Start();
                In1 = integ.calcPosl(n, a, b, x => x - Math.Log(2 * x) + 234);
                timer.Stop();
                //  (graph3.Model.Series[0] as ColumnSeries).Background.color

                (graph3.Model.Series[1] as ColumnSeries).Items.Add(new ColumnItem(timer.ElapsedMilliseconds, n / nn - 1));
                timer.Reset();

                graph3.InvalidatePlot();
                // MessageBox.Show(Convert.ToString(k));

                n *= 2;
            }

        }
    }
}
