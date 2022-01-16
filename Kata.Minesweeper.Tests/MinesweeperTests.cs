using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System.IO;

namespace Kata.Minesweeper.Tests
{
    public class MinesweeperTests
    {
        [Test]
        [TestCase("ApprovalScenario1")]
        [TestCase("ApprovalScenario2")]
        [UseReporter(typeof(DiffReporter))]
        public void ApprovalTest1(string inputFilename)
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