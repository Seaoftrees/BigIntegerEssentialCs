using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BigIntegerEssentialCs
{
   class Program
   {
      static void Main(string[] args)
      {
         var util = new BigIntegerUtilcs();

         //example (12345678901234567890^2 calculated by python3)
         string str = "111001010101010001101101000000111110110111000010010000011"
            + "0101001010001111111111000110110101000100101011010100010001010001000100";


         //2進数 => 10進数
         BigInteger n = util.ToDecimal(str);
         Console.WriteLine(n + "\r\n");

         //10進数 => 2進数
         string result = util.ToBinary(n);
         if (result == str) Console.WriteLine(result + "\r\n");

         //平方根
         BigInteger r = util.BigIntSqrt(n);
         Console.WriteLine(r + "\r\n");

         //平方数判定
         bool b = util.IsSquare(n);
         Console.WriteLine(b);

         Console.ReadKey();
      }
   }
}
