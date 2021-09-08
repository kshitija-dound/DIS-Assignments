using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignment_1
{
    class Program
    {
        //Question 1
        static public Boolean HalvesAreAlike(string s)
        {
            int i = 0;  //used to traverse the string from the begining
            int j = s.Length - 1;      //used to traverse the string from the end

            //counters for vowels
            int a = 0;
            int b = 0;

            while (i < j)
            {
                if ((s[i] == 'A') ||
                    (s[i] == 'E') ||
                    (s[i] == 'I') ||
                    (s[i] == 'O') ||
                    (s[i] == 'U') ||
                    (s[i] == 'a') ||
                    (s[i] == 'e') ||
                    (s[i] == 'i') ||
                    (s[i] == 'o') ||
                    (s[i] == 'u'))
                    a++;

                if ((s[j] == 'A') ||
                    (s[j] == 'E') ||
                    (s[j] == 'I') ||
                    (s[j] == 'O') ||
                    (s[j] == 'U') ||
                    (s[j] == 'a') ||
                    (s[j] == 'e') ||
                    (s[j] == 'i') ||
                    (s[j] == 'o') ||
                    (s[j] == 'u'))
                    b++;

                i++;
                j--;
            }

            if (a == b)
                return true;
            else
                return false;

        }

        //Question 2
        static public Boolean CheckIfPangram(string s)
        {
            if (s.Length < 26)      //it means it doesn't have all the 26 alphabet
                return false;
            s.ToLower();            //converts it to lower case to avoid the different ASCII values

            for (var i = 1; i <= 26; i++)
                if (s.IndexOf((char)(i + 96)) < 0)      //Indexof reports the zero-based index of the first occurrence of a specified Unicode character or string within this instance. 
                    return false;
            return true;
        }

        //Question 3
        static public int MaximumWealth(int[,] arr)
        {

            int largest = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[i, j];   //returns the sum of the array elements for that row
                }
                if (largest < sum)
                {
                    largest = sum;      //returns the largest sum thus, giving the wealth of the Richest Person
                }
            }


            return largest;
        }

        //Question 4
        static public int NumJewelsInStones(string jewels, string stones)
        {
            int numOfStones = 0;
            foreach (char c in stones)
            {
                if (jewels.IndexOf(c) > -1)     // checks if the jewel is in stones return a number > -1 if it is present, otherwise if not
                    numOfStones++;              //counter for the number of stones which are also jewels
            }
            return numOfStones;

        }

        //Question 5
        static public string RestoreString(string s, int[] indices)
        {
            char[] charArr = new char[indices.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                charArr[indices[i]] = s[i]; //traverse the string elements and stores them at the new indices
            }
            return new string(charArr);     //returns the whole string
        }


        //Question 6
        static public int[] CreateTargetArray(int[] nums, int[] index)
        {
            int[] target = new int[nums.Length];

            //the for loop runs through all the elements of index array and nums array 
            for (int i = 0; i < nums.Length; i++)
            {
                int j1;
                if (index[i] == i)
                {
                    target[i] = nums[i];
                }
                else
                {
                    for (j1 = i; j1 > index[i]; j1--)
                    {
                        target[j1] = target[j1 - 1];
                    }
                    target[index[i]] = nums[i];     //stores the i-th element of nums array in the target array at the position whose value is the i-th element of index array.
                }
            }
            return target;
        }
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the string to check if halves are alike:");
            String s1 = Console.ReadLine();

            Console.WriteLine(HalvesAreAlike(s1));
            Console.WriteLine();


            //Question 2:
            Console.WriteLine("Q2 : Enter the string to check for pangram:");
            String s2 = Console.ReadLine();
            Console.WriteLine(CheckIfPangram(s2));
            Console.WriteLine();



            //Question 3:
            int[,] A = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };

            Console.WriteLine();
            Console.WriteLine("Q3: Richest person has a wealth of " + MaximumWealth(A));
            Console.WriteLine();




            //Question 4:
            Console.WriteLine("Q4 : Enter the stones:");
            String s = Console.ReadLine();
            Console.WriteLine("Q4 : Enter the jewels:");

            String j = Console.ReadLine();

            Console.WriteLine("The number of stones you have that are also jewels are {0}", NumJewelsInStones(j, s));
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Q5: Shuffled String");
            string s3 = "aaiougrt";
            Console.WriteLine("The original string is :" + s3);
            int[] indices = { 4, 0, 2, 6, 7, 3, 1, 5 };

            string rotated_string = RestoreString(s3, indices);

            Console.WriteLine("The Final shuffled string is " + rotated_string);
            Console.WriteLine();



            //Quesiton 6:
            Console.WriteLine(" Q6 : Targeted array:");
            int[] nums = new int[5];
            int[] indicesnew = new int[5];

            for (int i = 0; i < 5; i++)
            {
                //inputs nums array
                Console.Write("Enter nums array element each on a new line- {0} : ", i);
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < 5; i++)
            {   
                //inputs indices array
                Console.Write("Enter indices elements each on a new line- {0} : ", i);
                indicesnew[i] = Convert.ToInt32(Console.ReadLine());
            }


            int[] target = CreateTargetArray(nums, indicesnew);
            Console.WriteLine("Target array  for the Given array is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }

            Console.WriteLine();
            Console.WriteLine("End");



        }
    }
}
