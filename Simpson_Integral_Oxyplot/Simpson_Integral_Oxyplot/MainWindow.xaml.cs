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
using System.Diagnostics;

namespace Simpson_Integral_Oxyplot {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        public double F(double x) {
            return 2 * x - Math.Log(2 * x) + 234;
        }

        void Default() {
            _resultText.Text = "";
            _timeText.Text = "";

        }

        void Calculate() {
            simpson integral = new simpson();
            int n = Convert.ToInt32(this._n.Text);
            double In;
            double a = 1;
            double b = 100;
            Stopwatch timer = new Stopwatch();
            if (_check.IsChecked.Value == true) {
                timer.Start();
                In = integral.calcParallel(n, a, b, x => 2 * x - Math.Log(2 * x) + 234);
                timer.Stop();
                this._resultText.Text = Convert.ToString(In);
                this._timeText.Text = Convert.ToString(timer.ElapsedMilliseconds);
                timer.Reset();
            }
            if (_check.IsChecked.Value == false) {
                timer.Start();
                In = integral.calcPosl(n, a, b, x => 2 * x - Math.Log(2 * x) + 234);
                timer.Stop();
                this._resultText.Text = Convert.ToString(In);
                this._timeText.Text = Convert.ToString(timer.ElapsedMilliseconds);
                timer.Reset();
            }



        }

        private void ButtonCulc_Click(object sender, RoutedEventArgs e) {

            try {
                Convert.ToDouble(_n.Text);
            }
            catch {
                MessageBox.Show("Введите целое число");
                return;
            }

            {
                Default();
                Calculate();
            }

        }
        graph_single posl = new graph_single();
        graph_parallel paral = new graph_parallel();
        graph_bars bar = new graph_bars();


        private void PoslGraph_Click(object sender, RoutedEventArgs e) {
            //posl.Hide();
            posl.culc();
            posl.Show();

        }

        private void ParalGraph_Click(object sender, RoutedEventArgs e) {
            // paral.Hide();
            paral.culc();
            paral.Show();
        }

        private void barGraph_Click(object sender, RoutedEventArgs e) {
            //bar.Hide();
            bar.culc();
            bar.Show();

        }
    }
}
