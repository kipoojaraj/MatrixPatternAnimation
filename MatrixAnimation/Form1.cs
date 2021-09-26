using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MatrixAnimation
{
    public partial class Form1 : Form
    {
        //add variables
        public int m_Width;// width of the cell
        public int m_Height;
        public int m_NofRows;//no of rows
        public int m_NofCols;//no of cols
        public int m_Yoffset;//offset from which drawining start
        public int m_Xoffset;
        public int r;

        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 50;
        public const int DEFAULT_NOFCOS = 5;
        public const int DEFAULT_NOFROWS = 5;
        public const int DEFAULT_HEIGHT = 50;
        public const int DEFAULT_WIDTH = 50;
        public const int DEFAULT_r = 2;
        public Form1()
        {
            Initialize();
            InitializeComponent();
            dThreadStatus = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DrawGridThread = new Thread(new ThreadStart(ThreadDrawGrid));
            DrawGridThread.Start();
            dThreadStatus = true;
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //r = DEFAULT_r + 4;
            this.Refresh();
            this.r = 6;
             this.label1.Text = "6";
        }

        private void OnPaint(object sender, EventArgs e)
        {
            dThreadStatus = false;
        }
        public void Initialize()
        {
            //all the default values
            m_NofRows = DEFAULT_NOFROWS;
            m_NofCols = DEFAULT_NOFCOS;
            m_Width = DEFAULT_HEIGHT;
            m_Height = DEFAULT_WIDTH;
            m_Yoffset = DEFAULT_X_OFFSET;
            m_Xoffset = DEFAULT_Y_OFFSET;
            r = 8;
        }
        private void ThreadDrawGrid()
        {
            Graphics boardLayout = this.CreateGraphics();
            Pen LayoutPen = new Pen(Color.Red);
            LayoutPen.Width = 5;
            // boardlayout.DrawLine(layoutPen,0,0,100,0);




            int p = 0;
           // int r = 0;


            p = 2;
          // r = 12;
            while (p <= this.r)
            {
                int X = DEFAULT_X_OFFSET;
                int Y = DEFAULT_Y_OFFSET;
                int A = DEFAULT_X_OFFSET;
                int B = DEFAULT_Y_OFFSET;
                Thread.Sleep(1000);

                System.Diagnostics.Debug.WriteLine('Y');
                System.Diagnostics.Debug.WriteLine(Y);

                m_NofCols = p;
                m_NofRows = p;

                //DRAW TH ROWS
                //if(p!=2)
                //if (p % 2 == 0)
                if (p > 1)
                {
                    for (int i = 0; i <= m_NofRows; i++)
                    {
                        boardLayout.DrawLine(LayoutPen, X, Y, X + this.m_Width * this.m_NofCols, Y);
                        Y = Y + this.m_Height;

                    }

                    //draw the cols


                    for (int j = 0; j <= m_NofCols; j++)
                    {
                        boardLayout.DrawLine(LayoutPen, A, B, A, B + this.m_Height * this.m_NofRows);
                        A = A + this.m_Width;

                    }
                }
                else
                {

                    //p=2;                    
                    //this.Invalidate();
                }
                if (p == this.r)
                {
                    Thread.Sleep(1000);
                    this.Invalidate();
                    p = 1;
                    
                }
                p++;
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           DrawGridThread.Suspend();
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.r = 2;
            this.label1.Text = "2";
            this.Refresh();



        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
           
            this.r = 3;
            this.label1.Text = "3";
             this.Refresh();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
            this.r = 4;
            
            this.label1.Text = "4";
            this.Refresh();

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.r = 5;
            this.label1.Text = "5";
           
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.r = 7;
            this.label1.Text = "7";
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.r = 8;
            this.label1.Text = "8";
        }
    }
    
}
