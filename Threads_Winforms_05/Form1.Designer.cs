namespace Threads_Winforms_05
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnThread = new System.Windows.Forms.Button();
            this.TxtThread = new System.Windows.Forms.TextBox();
            this.TxtTimer = new System.Windows.Forms.TextBox();
            this.BtnTimer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBW = new System.Windows.Forms.TextBox();
            this.BtnBW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnThread
            // 
            this.BtnThread.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnThread.Location = new System.Drawing.Point(10, 92);
            this.BtnThread.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnThread.Name = "BtnThread";
            this.BtnThread.Size = new System.Drawing.Size(166, 43);
            this.BtnThread.TabIndex = 0;
            this.BtnThread.Text = "Start";
            this.BtnThread.UseVisualStyleBackColor = true;
            this.BtnThread.Click += new System.EventHandler(this.BtnThread_Click);
            // 
            // TxtThread
            // 
            this.TxtThread.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtThread.Location = new System.Drawing.Point(10, 40);
            this.TxtThread.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtThread.Name = "TxtThread";
            this.TxtThread.Size = new System.Drawing.Size(166, 36);
            this.TxtThread.TabIndex = 1;
            // 
            // TxtTimer
            // 
            this.TxtTimer.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtTimer.Location = new System.Drawing.Point(240, 40);
            this.TxtTimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtTimer.Name = "TxtTimer";
            this.TxtTimer.Size = new System.Drawing.Size(166, 36);
            this.TxtTimer.TabIndex = 3;
            // 
            // BtnTimer
            // 
            this.BtnTimer.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnTimer.Location = new System.Drawing.Point(239, 92);
            this.BtnTimer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnTimer.Name = "BtnTimer";
            this.BtnTimer.Size = new System.Drawing.Size(166, 43);
            this.BtnTimer.TabIndex = 2;
            this.BtnTimer.Text = "Start";
            this.BtnTimer.UseVisualStyleBackColor = true;
            this.BtnTimer.Click += new System.EventHandler(this.BtnTimer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thread";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(239, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Timer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(467, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "BackgroundWorker";
            // 
            // TxtBW
            // 
            this.TxtBW.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtBW.Location = new System.Drawing.Point(467, 40);
            this.TxtBW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBW.Name = "TxtBW";
            this.TxtBW.Size = new System.Drawing.Size(166, 36);
            this.TxtBW.TabIndex = 7;
            // 
            // BtnBW
            // 
            this.BtnBW.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnBW.Location = new System.Drawing.Point(466, 92);
            this.BtnBW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnBW.Name = "BtnBW";
            this.BtnBW.Size = new System.Drawing.Size(166, 43);
            this.BtnBW.TabIndex = 6;
            this.BtnBW.Text = "Start";
            this.BtnBW.UseVisualStyleBackColor = true;
            this.BtnBW.Click += new System.EventHandler(this.BtnBW_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 153);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtBW);
            this.Controls.Add(this.BtnBW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTimer);
            this.Controls.Add(this.BtnTimer);
            this.Controls.Add(this.TxtThread);
            this.Controls.Add(this.BtnThread);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion



        private System.Windows.Forms.Button BtnThread;
        private System.Windows.Forms.TextBox TxtThread;
        private System.Windows.Forms.TextBox TxtTimer;
        private System.Windows.Forms.Button BtnTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBW;
        private System.Windows.Forms.Button BtnBW;
    }
}