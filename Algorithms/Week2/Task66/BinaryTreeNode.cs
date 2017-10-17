namespace Task66
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(int value)
        {
            this.Value = value;
        }

        public int Value { get; }

        public BinaryTreeNode LeftChild { get; set; }

        public BinaryTreeNode RightChild { get; set; }
    }
}