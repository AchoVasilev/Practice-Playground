class Program
    {
        //Given an array, find the average of each subarray of ‘K’ contiguous elements in it.
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var k = int.Parse(Console.ReadLine());

            var result = GetSums(arr, k);

            Console.WriteLine(string.Join(' ', result));
        }

        private static double[] GetSums(int[] arr, int k)
        {
            var resultSumsArr = new double[arr.Length - k + 1];
            var subArrSum = 0.0;
            var subArrStartElement = 0;

            for (int subArrEndElement = 0; subArrEndElement < arr.Length; subArrEndElement++)
            {
                subArrSum += arr[subArrEndElement];

                if (subArrEndElement >= k - 1)
                {
                    resultSumsArr[subArrStartElement] = subArrSum / k;
                    subArrSum -= arr[subArrStartElement];
                    subArrStartElement++;
                }
            }

            return resultSumsArr;
        }
    }
