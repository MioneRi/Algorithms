using System;
using System.Collections.Generic;
using System.Linq;

public class IterativeRotationCipher
{
    static void Main(string[] args)
    {
        Console.WriteLine($"{Encode("If you wish to make an apple pie from scratch, you must first invent the universe.")}");
    }

    public static string Encode(int n, string str)
    {
        // Remember its location.
        List<int> locationOfSpaces = new List<int>();

        for (var i = 0; i < str.Length; i++)
            if (str[i] == ' ')
                locationOfSpaces.Add(i);

        for (var i = 0; i < n; i++)
        {
            // Remove all spaces.
            str = str.Replace(" ", string.Empty);
            // Shift the order of chars to right by n.                                
            EncodeShiftChars(ref str, n);
            // Return spaces on their original positions.
            ReturnSpaces(ref str, locationOfSpaces);

            // Shift chars in substrings.
            string[] substrings = str.Split(' ');
            str = "";
            for (var j = 0; j < substrings.Length; j++)
            {
                EncodeShiftChars(ref substrings[j], n);
                if (j != substrings.Length - 1)
                    str += substrings[j] + " ";
                else
                    str += substrings[j];
            }
        }

        return n.ToString() + " " + str;
    }
    public static string Decode(string str)
    {
        // Let know encoding information.
        string ourNumber = "";
        foreach (char k in str)
        {
            if (k == ' ')
                break;
            ourNumber += k;
        }
        int n = Int32.Parse(ourNumber);
        // Here we get a string without iteration info.
        str = str.Substring(ourNumber.Length + 1);
        // Remember positions of spaces for future manipulations.
        List<int> locationOfSpaces = new List<int>();
        for (var i = 0; i < str.Length; i++)
            if (str[i] == ' ')
                locationOfSpaces.Add(i);

        for (var i = 0; i < n; i++)
        {
            // 1. Decode all substrings and remove spaces after that in one cycle.
            string[] substrings = str.Split(" ");
            str = "";
            for (var j = 0; j < substrings.Length; j++)
            {
                DecodeShiftChars(ref substrings[j], n);
                str += substrings[j];
            }
            // 2. Decode whole str wihout spaces.
            DecodeShiftChars(ref str, n);
            // 3. Return spaces to start positions.
            ReturnSpaces(ref str, locationOfSpaces);
        }

        return str;
    }

    // Shifts the order of chars str to right by n.        
    public static void EncodeShiftChars(ref string str, int n)
    {
        List<char> tmpStr = str.ToList();

        for (var j = 0; j < str.Length; j++)
        {
            int newIndex = (j + n) % str.Length;
            tmpStr[newIndex] = str[j];
        }
        str = new string(tmpStr.ToArray());
    }

    public static void ReturnSpaces(ref string str, List<int> locationOfSpaces)
    {
        foreach (int k in locationOfSpaces)
            str = str.Insert(k, " ");
    }

    public static void DecodeShiftChars(ref string str, int n)
    {
        List<char> tmpStr = str.ToList();

        for (var j = 0; j < str.Length; j++)
        {
            int newIndex = j - (n % str.Length);

            if (newIndex < 0)
                newIndex = str.Length + newIndex;

            tmpStr[newIndex] = str[j];
        }
        str = new string(tmpStr.ToArray());
    }
}