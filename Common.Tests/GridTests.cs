using FluentAssertions;
using FluentAssertions.Execution;

namespace Common.Tests;

public class GridTests
{
	[Fact]
	public void Constructor_GivenNegativeWidth_ThrowsArgumentException()
	{
		//Arrange

		//Act
		var initialize = () => new Grid<char>(-1, 0);

		//Assert
		initialize.Should()
		          .Throw<ArgumentException>();
	}

	[Fact]
	public void Constructor_GivenNegativeHeight_ThrowsArgumentException()
	{
		//Arrange

		//Act
		var initialize = () => new Grid<char>(0, -1);

		//Assert
		initialize.Should()
		          .Throw<ArgumentException>();
	}

	[Fact]
	public void Constructor_GivenDimensions_InitializeDimensions()
	{
		//Arrange
		var width = 1;
		var height = 2;

		//Act
		var grid = new Grid<char>(width, height);

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
		string[] text = ["ab", "cd"];

		//Act
		var grid = new Grid<char>(2, 2)
		{
			[0, 0] = 'a',
			[1, 0] = 'b',
			[0, 1] = 'c',
			[1, 1] = 'd'
		};

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
	public void Indexer_SetValue_ShouldChangeValue()
	{
		//Arrange
		string[] changedText = ["ab", "ce"];
		var grid = new Grid<char>(2, 2)
		{
			[0, 0] = 'a',
			[1, 0] = 'b',
			[0, 1] = 'c',
			[1, 1] = 'd'
		};

		//Act
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
		var grid = new Grid<char>(2, 2)
		{
			[0, 0] = 'a',
			[1, 0] = 'b',
			[0, 1] = 'c',
			[1, 1] = 'd'
		};

		//Act
		var transpose = grid.Transpose();

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