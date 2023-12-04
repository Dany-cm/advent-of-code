namespace Trebuchet
{
    public static class PartOne
    {
        public static void Main(string[] args)
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
}