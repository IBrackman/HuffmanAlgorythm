using System;
using System.IO;
using System.Text;

namespace HuffmanAlgorythm
{
    internal class Program
    {
        private static void Main()
        {
            var file = new FileStream(Environment.CurrentDirectory + @"\Test.txt", FileMode.Open);

            var freqArr = new int[256];

            var textBuf = new byte[file.Length];

            file.Read(textBuf, 0, (int) file.Length);

            var code = "\n" + Codec.Coder(Encoding.ASCII.GetString(textBuf), ref freqArr);

            var byteCode = Encoding.ASCII.GetBytes(code);

            file.Write(byteCode, 0, byteCode.Length);

            Console.ReadKey();

            file.Position -= byteCode.Length - 1;

            var codeBuf = new byte[byteCode.Length - 1];

            file.Read(codeBuf, 0, byteCode.Length - 1);

            var decoded = "\n" + Codec.Decoder(Encoding.ASCII.GetString(codeBuf), ref freqArr);

            byteCode = Encoding.ASCII.GetBytes(decoded);

            file.Write(byteCode, 0, byteCode.Length);

            Console.ReadKey();
        }
    }
}