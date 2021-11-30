using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Events01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        // delegate void EventHandler(object o, EventArgs ea)

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += (a, b) =>
            {
                b.Cancel = true;
            };

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Button b = new Button();
                    b.Text = (i * j).ToString();
                    b.SetBounds((i-1)*65 + 5, (j-1)*35+5, 60, 30);
                    b.Tag = $"{i} x {j} => {i * j}";
                    b.Click += (p1, p2) => {
                        
                        Button btn = p1 as Button;
                        if(btn!=null)
                        {
                            //MessageBox.Show(btn.Tag.ToString());
                            // MessageBox.Show(b.Tag.ToString());
                            btn.Enabled = false;
                            btn.BackColor = Color.Red;
                        }
                    };
                    // delgate void MouseEventHandler(object, MouseEventArgs)
                    // MouseEventArgs

                    b.MouseMove += (p1, p2) =>
                    {
                        this.Text = $"{p2.X}/{p2.Y}";
                    };
                    Controls.Add(b);
                }
            }
        }
    }
}
