namespace HuffmanAlgorythm
{
    internal class Node
    {
        public int Weight { get; set; }
        public char Symbol { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public bool Flag { get; set; }

        public Node(int weight, char symbol)
        {
            Weight = weight;
            Symbol = symbol;
            Left = null;
            Right = null;
            Flag = false;
        }

        public Node(int weight, char symbol, Node left, Node right)
        {
            Weight = weight;
            Symbol = symbol;
            Left = left;
            Right = right;
            Flag = false;
        }
    }
}