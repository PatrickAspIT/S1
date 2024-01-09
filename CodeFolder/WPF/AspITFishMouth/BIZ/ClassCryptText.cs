﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassCryptText
    {
        private List<string> key;
        private ClassDummyText CDT;

        public ClassCryptText()
        {
            
        }

        public ClassCryptText(List<string> inKey)
        {
            key = inKey;
            CDT = new ClassDummyText(key);
        }

        public string CryptString(string inString)
        {
            string res = CDT.MakeDummyString();
            Encoding enc1252 = Encoding.GetEncoding("Windows-1252");
            byte[] ascciBytes = enc1252.GetBytes(inString); // Konverterer input strengen til et array af bytes.

            foreach (byte aByte in ascciBytes)
            {
                char aChar = (char)aByte;
                res += MakeCodeOfChar(aChar) + CDT.MakeDummyString();
            }

            return res;
        }

        private string MakeCodeOfChar(char aChar)
        {
            string res = "";

            int intChar = (int)aChar;
            string strChar = intChar.ToString();

            foreach (char aDigit in strChar)
            {
                res += key[int.Parse(aDigit.ToString())];
            }

            return res;
        }
    }
}
