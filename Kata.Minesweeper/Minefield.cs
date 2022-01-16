using System.Text;

namespace Kata.Minesweeper
{
    internal class Minefield
    {
        private readonly MineType[,] minefield;
        private readonly int number;
        public Minefield(MinefieldInput input)
        {
            number = input.Number;
            minefield = new MineType[input.Height, input.Width];
            for (int i = 0; i < minefield.GetLength(0); i++)
            {
                var mines = input.Mines[i].ToCharArray();
                for (int j = 0; j < minefield.GetLength(1); j++)
                { 
                    minefield[i, j] = mines[j] == '*' ? MineType.Explosive : MineType.Empty;
                }
            }
        }

        public string Reveal()
        {
            if(minefield.Length == 0) return string.Empty;

            var revealedBoard = new StringBuilder();
            revealedBoard.AppendLine($"Field #{number}:");

            for (int i = 0; i < minefield.GetLength(0); i++)
            {
                var fieldLine = string.Empty;
                for (int j = 0; j < minefield.GetLength(1); j++)
                {
                    fieldLine = $"{fieldLine}{RevealPosition(i, j)}";
                }
                revealedBoard.AppendLine(fieldLine);
            }
            revealedBoard.AppendLine();

            return revealedBoard.ToString();
        }

        private string RevealPosition(int x, int y) 
        {
            if (minefield[x, y] == MineType.Explosive)
            {
                return "*";
            }

            return GetSurroundingMineCount(x, y).ToString();
        }

        private int GetSurroundingMineCount(int x, int y)
        {
            var mineTypes = new List<MineType>()
            {
                GetMineType(x -1, y -1),
                GetMineType(x -1, y),
                GetMineType(x, y -1),
                GetMineType(x -1, y +1),
                GetMineType(x +1, y -1),
                GetMineType(x +1, y),
                GetMineType(x, y +1),
                GetMineType(x +1, y +1)
            };

            return mineTypes.Count(x => x == MineType.Explosive);
        }

        private MineType GetMineType(int x, int y)
        {
            if (x < 0
               || x > this.minefield.GetLength(0) - 1
               || y > this.minefield.GetLength(1) - 1
               || y < 0)
            {
                return MineType.NonExistent;
            }

            return this.minefield[x, y];
        }
    }
}
