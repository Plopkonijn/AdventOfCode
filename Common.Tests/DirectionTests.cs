using FluentAssertions;

namespace Common.Tests;

public class DirectionTests
{
	[Fact]
	public void TurnLeft_GivenRightDirection_ReturnsDownDirection()
	{
		//Arrange
		var direction = new Direction(1, 0);
		var expected = new Direction(0, -1);

		//Act
		var actual = direction.TurnLeft();

		//Assert
		actual.Should()
		      .Be(expected);
	}

	[Fact]
	public void TurnLeft_GivenLeftDirection_ReturnsUpDirection()
	{
		//Arrange
		var direction = new Direction(-1, 0);
		var expected = new Direction(0, 1);

		//Act
		var actual = direction.TurnLeft();

		//Assert
		actual.Should()
		      .Be(expected);
	}

	[Fact]
	public void TurnLeft_GivenUpDirection_ReturnsRightDirection()
	{
		//Arrange
		var direction = new Direction(0, 1);
		var expected = new Direction(1, 0);

		//Act
		var actual = direction.TurnLeft();

		//Assert
		actual.Should()
		      .Be(expected);
	}

	[Fact]
	public void TurnLeft_GivenRightDirection_ReturnsLeftDirection()
	{
		//Arrange
		var direction = new Direction(0, -1);
		var expected = new Direction(-1, 0);

		//Act
		var actual = direction.TurnLeft();

		//Assert
		actual.Should()
		      .Be(expected);
	}

	[Fact]
	public void TurnRight_GivenRightDirection_ReturnsUpDirection()
	{
		//Arrange
		var direction = new Direction(1, 0);
		var expected = new Direction(0, 1);

		//Act
		var actual = direction.TurnRight();

		//Assert
		actual.Should()
		      .Be(expected);
	}

	[Fact]
	public void TurnRight_GivenLeftDirection_ReturnsDownDirection()
	{
		//Arrange
		var direction = new Direction(-1, 0);
		var expected = new Direction(0, -1);

		//Act
		var actual = direction.TurnRight();

		//Assert
		actual.Should()
		      .Be(expected);
	}

	[Fact]
	public void TurnRight_GivenUpDirection_ReturnsLeftDirection()
	{
		//Arrange
		var direction = new Direction(0, 1);
		var expected = new Direction(-1, 0);

		//Act
		var actual = direction.TurnRight();

		//Assert
		actual.Should()
		      .Be(expected);
	}

	[Fact]
	public void TurnRight_GivenRightDirection_ReturnsRightDirection()
	{
		//Arrange
		var direction = new Direction(0, -1);
		var expected = new Direction(1, 0);

		//Act
		var actual = direction.TurnRight();

		//Assert
		actual.Should()
		      .Be(expected);
	}
}