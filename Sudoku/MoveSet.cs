using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public class MoveSet : List<Tuple<Square, int>>
    {
        public MoveSet() : base() { }

        public MoveSet(IEnumerable<Tuple<Square, int>> initialValues) : base(initialValues) { }

        public IEnumerable<int> Values
        {
            get
            {
                return this.Select(i => i.Item2);
            }
        }
    }
}
