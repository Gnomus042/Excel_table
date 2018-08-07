using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Table
{
    public class Table
    {
        int H;
        int W;
        static Table instance;
        private Cell[,] T;
        private DataGridView data;
        private HTMLAdapt adapter;

        public static Table I()
        {
            if (instance == null)
            {
                instance = new Table();
            }
            return instance;
        }

        private Table()
        {

        }

        public int GetHeight()
        {
            return H;
        }

        public int GetWidth()
        {
            return W;
        }

        public double Change(int h, int w, string formula)
        {
            Parser parser = new Parser();
            TokenList a = parser.Parse(formula);
            List<string> vars = a.GetVars();
                T[h, w].formula = formula;
                foreach (string q in vars)
                {
                    int w1 = q[0] - 'A';
                    int w2 = Int32.Parse(q.Substring(1))-1;
                    T[w2, w1].AddHref(T[h,w]);
                }
            
            
            Show();
            return a.GetResult();
        }

        private void HeadersInit()
        {
            data.RowHeadersWidth = 50;
            for (int i = 0; i < data.RowCount; i++)
            {
                data.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            for (int i = 0; i < data.ColumnCount; i++)
            {
                data.Columns[i].HeaderText = ((char)('A' + i)).ToString();
            }
        }

        public void SetTable(DataGridView _data)
        {
            data = _data;
        }
        
        public void Resize(int h, int w)
        {
            data.RowCount = h;
            data.ColumnCount = w;
            
            if (h<=H||w<=W)
            {
                for (int i = h; i<H; i++)
                {
                    for (int j = 0; j<W; j++)
                    {
                        List<Cell> q = T[i, j].GetHrefs();
                        foreach (Cell z in q)
                        {
                            
                            z.formula = "0";
                        }
                    }
                }
                for (int i = 0; i < H; i++)
                {
                    for (int j = w; j < W; j++)
                    {
                        List<Cell> q = T[i, j].GetHrefs();
                        foreach (Cell z in q)
                        {

                            z.formula = "0";
                        }
                    }
                }
            }

            Cell[,] Tab = new Cell[h, w];
            for (int i = 0; i<h; i++)
            {
                for (int j = 0; j<w; j++)
                {
                    if (i < H && j < W)
                    {
                        Tab[i, j] = T[i, j];
                    }
                    else
                    {
                        Tab[i, j].value = 0;
                        Tab[i, j].formula = "0";
                    }
                }
            }

            T = Tab;
            H = h;
            W = w;
            Show();
            //int height = data.ColumnHeadersHeight;
            //for (int i = 0; i<data.RowCount; i++)
            //{
            //    height += data.Rows[i].Height;
            //}
            //data.Height = data.Location.Y+height;
            HeadersInit();
        }

        public void Create(int h, int w)
        {
            data.RowCount = h;
            data.ColumnCount = w;
            H = h;
            W = w;
            FillWith(null);
            Show();
            HeadersInit();
            adapter = new HTMLAdapt(null);
        }

        public void Open(string path)
        {
            adapter = new HTMLAdapt(path);
            H = adapter.GetHeight();
            W = adapter.GetWidth();
            data.RowCount = H;
            data.ColumnCount =W;
            T = new Cell[H, W];
            T = adapter.GetTable();
            HeadersInit();
            Show();

        }

        private void Show()
        {
            for (int i = 0; i < H; i++)
            {

                for (int j = 0; j < W; j++)
                {
                    if (T[i, j].value != 0)
                    {
                        data.Rows[i].Cells[j].Value = T[i, j].value;
                    }
                    else
                    {
                        data.Rows[i].Cells[j].Value = "";
                    }
                }
            }
        }

        public string GetPath()
        {
            return adapter.GetPath();
        }

        private void FillWith(string[,] info)
        {
            T = new Cell[H, W];
            if (info!=null)
            {
                
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        T[i, j] = new Cell(i, j);
                        T[i, j].value = Double.Parse(info[i, j]);
                        T[i, j].formula = info[i, j].ToString();
                    }
                }
                Show();
            }
            else
            {
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        T[i, j] = new Cell(i,j);   
                        T[i, j].value = 0;
                        T[i, j].formula = "0";
                    }
                }
            }
        }

        public double GetValue(int w, int h)
        {
            return T[h,w].value;
        }

        public string GetFormula(int w, int h)
        {
            return T[h,w].formula;
        }

        public void Save()
        {
            if (adapter.GetPath() == null)
            {
                throw new Exception();
            }
            else
            {
                adapter.Save(T, H, W);
            }
        }

        public void SaveNewFile(string path, string name)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                string p = path + @"\" + name + ".html";
                adapter = new HTMLAdapt(p);
                adapter.Save(T, H, W);
            }
            else
            {
                throw new Exception();
            }
        }


    }
}
