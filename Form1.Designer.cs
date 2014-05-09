namespace FormTerminal
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
            this.text = new System.Windows.Forms.Label();
            this.text_cursor = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.merowinger = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("Consolas", 13.94764F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text.ForeColor = System.Drawing.Color.Lime;
            this.text.Location = new System.Drawing.Point(39, 36);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(79, 43);
            this.text.TabIndex = 0;
            this.text.Text = ">: ";
            // 
            // text_cursor
            // 
            this.text_cursor.AutoSize = true;
            this.text_cursor.Font = new System.Drawing.Font("Consolas", 13.94764F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_cursor.ForeColor = System.Drawing.Color.Lime;
            this.text_cursor.Location = new System.Drawing.Point(39, 36);
            this.text_cursor.Name = "text_cursor";
            this.text_cursor.Size = new System.Drawing.Size(99, 43);
            this.text_cursor.TabIndex = 1;
            this.text_cursor.Text = ">: █";
            this.text_cursor.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // merowinger
            // 
            this.merowinger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.merowinger.AutoSize = true;
            this.merowinger.Font = new System.Drawing.Font("Consolas", 13.94764F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.merowinger.ForeColor = System.Drawing.Color.Orange;
            this.merowinger.Location = new System.Drawing.Point(889, 531);
            this.merowinger.Name = "merowinger";
            this.merowinger.Size = new System.Drawing.Size(39, 43);
            this.merowinger.TabIndex = 2;
            this.merowinger.Text = "π";
            this.merowinger.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.merowinger.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(940, 583);
            this.Controls.Add(this.merowinger);
            this.Controls.Add(this.text_cursor);
            this.Controls.Add(this.text);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.TransparencyKey = System.Drawing.Color.Yellow;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Label text_cursor;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label merowinger;
        private System.Windows.Forms.Timer timer2;

    }
}

