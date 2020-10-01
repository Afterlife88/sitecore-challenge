using System;
using System.Linq;
using System.Text;

namespace SitecoreChallange
{
    class Program
    {
        private static readonly char[] VALID_CHARS = { 'p', 'k', 'q', 'b', 'r', 'n' };

        static void Main(string[] args)
        {
            try
            {
                var res = Decode("r1bk3r/p2pBpNp/n4n2/1p1NP2P/6P1/3P4/P1P1K3/q5b1");
                //var res = Decode("3w4/7p/7p/7p/8/8/8/8");
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public static string Decode(string encoded)
        {
            var rows = encoded.Split("/");

            if (rows.Length != 8)
                throw new ArgumentException("Wrong number of rows");


            var decoded = rows.Select(DecodeRow).ToArray();

            foreach (var row in decoded)
            {
                if (row.Length != 8)
                {
                    throw new ArgumentException("Wrong number of squares on row");
                }

                if (row.ToLower().IndexOfAny(VALID_CHARS) == -1)
                {
                    throw new ArgumentException("Unexpected character");
                }
            }

            var result = string.Join("\n", decoded.ToArray());
            return result;
        }

      
        private static string DecodeRow(string row)
        {
            var sb = new StringBuilder();

            foreach (var c in row.ToCharArray())
            {
                var numericValue = (int)char.GetNumericValue(c);
                if (numericValue > 0 && numericValue < 10)
                {
                    sb.Append(new string('.', numericValue));
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

    }
}
