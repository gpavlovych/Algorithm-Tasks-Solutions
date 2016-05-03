namespace Task67
{
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
