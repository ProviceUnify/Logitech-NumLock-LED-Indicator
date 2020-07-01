namespace LogiNumLockLEDIndicator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonNumLockOn = new System.Windows.Forms.Button();
            this.NumLockOnLabel = new System.Windows.Forms.Label();
            this.NumLockOffLabel = new System.Windows.Forms.Label();
            this.buttonNumLockOff = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem1.Text = "Restore";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // buttonNumLockOn
            // 
            this.buttonNumLockOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonNumLockOn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonNumLockOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNumLockOn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNumLockOn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonNumLockOn.Location = new System.Drawing.Point(70, 30);
            this.buttonNumLockOn.Name = "buttonNumLockOn";
            this.buttonNumLockOn.Size = new System.Drawing.Size(55, 55);
            this.buttonNumLockOn.TabIndex = 1;
            this.buttonNumLockOn.Text = "NUM";
            this.buttonNumLockOn.UseVisualStyleBackColor = false;
            this.buttonNumLockOn.Click += new System.EventHandler(this.button1_Click);
            // 
            // NumLockOnLabel
            // 
            this.NumLockOnLabel.AutoSize = true;
            this.NumLockOnLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumLockOnLabel.Location = new System.Drawing.Point(48, 7);
            this.NumLockOnLabel.Name = "NumLockOnLabel";
            this.NumLockOnLabel.Size = new System.Drawing.Size(98, 18);
            this.NumLockOnLabel.TabIndex = 3;
            this.NumLockOnLabel.Text = "NumLock On";
            // 
            // NumLockOffLabel
            // 
            this.NumLockOffLabel.AutoSize = true;
            this.NumLockOffLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumLockOffLabel.Location = new System.Drawing.Point(176, 7);
            this.NumLockOffLabel.Name = "NumLockOffLabel";
            this.NumLockOffLabel.Size = new System.Drawing.Size(98, 18);
            this.NumLockOffLabel.TabIndex = 5;
            this.NumLockOffLabel.Text = "NumLock Off";
            // 
            // buttonNumLockOff
            // 
            this.buttonNumLockOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonNumLockOff.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonNumLockOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNumLockOff.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNumLockOff.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonNumLockOff.Location = new System.Drawing.Point(198, 30);
            this.buttonNumLockOff.Name = "buttonNumLockOff";
            this.buttonNumLockOff.Size = new System.Drawing.Size(55, 55);
            this.buttonNumLockOff.TabIndex = 4;
            this.buttonNumLockOff.Text = "NUM";
            this.buttonNumLockOff.UseVisualStyleBackColor = false;
            this.buttonNumLockOff.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonNumLockOn);
            this.panel1.Controls.Add(this.NumLockOffLabel);
            this.panel1.Controls.Add(this.NumLockOnLabel);
            this.panel1.Controls.Add(this.buttonNumLockOff);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 127);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(18, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Color on keyboard can be different from color on the screen.\r\nMinimize or Alt+Tab" +
    " window for apply changes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 145);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(284, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Start with Windows (with 10s delay for GHUB start first)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 169);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Logitech NumLock LED Indicator";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonNumLockOn;
        private System.Windows.Forms.Label NumLockOnLabel;
        private System.Windows.Forms.Label NumLockOffLabel;
        private System.Windows.Forms.Button buttonNumLockOff;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

