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
    public partial class YesNo : Form
    {
        public YesNo(string question)
        {
            InitializeComponent();
            label.Text = question;
            YES.DialogResult = DialogResult.Yes;
            NO.DialogResult = DialogResult.No;
        }

        private void YesNo_Load(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}
