using Year2024.Solvers;

namespace Year2024.Tests;
public sealed class Day5SolverTests : AdventOfCodeSolverTests
{
    protected override int Day => 5;

    protected override AdventOfCodeSolver GetSolver(string[] input)
    {
        return new Day5Solver(input);
    }

    [Fact]
    public void Example1()
    {
        //Arrange
        string[] input =
        [
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13",
            "",
            "75,47,61,53,29",
            "97,61,53,29,13",
            "75,29,13",
            "75,97,47,61,53",
            "61,13,29",
            "97,13,75,29,47"
        ];
        AdventOfCodeSolver solver = GetSolver(input);

        //Act
        long result = solver.SolvePart1();

        //Assert
        Assert.Equal(143, result);
    }

    [Fact]
    public void Example2()
    {
        //Arrange
        string[] input =
        [
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13",
            "",
            "75,47,61,53,29",
            "97,61,53,29,13",
            "75,29,13",
            "75,97,47,61,53",
            "61,13,29",
            "97,13,75,29,47"
        ];
        AdventOfCodeSolver solver = GetSolver(input);

        //Act
        long result = solver.SolvePart2();

        //Assert
        Assert.Equal(123, result);
    }
}