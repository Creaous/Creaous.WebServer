namespace Creaous.WebServer
{
    partial class frmMain
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
            this.gpHttp = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtHttpLog = new System.Windows.Forms.TextBox();
            this.btnStartHttpServ = new System.Windows.Forms.Button();
            this.txtHttpPort = new System.Windows.Forms.NumericUpDown();
            this.lblHPort = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.gpHttp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHttpPort)).BeginInit();
            this.SuspendLayout();
            // 
            // gpHttp
            // 
            this.gpHttp.Controls.Add(this.button2);
            this.gpHttp.Controls.Add(this.button1);
            this.gpHttp.Controls.Add(this.label2);
            this.gpHttp.Controls.Add(this.textBox1);
            this.gpHttp.Controls.Add(this.label1);
            this.gpHttp.Controls.Add(this.checkBox1);
            this.gpHttp.Controls.Add(this.txtHttpLog);
            this.gpHttp.Controls.Add(this.btnStartHttpServ);
            this.gpHttp.Controls.Add(this.txtHttpPort);
            this.gpHttp.Controls.Add(this.lblHPort);
            this.gpHttp.Location = new System.Drawing.Point(12, 12);
            this.gpHttp.Name = "gpHttp";
            this.gpHttp.Size = new System.Drawing.Size(408, 405);
            this.gpHttp.TabIndex = 2;
            this.gpHttp.TabStop = false;
            this.gpHttp.Text = "HTTP Server (yes it supports PHP)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Run in Background";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save Config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PHP Complier : ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(5, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "PHP is currently the only extenstion working. You can not disable it.\r\nPlease sup" +
    "ply a php complier path above.";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(178, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Enable PHP";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtHttpLog
            // 
            this.txtHttpLog.Location = new System.Drawing.Point(5, 126);
            this.txtHttpLog.Multiline = true;
            this.txtHttpLog.Name = "txtHttpLog";
            this.txtHttpLog.ReadOnly = true;
            this.txtHttpLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHttpLog.Size = new System.Drawing.Size(396, 272);
            this.txtHttpLog.TabIndex = 3;
            // 
            // btnStartHttpServ
            // 
            this.btnStartHttpServ.Location = new System.Drawing.Point(6, 22);
            this.btnStartHttpServ.Name = "btnStartHttpServ";
            this.btnStartHttpServ.Size = new System.Drawing.Size(103, 23);
            this.btnStartHttpServ.TabIndex = 2;
            this.btnStartHttpServ.Text = "Start Server";
            this.btnStartHttpServ.UseVisualStyleBackColor = true;
            this.btnStartHttpServ.Click += new System.EventHandler(this.btnStartHttpServ_Click);
            // 
            // txtHttpPort
            // 
            this.txtHttpPort.Location = new System.Drawing.Point(91, 51);
            this.txtHttpPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.txtHttpPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtHttpPort.Name = "txtHttpPort";
            this.txtHttpPort.Size = new System.Drawing.Size(64, 20);
            this.txtHttpPort.TabIndex = 1;
            this.txtHttpPort.Value = new decimal(new int[] {
            81,
            0,
            0,
            0});
            // 
            // lblHPort
            // 
            this.lblHPort.AutoSize = true;
            this.lblHPort.Location = new System.Drawing.Point(6, 53);
            this.lblHPort.Name = "lblHPort";
            this.lblHPort.Size = new System.Drawing.Size(77, 13);
            this.lblHPort.TabIndex = 0;
            this.lblHPort.Text = "Listening Port :";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(372, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Run in Background";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 422);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.gpHttp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Text = "Web Server";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gpHttp.ResumeLayout(false);
            this.gpHttp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHttpPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpHttp;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtHttpLog;
        private System.Windows.Forms.Button btnStartHttpServ;
        private System.Windows.Forms.NumericUpDown txtHttpPort;
        private System.Windows.Forms.Label lblHPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}