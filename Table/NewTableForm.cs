using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Table
{
    public partial class NewTableForm : Form
    {
        public NewTableForm()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
        }

       public int GetNewHeight()
        {
            return int.Parse(this.Height.Text);
        }

        public int GetNewWidth()
        {
            return int.Parse(this.Width.Text);
        }

        private void Height_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(this.Height.Text);
            }
            catch
            {
                this.Logs.Text = "Неправильний формат";
                this.OK.Enabled = false;
                return;
            }
            this.Logs.Text = "";
            this.OK.Enabled = true;

        }

        private void Width_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(this.Width.Text);
            }
            catch
            {
                this.Logs.Text = "Неправильний формат";
                this.OK.Enabled = false;
                return;
            }
            this.Logs.Text = "";
            this.OK.Enabled = true;
        }
    }
}
