using GoertzelOnTheFly;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oscilograph {
    public class FiltersDrawer {
        private GoertzelFilter[] filters;

        public FiltersDrawer(GoertzelFilter[] filters) {
            this.filters = filters;
        }

        public void Draw(Graphics gr) {
            foreach(var filter in filters) {
                gr.FillRectangle(Brushes.White, (float)filter.freq, 20, 10,(float) filter.value);
                gr.DrawString(string.Format("{0:0}", filter.freq), SystemFonts.DialogFont, Brushes.Wheat, (float)filter.freq, 0);
            }
        }
    }
}
