using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Table
{
    class Parser:ParserInfo
    {

        TokenList tokens;

        private string str;
        private int ind;
       

        public Parser()
        {
            tokens = new TokenList();
        }

        public TokenList Parse(string _str)
        {
            double result = 0;
            tokens = new TokenList();
            str = _str;
            ind = 0;
            List<char> errors = Check();
            if (errors.Count>0)
            {
                string error = "Невідомий символ: ";
                foreach (char s in errors)
                {
                    error += s + ",";
                }
                error = error.Substring(0, error.Length - 1);
                throw new Exception(error);
            }
            
            return tokens;
        }

        private List<char> Check()
        {
            List<char> k = new List<char>();
            token t;
            ind = 0;
            while (true)
            {
                try
                {
                    t = GetToken();
                    tokens.AddToken(t);
                }

                catch (Exception e)
                {
                    if (e.Message == "UnexpectedChar")
                    {
                        k.Add(str[ind-1]);
                      
                    }
                    else if (e.Message=="EOF")
                    {
                        break;
                    }
                }

                
            }
            ind = 0;
            return k;
        }

       

        private token GetToken()
        {
            token t = new token();
            t.val = "";
            t.type = Types.NONE;
            if (str.Length == ind)
            {
                throw new Exception("EOF");
            }
            while (ind<str.Length&&Char.IsWhiteSpace(str[ind]))
            {
                ind++;
            }
            if (Char.IsNumber(str[ind]))
            {
                string a = str[ind].ToString();
                ind++;
                while(ind!=str.Length&&(Char.IsNumber(str[ind])||str[ind]==','))
                {
                    a += str[ind];
                    ind++;
                }
                
                t.val = a;
                t.type = Types.NUM;
            }

            else if (str[ind]=='$')
            {
                string a= "";
                ind++;
                while (ind != str.Length && !Delim(str[ind]))
                {
                    a += str[ind];
                    ind++;
                }
              
                t.val = a;
                t.type = Types.VAR;
            }

            else if (Delim(str[ind]))
            {
                t.val = str[ind].ToString();
                t.type = Types.DELIMITER;
                ind++;
            }
            else if (str[ind] == 'm'||str[ind] == 'd')
            {
                string a ="";
                a += str[ind];
                for (int i = ind+1; i<=ind+2; i++)
                {
                    a += str[i];
                }
                if (a == "min" || a == "max" || a == "div"||a=="mod")
                {
                    ind+=3;
                    t.type = Types.MOP;
                    t.val = a;
                }
                else
                {
                    ind++;
                    throw new Exception("UnexpectedChar");
                }
            }
            else if (IsOBracket(str[ind]))
            {
                ind++;
                t.val = "(";
                t.type = Types.OBRACKET;
            }
            else if (IsCBracket(str[ind]))
            {
                ind++;
                t.val = ")";
                t.type = Types.CBRACKET;
            }
            else
            {
                ind++;
                throw new Exception("UnexpectedChar");
            }
            return t;
        }

        

        public bool Delim(char a)
        {
            if ( a == '+' || a == '-' || a == '*' || a == '/' || a == '^'|| a==','||a=='|')
            {
                return true;
            }
        
            else return false;
        }

        public bool IsOBracket(char a)
        {
            if (a == '(')
            {
                return true;
            }
            else return false;
        }

        public bool IsCBracket(char a)
        {
            if (a == ')')
            {
                return true;
            }
            else return false;
        }


    }
}
