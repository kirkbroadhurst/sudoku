using System;
using System.Collections.Generic;

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

        private HashSet<int> set = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        private ICollection<int> Gaps(ICollection<int> set)
        {
            var result = new HashSet<int>(set);
            result.ExceptWith(set);
            return result;
        }
    }
}

