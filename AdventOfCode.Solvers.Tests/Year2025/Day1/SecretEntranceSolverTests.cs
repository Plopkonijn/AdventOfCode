using AdvenOfCode.Solvers.Year2025.Day1;

namespace AdventOfCode.Solvers.Tests.Year2025.Day1
{
    public class SecretEntranceSolverTests
    {
        [Fact]
        public void Example_Part1()
        {
            //Arrange
            string[] input = File.ReadAllLines(@"Year2025\Day1\example.txt");

            //Act
            int result = SecretEntranceSolver.SolvePart1(input);

            //Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Day1_Part1()
        {
            //Arrange
            string[] input = File.ReadAllLines(@"Year2025\Day1\input.txt");

            //Act
            int result = SecretEntranceSolver.SolvePart1(input);

            //Assert
            Assert.Equal(995, result);
        }

        [Fact]
        public void Example_Part2()
        {
            //Arrange
            string[] input = File.ReadAllLines(@"Year2025\Day1\example.txt");

            //Act
            int result = SecretEntranceSolver.SolvePart2(input);

            //Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Day1_Part2()
        {
            //Arrange
            string[] input = File.ReadAllLines(@"Year2025\Day1\input.txt");

            //Act
            int result = SecretEntranceSolver.SolvePart2(input);

            //Assert
            Assert.Equal(5847, result);
        }
    }
}
