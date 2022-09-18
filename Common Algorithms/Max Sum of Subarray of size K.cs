class Program
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var k = int.Parse(Console.ReadLine());

            var result = GetSumBruteForce(arr, k);
            Console.WriteLine(result);
            
            result = GetSumOptimized(arr, k);
            Console.WriteLine(result);
        }

        private static int GetSumOptimized(int[] arr, int k)
        {
            var maxSum = 0;
            var subArrSum = 0;
            var subArrStartIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                subArrSum += arr[i];

                if (i >= k - 1)
                {
                    maxSum = Math.Max(maxSum, subArrSum);
                    subArrSum -= arr[subArrStartIndex];
                    subArrStartIndex++;
                }
            }

            return maxSum;
        }

        private static int GetSumBruteForce(int[] arr, int k)
        {
            var maxSum = 0;

            for (int i = 0; i <= arr.Length - k; i++)
            {
                var subArrSum = 0;
                for (int j = 0; j < i + k; j++)
                {
                    subArrSum += arr[j];
                }

                maxSum = Math.Max(maxSum, subArrSum);
            }

            return maxSum;
        }
    }
