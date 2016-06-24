using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoertzelOnTheFly {
    public class RingBuffer {
        private double[] values;
        private int position = 0;
        public RingBuffer(FilterConfig filterConfig) {
            values = new double[filterConfig.FrameSamplesCount];
        }
        public void PassValue(double value) {

            values[position] = value;
            position++;
            if (position >= values.Length) {
                position = 0;
            }
        }
        public double HeadValue { get { return values[position > 0 ? position - 1 : values.Length - 1]; } }
        public double TailValue { get { return values[position]; } }
        public double[] Values { get { return values; } }
    }
}
