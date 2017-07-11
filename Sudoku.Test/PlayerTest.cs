using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku;

namespace Sudoku.Test
{
    [TestClass]
    public class PlayerTest
    {
 
        [TestMethod]
        public void SolveRowTest()
        {
            var file = System.IO.Path.Combine("TestFiles", "001.txt");
            var game = new Game();
            game.LoadGame(file);

            var row = game.GetMoves(Game.GetRows()[0]);

            var player = new Player(game);
            var moves = new MoveSet();
            var result = player.SolveRow(row, out moves);

            Assert.IsTrue(result);
            Assert.AreEqual(moves.Count, 1);
            Assert.AreEqual(moves[0].Item1, new Square(0, 0));
            Assert.AreEqual(moves[0].Item2, 4);
        }

    }
}
