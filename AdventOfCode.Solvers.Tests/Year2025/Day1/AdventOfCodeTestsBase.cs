namespace AdventOfCode.Solvers.Tests.Year2025.Day1
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
}