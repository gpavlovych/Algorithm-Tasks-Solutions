namespace Task4
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; }

        public Node Next { get; set; }
    }
}