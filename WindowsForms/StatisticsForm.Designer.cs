namespace WindowsForms
{
    partial class StatisticsForm
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
            this.DGV_Stats = new System.Windows.Forms.DataGridView();
            this.DistrictColl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrugColl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountColl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Stats)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Stats
            // 
            this.DGV_Stats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Stats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DistrictColl,
            this.DrugColl,
            this.CountColl});
            this.DGV_Stats.Location = new System.Drawing.Point(55, 12);
            this.DGV_Stats.Name = "DGV_Stats";
            this.DGV_Stats.RowHeadersWidth = 51;
            this.DGV_Stats.RowTemplate.Height = 24;
            this.DGV_Stats.Size = new System.Drawing.Size(694, 378);
            this.DGV_Stats.TabIndex = 0;
            this.DGV_Stats.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Stats_CellContentClick);
            // 
            // DistrictColl
            // 
            this.DistrictColl.HeaderText = "Район";
            this.DistrictColl.MinimumWidth = 6;
            this.DistrictColl.Name = "DistrictColl";
            this.DistrictColl.Width = 210;
            // 
            // DrugColl
            // 
            this.DrugColl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DrugColl.HeaderText = "Наркотик";
            this.DrugColl.MinimumWidth = 6;
            this.DrugColl.Name = "DrugColl";
            // 
            // CountColl
            // 
            this.CountColl.HeaderText = "Количество";
            this.CountColl.MinimumWidth = 6;
            this.CountColl.Name = "CountColl";
            this.CountColl.Width = 125;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(606, 415);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(143, 23);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Вернуться";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.DGV_Stats);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Stats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Stats;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistrictColl;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrugColl;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountColl;
    }
}