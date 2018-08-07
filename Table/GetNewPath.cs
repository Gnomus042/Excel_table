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
    public partial class GetNewPath : Form
    {
        public GetNewPath()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
            
        }

        public string GetPath()
        {
            return this.Path.Text;
        }

        public string GetName()
        {
            return this.TName.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Path.Text = @"C:\Users\Настя\Documents\Visual Studio 2017\Projects\Table\test";
        }
    }
}
