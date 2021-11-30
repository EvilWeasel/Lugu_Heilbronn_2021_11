using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace spp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Thread [] p1, p2, p3, p4, p5;
            Gabel ga1 = new Gabel(g1);
            Gabel ga2 = new Gabel(g2);
            Gabel ga3 = new Gabel(g3);
            Gabel ga4 = new Gabel(g4);
            Gabel ga5 = new Gabel(g5);

            Philosoph ph1 = new Philosoph(p1, ga1, ga2);
            Philosoph ph2 = new Philosoph(p2, ga2, ga3);
            Philosoph ph3 = new Philosoph(p3, ga3, ga4);
            Philosoph ph4 = new Philosoph(p4, ga4, ga5);
            Philosoph ph5 = new Philosoph(p5, ga5, ga1);
            //p1 = new Thread(new Philosoph().Run);
            //p2 = new Thread(new Philosoph().Run);
            //p3 = new Thread(new Philosoph().Run);
            //p4 = new Thread(new Philosoph().Run);
            //p5 = new Thread(new Philosoph().Run);
            //List<Thread> tlist = new List<Thread>() { p1, p2, p3, p4, p5 };


        }
    }

    public class Philosoph
    {
        private int _fullness;
        public Button Ctrl { get; set; }
        private Thread thread;
        public int Fullness
        {
            get { return _fullness; }
            set { _fullness = value; }
        }
        public int Pos { get; set; }
        public Gabel GL { get; set; }
        public Gabel GR { get; set; }

        public Philosoph(Button ctrl, Gabel gl, Gabel gr)
        {
            Ctrl = ctrl;
            GL = gl;
            GR = gr;
            Run();
        }

        public void Run()
        {
            thread = new Thread(() =>
            {

                Fullness = 10;
                while (true)
                {
                    Fullness--;
                    Thread.Sleep(1000);
                    if (Fullness == 0)
                    {
                        Ctrl.Dispatcher.Invoke(() =>
                        {
                            Ctrl.Background = new SolidColorBrush(Colors.Red);
                            Eat();
                        });
                    }
                    Thread.Sleep(500);
                }

            });
            thread.Start();

        }

        private void Eat()
        {
            if (GL.Frei && GR.Frei)
            {
                lock (GL)
                {
                    lock (GR)
                    {
                        GL.Frei = false;
                        GR.Frei = false;
                        GL.Ctrl.Background = Ctrl.Background;
                        GR.Ctrl.Background = Ctrl.Background;
                        Fullness = 10;
                        Thread.Sleep(3000);

                        //GL.Frei = true;
                        //GR.Frei = true;
                        //GL.Ctrl.Background = new SolidColorBrush(Colors.Green);
                        //GR.Ctrl.Background = new SolidColorBrush(Colors.Green);

                    }
                }

            }
        }
    }
    public class Gabel
    {
        public Button Ctrl { get; set; }
        public bool Frei { get; set; } = true;

        public Gabel(Button ctrl)
        {
            Ctrl = ctrl;
        }




    }
}
