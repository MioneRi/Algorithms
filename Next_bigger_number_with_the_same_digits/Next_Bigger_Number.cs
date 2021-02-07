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
            int lengthOfNumber = originalDigits.Count();

            // Store all combinations like letters.
            List<string> combinationsStr = new List<string>();

            // Store all combinations like numbers of digits.            
            string[][] combinationsInt = new string[fact][];
            Fill2Darray(combinationsInt, lengthOfNumber);

            List<string> possibleValues = new List<string>();
            for (int i = 0; i < lengthOfNumber; i++)
                possibleValues.Add(i.ToString());

            // 1. Fill "combinationsInt".
            int combinationIterator = 0;
            int valueIterator = 0;

            // Stores previous step values.
            string[] combinationOnPreviousStep = new string[lengthOfNumber];

            func(lengthOfNumber, combinationsInt, possibleValues, combinationOnPreviousStep,
                                         ref combinationIterator, ref valueIterator);

            // 2. Converting "combinationsInt" to "combinationsStr" 
            //    according to positions of digits in "originalDigits".            
            for (int i = 0; i < fact; i++)
            {
                combinationsStr.Add("");
                for (int j = 0; j < lengthOfNumber; j++)
                {
                    combinationsStr[i] += originalDigits[Int32.Parse(combinationsInt[i][j])];
                }
            }

            // 3. Converting "combinationsStr" to "combinationsLong" and sorting values.
            List<long> combinationsLong = (from k in combinationsStr
                                           select long.Parse(k)).OrderBy(t => t).ToList();

            for (int i = 0; i < fact; i++)
            {
                if (combinationsLong[i] > n)
                    return combinationsLong[i];
            }

            return answer;
        }

        // "k" - amount of posible values, "possibleValues" - stores list of posible values, 
        // "combinationOnPreviousStep" - stores previous step values.
        public static void func(int numberOfPossibleValues, string[][] combinationsInt, List<string> possibleValues,
                                 string[] combinationOnPreviousStep,
                                 ref int combinationIterator, ref int valueIterator)
        {
            for (int i = 0; i < numberOfPossibleValues; i++)
            {
                // Copy combination on prev. step to current combination.
                combinationOnPreviousStep.CopyTo(combinationsInt[combinationIterator], 0);

                // Writing current digit from "possibleValues" to "combinationsInt".
                combinationsInt[combinationIterator][valueIterator] = possibleValues[i];
                // Update "tmpCombinationOnPreviousStep".
                var tmpCombinationOnPreviousStep = combinationOnPreviousStep;
                tmpCombinationOnPreviousStep[valueIterator] = possibleValues[i];

                // Increasing "digitIterator" cuz current position isn't free.
                valueIterator++;

                // Reducing possible digit values.
                var tmpList2 = new List<string>(possibleValues);
                tmpList2.RemoveAt(i);

                if (numberOfPossibleValues - 1 != 0)
                {
                    func(numberOfPossibleValues - 1, combinationsInt, tmpList2, combinationOnPreviousStep,
                                         ref combinationIterator, ref valueIterator);
                }
                // If there was last possible digit in current combination.
                else
                {
                    // Increasing "combinationIterator" cuz current combination is full.
                    combinationIterator++;

                    // Reduce "digitIterator" cuz new combination consists of "combinationOnPreviousStep" + next values.                    
                    valueIterator -= 2;
                }
            }
        }

        // Sets width of each subarray and initialize values with "-1";
        public static void Fill2Darray(string[][] arr, int width)
        {
            for (var i = 0; i < arr.Length; i++)
                arr[i] = new string[width];
            for (var i = 0; i < arr.Length; i++)
                for (var j = 0; j < width; j++)
                    arr[i][j] = "-1";
        }

        //public static long Fact(long n)
        //{
        //    long k = 1;
        //    for (int i = 2; i <= n; i++)
        //        k *= i;
        //    return k;
        //}


        public static long ProdTree(long l, long r)
        {
            if (l > r)
                return 1;
            if (l == r)
                return l;
            if (r - l == 1)
                return (long)l * r;
            long m = (l + r) / 2;
            return ProdTree(l, m) * ProdTree(m + 1, r);
        }

        public static long Fact(long n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            return ProdTree(2, n);
        }

    }

}
