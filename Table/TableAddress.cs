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
    public partial class TableAddress : Form
    {
        public TableAddress()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
        }

        public string GetPath()
        {
            return textBox1.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = @"C:\Users\Настя\Documents\Visual Studio 2017\Projects\Table\test";
        }
    }
}
