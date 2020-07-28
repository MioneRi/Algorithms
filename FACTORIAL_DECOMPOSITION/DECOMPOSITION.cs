using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ForCodeWars
{
    class Encoding
    {
        static void Main(string[] args)
        {
            string result = Decomp(22);
            Console.WriteLine($"result : {result}");  
			while(true)
			{
				Console.Write("input : ");
				int input = Int32.Parse(Console.ReadLine());				
				Console.WriteLine($"	output : {Decomp(input)}");
			}
			
        }        

        public static string Decomp(int n)
        {            
            // For storing all dividers of n!.
            List<int> dividers = new List<int>();
                        
            for (var i = 2; i <= n; i++)
            {
                dividers.AddRange(FindDividers(i));
            }

            dividers.Sort();
            // Stores dividers without duplicates.
            List<int> dividersWithoutDuplicates = new List<int>();
            // Stores powers of numbers.
            List<int> powersOfDividers = new List<int>();
            // Fill powers in the list, remove duplicates from dividers.
            foreach (int k in dividers)
            {
                if (!dividersWithoutDuplicates.Contains(k))
                {
                    var amountOfDuplicates = (from currNum in dividers
                                              where currNum == k
                                              select currNum).Count();
                    // Remove all numbers that was counted.
                    dividers = (from currNum in dividers
                                where currNum != k
                                orderby currNum
                                select currNum).ToList();
                    // Write amount of duplicates for current number.
                    powersOfDividers.Add(amountOfDuplicates);
                    // Add current number to list for knowing that we already count power of that number.
                    dividersWithoutDuplicates.Add(k);
                }                                
            }
            dividersWithoutDuplicates.Sort();
            
            return StringRepresentation(dividersWithoutDuplicates, powersOfDividers);
        }
        
        // Returns list of prime divisers of n.
        public static List<int> FindDividers(int n)
        {
            // For storing all dividers of n.
            List<int> dividers = new List<int>();
            // Looking for all dividers.
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                    dividers.Add(2);
                }
                else
                {
                    // Looking for some alternative odd divisor.
                    // Start checking from number 3 cuz it's minimal possible odd number.
                    int alternativeDivisor = 3;
                    // Loop won't endless cuz we compare our odd number (n) with all possible odd numbers.
                    while (true)
                    {
                        if (n % alternativeDivisor == 0)
                            break;
                        else
                            alternativeDivisor += 2;
                    }
                    n /= alternativeDivisor;
                    dividers.Add(alternativeDivisor);
                }
            }
            return dividers;
        }

        // Converts data into string.
        public static string StringRepresentation(List<int> dividersWithoutDuplicates, List<int> powersOfDividers)
        {
            // Build our result string.
            string resultStr = "";
            for (var i = 0; i < dividersWithoutDuplicates.Count; i++)
            {
                if (powersOfDividers[i] != 1)
                    resultStr += dividersWithoutDuplicates[i] + "^" + powersOfDividers[i];
                else
                    resultStr += dividersWithoutDuplicates[i];
                if (i != dividersWithoutDuplicates.Count - 1)
                    resultStr += " * ";
            }

            return resultStr;
        }
    }
}
