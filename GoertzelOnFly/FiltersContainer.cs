using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoertzelOnTheFly {
    public class FiltersContainer {
        private GoertzelFilter[] filters;
        private StringBuilder sb = new StringBuilder();
        public FiltersContainer(double freq, double step, int count, FilterConfig filterConfig) {
            filters = new GoertzelFilter[count];
            for (int i = 0; i < count; i++) {
                filters[i] = new GoertzelFilter(freq, filterConfig);
                freq += step;
            }
        }
        public void Update(RingBuffer buffer) {
            foreach (var filter in filters) {
                filter.Update(buffer);
            }
        }
        public override string ToString() {
            sb.Clear();
            foreach (var filter in filters) {
                sb.Append(filter.ToString());
            }
            return sb.ToString();
        }

        public GoertzelFilter[] Filters { get { return filters; } }
    }
}
