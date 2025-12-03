using AdvenOfCode.Solvers.Year2025.Day1;

namespace AdventOfCode.Solvers.Tests.Year2025.Day1
{
    public class SecretEntranceSolverTests : AdventOfCodeTestsBase
    {
        public override string PuzzleInputPath => @"Year2025\Day1";

        [Theory]
        [InlineData("example.txt", 3)]
        [InlineData("input.txt", 995)]
        public void Part1(string inputFilePath, int expectedSolution)
        {
            //Arrange
            string[] input = ReadPuzzleInput(inputFilePath);

            //Act
            int actualSolution = SecretEntranceSolver.SolvePart1(input);

            //Assert
            Assert.Equal(expectedSolution, actualSolution);
        }


        [Theory]
        [InlineData("example.txt", 6)]
        [InlineData("input.txt", 5847)]
        public void Part2(string inputFilePath, int expectedSolution)
        {
            //Arrange
            string[] input = ReadPuzzleInput(inputFilePath);

            //Act
            int actualSolution = SecretEntranceSolver.SolvePart2(input);

            //Assert
            Assert.Equal(expectedSolution, actualSolution);
        }
    }
}
