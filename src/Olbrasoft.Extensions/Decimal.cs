namespace Olbrasoft.Extensions
{
    public static class Decimal
    {
        /// <summary>
        /// https://stackoverflow.com/questions/2751593/how-to-determine-if-a-decimal-double-is-an-integer
        /// For floating point numbers, n % 1 == 0 is typically the way to check if there is anything past the decimal point.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>n % 1 == 0</returns>
        public static bool IsInteger(this decimal source)
        {
            return source % 1 == 0;
        }
    }
}