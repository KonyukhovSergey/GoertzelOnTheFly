using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoertzelOnTheFly {
    public class SignalGenerator {
        private double time = 0;
        private double DeltaTime;
        private Random rnd = new Random();

        public SignalGenerator(FilterConfig filterConfig) {
            DeltaTime = 1.0 / filterConfig.SignalFreqDisc;
        }

        //public double CurrentFreq() { return 300.0 - 200.0 * (Math.Sin(time)); }
        public double CurrentFreq() { return 100 + 50 * (Math.Round(time*2.0 % 15)); }
        //public double CurrentFreq() {  return 100.0 + 25.0 * ((time % 10.0)); }
        //public double CurrentFreq { get { return 200 + rnd.NextDouble()*1200; } }

        public double GetNextSample() {
            time += DeltaTime;
            return Math.Sin(time * 2.0 * Math.PI * CurrentFreq()) * 0.5 + 0.5;
            //            return Math.Sin(time * 2.0 * Math.PI * CurrentFreq) * 0.5 + 0.5 + Math.Sin(time * 2.0 *2.0* Math.PI * CurrentFreq) * 0.5 + 0.5;
        }
    }
}
