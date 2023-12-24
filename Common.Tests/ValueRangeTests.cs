using FluentAssertions;

namespace Common.Tests;

public class ValueRangeTests
{
	[Fact]
	public void SplitBy_GivenDisjointToTheRight_ReturnsEmptyMiddleAndRight()
	{
		//Arrange
		var range = new ValueRange(0, 1);
		var split = new ValueRange(1, 2);

		//Act
		(ValueRange left, ValueRange middle, ValueRange right) = range.SplitBy(split);

		//Assert

		left.Should()
		    .Be(range);
		middle.IsEmpty.Should()
		      .BeTrue();
		right.IsEmpty.Should()
		     .BeTrue();
	}

	[Fact]
	public void SplitBy_GivenDisjointToTheLeft_ReturnsEmptyLeftAndMiddle()
	{
		//Arrange
		var range = new ValueRange(1, 2);
		var split = new ValueRange(0, 1);

		//Act
		(ValueRange left, ValueRange middle, ValueRange right) = range.SplitBy(split);

		//Assert

		left.IsEmpty.Should()
		    .BeTrue();
		middle.IsEmpty.Should()
		      .BeTrue();
		right.Should()
		     .Be(range);
	}

	[Fact]
	public void SplitBy_GivenCompletelyContained_ReturnsThreeNonEmpty()
	{
		//Arrange
		var range = new ValueRange(0, 3);
		var split = new ValueRange(1, 1);

		//Act
		(ValueRange left, ValueRange middle, ValueRange right) = range.SplitBy(split);

		//Assert

		left.Should()
		    .Be(new ValueRange(0, 1));
		middle.Should()
		      .Be(split);
		right.Should()
		     .Be(new ValueRange(2, 1));
	}

	[Fact]
	public void SplitBy_GivenSameRange_ReturnsOriginalAsMiddle()
	{
		//Arrange
		var range = new ValueRange(0, 1);

		//Act
		(ValueRange left, ValueRange middle, ValueRange right) = range.SplitBy(range);

		//Assert

		left.IsEmpty.Should()
		    .BeTrue();
		middle.Should()
		      .Be(range);
		right.IsEmpty.Should()
		     .BeTrue();
	}

	[Fact]
	public void SplitBy_GivenOverLappingLeft_ReturnsEmptyLeft()
	{
		//Arrange
		var range = new ValueRange(1, 2);
		var split = new ValueRange(0, 2);

		//Act
		(ValueRange left, ValueRange middle, ValueRange right) = range.SplitBy(split);

		//Assert

		left.IsEmpty.Should()
		    .BeTrue();
		middle.Should()
		      .Be(new ValueRange(1, 1));
		right.Should()
		     .Be(new ValueRange(2, 1));
	}

	[Fact]
	public void SplitBy_GivenOverLappingRight_ReturnsEmptyRight()
	{
		//Arrange
		var range = new ValueRange(0, 2);
		var split = new ValueRange(1, 2);

		//Act
		(ValueRange left, ValueRange middle, ValueRange right) = range.SplitBy(split);

		//Assert

		left.Should()
		    .Be(new ValueRange(0, 1));
		middle.Should()
		      .Be(new ValueRange(1, 1));
		right.IsEmpty.Should()
		     .BeTrue();
	}
}