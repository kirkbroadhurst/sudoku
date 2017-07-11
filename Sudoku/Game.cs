using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sudoku
{
    public class Game
    {
        private static readonly HashSet<int> values = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private List<List<Square>> rows;
        private List<List<Square>> columns;

        public Dictionary<Square, int> Squares { get; set; }

        public Game()
        {
            this.Squares = new Dictionary<Square, int>();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    this.Squares.Add(new Square(i, j), 0);
        }

        public static ICollection<int> Gaps(IEnumerable<int> items)
        {
            var result = new HashSet<int>(values);
            result.ExceptWith(items);
            return result;
        }

        public List<List<Square>> Rows { get; private set; }

        public List<List<Square>> Columns { get; private set; }
        
        public List<List<Square>> Boxes { get; private set; }

        private void BuildSquares()
        {
            this.Rows = new List<List<Square>>();
            this.Columns = new List<List<Square>>();
            this.Boxes = new List<List<Square>>();

            for (int i = 0; i < 9; i++)
            {
                var row = new List<Square>();
                var column = new List<Square>();
                for (int j = 0; j < 9; j++)
                {
                    row.Add(new Square(i, j));
                    column.Add(new Square(j, i));
                }
                Rows.Add(row);
                Columns.Add(column);
            }

            for (int i = 0; i < 9; i+= 3)
                for (int j = 0; j < 9; j+= 3)
                {
                    var xx = Enumerable.Range(0, 3);
                    var yy = Enumerable.Range(0, 3);
                    var box = new List<Square>(xx.SelectMany(y => yy.Select(x => new Square(x + i, y + j))));
                    this.Boxes.Add(box);
                }
        }

        /// <summary>
        /// Load a game from a file
        /// </summary>
        /// <param name="path">Path to the file</param>
        public void LoadGame(string path)
        {
            var rows = File.ReadAllLines(path);
            var i = 0;
            foreach (var row in rows)
            {
                var values = row.Split('\t').Select(x => Int32.Parse(x));
                var j = 0;
                foreach (var val in values)
                {
                    this.Squares[new Square(i, j)] = val;
                    j++;
                }
                i++;
            }
        }

        public void PutPiece(int x, int y, int value)
        {
            this.Squares[new Square(x, y)] = value;
        }

        public IEnumerable<int> GetItems(List<Square> positions)
        {
            return positions.Select(p => this.Squares[p]);
        }

        public MoveSet GetMoves(List<Square> positions)
        {
            return new MoveSet(positions.Select(p => new Tuple<Square, int>(p, this.Squares[p])));
        }
    }
}

