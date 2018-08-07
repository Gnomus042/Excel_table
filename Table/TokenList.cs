using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Table
{
    class TokenList:ParserInfo
    {


        
        List<token> tokens;

        public TokenList()
        {
            tokens = new List<token>();
        }

        public void AddToken(token a)
        {
            tokens.Add(a);
        }

        public List<string> GetVars()
        {
            List<string> vars = new List<string>();
            foreach (token a in tokens)
            {
                if (a.type == Types.VAR)
                {
                    vars.Add(a.val);
                }
            }
            return vars;
        }

        public double GetResult()
        {
        
                SubstVars();
            
            if (tokens.Count > 1)
            {
                MOPs();
            }
            else { return Double.Parse(tokens[0].val); }
            if (tokens.Count > 1)
            {
                token t = new token();
                t.type = Types.OBRACKET;
                t.val = "(";
                while (tokens.Contains(t))
                {
                    Brackets();
                }
            }
            else { return Double.Parse(tokens[0].val); }
            if (tokens.Count > 1)
            {
                UnarOps();
            }
            else { return Double.Parse(tokens[0].val); }
            if (tokens.Count > 1)
            {
                MultDiv();
            }
            else { return Double.Parse(tokens[0].val); }
            if (tokens.Count > 1)
            {
                PlusMin();
            }
            else { return Double.Parse(tokens[0].val); }
            if (tokens.Count==1)
            {
                return Double.Parse(tokens[0].val);
            }
            else throw new Exception("?");
        }

        private void PlusMin()
        {
            int i = 0;
            while (i != tokens.Count)
            {
                if (tokens[i].val == "+" || tokens[i].val == "-")
                {
                    
                    if (tokens[i].val == "+")
                    {
                        Plus(i);
                    }
                    else
                    {
                        Minus(i);
                    }
                    i = 0;
                }
                else
                {
                    i++;
                }

            }
        }

        private void MultDiv()
        {
            int i = 0;
            while (i != tokens.Count)
            {
                if (tokens[i].val == "*" || tokens[i].val == "/")
                {

                    if (tokens[i].val == "*")
                    {
                        Multiply(i);
                    }
                    else
                    {
                        Division(i);
                    }
                    i = 0;
                }
                else
                {
                    i++;
                }

            }

        }

        private void Multiply(int ind)
        {
            double x = Double.Parse(tokens[ind - 1].val);
            double y = Double.Parse(tokens[ind + 1].val);
            double z = x * y;
            token q = new token();
            q.type = Types.NUM;
            q.val = z.ToString();
            Replace(ind - 1, ind + 1, q);
        }

        private void Plus(int ind)
        {
            double x = Double.Parse(tokens[ind - 1].val);
            double y = Double.Parse(tokens[ind + 1].val);
            double z = x + y;
            token q = new token();
            q.type = Types.NUM;
            q.val = z.ToString();
            Replace(ind - 1, ind + 1, q);
        }

        private void Minus(int ind)
        {
            double x = Double.Parse(tokens[ind - 1].val);
            double y = Double.Parse(tokens[ind + 1].val);
            double z = x - y;
            token q = new token();
            q.type = Types.NUM;
            q.val = z.ToString();
            Replace(ind - 1, ind + 1, q);
        }

        private void Division(int ind)
        {
            double x = Double.Parse(tokens[ind - 1].val);
            double y = Double.Parse(tokens[ind + 1].val);
            double z = 0;
            if (y != 0)
            {
                z = x / y;
            }
            else
            {
                throw new Exception("DivisionByZero");
            }
            token q = new token();
            q.type = Types.NUM;
            q.val = z.ToString();
            Replace(ind - 1, ind + 1, q);
        }

        private void UnarOps()
        {
            token q = new token();
            q.type = Types.NUM;
            if (tokens[0].val=="+")
            {
                double w = Double.Parse(tokens[1].val);
                if (w<0)
                {
                    q.val = (-w).ToString();
                }
                else
                {
                    q.val = w.ToString();
                }
                Replace(0, 1, q);
            }
            else if (tokens[0].val == "-")
            {
                double w = Double.Parse(tokens[1].val);
                q.val = (-w).ToString();
                Replace(0, 1, q);
            }
            
        }

        private void MOPs()
        {
            int i = 0;
            while(i!=tokens.Count)
            {
                if (tokens[i].type==Types.MOP)
                {
                    SubMOP(tokens[i], i);
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            
        }

        private void SubMOP(token t, int ind)
        {
            int a = ind;
            int find = ind+1;
            while (tokens[find].val!="|")
            {
                find++;
            }
            TokenList t1 = SubList(ind+2, find-1);
            double r1 = t1.GetResult();
            int ffind = find;
            while (tokens[ffind].type !=Types.CBRACKET)
            {
                ffind++;
            }
            TokenList t2 = SubList(find+1, ffind-1);
            double r2 = t2.GetResult();
            double r=0;
            switch (t.val)
            {
                case "min":
                    if (r1>r2)
                    {
                        r = r2;
                    }
                    else
                    {
                        r = r1;
                    }
                    break;
                case "max":
                    if (r1 > r2)
                    {
                        r = r1;
                    }
                    else
                    {
                        r = r2;
                    }
                    break;
                case "mod":
                    r = r1 % r2;
                    break;
                case "div":
                    r = (int)(r1 / r2);
                    break;
            }
            token q = new token();
            q.type = Types.NUM;
            q.val = r.ToString();
            Replace(a, ffind, q);
        }

        private void Brackets()
        {
            int a = 0;
            while(a != tokens.Count && tokens[a].type!=Types.OBRACKET)
            {
                a++;
            }
            if (a != tokens.Count)
            {
                //token t = new token();
                //t.type = Types.CBRACKET;
                //t.val = ")";
                int b = a;
                while (b != tokens.Count && tokens[b].type != Types.CBRACKET)
                {
                    if (tokens[b].val != "(")
                    {
                        b++;
                    }
                    else
                    {
                        a = b;
                        b++;
                    }
                }
                if (b != 0)
                {
                    TokenList tok = SubList(a + 1, b - 1);
                    double res = tok.GetResult();
                    token w = new token();
                    w.type = Types.NUM;
                    w.val = res.ToString();
                    Replace(a, b, w);
                }
            }
        }

        private TokenList SubList(int a, int b)
        {
            TokenList tok = new TokenList();
            for (int i = a; i<=b;i++)
            {
                tok.AddToken(tokens[i]);
            }
            return tok;
        }

        private void Replace(int a, int b, token q)
        {
            List<token> subTok = new List<token>();
            for (int i = 0; i<tokens.Count;i++)
            {
                if (i<a||i>b)
                {
                    subTok.Add(tokens[i]);
                }
                else if (i==a)
                {
                    subTok.Add(q);
                }
                else
                {

                }
            }
            tokens = subTok;
        }

        private void SubstVars()
        {
            int i = 0;
            while (i!=tokens.Count)
            {
                if (tokens[i].type == Types.VAR)
                {
                    double r = GetVarValue(tokens[i]);
                    token a = new token();
                    a.type = Types.NUM;
                    a.val = r.ToString();
                    tokens[i] = a;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
          
        }

        private double GetVarValue(token t)
        {
            int a = t.val[0] - 'A';
            string w = t.val.Substring(1);
            int b = Int32.Parse(w);
            return Table.I().GetValue(a, b-1);
        }
    }
}
