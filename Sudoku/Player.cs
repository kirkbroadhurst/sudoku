using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public class Player
    {
        public Player()
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
        public bool SolveMoveSet(MoveSet knownValues, out MoveSet moves)
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

        public void SolveEasyRows(Game game)
        {
            bool found = true;
            while (found)
            {
                found = false;
                foreach (var row in game.MoveSets)
                {
                    MoveSet moves;
                    this.SolveMoveSet(row, out moves);
                    if (moves.Any())
                        found = true;

                    foreach (var move in moves)
                    {
                        game.PutPiece(move.Item1.Item1, move.Item1.Item2, move.Item2);
                    }

                }
            }
        }
    }
}

