class Program
    {
        public static void Main(string[] args)
        {
            var str = Console.ReadLine();

            var result = LongestSubstringDistinct(str);
            Console.WriteLine(result);
        }

        private static int LongestSubstringDistinct(string str)
        {
            var windowStart = 0;
            var maxLenght = 0;
            var dictionary = new Dictionary<char, int>();

            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                var rightChar = str[windowEnd];
                if (dictionary.ContainsKey(rightChar))
                {
                    windowStart = Math.Max(windowStart, dictionary[rightChar] + 1);
                }

                dictionary[rightChar] = windowEnd;

                maxLenght = Math.Max(maxLenght, windowEnd - windowStart + 1);
            }

            return maxLenght;
        }
    }
