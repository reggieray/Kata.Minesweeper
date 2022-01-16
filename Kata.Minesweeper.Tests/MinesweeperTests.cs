using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System.IO;

namespace Kata.Minesweeper.Tests
{
    public class MinesweeperTests
    {
        [Test]
        [TestCase("SimpleMinefield")]
        [TestCase("MultipleMinefields")]
        [UseReporter(typeof(DiffReporter))]
        public void ScenarioTests(string inputFilename)
        {
            var input = File.ReadLines($"{inputFilename}.txt");
            var minesweeper = new Minesweeper(input);

            using (ApprovalTests.Namers.ApprovalResults.ForScenario(inputFilename))
            {
                Approvals.Verify(minesweeper.RevealMinefields());
            }      
        }
    }
}