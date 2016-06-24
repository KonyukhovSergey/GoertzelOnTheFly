using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoertzelOnTheFly {
    class Program {
        static void Main(string[] args) {

                FilterConfig filterConfig = new FilterConfig(8000, 80);
                SignalGenerator signalGenerator = new SignalGenerator(filterConfig);

                FiltersContainer filters = new FiltersContainer(50, 50, 20, filterConfig);
                RingBuffer signalBuffer = new RingBuffer(filterConfig);

            //for (int i = 0; i < 16000; i++)
            int i = 0;
            while (true) {
//                System.Threading.Thread.Sleep(10);
                signalBuffer.PassValue(signalGenerator.GetNextSample());
                filters.Update(signalBuffer);
                //Console.Write("\r");

                i++;
                if (i >= 1000) {
                    Console.Write(filters.ToString());
                    Console.Write("\t freq = " + signalGenerator.CurrentFreq());
                    //Console.WriteLine();
                    Console.ReadLine();
                    i = 0;
                }

            }

        }
    }
}
