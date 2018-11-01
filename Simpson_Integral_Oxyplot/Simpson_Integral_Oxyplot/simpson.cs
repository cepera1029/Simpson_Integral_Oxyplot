using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpson_Integral_Oxyplot {
    public class simpson {
        double f(double x) {
            return x - Math.Log(2 * x) + 234;
        }
        public double calcPosl(int n, double a, double b, Func<double, double> f) {
            //double sum = 0;
            double h = (b - a) / n;
            double k1 = 0, k2 = 0;
            for (int i = 1; i < n; i += 2) {
                k1 += f(a + i * h);
                k2 += f(a + (i + 1) * h);
            }
            return h / 3 * (f(a) + 4 * k1 + 2 * k2);

        }

        public double calcParallel(int n, double a, double b, Func<double, double> f) {
           // double integral = 0;
            object monitor = new object();
            double k1 = 0, k2 = 0;

            double h = (b - a) / n;
            int j = 1;
            Parallel.For(j, n, () => 0.0, (i, state, local) => {
                local += f(a + i * h);

                return local;
            }, local => { lock (monitor) k1 += local; });

            Parallel.For(j, n, () => 0.0, (i, state, local) => {
                local += f(a + (i + 1) * h);

                return local;
            }, local => { lock (monitor) k2 += local; });

            return (h / 3 * (f(a) + 4 * k1 + 2 * k2)) / 2;
        }
    }
}

