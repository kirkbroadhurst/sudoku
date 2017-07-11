using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class Square : Tuple<int, int>
    {
        public Square(int item1, int item2) : base(item1, item2)
        {
        }
    }

    public class MoveSet : List<Tuple<Square, int>>
    {
        public MoveSet() : base() { }

        public MoveSet(IEnumerable<Tuple<Square, int>> initialValues) : base(initialValues) { }
    }
}
