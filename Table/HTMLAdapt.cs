using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Table
{
    public class HTMLAdapt
    {
        private string path;
        private int w = 0;
        private int h = 0;

        public HTMLAdapt(string _path)
        {
            
            //if (_path!=null)
            //{
            //    FileInfo f = new FileInfo(_path);
            //    if (!f.Exists)
            //    {
            //        throw new Exception("Файл не знайдено");
            //    }
            //}
            path = _path;
        }

        public void UnsetPath()
        {
            path = null;
        }

        public void SetPath(string _path)
        {
            path = _path;
        }

        public string GetPath()
        {
            return path;
        }

        public int GetHeight()
        {
            string[] lines = File.ReadAllLines(path, Encoding.GetEncoding(1251));
            int c = 0;
            while  (!lines[c].Contains("id='H'"))
            {
                c++;
            }
            int a = lines[c].IndexOf(':');
            int b = lines[c].LastIndexOf('<');
            string s = lines[c].Substring(a+1, b-a-1);
            h = Int32.Parse(s);
            return h;
        }

        public int GetWidth()
        {
            string[] lines = File.ReadAllLines(path);
            int c = 0;
            while (!lines[c].Contains("id='W'"))
            {
                c++;
            }

            int a = lines[c].IndexOf(':');
            int b = lines[c].LastIndexOf('<');
            string s = lines[c].Substring(a+1, b - a-1);
            
             w = Int32.Parse(s);
            return w;
        }

        public Cell[,] GetTable()
        {
            string[] lines = File.ReadAllLines(path);
            Cell[,] result;
            GetWidth();
            GetHeight();
            int c = 0;
            while (!lines[c].Contains("Values:"))
            {
                
                c++;
            }
            result = new Cell[h, w];
            int tr = -1;
            int td = 0;
            while (!lines[c].Contains("Formulas"))
            {
                if (lines[c].Contains("tr")&&!lines[c].Contains("/"))
                {
                    tr++;
                    td = 0;
                }
                else if (lines[c].Contains("td"))
                {
                    if (tr!= 0&&td!=0)
                    {
                        result[tr-1, td-1].value = ValParser(lines[c]);
                    }
                    td++;
                    
                }
                c++;
            }
            tr = -1;
            td = 0;
            while (c!=lines.Count())
            {
                if (lines[c].Contains("tr") && !lines[c].Contains("/"))
                {
                    tr++;
                    td = 0;
                }
                else if (lines[c].Contains("td"))
                {
                    if (tr != 0 && td != 0)
                    {
                        result[tr-1, td-1].formula = FormParser(lines[c]);
                    }
                    td++;
                }
                c++;
            }


            return result;
        }

        private string FormParser(string a)
        {
            int a1 = a.IndexOf('>');
            int b1 = a.LastIndexOf('<');
            return a.Substring(a1 + 1, b1 - a1 - 1);
        }

        private double ValParser(string a)
        {
            int a1 = a.IndexOf('>');
            int b1 = a.LastIndexOf('<');
            if (b1-a1-1==0)
            {
                return 0;
            }
            else
            {
                return Double.Parse(a.Substring(a1 + 1, b1 - a1 - 1));
            }
            
        }

        public void Save(Cell[,] T, int H, int W)
        {
            File.WriteAllText(path, string.Empty);
            string[] text = File.ReadAllLines(@"..\..\For tables\tytle.txt", Encoding.GetEncoding(1251));
            List<string> text1 = text.ToList();
            text1.Add("<p id='W'>Width:"+W+"</p>");
            text1.Add("<p id='H'>Height: " + H + "</p>");
            text1.Add("<h2>Values:</h2>");
            text1.Add("<table border = "+1+"> ");
            for (int i = 0; i<=H; i++)
            {
                text1.Add("<tr>");
                for (int j = 0; j <= W; j++)
                {
                    if (i==0&&j==0)
                    {
                        text1.Add("<td></td>");
                    }
                    else if (i==0&&j!=0)
                    {
                        char a = (char)('A' + j - 1);
                        text1.Add("<td>"+a+"</td>");
                    }
                    else if (i!=0 && j==0)
                    {
                        text1.Add("<td>" + i + "</td>");
                    }
                    else
                    {
                        text1.Add("<td>" + T[i-1,j-1].value + "</td>");
                    }
                }
                text1.Add("</tr>");
            }
            text1.Add("</table> ");
            text1.Add("<h2>Formulas:</h2>");
            text1.Add("<table border = " + 1 + "> ");
            for (int i = 0; i <= H; i++)
            {
                text1.Add("<tr>");
                for (int j = 0; j <= W; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        text1.Add("<td></td>");
                    }
                    else if (i == 0 && j != 0)
                    {
                        char a = (char)('A' + j - 1);
                        text1.Add("<td>" + a + "</td>");
                    }
                    else if (i != 0 && j == 0)
                    {
                        text1.Add("<td>" + i + "</td>");
                    }
                    else
                    {
                        text1.Add("<td>" + T[i - 1, j - 1].formula + "</td>");
                    }
                }
                text1.Add("</tr>");
            }
            text1.Add("</table> ");
            text1.Add("</body> ");
            text1.Add("</html> ");
            string[] strs = text1.ToArray();
            File.WriteAllLines(path, strs);
        }
        
    }
}
