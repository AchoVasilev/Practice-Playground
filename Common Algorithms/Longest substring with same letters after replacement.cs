    class Program
    {
        public static void Main(string[] args)
        {
            var str = Console.ReadLine();

            var k = int.Parse(Console.ReadLine());
            
            var result = LongestSubstringAfterReplacement(str, k);
            Console.WriteLine(result);
        }

        private static int LongestSubstringAfterReplacement(string str, int k)
        {
            var windowStart = 0;
            var maxLenght = 0;
            var maxRepetitionLetterCount = 0;
            var dictionary = new Dictionary<char, int>();

            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                var rightChar = str[windowEnd];
                if (!dictionary.ContainsKey(rightChar))
                {
                    dictionary[rightChar] = 0;
                }

                dictionary[rightChar]++;

                maxRepetitionLetterCount = Math.Max(maxRepetitionLetterCount, dictionary[rightChar]);

                var currentWindow = windowEnd - windowStart + 1;
                if (currentWindow - maxRepetitionLetterCount > k)
                {
                    var leftChar = str[windowStart];
                    dictionary[leftChar]--;
                    windowStart++;
                }

                maxLenght = Math.Max(maxLenght, currentWindow);
            }

            return maxLenght;
        }
    }
