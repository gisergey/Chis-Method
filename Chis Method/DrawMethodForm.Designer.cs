namespace Chis_Method
{
    partial class DrawMethodForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AmountPoints_TrackBar = new System.Windows.Forms.TrackBar();
            this.PointAmount_TextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AmountPoints_TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // AmountPoints_TrackBar
            // 
            this.AmountPoints_TrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountPoints_TrackBar.BackColor = System.Drawing.Color.Black;
            this.AmountPoints_TrackBar.Location = new System.Drawing.Point(409, 12);
            this.AmountPoints_TrackBar.Maximum = 501;
            this.AmountPoints_TrackBar.Minimum = 2;
            this.AmountPoints_TrackBar.Name = "AmountPoints_TrackBar";
            this.AmountPoints_TrackBar.Size = new System.Drawing.Size(463, 45);
            this.AmountPoints_TrackBar.TabIndex = 0;
            this.AmountPoints_TrackBar.Value = 11;
            this.AmountPoints_TrackBar.Scroll += new System.EventHandler(this.AmountPoints_TrackBar_Scroll);
            // 
            // PointAmount_TextBox
            // 
            this.PointAmount_TextBox.BackColor = System.Drawing.Color.Black;
            this.PointAmount_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointAmount_TextBox.ForeColor = System.Drawing.Color.DarkOrchid;
            this.PointAmount_TextBox.Location = new System.Drawing.Point(303, 12);
            this.PointAmount_TextBox.Name = "PointAmount_TextBox";
            this.PointAmount_TextBox.Size = new System.Drawing.Size(100, 44);
            this.PointAmount_TextBox.TabIndex = 1;
            this.PointAmount_TextBox.Text = "6";
            this.PointAmount_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PointAmount_TextBox.TextChanged += new System.EventHandler(this.PointAmount_TextBox_TextChanged);
            // 
            // DrawMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.PointAmount_TextBox);
            this.Controls.Add(this.AmountPoints_TrackBar);
            this.Name = "DrawMethodForm";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MethodDraw_Paint);
            this.Resize += new System.EventHandler(this.DrawMethodForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.AmountPoints_TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar AmountPoints_TrackBar;
        private System.Windows.Forms.TextBox PointAmount_TextBox;
    }
}

