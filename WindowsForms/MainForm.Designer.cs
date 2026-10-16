namespace WindowsForms
{
    partial class MainForm
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
            this.textBoxDrug = new System.Windows.Forms.TextBox();
            this.labelForDrug = new System.Windows.Forms.Label();
            this.textBoxDistrict = new System.Windows.Forms.TextBox();
            this.labelForDistrict = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.button_Create = new System.Windows.Forms.Button();
            this.labelForName = new System.Windows.Forms.Label();
            this.DGV_Buyers = new System.Windows.Forms.DataGridView();
            this.listBoxDrugs = new System.Windows.Forms.ListBox();
            this.button_Reset = new System.Windows.Forms.Button();
            this.bttnReportDistricts = new System.Windows.Forms.Button();
            this.NameColl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistrictColl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrugColl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Buyers)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDrug
            // 
            this.textBoxDrug.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDrug.Location = new System.Drawing.Point(177, 381);
            this.textBoxDrug.Name = "textBoxDrug";
            this.textBoxDrug.Size = new System.Drawing.Size(179, 30);
            this.textBoxDrug.TabIndex = 19;
            // 
            // labelForDrug
            // 
            this.labelForDrug.AutoSize = true;
            this.labelForDrug.BackColor = System.Drawing.Color.DarkSlateGray;
            this.labelForDrug.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForDrug.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelForDrug.Location = new System.Drawing.Point(30, 353);
            this.labelForDrug.Name = "labelForDrug";
            this.labelForDrug.Size = new System.Drawing.Size(141, 58);
            this.labelForDrug.TabIndex = 18;
            this.labelForDrug.Text = "Любимый \r\nпорошок:";
            // 
            // textBoxDistrict
            // 
            this.textBoxDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDistrict.Location = new System.Drawing.Point(131, 309);
            this.textBoxDistrict.Name = "textBoxDistrict";
            this.textBoxDistrict.Size = new System.Drawing.Size(225, 30);
            this.textBoxDistrict.TabIndex = 17;
            // 
            // labelForDistrict
            // 
            this.labelForDistrict.AutoSize = true;
            this.labelForDistrict.BackColor = System.Drawing.Color.DarkSlateGray;
            this.labelForDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForDistrict.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelForDistrict.Location = new System.Drawing.Point(30, 309);
            this.labelForDistrict.Name = "labelForDistrict";
            this.labelForDistrict.Size = new System.Drawing.Size(95, 29);
            this.labelForDistrict.TabIndex = 16;
            this.labelForDistrict.Text = "Район:";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(120, 268);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(236, 30);
            this.textBoxName.TabIndex = 15;
            // 
            // button_Delete
            // 
            this.button_Delete.BackColor = System.Drawing.Color.CadetBlue;
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Delete.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_Delete.Location = new System.Drawing.Point(282, 445);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(123, 42);
            this.button_Delete.TabIndex = 14;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = false;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click_1);
            // 
            // button_Update
            // 
            this.button_Update.BackColor = System.Drawing.Color.CadetBlue;
            this.button_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Update.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_Update.Location = new System.Drawing.Point(157, 445);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(119, 42);
            this.button_Update.TabIndex = 13;
            this.button_Update.Text = "Обновить";
            this.button_Update.UseVisualStyleBackColor = false;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Create
            // 
            this.button_Create.BackColor = System.Drawing.Color.CadetBlue;
            this.button_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Create.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_Create.Location = new System.Drawing.Point(28, 445);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(123, 42);
            this.button_Create.TabIndex = 12;
            this.button_Create.Text = "Добавить";
            this.button_Create.UseVisualStyleBackColor = false;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click_1);
            // 
            // labelForName
            // 
            this.labelForName.AutoSize = true;
            this.labelForName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.labelForName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelForName.Location = new System.Drawing.Point(30, 269);
            this.labelForName.Name = "labelForName";
            this.labelForName.Size = new System.Drawing.Size(84, 29);
            this.labelForName.TabIndex = 11;
            this.labelForName.Text = "ФИО:";
            // 
            // DGV_Buyers
            // 
            this.DGV_Buyers.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.DGV_Buyers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Buyers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColl,
            this.DistrictColl,
            this.DrugColl});
            this.DGV_Buyers.Location = new System.Drawing.Point(628, 163);
            this.DGV_Buyers.Name = "DGV_Buyers";
            this.DGV_Buyers.RowHeadersWidth = 51;
            this.DGV_Buyers.RowTemplate.Height = 24;
            this.DGV_Buyers.Size = new System.Drawing.Size(643, 346);
            this.DGV_Buyers.TabIndex = 10;
            this.DGV_Buyers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Buyers_CellContentClick);
            // 
            // listBoxDrugs
            // 
            this.listBoxDrugs.BackColor = System.Drawing.Color.MintCream;
            this.listBoxDrugs.FormattingEnabled = true;
            this.listBoxDrugs.ItemHeight = 16;
            this.listBoxDrugs.Location = new System.Drawing.Point(628, 111);
            this.listBoxDrugs.Name = "listBoxDrugs";
            this.listBoxDrugs.Size = new System.Drawing.Size(528, 36);
            this.listBoxDrugs.TabIndex = 20;
            this.listBoxDrugs.SelectedIndexChanged += new System.EventHandler(this.listBoxDrugs_SelectedIndexChanged);
            // 
            // button_Reset
            // 
            this.button_Reset.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Reset.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_Reset.Location = new System.Drawing.Point(1196, 111);
            this.button_Reset.Margin = new System.Windows.Forms.Padding(1);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(75, 36);
            this.button_Reset.TabIndex = 21;
            this.button_Reset.Text = "Reset";
            this.button_Reset.UseVisualStyleBackColor = false;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // bttnReportDistricts
            // 
            this.bttnReportDistricts.BackColor = System.Drawing.Color.DarkSlateGray;
            this.bttnReportDistricts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bttnReportDistricts.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.bttnReportDistricts.Location = new System.Drawing.Point(1102, 627);
            this.bttnReportDistricts.Name = "bttnReportDistricts";
            this.bttnReportDistricts.Size = new System.Drawing.Size(169, 49);
            this.bttnReportDistricts.TabIndex = 22;
            this.bttnReportDistricts.Text = "Просмотреть отчет";
            this.bttnReportDistricts.UseVisualStyleBackColor = false;
            this.bttnReportDistricts.Click += new System.EventHandler(this.bttnReportDistricts_Click);
            // 
            // NameColl
            // 
            this.NameColl.DataPropertyName = "Name";
            this.NameColl.HeaderText = "ФИО:";
            this.NameColl.MinimumWidth = 6;
            this.NameColl.Name = "NameColl";
            this.NameColl.Width = 215;
            // 
            // DistrictColl
            // 
            this.DistrictColl.DataPropertyName = "District";
            this.DistrictColl.HeaderText = "Район:";
            this.DistrictColl.MinimumWidth = 6;
            this.DistrictColl.Name = "DistrictColl";
            this.DistrictColl.Width = 200;
            // 
            // DrugColl
            // 
            this.DrugColl.DataPropertyName = "FavouriteDrug";
            this.DrugColl.HeaderText = "Наркотик:";
            this.DrugColl.MinimumWidth = 6;
            this.DrugColl.Name = "DrugColl";
            this.DrugColl.Width = 185;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsForms.Properties.Resources.Inside_Van;
            this.ClientSize = new System.Drawing.Size(1321, 721);
            this.Controls.Add(this.bttnReportDistricts);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.listBoxDrugs);
            this.Controls.Add(this.textBoxDrug);
            this.Controls.Add(this.labelForDrug);
            this.Controls.Add(this.textBoxDistrict);
            this.Controls.Add(this.labelForDistrict);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.labelForName);
            this.Controls.Add(this.DGV_Buyers);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load1);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Buyers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDrug;
        private System.Windows.Forms.Label labelForDrug;
        private System.Windows.Forms.TextBox textBoxDistrict;
        private System.Windows.Forms.Label labelForDistrict;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Label labelForName;
        private System.Windows.Forms.DataGridView DGV_Buyers;
        private System.Windows.Forms.ListBox listBoxDrugs;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Button bttnReportDistricts;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColl;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistrictColl;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrugColl;
    }
}

