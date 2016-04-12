namespace Task46
{
    /// <summary>
    /// Fast way to multiply by 7
    /// </summary>
    public static class Solver
    {
        public static long MultiplyBy7(long number)
        {
            return (number << 3) - number;
        }
    }
}
