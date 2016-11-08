using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Snake1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Cell> zmey = new List<Cell>();
        Graphics g;
        List<int> zmeyx = new List<int>();
        List<int> zmeyy = new List<int>();
        List<int> nezanyatx = new List<int>();
        List<int> nezanyaty = new List<int>();
        List<Predmet> predm = new List<Predmet>();
        int a;
        int b;
        bool verh;
        bool vniz;
        bool vpravo;
        bool vlevo;
        int edi_ostal;
        int level=1;
        int record = 0;
        bool go_to_next_level;
        string imya;
        Level lv = new Level();
       private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
           if ((e.KeyCode == Keys.Left) && (!vlevo) && (!vpravo))
            {
                vlevo = true;
                verh = false;
                vniz = false;
            }
           if ((e.KeyCode == Keys.Right) && (!vpravo) && (!vlevo))
            {
                vpravo = true;
                verh = false;
                vniz = false;
            }
           if ((e.KeyCode == Keys.Up) && (!verh) && (!vniz))
            {
                verh = true;
                vlevo = false;
                vpravo = false;
            }
           if ((e.KeyCode == Keys.Down) && (!vniz) && (!verh))
            {
                vniz = true;
                vlevo = false;
                vpravo = false;
            }
       }
        private void timer1_Tick(object sender, EventArgs e)
       {
           viewRecordsToolStripMenuItem.Enabled = false;
            zmeyx.Clear();
            zmeyy.Clear();
            edi_ostal = 0;
            for (int i = 0; i < predm.Count; i++)
            {
                if (predm[i].number == 1)
                {
                    edi_ostal++;
                }
            }
            if (edi_ostal == 0)
            {
                timer1.Stop();
                MessageBox.Show("Go to next level");
                go_to_next_level = true;
                level++;
                if (level > 10)
                {
                    MessageBox.Show("You win");
                }
                else { 
                StartGame();
                }
                
            }
            pictureBox1.Refresh();
            g = pictureBox1.CreateGraphics();
            Brush c = Brushes.Blue;
            Brush d = Brushes.Red;
           for (int i = 0; i < zmey.Count-1; i++) {
               zmeyx.Add(zmey[i].x);
               zmeyy.Add(zmey[i].y);
           }
           int konecx = zmey[zmey.Count - 1].x;
           int konecy = zmey[zmey.Count - 1].y;
           if (vlevo) {
               zmey[0].x -= 10;
           }
           if (vpravo) {
               zmey[0].x += 10;
           }
           if (vniz) {
               zmey[0].y += 10;
           }
           if (verh) {
               zmey[0].y -= 10;
           }
            
           zmeyx.Insert(0,zmey[0].x);
           zmeyy.Insert(0, zmey[0].y);
            Pen p=new Pen(Brushes.Red,2);
           for (int i = 0; i < zmey.Count; i++)
           {
               zmey[i].x = zmeyx[i];
               zmey[i].y = zmeyy[i];
           }
                     pictureBox1.Refresh();
                     g.FillRectangle(d, zmey[0].x, zmey[0].y, 10, 10);
                     g.DrawRectangle(p, zmey[0].x, zmey[0].y, 10, 10);
                     for (int i = 1; i < zmey.Count; i++)
                     {
                         g.FillRectangle(c, zmey[i].x, zmey[i].y, 10, 10);
                         g.DrawRectangle(p, zmey[i].x, zmey[i].y, 10, 10);
                     }
                     for (int i = 1; i < zmey.Count; i++)
                     {
                         if ((zmey[0].x == zmey[i].x) && (zmey[0].y == zmey[i].y))
                         {
                                 verh = false;
                                 vniz = false;
                                 vlevo = false;
                                 vpravo = false;
                                 timer1.Stop();
                                 MessageBox.Show("Игра окончена.Змейка съела сама себя");
                                 viewRecordsToolStripMenuItem.Enabled = true;
                                 string str = imya + " " + level.ToString() + " " + record.ToString()+'\n';
                                 File.AppendAllText(@"records.txt",str);
                         }
                     }
                     for (int i = 0; i < predm.Count; i++) {
                         if ((zmey[0].x == predm[i].x) && (zmey[0].y == predm[i].y)) {
                             if (predm[i].number == 0)
                             {
                                 verh = false;
                                 vniz = false;
                                 vlevo = false;
                                 vpravo = false;
                                 timer1.Stop();
                                 MessageBox.Show("Игра окончена.Вы наткнулись на препятствие");
                                 viewRecordsToolStripMenuItem.Enabled = true;
                                 string str = imya + " " + level.ToString() + " " + record.ToString() + '\n';
                                 File.AppendAllText(@"records.txt", str);
                             }
                             if (predm[i].number == 1) {
                                 predm.RemoveAt(i);
                                 Cell c5 = new Cell();
                                 c5.x = konecx;
                                 c5.y = konecy;
                                 zmey.Add(c5);
                                 record+=lv.ball;
                             }
                         }
                     }
                     
            Brush k = Brushes.Black;
            Brush l = Brushes.Red;
            for (int i = 0; i < predm.Count; i++)
                         {
                             if (predm[i].number == 0)
                             {
                                 g.FillRectangle(k, predm[i].x, predm[i].y, 10, 10);
                             }
                             if (predm[i].number == 1)
                             {
                                 g.FillEllipse(l, predm[i].x, predm[i].y, 10, 10);
                             }
                         }
            
                     if ((zmey[0].x <= 0) || (zmey[0].x >= a) || (zmey[0].y <= 0) || (zmey[0].y >= b)) {
                         verh = false;
                         vniz = false;
                         vlevo = false;
                         vpravo = false;
                         timer1.Stop();
                         MessageBox.Show("Игра окончена.Вы вышли за границы поля");
                         viewRecordsToolStripMenuItem.Enabled = true;
                         string str = imya + " " + level.ToString() + " " + record.ToString() + '\n';
                         File.AppendAllText("records.txt", str);
                         
                     }
                     label1.Text = "level:" + level.ToString() + " " + "rezult:" + record.ToString()+" "+"name:"+imya;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
            imya = frm2.imya1;
            record = 0;
            level = 1;
            timer1.Stop();
            StartGame();  
        }
        void StartGame() {
            verh = false;
            vniz = false;
            vlevo = false;
            vpravo = false;
            g = pictureBox1.CreateGraphics();
            pictureBox1.BackColor = Color.Turquoise;
            pictureBox1.Refresh();
            go_to_next_level = false;
            nezanyatx.Clear();
            nezanyaty.Clear();
            predm.Clear();
            zmey.Clear();
            for (int i = 0; i < 36; i++) {
                nezanyatx.Add(i);
            }
            for (int i = 0; i < 34; i++)
            {
                nezanyaty.Add(i);
            }
            a = pictureBox1.Size.Height;
            b = pictureBox1.Size.Width;
            Cell c1 = new Cell();
            Cell c2 = new Cell();
            Cell c3 = new Cell();
            Cell c4 = new Cell();
            c1.x = b / 2;
            c1.y = a / 2 + 10;
            c2.x = b / 2;
            c2.y = a / 2;
            c3.x = b / 2;
            c3.y = a / 2 - 10;
            c4.x = b / 2;
            c4.y = a / 2 - 20;
            nezanyatx.Remove(b / 20);
            nezanyaty.Remove(a / 20 + 1);
            nezanyaty.Remove(a / 20);
            nezanyaty.Remove(a / 20 - 1);
            nezanyaty.Remove(a / 20 - 2);
            zmey.Add(c1);
            zmey.Add(c2);
            zmey.Add(c3);
            zmey.Add(c4);
            timer1.Enabled = true;
            timer1.Start();
            vniz = true;
            Random r1 = new Random();
            lv.SetLevel(level);
            timer1.Interval = lv.dt;
            for (int i = 0; i < lv.kolvo_edi; i++)
            {
                Predmet pr = new Predmet();
                int i1 = r1.Next(1, nezanyatx.Count - 2);
                int i2 = r1.Next(1, nezanyaty.Count - 2);
                pr.x = i1 * 10;
                pr.y = i2 * 10;
                pr.number =1;
                nezanyatx.Remove(i1);
                nezanyaty.Remove(i2);
                predm.Add(pr);
            }
            for (int i = 0; i < lv.kolvo_prepjat; i++)
            {
                Predmet pr = new Predmet();
                int i1 = r1.Next(1, nezanyatx.Count - 2);
                int i2 = r1.Next(1, nezanyaty.Count - 2);
                pr.x = i1 * 10;
                pr.y = i2 * 10;
                pr.number = 0;
                nezanyatx.Remove(i1);
                nezanyaty.Remove(i2);
                predm.Add(pr);
            }
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор игры инженер-электрик Ахметов Р.Р.");
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Игра 'Змейка'.Надо собирать круглые яблоки и уворачиваться от квадратных стен.Когда мы все собрали, переходим на следующий уровень.Выходить за пределы поля нельзя");
        }

        private void viewRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
          }
       }
    }
