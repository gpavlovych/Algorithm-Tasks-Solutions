namespace Task68
{
    /// <summary>
    /// 68.Reverse the bits of an unsigned integer.
    /// </summary>
    public static class Solver
    {
        public static uint ReverseBits(uint input)
        {
            var count = 31;
            var result = input;
            input >>= 1;
            while (input != 0)
            {
                result <<= 1;
                result |= input & 1;
                input >>= 1;
                count--;
            }
            result <<= count;
            return result;
        } 
    }
}
