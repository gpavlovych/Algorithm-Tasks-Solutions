namespace Task11
{
    internal class Node<TKey, TValue>
    {
        public Node(TKey key)
        {
            this.Key = key;
        }

        public TKey Key { get; }

        public TValue Value { get; set; }

        public Node<TKey, TValue> Next { get; set; }
    }
}
