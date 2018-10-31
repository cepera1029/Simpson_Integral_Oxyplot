using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpson_Integral_Oxyplot {
    public class simpson {
        public double F(double x) {
            return 2 * x - Math.Log(2*x) + 234;
        }
        public static double calcPosl(int n, double a, double b, Func<double, double> f) {
            double sum = 0;
            double h = (b - a) / n;
            for (int i = 0; i < n; i++)
                sum += f(a + h * i) + 4 * f(a + h * (i + 0.5)) + f(a + h * (i + 1)) * h / 6;
            return sum;
        }

        public static double calcParallel(int n, double a, double b, Func<double, double> f) {
            double sum = 0;
            double h = (b - a) / n;
            int i = 0;
            Parallel.For(i, n, y => {
                sum += f(a + h * i) + 4 * f(a + h * (i + 0.5)) + f(a + h * (i + 1)) * h / 6;
            });
            return sum;
        }
    }
}

