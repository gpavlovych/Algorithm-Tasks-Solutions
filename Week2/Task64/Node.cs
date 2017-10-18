namespace Task64
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public Node Next { get; set; }
        public int Value { get; }
    }
}