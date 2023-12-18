namespace AdventOfCode2023.FirstDay
{
    public static class FirstDay
    {
        public static void Execute()
        {
            var inputs = File.ReadAllLines("InputData.txt").ToList();
            List<string> numbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            List<string> numbersAsText = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero" };

            int total = 0;
            foreach (var input in inputs)
            {
                List<NumberMetaInfo> numbersMetaInfo = new List<NumberMetaInfo>();
                if (input.Count() > 0)
                {
                    foreach (var numberAsText in numbersAsText)
                    {
                        var result = input.IndexOf(numberAsText);
                        var lastResult = input.LastIndexOf(numberAsText);

                        if (result != -1)
                        {
                            numbersMetaInfo.Add(new NumberMetaInfo { Position = result, Value = TextToNumber(numberAsText) });
                        }
                        if (lastResult != -1)
                        {
                            numbersMetaInfo.Add(new NumberMetaInfo { Position = lastResult, Value = TextToNumber(numberAsText) });
                        }
                    }

                    foreach (var number in numbers)
                    {
                        var result = input.IndexOf(number);
                        var lastResult = input.LastIndexOf(number);

                        if (result != -1)
                        {
                            numbersMetaInfo.Add(new NumberMetaInfo { Position = result, Value = number });
                        }
                        if (lastResult != -1)
                        {
                            numbersMetaInfo.Add(new NumberMetaInfo { Position = lastResult, Value = number });
                        }
                    }

                    var numbersMetaInfoOrdered = numbersMetaInfo.OrderBy(x => x.Position);

                    var first = numbersMetaInfoOrdered.FirstOrDefault();
                    var last = numbersMetaInfoOrdered.LastOrDefault();

                    var totalValue = first?.Value + last?.Value;

                    if (totalValue?.Length == 2)
                        total = total + int.Parse(totalValue);
                }
            }
            Console.WriteLine(total);

        }

        public static string TextToNumber(string text)
        {
            switch (text.ToLower())
            {
                case "zero":
                    return "0";
                case "one":
                    return "1";
                case "two":
                    return "2";
                case "three":
                    return "3";
                case "four":
                    return "4";
                case "five":
                    return "5";
                case "six":
                    return "6";
                case "seven":
                    return "7";
                case "eight":
                    return "8";
                case "nine":
                    return "9";
                case "ten":
                    return "10";
                // Add more cases as needed
                default:
                    throw new ArgumentException("Invalid text input");
            }
        }
    }
}