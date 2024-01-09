using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassDecryptText
    {
        List<string> listStringKey;

        public ClassDecryptText()
        {
            
        }

        public ClassDecryptText(List<string> ínKey)
        {
            listStringKey = ínKey;
        }

        public string DecryptString(string inString)
        {
            string res = "";
            string temp = "";

            // Gennemløb hele den krypterede tekststreng og udvælg de tegn der er en del af nøglen.
            // Når der findes et tegn der er en del af nøglen gemmes det i et temp string objekt.
            // Så snart der ikke findes flere tegn der er en del af nøglen,
            // konverteres temp string objektet til et int, som sendes til metoden MakeCharOfCode.
            // Resultatet af MakeCharOfCode gemmes i res string objektet.
            // Objektet temp nulstilles og processen gentages indtil hele den krypterede
            // tekststreng er gennemløbet.

            Encoding enc1252 = Encoding.GetEncoding("Windows-1252");
            byte[] ascciBytes = enc1252.GetBytes(inString); // Konverterer input strengen til et array af bytes.

            foreach (char asciiNO in ascciBytes)
            {
                if (listStringKey.Contains(asciiNO.ToString()))
                {
                    temp += asciiNO.ToString();
                }
                else
                {
                    if (temp != "")
                    {
                        res += MakeCharOfCode(temp);
                        temp = "";
                    }
                }
            }

            return res;
        }

        private string MakeCharOfCode(string inCharString)
        {
            string res = "";

            // Gennemløb InCharString tekststreng og omsæt tegn til tal der fremkommer ved at tegnet
            // passer til en placering i List<string> key.
            // Resultatet af omsætningen gemmes i res string objektet, som konverteres til en char og 
            // indsættes i res.
            // res returneres.

            foreach (char aDigit in inCharString)
            {
                int intChar = listStringKey.IndexOf(aDigit.ToString());
                res += intChar.ToString();
            }

            return $"{(char)Convert.ToInt32(res)}";
        }
    }
}
