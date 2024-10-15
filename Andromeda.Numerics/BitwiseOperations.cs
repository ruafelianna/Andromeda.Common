namespace Andromeda.Numerics
{
    public static class BitwiseOperations
    {
        public const int ByteSize = 8;

        public const int Log_2_ByteSize = 3;

        public const int ByteStartIndex = 0;

        public const int ByteStopIndex = ByteSize - 1;

        #region IsEven

        public static bool IsEven(this byte number)
            => (number & 1) == 0;

        public static bool IsEven(this sbyte number)
            => (number & 1) == 0;

        public static bool IsEven(this ushort number)
            => (number & 1) == 0;

        public static bool IsEven(this short number)
            => (number & 1) == 0;

        public static bool IsEven(this uint number)
            => (number & 1) == 0;

        public static bool IsEven(this int number)
            => (number & 1) == 0;

        public static bool IsEven(this ulong number)
            => (number & 1) == 0;

        public static bool IsEven(this long number)
            => (number & 1) == 0;

        #endregion

        #region IsOdd

        public static bool IsOdd(this byte number)
            => (number & 1) == 1;

        public static bool IsOdd(this sbyte number)
            => (number & 1) == 1;

        public static bool IsOdd(this ushort number)
            => (number & 1) == 1;

        public static bool IsOdd(this short number)
            => (number & 1) == 1;

        public static bool IsOdd(this uint number)
            => (number & 1) == 1;

        public static bool IsOdd(this int number)
            => (number & 1) == 1;

        public static bool IsOdd(this ulong number)
            => (number & 1) == 1;

        public static bool IsOdd(this long number)
            => (number & 1) == 1;

        #endregion

        #region N-th byte

        public static byte Byte1(this ushort number)
            => unchecked((byte)(number >> ByteSize));

        public static byte Byte2(this ushort number)
            => unchecked((byte)(number & byte.MaxValue));

        #endregion

        #region Full bytes

        public static int FullBytes(this ushort bits)
            => bits >> Log_2_ByteSize;

        public static int FullBytes(this short bits)
            => bits >> Log_2_ByteSize;

        public static long FullBytes(this uint bits)
            => bits >> Log_2_ByteSize;

        public static int FullBytes(this int bits)
            => bits >> Log_2_ByteSize;

        public static ulong FullBytes(this ulong bits)
            => bits >> Log_2_ByteSize;

        public static long FullBytes(this long bits)
            => bits >> Log_2_ByteSize;

        #endregion

        #region Byte remainder

        public static byte ByteRemainder(this ushort bits)
            => unchecked((byte)(bits & ByteStopIndex));

        public static byte ByteRemainder(this short bits)
            => unchecked((byte)(bits & ByteStopIndex));

        public static byte ByteRemainder(this uint bits)
            => unchecked((byte)(bits & ByteStopIndex));

        public static byte ByteRemainder(this int bits)
            => unchecked((byte)(bits & ByteStopIndex));

        public static byte ByteRemainder(this ulong bits)
            => unchecked((byte)(bits & ByteStopIndex));

        public static byte ByteRemainder(this long bits)
            => unchecked((byte)(bits & ByteStopIndex));

        #endregion

        #region Containing bytes

        public static int ContainingBytes(this ushort bits)
            => (bits + ByteStopIndex) >> Log_2_ByteSize;

        public static int ContainingBytes(this int bits)
            => (bits + ByteStopIndex) >> Log_2_ByteSize;

        #endregion

        public static bool[] AsBools(this byte b, int num = ByteSize)
        {
            var result = new bool[num];

            for (var i = 0; i < num; i++)
            {
                result[i] = b.IsOdd();
                b >>= 1;
            }

            return result;
        }
        public static byte Mod8(this int number)
            => unchecked((byte)(number & ByteStopIndex));
    }
}
