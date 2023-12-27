using FluentAssertions;
using FluentAssertions.Execution;
using Year2023.Day13;

namespace Common.Tests;

public class GridTests
{
	[Fact]
	public void Constructor_GivenNegativeWidth_ThrowsArgumentException()
	{
		//Arrange

		//Act
		Func<Grid> initialize = () => new Grid(-1, 0);

		//Assert
		initialize.Should()
		          .Throw<ArgumentException>();
	}

	[Fact]
	public void Constructor_GivenNegativeHeight_ThrowsArgumentException()
	{
		//Arrange

		//Act
		Func<Grid> initialize = () => new Grid(0, -1);

		//Assert
		initialize.Should()
		          .Throw<ArgumentException>();
	}

	[Fact]
	public void Constructor_GivenDimensions_InitializeDimensions()
	{
		//Arrange
		int width = 1;
		int height = 2;

		//Act
		var grid = new Grid(width, height);

		//Assert
		grid.Width.Should()
		    .Be(width);
		grid.Height.Should()
		    .Be(height);
	}

	[Fact]
	public void Constructor_GivenValidText_InitializesGrid()
	{
		//Arrange
		string[] text = { "ab", "cd" };

		//Act
		var grid = new Grid(text);

		//Assert
		using var scope = new AssertionScope();
		Enumerable.Range(0, 2)
		          .SelectMany(x => Enumerable.Range(0, 2)
		                                     .Select(y => (x, y)))
		          .Should()
		          .AllSatisfy(t =>
		          {
			          grid[t.x, t.y]
				          .Should()
				          .Be(text[t.y][t.x]);
		          });
	}

	[Fact]
	public void Constructor_GivenInvalidText_ThrowsArgumentOutOfRangeException()
	{
		//Arrange
		string[] text = { "ab", "c" };

		//Act
		Func<Grid> initialize = () => new Grid(text);

		//Assert
		initialize.Should()
		          .Throw<ArgumentOutOfRangeException>();
	}

	[Fact]
	public void Indexer_SetValue_ShouldChangeValue()
	{
		//Arrange
		string[] originalText = { "ab", "cd" };
		string[] changedText = { "ab", "ce" };

		//Act
		var grid = new Grid(originalText);
		grid[1, 1] = 'e';

		//Assert
		using var scope = new AssertionScope();
		Enumerable.Range(0, 2)
		          .SelectMany(x => Enumerable.Range(0, 2)
		                                     .Select(y => (x, y)))
		          .Should()
		          .AllSatisfy(t =>
		          {
			          grid[t.x, t.y]
				          .Should()
				          .Be(changedText[t.y][t.x]);
		          });
	}

	[Fact]
	public void Transpose_ShouldCorrectlyTransposeGrid()
	{
		//Arrange
		string[] text = { "ab", "cd" };
		var grid = new Grid(text);

		//Act
		Grid transpose = grid.Transpose();

		//Assert
		using var scope = new AssertionScope();
		Enumerable.Range(0, 2)
		          .SelectMany(x => Enumerable.Range(0, 2)
		                                     .Select(y => (x, y)))
		          .Should()
		          .AllSatisfy(t =>
		          {
			          grid[t.x, t.y]
				          .Should()
				          .Be(transpose[t.y, t.x]);
		          });
	}
}