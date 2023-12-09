using Trebuchet;

// PartOne.One(args);
PartTwo.Two(args);

namespace Trebuchet
{
    public static class PartOne
    {
        public static void One(string[] args)
        {
            var totalSum = 0;
            foreach (var item in Utilities.ReadFileContents("input.txt"))
            {
                var firstSum = "";
                var lastSum = "";
                var singleDigit = item.ToCharArray();

                foreach (var firstDigit in singleDigit)
                {
                    if (char.IsDigit(firstDigit))
                    {
                        // save the first number
                        int.TryParse(firstDigit.ToString(), out var firstDigitInt);
                        firstSum += firstDigitInt;
                        break;
                    }
                }

                foreach (var lastDigit in singleDigit.Reverse())
                {
                    if (char.IsDigit(lastDigit))
                    {
                        // save the first number from the end
                        int.TryParse(lastDigit.ToString(), out var lastDigitInt);
                        lastSum += lastDigitInt;
                        break;
                    }
                }

                var concatenateSum = firstSum + lastSum;
                totalSum += int.Parse(concatenateSum);
            }

            Console.WriteLine(totalSum);
        }
    }

    public static class PartTwo
    {
        public static void Two(string[] args)
        {
            var totalSum = "";
            var numbers = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            foreach (var item in File.ReadAllLines("sample.txt"))
            {
                var firstSum = "";
                var lastSum = "";

                #region FindNumbers

                var singleDigit = item.ToCharArray();

                foreach (var firstDigit in singleDigit)
                {
                    if (char.IsDigit(firstDigit))
                    {
                        // save the first number
                        int.TryParse(firstDigit.ToString(), out var firstDigitInt);
                        firstSum += firstDigitInt;
                        break;
                    }
                }

                #endregion

                #region FindWrittenNumbers

                // We set this to an arbitrary big number to start with
                // This means that anything returned by IndexOf is guaranteed to be lower than this
                // So we can just check if `IndexOf(whatever) < lowestFirstIndex`
                var lowestFirstIndex = int.MaxValue;

                // Call ToIndex for each 
                foreach (var number in numbers)
                {
                    var index = item.IndexOf(number, StringComparison.InvariantCulture);
                    // Make sure we have a valid index (at least 0), otherwise we didn't find our string at all
                    if (index >= 0)
                    {
                        // If the index is lower than the last index we stored, we know the current number is 
                        // earlier in the string, so overwrite it
                        if (index < lowestFirstIndex)
                        {
                            firstSum = number;
                            lowestFirstIndex = index;
                        }
                    }
                }

                #endregion

                var concatenateSum = firstSum + lastSum;
                Console.WriteLine(concatenateSum);
                int.TryParse(concatenateSum, out var result);
                totalSum += result;
            }

            Console.WriteLine(totalSum);
        }
    }
}