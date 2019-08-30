using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFHelper
{
    public static class PDFHelper
    {
        public static void MakeReadOnly(string inputFilePath, string outputFilePath, string password)
        {
            try
            {
                using (Stream inputPdfStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                
                using (Stream outputPdfStream2 = new FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    //Opens our outputted file for reading
                    var reader2 = new PdfReader(inputPdfStream);

                    //Encrypts the outputted PDF to make it not allow Copy or Pasting
                    PdfEncryptor.Encrypt(
                        reader2,
                        outputPdfStream2,
                        true,
                        null,
                        password,
                        PdfWriter.ALLOW_SCREENREADERS
                    );
                    //Creates the outputted final file
                    reader2.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string MakeReadOnly(string inputFilePath, string outputFilePath)
        {
            try
            {
                string password = RandomPasswordGenerator();

                MakeReadOnly(inputFilePath, outputFilePath, password);

                return password;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static string RandomPasswordGenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string password = new String(stringChars);
            return password;
        }
    }
}
