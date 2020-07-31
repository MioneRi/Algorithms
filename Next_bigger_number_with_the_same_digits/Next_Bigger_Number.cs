using System;
using System.Collections.Generic;
using System.Linq;

namespace SomeTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("Input : ");
                long number;

                if (long.TryParse(Console.ReadLine(), out number))
                    Console.WriteLine($"    Answer : {NextBiggerNumber(number)}\n");
                else
                    Console.WriteLine("Try again !!!\n");

            }
        }

        public static long NextBiggerNumber(long n)
        {
            long answer;
            string answerStr = "";

            // Converts number to list of chars, it's convenient way to create their possible combinations.
            List<string> originalDigits = (from x in n.ToString()
                                           select x.ToString()).ToList();
            // Store all combinations like letters.
            List<string> combinationsStr = new List<string>();

            // Store all combinations like numbers of digits.
            List<string> combinationsInt = new List<string>();

            List<string> tmpList = new List<string>();
            for (int i = 0; i < originalDigits.Count; i++)
                tmpList.Add(i.ToString());
            string tmpStr = "";

            func(originalDigits.Count, combinationsInt, tmpList, ref tmpStr);

            // 2. Converting "combinationsInt" to "combinationsStr" 
            //     according to positions of digits in "originalDigits".
            // 3. Sorting and find bigger number in "combinationsStr".

            if (long.TryParse(answerStr, out answer))
                return answer;
            else
                throw new Exception("An Error with converting string to long!!!\n");
        }

        // k - amount of digits, tmpList - stores list of positions.
        public static void func(int k, List<string> combinationsInt, List<string> tmpList, ref string tmpStr)
        {
            if (k == 0)
            {
                combinationsInt.Add(tmpStr);
                if (combinationsInt.Count == k - 1)
                    return;
            }

            for (int i = 0; i < k; i++)
            {
                tmpStr += tmpList[i];

                var tmpList2 = new List<string>(tmpList);
                tmpList2.RemoveAt(i);
                func(k - 1, combinationsInt, tmpList2, ref tmpStr);

                tmpStr = tmpStr.Substring(0, tmpStr.Length - 1);
            }
        }

        public static long Fact(long n)
        {
            long k = 1;
            for (int i = 2; i <= n; i++)
                k *= i;
            return k;
        }

        //public static long ProdTree(long l, long r)
        //{
        //    if (l > r)
        //        return 1;
        //    if (l == r)
        //        return l;
        //    if (r - l == 1)
        //        return (long)l * r;
        //    long m = (l + r) / 2;
        //    return ProdTree(l, m) * ProdTree(m + 1, r);
        //}

        //public static long FactTree(long n)
        //{
        //    if (n < 0)
        //        return 0;
        //    if (n == 0)
        //        return 1;
        //    if (n == 1 || n == 2)
        //        return n;
        //    return ProdTree(2, n);
        //}

    }

}
