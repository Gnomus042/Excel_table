namespace Table
{
    partial class YesNo
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
            this.YES = new System.Windows.Forms.Button();
            this.NO = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // YES
            // 
            this.YES.Location = new System.Drawing.Point(51, 76);
            this.YES.Name = "YES";
            this.YES.Size = new System.Drawing.Size(75, 23);
            this.YES.TabIndex = 1;
            this.YES.Text = "ТАК";
            this.YES.UseVisualStyleBackColor = true;
            // 
            // NO
            // 
            this.NO.Location = new System.Drawing.Point(158, 76);
            this.NO.Name = "NO";
            this.NO.Size = new System.Drawing.Size(75, 23);
            this.NO.TabIndex = 2;
            this.NO.Text = "НІ";
            this.NO.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.ReadOnly = true;
            this.label.Size = new System.Drawing.Size(287, 70);
            this.label.TabIndex = 3;
            this.label.Text = "";
            // 
            // YesNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.label);
            this.Controls.Add(this.NO);
            this.Controls.Add(this.YES);
            this.Name = "YesNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Table";
            this.Load += new System.EventHandler(this.YesNo_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button YES;
        private System.Windows.Forms.Button NO;
        private System.Windows.Forms.RichTextBox label;
    }
}