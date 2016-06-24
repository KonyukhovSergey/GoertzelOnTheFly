using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoertzelOnTheFly {
    public class FilterConfig {
        public double SignalFreqDisc { get; private set; } = 8000;
        public int FrameSamplesCount { get; private set; } = 160;
        public FilterConfig() {

        }
        public FilterConfig(double signalFreqDisc, int frameSamplesCount) {
            this.SignalFreqDisc = signalFreqDisc;
            this.FrameSamplesCount = frameSamplesCount;
        }
    }
}
