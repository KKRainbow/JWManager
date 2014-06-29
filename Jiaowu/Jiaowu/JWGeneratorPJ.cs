using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jiaowu
{
    class JWGeneratorPJ
    {
        private static int a= 1;
        public static string convertToEvaluation(string num)
        {
            return num.Replace("1", "A").Replace("2", "B").Replace("3", "C").Replace("4", "D");
        }
        public static string convertToNumber(string eva)
        {
            return eva.ToUpper().Replace("A", "1").Replace("B", "2").Replace("C", "3").Replace("D", "4");
        }
        public static string generator(int numOfA,int numOfB,int length = 6)
        {
            if (numOfA + numOfB > length || numOfA < 0 || numOfB < 0) return null;
            int numOfC = length - numOfB - numOfA;
            char[] result = new char[length];

            Random rand = new Random(a++);

            while (numOfA!=0||numOfB!=0||numOfC!=0)
            {
                int r = rand.Next(length);
                while (result[r] != '\0')
                {
                    r = (r + rand.Next(6)) % length;
                }

                if (numOfA > 0)
                {
                    numOfA--;
                    result[r] = '1';
                }
                else if (numOfB > 0)
                {
                    numOfB--;
                    result[r] = '2';
                }
                else if (numOfC > 0)
                {
                    numOfC--;
                    result[r] = '3';
                }
            }
            return new string(result);
        }
    }
}
