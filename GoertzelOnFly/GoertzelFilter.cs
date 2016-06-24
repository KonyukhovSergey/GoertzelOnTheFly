using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoertzelOnTheFly {
    public class GoertzelFilter {
        private double i0, i1, q0, q1;
        private double a, b,k0;
        public double freq, value;
        public GoertzelFilter(double frequence, FilterConfig filterConfig) {
            k0 = filterConfig.FrameSamplesCount * frequence / filterConfig.SignalFreqDisc;
            a = 0.9995 * Math.Cos(2.0 * Math.PI * k0 / filterConfig.FrameSamplesCount);
            b = 0.9995 * Math.Sin(2.0 * Math.PI * k0 / filterConfig.FrameSamplesCount);
            this.freq = frequence;
        }
        public double Update(RingBuffer buffer) {
            i0 = i1;
            q0 = q1;
            double u = i0 + buffer.HeadValue - buffer.TailValue;
            i1 = u * a - b * q0;
            q1 = u * b + a * q0;
            value = Math.Sqrt(i1 * i1 + q1 * q1) / k0;
            return value;
        }

        public override string ToString() {
            return string.Format("\t{0:0}", value);
            //            return string.Format("f={0:0.00}\t v={1:0.00}\t", freq, value);
        }
    }

}
