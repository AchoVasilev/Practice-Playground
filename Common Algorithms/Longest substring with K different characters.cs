 class Program
    {
        public static void Main(string[] args)
        {
            var str = Console.ReadLine();

            var size = int.Parse(Console.ReadLine());

            var result = LongestSubstringKDistinct(size, str);
            Console.WriteLine(result);
        }
        
        private static int LongestSubstringKDistinct(int size, string str)
        {
            var windowStart = 0;
            var maxLenght = 0;
            var dictionary = new Dictionary<char, int>();

            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                var rightChar = str[windowEnd];
                if (!dictionary.ContainsKey(rightChar))
                {
                    dictionary[rightChar] = 0;
                }

                dictionary[rightChar]++;

                while (dictionary.Keys.Count > size)
                {
                    var leftChar = str[windowStart];
                    dictionary[leftChar]--;

                    if (dictionary[leftChar] == 0)
                    {
                        dictionary.Remove(leftChar);
                    }

                    windowStart++;
                }

                maxLenght = Math.Max(maxLenght, windowEnd - windowStart + 1);
            }

            return maxLenght;
        }
    }
