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
            long answer = -1;            
            long fact = Fact(n.ToString().Length);

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

            // 1. Fill "combinationsInt".
            func(originalDigits.Count, combinationsInt, tmpList, ref tmpStr);

            // 2. Converting "combinationsInt" to "combinationsStr" 
            //    according to positions of digits in "originalDigits".
            long lengthOfCombination = originalDigits.Count();
            for (int i = 0; i < fact; i++)
            {
                combinationsStr.Add("");
                for (int j = 0; j < lengthOfCombination; j++)
                {
                    combinationsStr[i] += originalDigits[Int32.Parse(combinationsInt[i][j].ToString())];
                }
            }

            // 3. Converting "combinationsStr" to "combinationsLong" and sorting values.
            List<long> combinationsLong = (from k in combinationsStr                                           
                                           select long.Parse(k)).OrderBy(t => t).ToList();

            for (int i = 0; i < fact; i++)
            {
                if (combinationsLong[i] > n)
                    answer = combinationsLong[i];
            }
            
            return answer;                    
        }        

        // k - amount of digits, tmpList - stores list of positions.
        public static void func (int k, List<string> combinationsInt, List<string> tmpList, ref string tmpStr)
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
                func(k-1, combinationsInt, tmpList2, ref tmpStr);

                tmpStr = tmpStr.Substring(0, tmpStr.Length-1);
            }
        }

        public static long Fact(long n)
        {
            long k = 1;
            for (int i = 2; i <= n; i++)
                k *= i;
            return k;
        }        
    }

}
