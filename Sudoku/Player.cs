using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public class Player
    {
        public Game Game { get; set; }

        public Player()
        {
        }
 
        public Player (Game game)
        {
        }

        public void FindPossibleMoves()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="squares"></param>
        /// <param name="result"></param>
        /// <returns>True if the row was solved</returns>
        public bool SolveRow(MoveSet knownValues, out MoveSet moves)
        {
            moves = new MoveSet();
            var missingVals = Game.Gaps(knownValues.Select(v => v.Item2));

            if (!missingVals.Any())
                return true;

            if (missingVals.Count == 1)
            {
                moves.Add(new Tuple<Square, int>(knownValues.Single(v => v.Item2 == 0).Item1, missingVals.Single()));
                return true;
            }

            return false;
        }
    }
}

