using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1
{
    class Program
    {
        public int[] ReadArrayFromConsole()
        {

            String read = Console.ReadLine();
            String[] strNums = read.Split(',');
            List<int> outputNums = new List<int>();
            foreach(String num in strNums)
            {
                int temp;
                if(!Int32.TryParse(num,out temp))
                {
                    continue;
                }
                outputNums.Add(temp);
            }
            return outputNums.ToArray();
        }
        public int[] BubbleSort(int[] array)
        {

            bool swapped = false;
            do
            {
                for (int y = 0; y < array.Length - 1; y++)
                {
                    if (array[y] > array[y + 1])
                    {
                        swapped = true;
                        int temp = array[y];
                        array[y] = array[y + 1];
                        array[y + 1] = temp;
                    }
                }
            } while (!swapped);
            return array;      
        }
        public int[] BetterSort(int[] array)
        {
            List<int> toSort = new List<int>();
            toSort.AddRange(array);
            toSort.Sort();
            toSort.Reverse();
            return toSort.ToArray();
        }
        private (bool, int) Balanced(string braces)
        {
            //initialize some variables to store our state
            Stack<char> braceStack = new Stack<char>();
            int maxDepth = 0;
            Dictionary<char, char> braceList = new Dictionary<char, char>()
            {
                { '(',')' },
                { '[',']' },
                { '{','}' }
            };

            //loop through every character in our input string
            foreach (char c in braces.ToCharArray())
            {
                if (braceList.ContainsKey(c)) //found an open brace 
                {
                    braceStack.Push(c);//add to stack of open brackets
                    //track depth
                    int cDepth = braceStack.Count(); //current depth
                    if (cDepth > maxDepth)
                        maxDepth = cDepth; //if current depth is greater than maxDepth, update maxDepth
                    continue;
                }
                else if (braceList.ContainsValue(c))//ClosingBrace found!
                {
                    if (braceList[braceStack.Peek()] == c)//Proper closing brace for the last open brace in stack?
                    {
                        braceStack.Pop(); //Remove last open brace, since we now closed it
                    }
                    else
                    {//Uh oh... not matching...
                        return (false, -1);
                    }
                }
                //otherwise its a non-brace character we can ignore...
            }
            if (braceStack.Count() == 0) //no braces left to be closed
            {
                return (true, maxDepth); //return balanced, and depth
            }
            return (false, -1); //not balanced, return accordingly
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            int[] r = p.ReadArrayFromConsole();
            var sorted = p.BubbleSort(r);
            int[] o = p.BetterSort(r);
            String i = Console.ReadLine();
            var balanceResult = p.Balanced(i);
        }
    }
}
