using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Repository;

namespace BIZ
{
    public class ClassBIZ
    {
        ClassFileHandler fileIO = new ClassFileHandler();
        ClassZIP zip = new ClassZIP();
        List<string> encryptionKey = new List<string>() { "T", "O", "R", "S", "K", "E", "M", "U", "N", "D"};

        public ClassBIZ()
        {
            clearText = new ClassText();
            cryptText = new ClassText();
        }

        public ClassText clearText { get; set; }
        public ClassText cryptText { get; set; }

        public void MakeCryptText()
        {
            ClassCryptText CCT = new ClassCryptText(encryptionKey);
            cryptText.fishText = CCT.CryptString(clearText.fishText);
        }

        public void MakeDeCryptText()
        {
            ClassDecryptText CCT = new ClassDecryptText(encryptionKey);
            clearText.fishText = CCT.DecryptString(cryptText.fishText);
        }

        public void MakeRolingCryptText()
        {

        }

        public void MakeRolingDecryptText()
        {

        }

        public void MakeExtraCryptText()
        {

        }

        public void DecryptExtraCryptText()
        {

        }

        public void ReadClearTextFromFile(string path)
        {
            clearText.fishText = fileIO.ReadTextFromFile(path);
        }
        public void WriteClearTextToFile(string path)
        {
            fileIO.WriteTextToFile_StreamWriter(path, clearText.fishText);
        }

        public void ReadCryptTextFromFile(string path)
        {
            cryptText.fishText = fileIO.ReadTextFromFile(path);           
        }
        
        public void WriteCryptTextToFile(string path)
        {
            fileIO.WriteTextToFile_StreamWriter(path, cryptText.fishText);
        }
    }
}
