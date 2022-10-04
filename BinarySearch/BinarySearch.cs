using System.Security.Cryptography;

namespace BinarySearch
{
    static class BinarySearch
    {
        static Random random = new Random();
        static List<int> Numbers;
        static List<List<int>> Trace = new List<List<int>>();
        static void Main()
        {
            // Generate random numbers
            Numbers = GenerateRandomNumbers(random.Next(10, 20)).ToList();
            int find = Numbers[random.Next(0, Numbers.Count - 1)];
            // Add a probablity that the number is not in the list.
            if (random.Next(0,1)==1) { find = random.Next(100, 200); }
            Console.WriteLine("Searching for: "+find);
            int index = RunBinaryScan(0, Numbers.Count-1, find);

            if (index > -1) Console.WriteLine("\n"+find+" is found at "+(index+1));
            else Console.WriteLine("\nCould not find "+find);

            Console.WriteLine("\nTrace:");
            foreach (List<int> i in Trace) PrintNumbers(i);
            Console.WriteLine("\n\n");
            
        }

        /// <summary>
        /// Searches a list of numbers for a value using binary search
        /// </summary>
        /// <param name="find"></param>
        /// <returns>index of find</returns>
        private static int RunBinaryScan(int start, int end, int find)
        {
            List<int> target = Numbers.GetRange(start, end);
            if (target.Count>0)
            {
                PrintNumbers(target);
                Trace.Add(target);
                int mid = ((target.Count-1) / 2);
                if (target[mid] == find) {return start+mid;}
                if (find > target.ElementAt(mid)) {
                    int count = target.Count-mid-1;
                    return RunBinaryScan(mid + 1, count, find);
                } else {
                    return RunBinaryScan(0, mid, find);
                }
            }
            return -1;
        }

        static SortedSet<int> GenerateRandomNumbers(int count)
        {
            SortedSet<int> result = new SortedSet<int>();
            while (result.Count<count)
            {
                int r = random.Next(10, 100);
                if (!result.Contains(r)) result.Add(r);
            }
            return result;
        }

        static void PrintNumbers(List<int> numbers)
        {
            Console.Write("\nNumbers:");
            foreach (int number in numbers) Console.Write(" "+number);
        }
    }
}