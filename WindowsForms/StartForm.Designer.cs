namespace WindowsForms
{
    partial class StartForm
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAuthor1 = new System.Windows.Forms.Label();
            this.labelAuthor2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(315, 216);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(155, 61);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Войти (опасно)";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(315, 293);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(155, 61);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(152, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 108);
            this.label1.TabIndex = 2;
            this.label1.Text = "Бизнес лабаратория \r\n(никакой черни)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelAuthor1
            // 
            this.labelAuthor1.AutoSize = true;
            this.labelAuthor1.Location = new System.Drawing.Point(674, 425);
            this.labelAuthor1.Name = "labelAuthor1";
            this.labelAuthor1.Size = new System.Drawing.Size(114, 16);
            this.labelAuthor1.TabIndex = 3;
            this.labelAuthor1.Text = "В.И. Степаненко";
            // 
            // labelAuthor2
            // 
            this.labelAuthor2.AutoSize = true;
            this.labelAuthor2.Location = new System.Drawing.Point(686, 409);
            this.labelAuthor2.Name = "labelAuthor2";
            this.labelAuthor2.Size = new System.Drawing.Size(102, 16);
            this.labelAuthor2.TabIndex = 4;
            this.labelAuthor2.Text = "И.В. Савельев ";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAuthor2);
            this.Controls.Add(this.labelAuthor1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStart);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAuthor1;
        private System.Windows.Forms.Label labelAuthor2;
    }
}