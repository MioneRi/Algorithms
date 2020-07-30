using System;
using System.Collections.Generic;
using System.Linq;

namespace ForCodeWars
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("Input1 : ");
                string str1 = Console.ReadLine();
                Console.Write("Input2 : ");
                string str2 = Console.ReadLine();

                Console.WriteLine($" answer : {sumStrings(str1, str2)}\n");
            }
        }

        public static string sumStrings(string a, string b)
        {
            string resultStr = "";
            List<string> resultList = new List<string>();

            RemoveFirstZeros(ref a);
            RemoveFirstZeros(ref b);

            List<int> biggerString = a.Length >= b.Length ?
                                    (from u in a select int.Parse(u.ToString())).ToList() :
                                    (from u in b select int.Parse(u.ToString())).ToList();
            List<int> smallerString = a.Length >= b.Length ?
                                    (from u in b select int.Parse(u.ToString())).ToList() :
                                    (from u in a select int.Parse(u.ToString())).ToList();

            biggerString.Reverse();
            smallerString.Reverse();

            // Sum logic.
            var reminder = 0;
            var i = 0;
            var sumOfDigits = 0;
            while (reminder != 0 || i < biggerString.Count)
            {
                if (i < smallerString.Count && i < biggerString.Count)
                    sumOfDigits = smallerString[i] + biggerString[i] + reminder;
                else if (i < biggerString.Count)
                    sumOfDigits = biggerString[i] + reminder;
                else
                    sumOfDigits = reminder;

                var writeCell = (sumOfDigits % 10);

                resultList.Add(writeCell.ToString());
                reminder = (int)(sumOfDigits / 10);
                i++;
            }

            resultList.Reverse();
            resultStr = string.Join("", resultList);
            return resultStr;
        }

        public static string RemoveFirstZeros(ref string n)
        {
            bool wordBegin = false;
            var i = 0;

            while (!wordBegin && i < n.Length)
            {
                if (n[i] == '0')
                    n = n.Substring(i + 1);
                else
                    wordBegin = true;
            }
            return n;
        }

    }

}