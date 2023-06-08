using System.Windows.Forms;

namespace PZKIS_5LB
{
    public partial class Form1 : Form
    {
        private int coinCount5;
        private int coinCount15;
        private int coinCount25;

        private int carriageX;
        private int carriageY;
        private int moveType;

        private System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            pictureBox.Paint += PictureBox_Paint;
            pictureBox.Resize += PictureBox_Resize;

            carriageX = 50;
            carriageY = 100;

            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 100;
            timer1.Tick += timer1_Tick;
        }


        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle hole = new Rectangle(50, 50, 75, 75);
            g.FillRectangle(Brushes.Black, hole);

            Rectangle carriageRect = new Rectangle(carriageX, carriageY, 25, 50);
            g.FillRectangle(Brushes.Green, carriageRect);

            Rectangle indicator1Rect = new Rectangle(50, 200, 25, 25);
            Rectangle indicator2Rect = new Rectangle(100, 200, 35, 35);
            Rectangle indicator3Rect = new Rectangle(150, 200, 45, 45);
            g.FillEllipse(Brushes.Red, indicator1Rect);
            g.FillEllipse(Brushes.Red, indicator2Rect);
            g.FillEllipse(Brushes.Red, indicator3Rect);


            Font font = new Font(FontFamily.GenericSansSerif, 12);
            g.DrawString("5 Coin Count: " + coinCount5, font, Brushes.Black, 200, 100);
            g.DrawString("15 Coin Count: " + coinCount15, font, Brushes.Black, 200, 120);
            g.DrawString("25 Coin Count: " + coinCount25, font, Brushes.Black, 200, 140);
        }

        private void PictureBox_Resize(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int diameter = Convert.ToInt32(diameterTextBox.Text);
            switch(diameter)
            {
                case 5:
                    moveType = 1;
                    Move();
                    break;
                case 15:
                    moveType = 2;
                    Move();
                    break;
                case 25:
                    moveType = 3;
                    Move();
                    break;
                default: 
                    moveType = 0;
                    break;
            }
            pictureBox.Invalidate();
        }

        private void Move()
        {
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (moveType)
            {
                case 1:
                    carriageY += 5;
                    pictureBox.Invalidate();
                    if (carriageY > 160) 
                    {
                        timer1.Stop();
                        coinCount5++;
                        carriageX = 50;
                        carriageY = 100;
                    }
                    break;
                case 2:
                    if(carriageX < 105)
                    {
                        carriageX += 5;
                    }
                    else
                    {
                        if(carriageY < 160)
                        {
                            carriageY += 5;
                        }
                        else
                        {
                            timer1.Stop();
                            coinCount15++;
                            carriageX = 50;
                            carriageY = 100;
                        }
                    }
                    pictureBox.Invalidate();
                    break;
                case 3:
                    if (carriageX < 165)
                    {
                        carriageX += 8;
                    }
                    else
                    {
                        if (carriageY < 160)
                        {
                            carriageY += 5;
                        }
                        else
                        {
                            timer1.Stop();
                            coinCount25++;
                            carriageX = 50;
                            carriageY = 100;
                        }
                    }
                    pictureBox.Invalidate();
                    break;
                    
            }
        }

    }
}