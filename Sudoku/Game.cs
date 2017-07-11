using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public class Game
    {        
        public Dictionary<Square, int> Squares { get; set; }

        public Game()
        {
            this.Squares = new Dictionary<Square, int>();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    this.Squares.Add(new Square(i, j), 0);
        }

        private static readonly HashSet<int> values = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static ICollection<int> Gaps(ICollection<int> set)
        {
            var result = new HashSet<int>(values);
            result.ExceptWith(set);
            return result;
        }

        public void PutPiece(int x, int y, int value)
        {
            this.Squares[new Square(x, y)] = value;
        }

        public IEnumerable<int> GetItems(List<Square> positions)
        {
            return positions.Select(p => this.Squares[p]);
        }
    }
}
