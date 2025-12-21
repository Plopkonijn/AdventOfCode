using AdvenOfCode.Solvers.Year2025;
using AdvenOfCode.Solvers.Year2025.Day3;

namespace AdventOfCode.Solvers.Tests.Year2025.Day03
{
    public sealed class LobbySolverTests : AdventOfCodeTestsBase<LobbySolver>
    {
        public override string PuzzleInputPath => @"Year2025\Day03";

        [Theory]
        [InlineData("example.txt", 357)]
        [InlineData("input.txt", 17142)]
        public override void Part1(string inputFilePath, long expectedSolution)
        {
            //Arrange
            string[] input = ReadPuzzleInput(inputFilePath);
            Solver solver = CreateSolver(input);

            //Act
            long actualSolution = solver.SolvePart1();

            //Assert
            Assert.Equal(expectedSolution, actualSolution);
        }


        [Theory]
        [InlineData("example.txt", 3121910778619)]
        [InlineData("input.txt", 169935154100102)]
        public override void Part2(string inputFilePath, long expectedSolution)
        {
            //Arrange
            string[] input = ReadPuzzleInput(inputFilePath);
            Solver solver = CreateSolver(input);

            //Act
            long actualSolution = solver.SolvePart2();

            //Assert
            Assert.Equal(expectedSolution, actualSolution);
        }

        protected override LobbySolver CreateSolver(string[] puzzleInput)
        {
            return new LobbySolver(puzzleInput);
        }
    }
}
