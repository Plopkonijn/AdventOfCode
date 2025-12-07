using AdvenOfCode.Solvers.Year2025;

namespace AdventOfCode.Solvers.Tests.Year2025
{
    public abstract class AdventOfCodeTestsBase<TSolver>
        where TSolver : Solver
    {
        public abstract string PuzzleInputPath { get; }

        protected abstract TSolver CreateSolver(string[] puzzleInput);

        protected string[] ReadPuzzleInput(string inputFileName)
        {
            string path = Path.Combine(PuzzleInputPath, inputFileName);
            return File.ReadAllLines(path);
        }
    }
}