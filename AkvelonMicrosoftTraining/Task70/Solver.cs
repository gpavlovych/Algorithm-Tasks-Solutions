namespace Task70
{
    /// <summary>
    /// 70. Set the highest significant bit of an unsigned integer to zero.
    /// </summary>
    public static class Solver
    {
        public static uint ClearHighestSignificantBit(uint num)
        {
            return ( num << 1 ) >> 1;
        }
    }
}
