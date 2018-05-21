namespace DarrenSHARPSHOOTER
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
            this.components = new System.ComponentModel.Container();
            this.Clock = new System.Windows.Forms.Timer(this.components);
            this.start = new System.Windows.Forms.Label();
            this.LEVEL1 = new System.Windows.Forms.Label();
            this.HEALTH = new System.Windows.Forms.Label();
            this.heart = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.heart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).BeginInit();
            this.SuspendLayout();
            // 
            // Clock
            // 
            this.Clock.Interval = 20;
            this.Clock.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Font = new System.Drawing.Font("Franklin Gothic Medium", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.ForeColor = System.Drawing.Color.Red;
            this.start.Location = new System.Drawing.Point(240, 257);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(271, 101);
            this.start.TabIndex = 1;
            this.start.Text = "START";
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // LEVEL1
            // 
            this.LEVEL1.AutoSize = true;
            this.LEVEL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEVEL1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LEVEL1.Location = new System.Drawing.Point(266, 278);
            this.LEVEL1.Name = "LEVEL1";
            this.LEVEL1.Size = new System.Drawing.Size(214, 55);
            this.LEVEL1.TabIndex = 2;
            this.LEVEL1.Text = "LEVEL 1";
            this.LEVEL1.Visible = false;
            // 
            // HEALTH
            // 
            this.HEALTH.AutoSize = true;
            this.HEALTH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HEALTH.ForeColor = System.Drawing.Color.Lime;
            this.HEALTH.Location = new System.Drawing.Point(717, 506);
            this.HEALTH.Name = "HEALTH";
            this.HEALTH.Size = new System.Drawing.Size(73, 20);
            this.HEALTH.TabIndex = 3;
            this.HEALTH.Text = "HEALTH";
            this.HEALTH.Visible = false;
            // 
            // heart
            // 
            this.heart.Image = global::DarrenSHARPSHOOTER.Properties.Resources._8_bit_heart_stock_by_xquatrox_d4r844m;
            this.heart.Location = new System.Drawing.Point(702, 491);
            this.heart.Name = "heart";
            this.heart.Size = new System.Drawing.Size(70, 58);
            this.heart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heart.TabIndex = 4;
            this.heart.TabStop = false;
            this.heart.Visible = false;
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Black;
            this.title.Image = global::DarrenSHARPSHOOTER.Properties.Resources.Title;
            this.title.Location = new System.Drawing.Point(91, 28);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(594, 196);
            this.title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.title.TabIndex = 0;
            this.title.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.HEALTH);
            this.Controls.Add(this.LEVEL1);
            this.Controls.Add(this.start);
            this.Controls.Add(this.title);
            this.Controls.Add(this.heart);
            this.Name = "MainForm";
            this.Text = "Sharpshooter";
            ((System.ComponentModel.ISupportInitialize)(this.heart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Clock;
        private System.Windows.Forms.PictureBox title;
        private System.Windows.Forms.Label start;
        private System.Windows.Forms.Label LEVEL1;
        private System.Windows.Forms.Label HEALTH;
        private System.Windows.Forms.PictureBox heart;
    }
}

