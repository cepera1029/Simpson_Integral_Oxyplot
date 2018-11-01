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
            if (n < 0.0)
                throw new ArgumentException("n<0");
            double h = (b - a) / n;
            double k1 = 0, k2 = 0;
            for (int i = 1; i < n; i += 2) {
                k1 += f(a + i * h);
                k2 += f(a + (i + 1) * h);
            }
            return h / 3 * (f(a) + 4 * k1 + 2 * k2);

        }

        private static IEnumerable<int> SteppedIterator(int startIndex, int endIndex, int stepSize) {
            for(int j = startIndex; j < endIndex; j += stepSize) {
                yield return j;
            }
        }

        public double calcParallel(int n, double a, double b, Func<double, double> f) {
            object monitor = new object();
            double k1 = 0, k2 = 0;
            double h = (b - a) / n;

             Parallel.ForEach(SteppedIterator(1, n, 2), () => 0.0, (i, state, local) => {
                 local += f(a + i * h);

                 return local;
             }, local => { lock (monitor) k1 += local; });

                Parallel.ForEach(SteppedIterator(1, n, 2), () => 0.0, (i, state, local) => {
                    local += f(a + (i + 1) * h);

                    return local;
                }, local => { lock (monitor) k2 += local; });


                return h / 3 * (f(a) + 4 * k1 + 2 * k2);
        }
    }
}

