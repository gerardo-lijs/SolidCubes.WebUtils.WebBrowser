namespace SolidCubes.WebUtils
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Bt_Refresh = new System.Windows.Forms.Button();
            this.Bt_Stop = new System.Windows.Forms.Button();
            this.Bt_Forward = new System.Windows.Forms.Button();
            this.Bt_Back = new System.Windows.Forms.Button();
            this.Bt_Print = new System.Windows.Forms.Button();
            this.Tx_Url = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.content = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Bt_Refresh
            // 
            this.Bt_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Refresh.ForeColor = System.Drawing.Color.White;
            this.Bt_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Refresh.Image")));
            this.Bt_Refresh.Location = new System.Drawing.Point(833, 2);
            this.Bt_Refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Bt_Refresh.Name = "Bt_Refresh";
            this.Bt_Refresh.Size = new System.Drawing.Size(35, 35);
            this.Bt_Refresh.TabIndex = 3;
            this.Bt_Refresh.UseVisualStyleBackColor = true;
            this.Bt_Refresh.Click += new System.EventHandler(this.Bt_Refresh_Click);
            // 
            // Bt_Stop
            // 
            this.Bt_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Stop.ForeColor = System.Drawing.Color.White;
            this.Bt_Stop.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Stop.Image")));
            this.Bt_Stop.Location = new System.Drawing.Point(833, 2);
            this.Bt_Stop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Bt_Stop.Name = "Bt_Stop";
            this.Bt_Stop.Size = new System.Drawing.Size(35, 35);
            this.Bt_Stop.TabIndex = 2;
            this.Bt_Stop.UseVisualStyleBackColor = true;
            this.Bt_Stop.Click += new System.EventHandler(this.Bt_Stop_Click);
            // 
            // Bt_Forward
            // 
            this.Bt_Forward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Forward.ForeColor = System.Drawing.Color.White;
            this.Bt_Forward.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Forward.Image")));
            this.Bt_Forward.Location = new System.Drawing.Point(39, 2);
            this.Bt_Forward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Bt_Forward.Name = "Bt_Forward";
            this.Bt_Forward.Size = new System.Drawing.Size(35, 35);
            this.Bt_Forward.TabIndex = 1;
            this.Bt_Forward.UseVisualStyleBackColor = true;
            this.Bt_Forward.Click += new System.EventHandler(this.Bt_Forward_Click);
            // 
            // Bt_Back
            // 
            this.Bt_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Back.ForeColor = System.Drawing.Color.White;
            this.Bt_Back.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Back.Image")));
            this.Bt_Back.Location = new System.Drawing.Point(2, 2);
            this.Bt_Back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Bt_Back.Name = "Bt_Back";
            this.Bt_Back.Size = new System.Drawing.Size(35, 35);
            this.Bt_Back.TabIndex = 0;
            this.Bt_Back.UseVisualStyleBackColor = true;
            this.Bt_Back.Click += new System.EventHandler(this.Bt_Back_Click);
            // 
            // Bt_Print
            // 
            this.Bt_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_Print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Bt_Print.BackgroundImage")));
            this.Bt_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Bt_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Print.ForeColor = System.Drawing.Color.White;
            this.Bt_Print.Location = new System.Drawing.Point(872, 8);
            this.Bt_Print.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Bt_Print.Name = "Bt_Print";
            this.Bt_Print.Size = new System.Drawing.Size(25, 25);
            this.Bt_Print.TabIndex = 4;
            this.Bt_Print.UseVisualStyleBackColor = true;
            this.Bt_Print.Click += new System.EventHandler(this.Bt_Print_Click);
            // 
            // Tx_Url
            // 
            this.Tx_Url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tx_Url.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tx_Url.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tx_Url.Location = new System.Drawing.Point(85, 7);
            this.Tx_Url.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Tx_Url.Name = "Tx_Url";
            this.Tx_Url.Size = new System.Drawing.Size(742, 25);
            this.Tx_Url.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Bt_Refresh);
            this.panel1.Controls.Add(this.Tx_Url);
            this.panel1.Controls.Add(this.Bt_Print);
            this.panel1.Controls.Add(this.Bt_Forward);
            this.panel1.Controls.Add(this.Bt_Back);
            this.panel1.Controls.Add(this.Bt_Stop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 40);
            this.panel1.TabIndex = 6;
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 40);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(912, 535);
            this.content.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(912, 575);
            this.Controls.Add(this.content);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.Button Bt_Forward;
		private System.Windows.Forms.Button Bt_Back;
		private System.Windows.Forms.Button Bt_Stop;
		private System.Windows.Forms.Button Bt_Refresh;
		private System.Windows.Forms.Button Bt_Print;
		private System.Windows.Forms.TextBox Tx_Url;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel content;
    }
}

