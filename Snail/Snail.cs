using System;
using System.Collections.Generic;
using System.Linq;

public static int[] Snail(int[][] array)
        {
            // Counting amount of elements.
            var amountOfElements = array.Length * array[0].Length;
            
            List<int> answerList = new List<int>();

            int[] emotyArray = new int[0];

            //var iterator = 1;
            int i, j;
            i = j = 0;
            int iFrom, iTo, jFrom, jTo;
            iFrom = 1;
            jFrom = 0;
            iTo = jTo = (int)Math.Sqrt(amountOfElements) - 1;

            while (answerList.Count < amountOfElements)
            {                
                // Along j to right.
                if (answerList.Count < amountOfElements)
                    for (j = jFrom; j <= jTo; j++)
                        answerList.Add(array[i][j]);
                j--;
                Swap(ref jFrom, ref jTo);
                jFrom--;

                // Along i to bottom.
                if (answerList.Count < amountOfElements)
                    for (i = iFrom; i <= iTo; i++)
                        answerList.Add(array[i][j]);
                i--;
                Swap(ref iFrom, ref iTo);
                iFrom--;

                // Along j to left.
                if (answerList.Count < amountOfElements)
                    for (j = jFrom; j >= jTo; j--)
                        answerList.Add(array[i][j]);
                j++;
                Swap(ref jFrom, ref jTo);
                jFrom++;

                // Along i to the top.
                if (answerList.Count < amountOfElements)
                    for (i = iFrom; i >= iTo; i--)
                        answerList.Add(array[i][j]);
                i++;
                Swap(ref iFrom, ref iTo);
                iFrom++;

            }

            return answerList.ToArray();
        }

        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }