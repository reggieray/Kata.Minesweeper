namespace Kata.Minesweeper
{
    public class Minesweeper
    {
        private readonly List<Minefield> minefields = new();

        public Minesweeper(IEnumerable<string> input)
        {
            var minefieldOption = InputParser.Parse(input);
            minefieldOption.ForEach(option => minefields.Add(new Minefield(option)));
        }

        public string RevealMinefields() => string.Join(string.Empty, minefields.Select(minefield => minefield.Reveal())).Trim();
    }
}
