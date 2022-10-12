using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2ndLab
{
    public partial class Form1 : Form
    {
        private Pen myPen;
        private SolidBrush face;
        private SolidBrush forPnt;
        private Image canvas;
        private Graphics myGraphics;
        private List<int[]> polygons;


        private double alf, bet;        // alf - угол вертикального поворота    bet - угол горизонтального поворота

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.PictureBox pictureBox1;

        public Form1()
        {
            InitializeComponent();

            myPen = new Pen(Color.Black) { Width = 2 };
            face = new SolidBrush(Color.LightBlue);
            forPnt = new SolidBrush(Color.Blue);

            canvas = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            myGraphics = Graphics.FromImage(canvas);

            myGraphics.FillRectangle(Brushes.SkyBlue, 0, 0, pictureBox1.Height, pictureBox1.Width);

            alf = -Math.PI * (double)trackBar2.Value / (2.0 * (double)trackBar2.Maximum);
            bet = Math.PI * (double)trackBar1.Value / (2.0 * (double)trackBar1.Maximum);

            LoadPolygons();
            Draw();
        }

        private void changeAlf(object sender, EventArgs e)
        {
            alf = -Math.PI * (double)trackBar2.Value / (2.0 * (double)trackBar2.Maximum);
            Draw();
        }

        private void changeBet(object sender, EventArgs e)
        {
            bet = Math.PI * (double)trackBar1.Value / (2.0 * (double)trackBar1.Maximum);
            Draw();
        }


        private double[,] TransformPoints()
        {
            //(float)Math.PI / (176.0f / 50)
            double sinA = Math.Sin(alf),
                    cosA = Math.Cos(alf),
                    sinB = Math.Sin(bet),
                    cosB = Math.Cos(bet);
            double[,] Ry = new double[,]
            {
                {cosB, 0, -sinB, 0},
                { 0, 1, 0 ,0},
                { sinB, 0, cosB, 0},
                {0, 0 ,0 ,1 },
            };
            double[,] Rx = new double[,]
            {
                { 1, 0, 0, 0},
                { 0, cosA, sinA, 0},
                { 0, -sinA, cosA, 0},
                {0, 0, 0, 1},
            };
            double[,] P = new double[,]
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 0, 0},
                { 0, 0, 0, 1},
            };

            double[,] T = MatrixMult(Ry, Rx);
            T = MatrixMult(T, P);

            return MatrixMult(points, T);
        }


        private readonly double[,] points = new double[,]
        {
            { 40, -5,0,1}, //00
            { -50, 10, 0, 1},//01
            {-50,80,0,1 },//02
            { 0,100,0,1},//03
            {50,80,0,1 },//04
            { 50,10,0,1},//05
            {-50,80,20,1 }, //06
            {0,100,20,1 }, //07
            { 50,80,20,1}, //08
            { -50,10,20, 1}, //09
            {50,10,20,1 },//10
            {60, 10, 5,1 },//11
            { 60,-20,5,1},//12
            { 40,-20,5,1},//13
            {40,10,5,1 },//14
            { -60,10,5,1},//15
            { -60,-20,5,1,},//16
            {-40,-20,5,1 },//17
            { -40,10,5,1},//18
            {60, 10,-50,1 },//19
            { 60,-20,-50,1},//20
            { 40,-20,-50,1},//21
            {40,10,-50,1 },//22
            { -60,10,-50,1},//23
            { -60,-20,-50,1,},//24
            {-40,-20,-50,1 },//25
            { -40,10,-50,1},//26
            { -40, -5, 0, 1},//27
            { -40,-5, -25,1},//28
            { 40, -5, -25, 1},//29
            { -40,-10,-30,1},//30
            {40,-10,-30,1 },//31
            {-40,-10,-25,1 },//32
            { 40,-10,-25,1},//33
            { -40,-15,-30, 1},//34
            { 40,-15,-30, 1},//35
            { -40,-15,-35, 1},//36
            { 40,-15,-35, 1},//37
            {-40,-20,-35,1 },//38
            {40,-20,-35,1 },//39
            {-40,-20,-40,1 },//40
            {40,-20,-40,1 },//41
            // door
            { -15, 50, 0, 1},//42
            { 0,55,-10,1},//43
            {15,50,0,1 },//44
            {-15,-5,0,1 },//45
            {15,-5,0,1},//46
            
            //window
            {-25,75,5,1},//47
            {25,75,5,1},//48
            {-25,70,5,1},//49
            {25,70,5,1},//50
            {-25,75,0,1},//51
            {25,75,0,1},//52
            {-25,70,0,1},//53
            {25,70,0,1},//54
            
            //доработки
            {0,-5,-10,1 }//55

          
            };

        private void LoadPolygons()
        {
            polygons = new List<int[]>();
            polygons.Add(new int[] { 2, 3, 7, 6 });
            polygons.Add(new int[] { 3,7,8,4 });
            polygons.Add(new int[] { 1,2,6,9});
            polygons.Add(new int[] { 4,5,10,8 });
            polygons.Add(new int[] { 11,12,13,14 });
            polygons.Add(new int[] {15,16,17,18});
            polygons.Add(new int[] {19,20,21,22});
            polygons.Add(new int[] {23,24,25,26});
            polygons.Add(new int[] { 14, 22 });
            polygons.Add(new int[] { 11, 19 });
            polygons.Add(new int[] { 12, 20 });
            polygons.Add(new int[] { 13, 21 });
            polygons.Add(new int[] { 15, 23 });
            polygons.Add(new int[] { 16, 24 });
            polygons.Add(new int[] {17, 25 });
            polygons.Add(new int[] {18, 26 });
            polygons.Add(new int[] {0, 27, 28, 29});
            polygons.Add(new int[] { 30, 31 });
            polygons.Add(new int[] { 30, 32 });
            polygons.Add(new int[] { 31, 33 });
            polygons.Add(new int[] { 32, 28 });
            polygons.Add(new int[] { 32,33 });
            polygons.Add(new int[] { 33, 29 });
            polygons.Add(new int[] { 30, 34 });
            polygons.Add(new int[] { 31, 35 });
            polygons.Add(new int[] { 34, 35 });
            polygons.Add(new int[] { 36,37 });
            polygons.Add(new int[] { 34, 36 });
            polygons.Add(new int[] { 35,37 });
           // polygons.Add(new int[] { 40,41 });
            polygons.Add(new int[] { 38,39 });
            polygons.Add(new int[] { 38,40 });
            polygons.Add(new int[] { 39,41});
            polygons.Add(new int[] { 37,39 });
            polygons.Add(new int[] { 36, 38 });
            polygons.Add(new int[] { 42,43});
            polygons.Add(new int[] { 43,44 });
            polygons.Add(new int[] { 42,45 });
            polygons.Add(new int[] { 44,46 });
            polygons.Add(new int[] { 47,48  });
            polygons.Add(new int[] { 47,49 });
            polygons.Add(new int[] { 48,50 });
            polygons.Add(new int[] { 49,50});
           
            polygons.Add(new int[] { 47,51});
            polygons.Add(new int[] { 48,52 });
            polygons.Add(new int[] { 49,53 });
            polygons.Add(new int[] { 50,54 });
            polygons.Add(new int[] { 51,52,54,53 });
            polygons.Add(new int[] { 43,55 });
            polygons.Add(new int[] { 45, 55 });
            polygons.Add(new int[] { 46, 55 });



        }



        private static double[,] MatrixMult(double[,] A, double[,] B)
        {
            int ARows = A.GetLength(0), AColumns = A.GetLength(1);
            int BRows = B.GetLength(0), BColumns = B.GetLength(1);

            if (AColumns != BRows)
                throw new Exception("Нельзя перемножить данные матрицы");

            double[,] res = new double[ARows, BColumns];
            for (int rowA = 0; rowA < ARows; rowA++)
                for (int columnB = 0; columnB < BColumns; columnB++)
                    for (int columnA = 0; columnA < AColumns; columnA++)
                        res[rowA, columnB] += A[rowA, columnA] * B[columnA, columnB];
            return res;
        }

        private PointF GetPoint(double x, double y, double scale = 1.0) => 
                                    new PointF((float)(pictureBox1.Width /2 + x * scale), 
                                               (float)(pictureBox1.Height/2  -  y * scale));
        private RectangleF GetCircleRectangle(double x, double y, double scale = 1.0, double r = 2.0) => 
                                    new RectangleF((float)(pictureBox1.Width   / 2    + x * scale - r/2), 
                                                    (float)(pictureBox1.Height / 2  - y * scale),
                                                    (float)r * 2, 
                                                    (float)r * 2);

        private void Draw()
        {
            myGraphics.FillRectangle(Brushes.PapayaWhip, 0, 0, pictureBox1.Width, pictureBox1.Height);
            double scale = 2.5;
            double[,] transformedPoints = TransformPoints();
            PointF[] p;
            for (int i = 0; i < polygons.Count; i++)
            {
                p = new PointF[polygons[i].Length];
                for (int point = 0; point < polygons[i].Length; point++)
                    p[point] = GetPoint(transformedPoints[polygons[i][point], 0], transformedPoints[polygons[i][point], 1], scale);
                for (int point = 1; point < p.Length; point++)
                    myGraphics.DrawLine(myPen, p[point - 1], p[point]);
                myGraphics.DrawLine(myPen, p[0], p[p.Length - 1]);
                myGraphics.DrawPolygon(myPen, p);
                //if (isFill)
                //    graphics.FillPolygon(faceBrush, p);
            }
            //if (isPoint)
            for (int point = 0; point < transformedPoints.GetLength(0); point++)
                myGraphics.FillEllipse(forPnt, GetCircleRectangle(transformedPoints[point, 0], transformedPoints[point, 1], scale, 2));
            
            pictureBox1.Image = canvas;
        }
    }
}
