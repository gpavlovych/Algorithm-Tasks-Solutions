namespace ArrayToBinaryTreeConverter
{
    public class TreeNode
    {
        public TreeNode(int value)
        {
            this.Value = value;
        }

        public int Value { get; }

        public TreeNode Child1 { get; set; }

        public TreeNode Child2 { get; set; }
    }
}