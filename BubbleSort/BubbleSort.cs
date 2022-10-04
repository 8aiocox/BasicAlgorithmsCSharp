namespace BubbleSort
{
    static class BubbleSort
    {
        static List<int> Numbers;

        static Random Rand = new Random();
        internal static void Main()
        {
            Console.WriteLine("********************BUBBLE SORT PROGRAM****************");
            Numbers = GenerateUniqueRandomNumbers(Rand.Next(10, 20)).ToList();
            PrintNumbers(Numbers);
            // Perform bubble sort
            int swaps = 0;
            do
            {
                RunBubbleSortOneScan(out swaps);
                PrintNumbers(Numbers);
            }while (swaps > 0);
        }
        /// <summary>
        /// Returns a list of unorder random numbers
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        static HashSet<int> GenerateUniqueRandomNumbers (int count)
        {
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count<count)
            {
                int r = Rand.Next(10, 100);
                if (!numbers.Contains(r)) {  numbers.Add(r); }
            }
            return numbers;
        }
        /// <summary>
        /// Print the numbers from a list on to the console
        /// </summary>
        /// <param name="numbers"></param>
        static void PrintNumbers(List<int> numbers)
        {
            Console.Write("\nNumbers:");
            for (int i = 0; i < numbers.Count; i++) Console.Write(" "+numbers[i]);
        }

        static void RunBubbleSortOneScan(out int swaps)
        {
            swaps = 0;
            int prev = 0;
            for (int next=1; next<Numbers.Count; prev=next++)
            {
                int first = Numbers[prev];
                int second = Numbers[next];
                if (first > second)
                {
                    Numbers[prev] = second;
                    Numbers[next] = first;
                    swaps++;
                }
            }
        }
    }
}