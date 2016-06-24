using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oscilograph {
    public class ValuesDrawer {
        public void Draw(Graphics gr, double[] values) {
            for(int i = 1; i < values.Length;i++) {
                gr.DrawLine(Pens.White, (i - 1) * 4, (float)values[i - 1] * 128.0f + 128.0f, i * 4, (float)values[i] * 128.0f + 128.0f);
            }
        }
    }
}
