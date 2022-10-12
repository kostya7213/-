using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testform
{
	public partial class Form1 : Form
	{
		double a, b;
		double x, y, x0, y0;
		Bitmap canvas;
		Graphics user_Graphics;
		Pen userPen;
		int w, h;
		double xmin, xmax, ymin, ymax;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        double step =0.01;
		public Form1()
		{
			InitializeComponent();
			canvas = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
			user_Graphics = Graphics.FromImage(canvas);
			user_Graphics.FillRectangle(Brushes.White, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
			pictureBox1.Image = canvas;

		}
		private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			user_Graphics.FillRectangle(Brushes.White, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
			user_Graphics.DrawLine(Pens.White, 0, 0, 0, 0);
			pictureBox1.Image = canvas;
		}
		private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (textBoxA.Text == "" || textBoxB.Text == "")
			{
				MessageBox.Show("Choose all parametres!", "Error");
				return;
			}
			else
			{
				a = Convert.ToDouble(textBoxA.Text);
				b = Convert.ToDouble(textBoxB.Text);
			}
			if(radioButton1.Checked)
			{
				userPen =  Pens.Red;
			}
			else if(radioButton2.Checked)
			{
				userPen = Pens.Blue;

			}
			else if (radioButton3.Checked)
			{
				userPen = Pens.Green;
			}
			else
			{
				MessageBox.Show("Choose any color", "Error");
				return;
			}
			//Clear
			user_Graphics.FillRectangle(Brushes.White, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
			user_Graphics.DrawLine(Pens.White, 0, 0, 0, 0);
			pictureBox1.Image = canvas;

			double scale;
			var coords = new List<Tuple<double, double>>();
			double t = 0;
			if(textBox1.Text!="")
			step = Convert.ToDouble(textBox1.Text);
			pictureBox1_paint(sender, e);
			xmin = a * Math.Pow(Math.Cos(t),2) + b * Math.Cos(t);
			xmax = xmin;
			ymin = a * Math.Cos(t)*Math.Sin(t)+b*Math.Sin(t);
			ymax = ymin;
			while (t < Math.PI * 2)
			{
				x = a * Math.Pow(Math.Cos(t),2) + b * Math.Cos(t);
				y = a * Math.Cos(t)*Math.Sin(t)+b*Math.Sin(t);
				if (x < xmin) xmin = x;
				if (x > xmax) xmax = x;
				if (y < ymin) ymin = y;
				if (y > ymax) ymax = y;
				coords.Add(new Tuple<double, double>(x, y));
				t += step;
			}
			if (xmax - xmin < ymax - ymin)
				scale = (double)this.pictureBox1.Width / (double)(xmax - xmin)/1.5;
			else
				scale =  (double)this.pictureBox1.Height / (double)(ymax - ymin)/1.5;

			var newcoords = new List<Tuple<double, double>>();

			for (int i = 0; i < coords.Count(); i++)
			{
				newcoords.Add(new Tuple<double, double>((float)(coords[i].Item1 * scale), (float)(coords[i].Item2 * scale)));
			}
			for (int i = 0; i < coords.Count() - 1; ++i)
			{
				user_Graphics.DrawLine(userPen, (float)(x0 + newcoords[i].Item1), (float)(y0 - newcoords[i].Item2), (float)(x0 + newcoords[i + 1].Item1), (float)(y0 - newcoords[i + 1].Item2));
				user_Graphics.DrawLine(userPen, (float)(x0 + newcoords[i].Item1), (float)(y0 + newcoords[i].Item2), (float)(x0 + newcoords[i + 1].Item1), (float)(y0 + newcoords[i + 1].Item2));
			}
			Axis(sender,e,scale);
			pictureBox1.Image = canvas;

		}
		private void pictureBox1_paint(object sender, EventArgs e)
		{
			w = pictureBox1.Width;
			h = pictureBox1.Height;
			x0 = w / 4;
			y0 = h / 2;
		}
		private void Axis(object sender, EventArgs e,double scale)
		{
			System.Drawing.Rectangle rect = ClientRectangle;
			System.Windows.Forms.PaintEventArgs e1 = new System.Windows.Forms.PaintEventArgs(user_Graphics, rect);
			pictureBox1_paint(sender, e1);
			user_Graphics.DrawLine(Pens.Black, (float)x0, 5, (float)x0, h);  //OY
			user_Graphics.DrawLine(Pens.Black, 0, (float)y0, w - 5, (float)y0);  //OX
			user_Graphics.DrawLine(Pens.Black, w - 10, (float)y0 + 5, w - 5, (float)y0);//oxarr
			user_Graphics.DrawLine(Pens.Black, w - 10, (float)y0 - 5, w - 5, (float)y0);
			user_Graphics.DrawLine(Pens.Black, (float)x0 - 5, 10, (float)x0, 5);//oyarr
			user_Graphics.DrawLine(Pens.Black, (float)x0 + 5, 10, (float)x0, 5);
			pictureBox1.Image = canvas;

			// SCALING
			user_Graphics.DrawString("0", label1.Font, Brushes.Black, (float)(x0 + 2), (float)(y0+3));
			user_Graphics.DrawString("X", label1.Font, Brushes.Black, (float)(w-10), (float)(y0 +2));
			user_Graphics.DrawString("Y", label1.Font, Brushes.Black, (float)(x0 - 10), 10);
			double n = Math.PI;
				user_Graphics.DrawLine(Pens.Red, (float)x0+(float)(scale*n), (float)(y0-2), (float)x0 + (float)(scale * n), (float)(y0 + 2));
				user_Graphics.DrawString("PI", label1.Font, Brushes.Black, (float)x0 + (float)(scale * n)-5, (float)(y0 + 3));
				user_Graphics.DrawLine(Pens.Red, (float)x0 - (float)(scale * n), (float)(y0 - 2), (float)x0 - (float)(scale * n), (float)(y0 + 2));
				user_Graphics.DrawString("-PI", label1.Font, Brushes.Black, (float)x0 - (float)(scale * n) - 5, (float)(y0 + 3));
			
			
				user_Graphics.DrawLine(Pens.Red, (float)(x0 - 2), (float)y0 + (float)(scale * n), (float)(x0 + 2), (float)y0 + (float)(scale * n));
				user_Graphics.DrawString("-PI", label1.Font, Brushes.Black, (float)(x0 + 3), (float)y0 + (float)(scale * n) - 5);
				user_Graphics.DrawLine(Pens.Red, (float)(x0 - 2), (float)y0 - (float)(scale * n), (float)(x0 + 2), (float)y0 - (float)(scale * n));
				user_Graphics.DrawString("PI", label1.Font, Brushes.Black, (float)(x0 + 3), (float)y0 - (float)(scale * n) - 5);
		}
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
				Application.Exit();
		}
	}
}

