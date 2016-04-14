namespace Task46
{
    /// <summary>
    /// Give a fast way to multiply a number by 7.
    /// </summary>
    public static class Solver
    {
        public static long MultiplyBy7(long number)
        {
            return (number << 3) - number;
        }
    }
}
