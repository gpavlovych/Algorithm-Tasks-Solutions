namespace Task64
{
    /// <summary>
    /// 64.Given a singly linked list, determine whether it contains a loop or not.
    /// </summary>
    public static class Solver
    {
        public static bool IsLooped(Node node)
        {
            var slowNode = node;
            Node fastNode1;
            var fastNode2 = node;
            while (slowNode != null && ( fastNode1 = fastNode2.Next ) != null && ( fastNode2 = fastNode1.Next ) != null)
            {
                if (slowNode == fastNode1 || slowNode == fastNode2)
                    return true;
                slowNode = slowNode.Next;
            }
            return false;
        }
    }
}
