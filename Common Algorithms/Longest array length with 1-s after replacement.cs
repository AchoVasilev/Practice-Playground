    class Program
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var k = int.Parse(Console.ReadLine());
            
            var result = LongestArrLength(arr, k);
            Console.WriteLine(result);
        }

        private static int LongestArrLength(int[] arr, int k)
        {
            var windowStart = 0;
            var maxLength = 0;
            var maxOnesCount = 0;

            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                if (arr[windowEnd] == 1)
                {
                    maxOnesCount++;
                }

                var currentWindowSize = windowEnd - windowStart + 1;
                if (currentWindowSize - maxOnesCount > k)
                {
                    if (arr[windowStart] == 1)
                    {
                        maxOnesCount--;
                    }

                    windowStart++;
                }

                maxLength = Math.Max(maxLength, currentWindowSize);
            }

            return maxLength;
        }
    }
