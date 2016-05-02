namespace Task63
{
    public class Node
    {
        public Node(int value, Node next)
        {
            this.Value = value;
            this.Next = next;
        }
        public int Value { get; }
        public Node Next { get; }
    }
}