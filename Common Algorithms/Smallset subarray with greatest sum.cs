        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var sum = int.Parse(Console.ReadLine());

            var result = FindSubArrayLength(sum, arr);
            Console.WriteLine(result);
        }
        
        private static int FindSubArrayLength(int sum, int[] arr)
        {
            var subArrSum = 0;
            var subArrStartIndex = 0;
            var minLength = int.MaxValue;
            
            for (int i = 0; i < arr.Length; i++)
            {
                subArrSum += arr[i];

                while (subArrSum >= sum)
                {
                    minLength = Math.Max(minLength, i - subArrStartIndex + 1);
                    subArrSum -= arr[subArrStartIndex];
                    subArrStartIndex++;
                }
            }

            return minLength;
        }
    }
