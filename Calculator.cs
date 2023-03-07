namespace CalculatorTest
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = GetDelimiters(numbers);
            var numberList = numbers
                .Split(delimiters.ToArray(), StringSplitOptions.None)
                .Select(n => int.TryParse(n, out var value) ? value : 0)
                .Where(n => n >= 0 && n <= 1000)
                .ToList();

            CheckNegativeNumbers(numberList);


            return numberList.Sum();
        }

        private List<string> GetDelimiters(string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                var delimiterLine = numbers.Split('\n')[0].Substring(2);

                if (delimiterLine.StartsWith("[") && delimiterLine.EndsWith("]"))
                {
                    delimiters.AddRange(delimiterLine.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {
                    delimiters.Add(delimiterLine);
                }
            }

            return delimiters;
        }

        private void CheckNegativeNumbers(List<int> numberList)
        {
            var negativeNumbers = numberList.Where(n => n < 0);

            if (negativeNumbers.Any())
            {
                Console.WriteLine($"Negative numbers not allowed: {string.Join(',', negativeNumbers)}");
                throw new ArgumentException($"Negatives not allowed: {string.Join(',', negativeNumbers)}");
            }
        }
    }

}