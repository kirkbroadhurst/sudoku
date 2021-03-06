using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku;

namespace Sudoku.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void GameConstructorTest()
        {
            var game = new Game(); 
            Assert.AreEqual(81, game.Squares.Count);
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)               
                    Assert.AreEqual(0, game.Squares[new Square(i, j)]);
        }

        [TestMethod]
        public void GameGetItemsTest()
        {
            var game = new Game();
            var rowSquares = new List<Square>();
            var colSquares = new List<Square>();

            for (int i = 0; i < 9; i++)
            {
                game.PutPiece(0, i, i+1);
                game.PutPiece(i, 0, i+1);

                rowSquares.Add(new Square(0, i));
                colSquares.Add(new Square(i, 0));
            }

            var rowItems = game.GetItems(rowSquares);
            var rowGaps = Game.Gaps(new HashSet<int>(rowItems));
            Assert.IsTrue(rowGaps.Count == 0);

            var colItems = game.GetItems(colSquares);
            var colGaps = Game.Gaps(new HashSet<int>(colItems));
            Assert.IsTrue(colGaps.Count == 0);
        }

        [TestMethod]
        public void LoadGameTest()
        {
            var file = System.IO.Path.Combine("TestFiles", "001.txt");
            var game = new Game();
            game.LoadGame(file);

            var row = game.Rows.First();
            Assert.AreEqual(0, row[0].Item2);
        }

    }
}
