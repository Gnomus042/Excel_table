using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Table
{
    public class Cell
    {
        private string name;
        private double val;
        private string form;
        private List<Cell> hrefs;

        public Cell(int h, int w)
        {
            name = "$" + (char)(w + 'A') + (h + 1);
            hrefs = new List<Cell>();
        }

        public double value
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }

        public string formula
        {
            get { return form; }
            set
            {
                if (CheckFormula(value) == false)
                {
                    throw new Exception("Знайдено цикл");
                }
                
                form = value;
                Renew();
            }
        }

        public void AddHref(Cell a)
        {
            hrefs.Add(a);
        }

        public void ClearHrefs()
        {
            hrefs = new List<Cell>();
        }

        public List<Cell> GetHrefs()
        {
            return hrefs;
        }

        public void SetHrefs(List<Cell> h)
        {
            hrefs = h;
        }

        public void Renew()
        {
            Parser parser = new Parser();
            TokenList t = parser.Parse(formula);
            val = t.GetResult();
            foreach (Cell h in hrefs)
                {
                    h.Renew();
                }
        }

        public bool CheckFormula(string f)
        {
            if (f.Contains(name))
            {
                return false;
            }
            else
            {
                foreach (Cell h in hrefs)
                {
                    bool a = h.CheckFormula(f);
                    if (a == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        
    }
}
