using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sudoku
{
    public class Game
    {
        private static readonly HashSet<int> values = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private Func<List<List<Square>>, IEnumerable<MoveSet>> lookup;
        private List<List<Square>> rows;
        private List<List<Square>> columns;
        private List<List<Square>> boxes;

        /// <summary>
        /// The 'board' data structure
        /// </summary>
        public Dictionary<Square, int> Squares { get; set; }

        public Game()
        {
            this.Squares = new Dictionary<Square, int>();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    this.Squares.Add(new Square(i, j), 0);

            this.BuildSquares();
            this.lookup = set => set.Select(row => new MoveSet(row.Select(item => new Tuple<Square, int>(item, this.Squares[item]))));
        }

        public static ICollection<int> Gaps(IEnumerable<int> items)
        {
            var result = new HashSet<int>(values);
            result.ExceptWith(items);
            return result;
        }        

        public IEnumerable<MoveSet> Rows
        {
            get
            {
                return this.lookup(this.rows);
            }
        }

        public IEnumerable<MoveSet> Columns
        {
            get
            {
                return this.lookup(this.columns);
            }
        }
        
        public IEnumerable<MoveSet> Boxes
        {
            get
            {
                return this.lookup(this.boxes);
            }
        }

        public IEnumerable<MoveSet> MoveSets
        {
            get
            {
                return this.Rows.Union(this.Columns).Union(this.Boxes);
            }
        }


        private void BuildSquares()
        {
            this.rows = new List<List<Square>>();
            this.columns = new List<List<Square>>();
            this.boxes = new List<List<Square>>();

            for (int i = 0; i < 9; i++)
            {
                var row = new List<Square>();
                var column = new List<Square>();
                for (int j = 0; j < 9; j++)
                {
                    row.Add(new Square(i, j));
                    column.Add(new Square(j, i));
                }
                this.rows.Add(row);
                this.columns.Add(column);
            }

            for (int i = 0; i < 9; i+= 3)
                for (int j = 0; j < 9; j+= 3)
                {
                    var xx = Enumerable.Range(0, 3);
                    var yy = Enumerable.Range(0, 3);
                    var box = new List<Square>(xx.SelectMany(y => yy.Select(x => new Square(x + i, y + j))));
                    this.boxes.Add(box);
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

        public void PutPiece(Tuple<Square, int> move)
        {
            this.PutPiece(move.Item1.Item1, move.Item1.Item2, move.Item2);
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

        public bool IsFinished()
        {
            foreach (var set in this.MoveSets)
            {
                if (Game.Gaps(set.Values).Any())
                    return false;
            }
            return true;
        }
    }
}

