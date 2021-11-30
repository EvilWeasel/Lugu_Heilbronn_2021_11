using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threads_Winforms_05
{
    public partial class Form1 : Form
    {
        public Thread clock01;
        System.Threading.Timer timer02;
        System.Timers.Timer timer03;
        System.Windows.Forms.Timer timer04;
        BackgroundWorker worker01;

        public Form1()
        {
            InitializeComponent();
            clock01 = new(() =>
            {
                try
                {
                    while (true)
                    {
                        // Kein direkter Zugriff auf anderen Thread
                        // WPF Dispatcher.Invoke(...)
                        this.Invoke(() =>
                        {
                            TxtThread.Text = DateTime.Now.AddHours(-1).ToLongTimeString();

                        });
                        Thread.Sleep(1000);
                    }

                }
                catch (ThreadInterruptedException)
                {


                }
            });
            worker01 = new();
            worker01.DoWork += Worker01_DoWork;
            worker01.ProgressChanged += Worker01_ProgressChanged;
            worker01.RunWorkerCompleted += Worker01_RunWorkerCompleted;
            worker01.WorkerReportsProgress = true;
            worker01.WorkerSupportsCancellation = true;
            timer04 = new();
        }

        private void Worker01_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("BW am ENDE");
        }

        private void Worker01_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            // e.ProgressPercentage
            TxtBW.Text = ((DateTime)e.UserState).ToLongTimeString();
        }

        private void Worker01_DoWork(object? sender, DoWorkEventArgs e)
        {
            while (true)
            {
                worker01.ReportProgress(0, DateTime.Now.AddHours(1));
                Thread.Sleep(1000);
                if (worker01.CancellationPending)
                {
                    break;
                }


            }
        }

        private void BtnThread_Click(object sender, EventArgs e)
        {
            BtnThread.Enabled = false;
            clock01.Start();
        }

        private void BtnTimer_Click(object sender, EventArgs e)
        {
            timer04.Enabled = true;
            BtnTimer.Enabled = false;
        }

        private void BtnBW_Click(object sender, EventArgs e)
        {
            BtnBW.Enabled = false;
            if (!worker01.IsBusy)
            {
                worker01.RunWorkerAsync();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            clock01.Interrupt();
        }
    }
}
