using System;

namespace CodeTest
{
    /*
    Write a Function, that given a string S of length N and an integer K,
     returns the shortest possible length of the compressed representation of S 
     after removing exactly K consecutive charactes from S
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // public int solution(string S, int K)
            // {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            //approach
            /*
            Take string S and convert to compressed
            save compression array that has the number of repetitions with index being the index of the letter
            find the compression length
            -find the repetitions that are size k or smaller
            -find small repetitions that are couched between identical letters
            -choose and remove the smallest repetition (and leftover K from the next few places in the string)
            first column = letter charCode
            2nd col = letter location in string (first time)
            3rd col = letter location in string (last appearance consecutively)
            */
            //convert string to array
            var s = "AAABBBCCD"; //Should compress to "A3B3C2D"
            Console.WriteLine("Starting challenge is {0}", s);
            var SArray = s.ToCharArray();
            var compressedString = ""; //initialize compressed string
            int[,] repeatLetters = new int[SArray.Length, 3]; //2d array of repeating characters with start index and end index of repeating characters
            for (int i = 0; i < SArray.Length; i++)
            {
                if (i > 0)
                {
                    if (repeatLetters[i - 1, 0] == SArray[i])
                    {
                        continue;
                    }

                }
                //0 index is the letter itself (charcode)
                //i,1 index is the first position (in sArray) of the letter
                //i,2 is the last position (in sArray) of the letter
                repeatLetters[i, 0] = (int)SArray[i]; //charcode of current letter
                repeatLetters[i, 1] = i;
                repeatLetters[i, 2] = i; //assume no repeats by default

                //no loop thru sArray, incrementing [i,2] with the next match in sArray. Start with next position
                if (i < SArray.Length -1) //only do this if we're at end of array
                {

                    for (int j = i ; SArray[i] == SArray[j]; j++)
                    {
                        repeatLetters[i, 2] = j; //use this as repetition endpoint
                         //start next outer loop at J
                    }
                }

                compressedString += SArray[i]; //compressed letter itself
                if (repeatLetters[i, 2] != repeatLetters[i, 1]) // if start/end are different, we have more than one letter, add it's freq.
                {
                    compressedString += (repeatLetters[i, 2] - repeatLetters[i, 1] + 1);//compressed frequency of this letter
                }
            }
            Console.WriteLine(compressedString);

            // }

        }
    }
}
