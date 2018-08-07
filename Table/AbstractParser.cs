using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Table
{
    abstract class ParserInfo
    {
        public enum Types { NONE, VAR, DELIMITER, NUM, MOP, OBRACKET,CBRACKET, ERROR};

        public struct token
        {
            public string val;
            public Types type;
        }
    }
}
