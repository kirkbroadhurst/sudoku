using System;

namespace Sudoku
{
    public class Square : Tuple<int, int>
    {
        public Square(int item1, int item2) : base(item1, item2)
        {
        }
    }
}
