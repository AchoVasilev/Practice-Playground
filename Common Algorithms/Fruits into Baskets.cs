class Program
    {
        public static void Main(string[] args)
        {
            var charArr = Console.ReadLine()
                .Split(", ")
                .Select(char.Parse)
                .ToArray();

            var size = int.Parse(Console.ReadLine());

            var result = LongestSubstringKDistinct(size, charArr);
            Console.WriteLine(result);
        }
        
        private static int LongestSubstringKDistinct(int size, char[] charArr)
        {
            var windowStart = 0;
            var maxLenght = 0;
            var dictionary = new Dictionary<char, int>();

            for (int windowEnd = 0; windowEnd < charArr.Length; windowEnd++)
            {
                var currentChar = charArr[windowEnd];
                if (!dictionary.ContainsKey(currentChar))
                {
                    dictionary[currentChar] = 0;
                }

                dictionary[currentChar]++;

                while (dictionary.Keys.Count > size)
                {
                    var charToRemove = charArr[windowStart];
                    dictionary[charToRemove]--;

                    if (dictionary[charToRemove] == 0)
                    {
                        dictionary.Remove(charToRemove);
                    }

                    windowStart++;
                }

                maxLenght = Math.Max(maxLenght, windowEnd - windowStart + 1);
            }

            return maxLenght;
        }
    }
