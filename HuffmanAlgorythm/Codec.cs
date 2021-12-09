using System.Linq;

namespace HuffmanAlgorythm
{
    internal class Codec
    {
        public static string Coder(string str, ref int[] freqArr)
        {
            var tree = new Tree();

            foreach (var t in str) freqArr[t]++;

            for (var i = 0; i < 256; ++i)
            {
                if (freqArr[i] == 0) continue;

                tree.AddNode(new Node(freqArr[i], (char) i));
            }

            tree.BuildTree();

            tree.TreeTraverse();

            var table = tree.GetTable();

            var res = str.Aggregate("", (current, t) => current + table[t]);

            return res;
        }

        public static string Decoder(string code, ref int[] freqArr)
        {
            var res = "";

            var tree = new Tree();

            for (var i = 0; i < 256; ++i)
            {
                if (freqArr[i] == 0) continue;

                tree.AddNode(new Node(freqArr[i], (char) i));
            }

            tree.BuildTree();

            var temp = tree.GetTop();

            foreach (var t in code)
            {
                temp = t == '0' ? temp.Left : temp.Right;

                if (temp.Symbol <= 0) continue;

                res += temp.Symbol;

                temp = tree.GetTop();
            }

            return res;
        }
    }
}