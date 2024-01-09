using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassRolingCryptText
    {
        private List<string> key;
        private ClassDummyText CDT;
        private int keyJump;

        public ClassRolingCryptText()
        {
            CDT = new ClassDummyText();
        }

        public ClassRolingCryptText(List<string> inKey)
        {

        }

        public string RolingCryptString(string inString)
        {
            return inString;
        }

        private string MakeCodeOfChar(char aChar)
        {
            return "";
        }
    }
}
