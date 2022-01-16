namespace Kata.Minesweeper
{
    public static class InputParser
    {
        internal static List<MinefieldInput> Parse(IEnumerable<string> input)
        {
            var minesweeperOptions = new List<MinefieldInput>();
            var minefieldInput = new List<string>();
            foreach (var inputLine in input)
            {
                if (inputLine.IsMinefieldDimensions() && minefieldInput.Any())
                {
                    minesweeperOptions.Add(minefieldInput.ToMinefieldOption(minesweeperOptions.Count + 1));
                    minefieldInput.Clear();
                }

                minefieldInput.Add(inputLine);
            }
            minesweeperOptions.Add(minefieldInput.ToMinefieldOption(minesweeperOptions.Count + 1));

            return minesweeperOptions;   
        }

        private static MinefieldInput ToMinefieldOption(this List<string> minefieldInput, int number)
        {
            var gridDimension = minefieldInput[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var height = int.Parse(gridDimension[0]);
            var width = int.Parse(gridDimension[1]);
            var mines = new List<string>(minefieldInput.Skip(1));
            return new MinefieldInput(number, height, width, mines.ToArray());
        }

        private static bool IsMinefieldDimensions(this string line)
        {
            return !string.IsNullOrEmpty(line) && line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).IsAllNumeric();
        }

        private static bool IsAllNumeric(this string[] characters)
        {
            return characters.All(x => x.IsNumeric());
        }

        private static bool IsNumeric(this string character)
        {
            return int.TryParse(character, out int _);
        }
    }
}
