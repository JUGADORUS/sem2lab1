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
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Buyers)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDrug
            // 
            this.textBoxDrug.Location = new System.Drawing.Point(101, 173);
            this.textBoxDrug.Name = "textBoxDrug";
            this.textBoxDrug.Size = new System.Drawing.Size(135, 22);
            this.textBoxDrug.TabIndex = 19;
            // 
            // labelForDrug
            // 
            this.labelForDrug.AutoSize = true;
            this.labelForDrug.Location = new System.Drawing.Point(32, 163);
            this.labelForDrug.Name = "labelForDrug";
            this.labelForDrug.Size = new System.Drawing.Size(71, 32);
            this.labelForDrug.TabIndex = 18;
            this.labelForDrug.Text = "Любимый \r\nпорошок:";
            // 
            // textBoxDistrict
            // 
            this.textBoxDistrict.Location = new System.Drawing.Point(101, 111);
            this.textBoxDistrict.Name = "textBoxDistrict";
            this.textBoxDistrict.Size = new System.Drawing.Size(135, 22);
            this.textBoxDistrict.TabIndex = 17;
            // 
            // labelForDistrict
            // 
            this.labelForDistrict.AutoSize = true;
            this.labelForDistrict.Location = new System.Drawing.Point(32, 111);
            this.labelForDistrict.Name = "labelForDistrict";
            this.labelForDistrict.Size = new System.Drawing.Size(51, 16);
            this.labelForDistrict.TabIndex = 16;
            this.labelForDistrict.Text = "Район:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(101, 63);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(135, 22);
            this.textBoxName.TabIndex = 15;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(268, 364);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 14;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click_1);
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(153, 364);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(95, 23);
            this.button_Update.TabIndex = 13;
            this.button_Update.Text = "Обновить";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(35, 365);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(97, 23);
            this.button_Create.TabIndex = 12;
            this.button_Create.Text = "Добавить";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click_1);
            // 
            // labelForName
            // 
            this.labelForName.AutoSize = true;
            this.labelForName.Location = new System.Drawing.Point(32, 63);
            this.labelForName.Name = "labelForName";
            this.labelForName.Size = new System.Drawing.Size(41, 16);
            this.labelForName.TabIndex = 11;
            this.labelForName.Text = "ФИО:";
            // 
            // DGV_Buyers
            // 
            this.DGV_Buyers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Buyers.Location = new System.Drawing.Point(279, 63);
            this.DGV_Buyers.Name = "DGV_Buyers";
            this.DGV_Buyers.RowHeadersWidth = 51;
            this.DGV_Buyers.RowTemplate.Height = 24;
            this.DGV_Buyers.Size = new System.Drawing.Size(490, 248);
            this.DGV_Buyers.TabIndex = 10;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(304, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(372, 36);
            this.listBox1.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
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
        private System.Windows.Forms.ListBox listBox1;
    }
}

