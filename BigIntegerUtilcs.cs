using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BigIntegerEssentialCs
{
   class BigIntegerUtilcs
   {

      //String(2進数) => BigInteger(10進数)
      public BigInteger ToDecimal(string str)
      {
         BigInteger result = BigInteger.Zero;
         foreach (char c in str)
         {
            result <<= 1;
            if (c == 49) result++;
         }

         return result;
      }

      //BigInteger(10進数) => String(2進数)
      public string ToBinary(BigInteger n)
      {
         string s = "";
         byte[] table = { 128, 64, 32, 16, 8, 4, 2, 1 };
         foreach (byte b in n.ToByteArray().Reverse())
         {
            if (s == "")
            {
               s += Convert.ToString(b, 2);
            }
            else
            {
               byte bb = b;
               foreach (byte t in table)
               {
                  if (bb - t >= 0)
                  {
                     bb -= t;
                     s += "1";
                  }
                  else
                  {
                     s += "0";
                  }
               }
            }
         }
         return s;
      }


      //[√n](小数切り捨て)を返す
      //なお、桁数がINT32_MAXを超える場合には対応していない
      public BigInteger BigIntSqrt(BigInteger n)
      {
         //二進数文字列に変換
         string origin = ToBinary(n);
         BigInteger len = origin.Length;
         if (len % 2 == 1)
         {
            origin = "0" + origin;
            len++;
         }

         //2進数平開法
         BigInteger remain = BigInteger.Zero;
         BigInteger subEval = BigInteger.Zero;
         BigInteger result = BigInteger.Zero;
         for (int i = 0; i < (len >> 1); i++)
         {
            remain <<= 2;
            subEval <<= 1;
            result <<= 1;
            remain += Convert.ToInt32(origin.Substring(i << 1, 2), 2);
            if (subEval + 1 <= remain)
            {
               remain -= subEval + 1;
               subEval += 2;
               result++;
            }
         }

         return result;
      }

      //平方数なら true を返す
      public bool IsSquare(BigInteger n)
      {
         BigInteger r = n % 12;
         if (r == 0 || r == 1 || r == 4 || r == 9)
         {
            //二進数文字列に変換
            string origin = ToBinary(n);
            BigInteger len = origin.Length;
            if (len % 2 == 1)
            {
               origin = "0" + origin;
               len++;
            }

            //2進数平開法
            BigInteger remain = BigInteger.Zero;
            BigInteger subEval = BigInteger.Zero;
            for (int i = 0; i < (len >> 1); i++)
            {
               remain <<= 2;
               subEval <<= 1;
               remain += Convert.ToInt32(origin.Substring(i << 1, 2), 2);
               if (subEval + 1 <= remain)
               {
                  remain -= subEval + 1;
                  subEval += 2;
               }
            }

            if (remain == 0) return true;
         }
         return false;
      }

   }
}
