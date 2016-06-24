using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoertzelOnTheFly;

namespace oscilograph {
    public partial class Form1 : Form {

        private FilterConfig filterConfig = new FilterConfig(8000, 160);
        private SignalGenerator signalGenerator;
        private FiltersContainer filters;
        private RingBuffer signalBuffer;
        private ValuesDrawer vd;
        private FiltersDrawer fd;

        public Form1() {
            InitializeComponent();
            DoubleBuffered = true;
            ResizeRedraw = true;

            signalGenerator = new SignalGenerator(filterConfig);
            filters = new FiltersContainer(50, 50, 20, filterConfig);
            signalBuffer = new RingBuffer(filterConfig);
            vd = new ValuesDrawer();
            fd = new FiltersDrawer(filters.Filters);
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            //base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.Clear(Color.Black);
            base.OnPaint(e);

           for (int i = 0; i < filterConfig.FrameSamplesCount/1;i++)
                {
                double vl = signalGenerator.GetNextSample();
                signalBuffer.PassValue(vl);

                e.Graphics.FillEllipse(Brushes.Red, i * 4-3, (float)vl * 128.0f + 128.0f-3, 5, 5);

                filters.Update(signalBuffer);
            }


            vd.Draw(e.Graphics, signalBuffer.Values);
            fd.Draw(e.Graphics);

            e.Graphics.DrawString(string.Format("current freq = {0:0.0}", signalGenerator.CurrentFreq()), SystemFonts.DialogFont, Brushes.LightGreen, 128, 300);

            System.Threading.Thread.Sleep(50);
            Invalidate();
        }
    }
}
