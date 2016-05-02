namespace Task63
{
    /// <summary>
    /// 63.Given a list of numbers (fixed list). Now given any other list, how can you efficiently find out if
    /// there is any element in the second list that is an element of the first list(fixed list).
    /// </summary>
    /// <remarks>Linked list with int values need to be checked for intersection.</remarks>
    public static class Solver
    {
        public static bool IsIntersection(Node fixedList, Node list)
        {
            bool result = false;
            while (fixedList != null && list != null)
            {
                while (list != null)
                {
                    if (fixedList.Value == list.Value)
                    {
                        result = true;
                        break;
                    }
                    list = list.Next;
                }
                fixedList = fixedList.Next;
            }
            return result;
        }
    }
}
