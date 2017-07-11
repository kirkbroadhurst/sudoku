using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var row = game.Rows.First();

            var player = new Player();
            var moves = new MoveSet();
            var result = player.SolveMoveSet(row, out moves);

            Assert.IsTrue(result);
            Assert.AreEqual(moves.Count, 1);
            Assert.AreEqual(moves[0].Item1, new Square(0, 0));
            Assert.AreEqual(moves[0].Item2, 4);
        }

        [TestMethod]
        public void SolveGameTest()
        {
            foreach (var file in Directory.GetFiles("TestFiles"))
            {

                //var file = System.IO.Path.Combine("TestFiles", "001.txt");
                var game = new Game();
                game.LoadGame(file);

                var player = new Player();
                player.SolveEasyRows(game);
                Assert.IsTrue(game.IsFinished());
            }
        }
    }
}
