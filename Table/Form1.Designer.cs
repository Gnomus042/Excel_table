namespace Table
{
    partial class TableForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.операціїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.створитиНовуТаблицюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenTable = new System.Windows.Forms.ToolStripMenuItem();
            this.змінитиРозмірToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиЗміниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиОстаннюТаблицюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.інформаціяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.FormText = new System.Windows.Forms.TextBox();
            this.GrTable = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операціїToolStripMenuItem,
            this.інформаціяToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // операціїToolStripMenuItem
            // 
            this.операціїToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.створитиНовуТаблицюToolStripMenuItem,
            this.OpenTable,
            this.змінитиРозмірToolStripMenuItem,
            this.зберегтиЗміниToolStripMenuItem,
            this.відкритиОстаннюТаблицюToolStripMenuItem});
            this.операціїToolStripMenuItem.Name = "операціїToolStripMenuItem";
            this.операціїToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.операціїToolStripMenuItem.Text = "Операції";
            // 
            // створитиНовуТаблицюToolStripMenuItem
            // 
            this.створитиНовуТаблицюToolStripMenuItem.Name = "створитиНовуТаблицюToolStripMenuItem";
            this.створитиНовуТаблицюToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.створитиНовуТаблицюToolStripMenuItem.Text = "Створити нову таблицю";
            this.створитиНовуТаблицюToolStripMenuItem.Click += new System.EventHandler(this.створитиНовуТаблицюToolStripMenuItem_Click);
            // 
            // OpenTable
            // 
            this.OpenTable.Name = "OpenTable";
            this.OpenTable.Size = new System.Drawing.Size(225, 22);
            this.OpenTable.Text = "Відкрити існуючу таблицю";
            this.OpenTable.Click += new System.EventHandler(this.OpenTable_Click);
            // 
            // змінитиРозмірToolStripMenuItem
            // 
            this.змінитиРозмірToolStripMenuItem.Name = "змінитиРозмірToolStripMenuItem";
            this.змінитиРозмірToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.змінитиРозмірToolStripMenuItem.Text = "Змінити розмір";
            this.змінитиРозмірToolStripMenuItem.Click += new System.EventHandler(this.змінитиРозмірToolStripMenuItem_Click);
            // 
            // зберегтиЗміниToolStripMenuItem
            // 
            this.зберегтиЗміниToolStripMenuItem.Name = "зберегтиЗміниToolStripMenuItem";
            this.зберегтиЗміниToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.зберегтиЗміниToolStripMenuItem.Text = "Зберегти зміни";
            this.зберегтиЗміниToolStripMenuItem.Click += new System.EventHandler(this.зберегтиЗміниToolStripMenuItem_Click);
            // 
            // відкритиОстаннюТаблицюToolStripMenuItem
            // 
            this.відкритиОстаннюТаблицюToolStripMenuItem.Name = "відкритиОстаннюТаблицюToolStripMenuItem";
            this.відкритиОстаннюТаблицюToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.відкритиОстаннюТаблицюToolStripMenuItem.Text = "Відкрити останню таблицю";
            this.відкритиОстаннюТаблицюToolStripMenuItem.Click += new System.EventHandler(this.відкритиОстаннюТаблицюToolStripMenuItem_Click);
            // 
            // інформаціяToolStripMenuItem
            // 
            this.інформаціяToolStripMenuItem.Name = "інформаціяToolStripMenuItem";
            this.інформаціяToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.інформаціяToolStripMenuItem.Text = "Інформація";
            this.інформаціяToolStripMenuItem.Click += new System.EventHandler(this.інформаціяToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Формула: ";
            // 
            // FormText
            // 
            this.FormText.Location = new System.Drawing.Point(76, 28);
            this.FormText.Name = "FormText";
            this.FormText.Size = new System.Drawing.Size(484, 20);
            this.FormText.TabIndex = 3;
            this.FormText.Text = "=";
            // 
            // GrTable
            // 
            this.GrTable.AllowUserToAddRows = false;
            this.GrTable.AllowUserToDeleteRows = false;
            this.GrTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrTable.Location = new System.Drawing.Point(0, 54);
            this.GrTable.MultiSelect = false;
            this.GrTable.Name = "GrTable";
            this.GrTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = "1";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GrTable.RowTemplate.Height = 30;
            this.GrTable.Size = new System.Drawing.Size(628, 329);
            this.GrTable.TabIndex = 4;
            this.GrTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrTable_CellContentClick);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 385);
            this.Controls.Add(this.GrTable);
            this.Controls.Add(this.FormText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Table";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem операціїToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FormText;
        private System.Windows.Forms.DataGridView GrTable;
        private System.Windows.Forms.ToolStripMenuItem створитиНовуТаблицюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenTable;
        private System.Windows.Forms.ToolStripMenuItem змінитиРозмірToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиЗміниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиОстаннюТаблицюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem інформаціяToolStripMenuItem;
    }
}

