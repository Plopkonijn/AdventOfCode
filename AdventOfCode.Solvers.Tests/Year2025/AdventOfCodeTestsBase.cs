using AdvenOfCode.Solvers.Year2025;

namespace AdventOfCode.Solvers.Tests.Year2025
{
    public abstract class AdventOfCodeTestsBase
    {
        public abstract string PuzzleInputPath { get; }
        protected string[] ReadPuzzleInput(string inputFileName)
        {
            string path = Path.Combine(PuzzleInputPath, inputFileName);
            return File.ReadAllLines(path);
        }
    }
    public abstract class AdventOfCodeTestsBase<TSolver> : AdventOfCodeTestsBase
        where TSolver : Solver
    {
        protected abstract TSolver CreateSolver(string[] puzzleInput);

        public abstract void Part1(string inputFilePath, long expectedSolution);
        public abstract void Part2(string inputFilePath, long expectedSolution);
    }
}