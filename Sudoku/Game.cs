using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class Game
    {
        private static readonly HashSet<int> values = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static ICollection<int> Gaps(ICollection<int> set)
        {
            var result = new HashSet<int>(values);
            result.ExceptWith(set);
            return result;
        }
    }
}
