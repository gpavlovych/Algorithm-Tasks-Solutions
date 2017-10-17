using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task40App
{
    using Task40;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            radiusNumericUpDown.Maximum = Math.Min(e.ClipRectangle.Width / 2-2, e.ClipRectangle.Height / 2-2);
            var r = (int)radiusNumericUpDown.Value;

            if (e.ClipRectangle.Width / 2 > r && e.ClipRectangle.Height / 2 > r)
            {
                if (drawSolverCheckBox.Checked)
                {
                    var bitmap = new Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height);
                    Solver.BuildCircle(bitmap, bitmap.Width / 2, bitmap.Height / 2, r, Color.Black);
                    e.Graphics.DrawImage(bitmap, new Point(0, 0));
                }
                if (drawGraphicsEllipseCheckBox.Checked)
                {
                    e.Graphics.DrawEllipse(
                        new Pen(Color.Red),
                        e.ClipRectangle.Width / 2 - r,
                        e.ClipRectangle.Height / 2 - r,
                        r * 2,
                        r * 2);
                }
            }
        }

        private void radiusNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            drawingPanel.Invalidate();
        }

        private void drawSolverCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            drawingPanel.Invalidate();
        }

        private void drawGraphicsEllipseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            drawingPanel.Invalidate();
        }

        private void drawingPanel_SizeChanged(object sender, EventArgs e)
        {
            drawingPanel.Invalidate();
        }
    }
}
