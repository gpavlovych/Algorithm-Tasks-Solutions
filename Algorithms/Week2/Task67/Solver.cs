namespace Task67
{
    /// <summary>
    /// 67.Given a singly linked list, find the middle of the list.
    /// </summary>
    /// <remarks>list contains int elements.</remarks>
    public static class Solver
    {
        public static Node FindMiddle(Node head)
        {
            var start = head;
            var fastStart = head;
            if (head != null)
            {
                while (( fastStart = fastStart.Next ) != null 
                    && ( fastStart = fastStart.Next ) != null
                    && ( start = start.Next ) != null)
                {
                }
            }
            return start;
        }
    }
}
