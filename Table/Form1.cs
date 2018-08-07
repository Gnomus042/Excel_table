using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Table
{
    public partial class TableForm : Form
    {


        private static string text = "";
        int ah = 0;
        int aw = 0;
        bool saved = true;
        

        public TableForm()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
           // this.GrTable.RowCount = (int)(GrTable.Height / GrTable.RowTemplate.Height); 
            this.GrTable.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.FormClosing += new FormClosingEventHandler(this.Form1_Closing);

            GrTable.Left = 0;
            GrTable.Top = 60;
            GrTable.Size = new Size(this.Size.Width, this.Size.Width - 60);

            
            this.GrTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellClick);
            this.GrTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_CellRed);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Key_Handler);

            Table.I().SetTable(GrTable);
            Table.I().Create(10, 3);
        }

        public string GetLastPath()
        {
            string path = File.ReadAllText(@"../../For tables/last_path.txt", Encoding.GetEncoding(1251));
            return path;
        }

        private void Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int h = e.RowIndex;
            int w = e.ColumnIndex;
            if (h != -1 && w != -1)
            {
                ah = h;
                aw = w;
                string formula = Table.I().GetFormula(w, h);
                text = "=" + formula;
                
                FormText.Text = text;
                
            }
        }

        private void Table_CellRed(object sender, DataGridViewCellEventArgs e)
        {

            if (this.GrTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string a = this.GrTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            
            text = "=" + a;
                try
                {
                    Table.I().Change(ah, aw, a);
                    saved = false;
                    this.FormText.Text = text;
                }
                catch (Exception w)
                {
                    this.GrTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    MessageBox.Show(w.Message);
                }
            }
        }

        private void Key_Handler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string t = this.FormText.Text;
                if (t!=text)
                {
                    if (t[0]=='=')
                    {
                        t = t.Substring(1);
                        
                        try
                        {
                            double a = Table.I().Change(ah, aw, t);
                            text = "=" + a.ToString();
                            saved = false;
                            this.FormText.Text = text;
                        }
                        catch (Exception f)
                        {
                            MessageBox.Show(f.Message);
                        }
                        
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void створитиНовуТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved != true)
            {
                YesNo y = new YesNo("Ви бажаєте зберігти зміни?");
                switch (y.ShowDialog())
                {
                    case DialogResult.Yes:
                        Save();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            int h = 0;
            int w = 0;
            NewTableForm form = new NewTableForm();
            switch (form.ShowDialog() )
            {
                case DialogResult.OK:
                h = form.GetNewHeight();
                w = form.GetNewWidth();
                    break;
                case DialogResult.Cancel:
                    return;
                    break;

            }
            Table.I().Create(h,w);
          
        }

        private void зберегтиЗміниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void OpenTable_Click(object sender, EventArgs e)
        {
            if (saved!=true)
            {
                YesNo y = new YesNo("Ви бажаєте зберігти зміни?");
                switch (y.ShowDialog())
                {
                    case DialogResult.Yes:
                        Save();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            TableAddress t = new TableAddress();
            string path = null;
            saved = true;
            switch(t.ShowDialog() )
            {
                case DialogResult.OK:
                path = t.GetPath();
                    break;
                case DialogResult.Cancel:
                    return;
                    break;
            }
            try
            {
                Table.I().Open(path);
                this.FormText.Text = "=";
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void змінитиРозмірToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTableForm t = new NewTableForm();
            int h = 0;
            int w = 0;
            saved = false;
            switch (t.ShowDialog() )
            {
                case DialogResult.OK:
                h = t.GetNewHeight();
                w = t.GetNewWidth();
                    break;
                case DialogResult.Cancel:
                    return;
                    break;
            }
            int H = Table.I().GetHeight();
            int W = Table.I().GetWidth();
            if (h < H || w < W)
            {
                YesNo y = new YesNo("Розмір нової таблиці менший, за розмір існуючої, тому деякі дані може бути втрачено. Ви бажаєте змінити розмір?");
                switch (y.ShowDialog())
                {
                    case DialogResult.Yes:
                        Table.I().Resize(h, w);
                        this.FormText.Text = "=";

                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                Table.I().Resize(h, w);
                this.FormText.Text = "=";

            }
        }

        private void Save()
        {
            try
            {
                Table.I().Save();
                saved = true;
            }
            catch
            {
                GetNewPath p = new GetNewPath();
                string path = null;
                string name = null;
                switch(p.ShowDialog()) 
                {
                    case DialogResult.OK:
                        path = p.GetPath();
                        name = p.GetName();
                        Table.I().SaveNewFile(path, name);
                        break;
                    case DialogResult.Cancel:
                        break;
                }
                
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (saved != true)
            {

                YesNo y = new YesNo("Ви бажаєте зберігти зміни?");
                switch (y.ShowDialog())
                {
                    case DialogResult.Yes:
                        Save();
                        break;
                    case DialogResult.No:
                        
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                        break;
                }
            }
            string path = Table.I().GetPath();
            File.WriteAllText(@"../../For tables/last_path.txt", path, Encoding.GetEncoding(1251));
        }

        private void GrTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void відкритиОстаннюТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetLastPath();
            Table.I().Open(path);
        }

        private void інформаціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info inf = new Info();
            inf.ShowDialog();
        }
    }
}
