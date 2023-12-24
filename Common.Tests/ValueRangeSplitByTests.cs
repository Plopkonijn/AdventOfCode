using FluentAssertions;

namespace Common.Tests;

public class ValueRangeSplitByTests
{
	[Fact]
	public void SplitBy_GivenDisjointSplitLeft_ReturnsLeftEmptyMiddleEmptyRightOriginal()
	{
		//Arrange
		var range = new ValueRangeSplitBy(1, 2);
		var split = new ValueRangeSplitBy(0, 1);

		//Act
		(ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) = range.SplitBy(split);

		//Assert

		left.IsEmpty.Should()
		    .BeTrue();
		middle.IsEmpty.Should()
		      .BeTrue();
		right.Should()
		     .Be(range);
	}

	[Fact]
	public void SplitBy_GivenOverlappingSplitLeft_ReturnsLeftEmptyMiddleIntersectionRightDifference()
	{
		//Arrange
		var range = new ValueRangeSplitBy(1, 2);
		var split = new ValueRangeSplitBy(0, 2);

		//Act
		(ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) = range.SplitBy(split);

		//Assert

		left.IsEmpty.Should()
		    .BeTrue();
		middle.Should()
		      .Be(new ValueRangeSplitBy(1, 1));
		right.Should()
		     .Be(new ValueRangeSplitBy(2, 1));
	}

	[Fact]
	public void SplitBy_GivenContainedSplitLeft_ReturnsLeftEmptyMiddleIntersectionRightDifference()
	{
		//Arrange
		var range = new ValueRangeSplitBy(0, 2);
		var split = new ValueRangeSplitBy(0, 1);

		//Act
		(ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) = range.SplitBy(split);

		//Assert

		left.IsEmpty.Should()
		    .BeTrue();
		middle.Should()
		      .Be(new ValueRangeSplitBy(0, 1));
		right.Should()
		     .Be(new ValueRangeSplitBy(1, 1));
	}

	[Fact]
	public void SplitBy_GivenEqualSplit_ReturnsLeftEmptyMiddleOriginalRightEmpty()
	{
		//Arrange
		var range = new ValueRangeSplitBy(0, 1);

		//Act
		(ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) = range.SplitBy(range);

		//Assert

		left.IsEmpty.Should()
		    .BeTrue();
		middle.Should()
		      .Be(new ValueRangeSplitBy(0, 1));
		right.IsEmpty.Should()
		     .BeTrue();
	}

	[Fact]
	public void SplitBy_GivenContainedSplit_ReturnsLeftDifferenceMiddleIntersectionRightDifference()
	{
		//Arrange
		var range = new ValueRangeSplitBy(0, 3);
		var split = new ValueRangeSplitBy(1, 1);

		//Act
		(ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) = range.SplitBy(split);

		//Assert

		left.Should()
		    .Be(new ValueRangeSplitBy(0, 1));
		middle.Should()
		      .Be(new ValueRangeSplitBy(1, 1));
		right.Should()
		     .Be(new ValueRangeSplitBy(2, 1));
	}

	[Fact]
	public void SplitBy_GivenSplitContaining_ReturnsLeftEmptyMiddleOriginalRightEmpty()
	{
		//Arrange
		var range = new ValueRangeSplitBy(1, 1);
		var split = new ValueRangeSplitBy(0, 3);

		//Act
		(ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) = range.SplitBy(split);

		//Assert

		left.IsEmpty.Should()
		    .BeTrue();
		middle.Should()
		      .Be(range);
		right.IsEmpty.Should()
		     .BeTrue();
	}

	[Fact]
	public void SplitBy_GivenContainedSplitRight_ReturnsLeftDifferenceMiddleIntersectionRightEmpty()
	{
		//Arrange
		var range = new ValueRangeSplitBy(0, 2);
		var split = new ValueRangeSplitBy(1, 1);

		//Act
		(ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) = range.SplitBy(split);

		//Assert

		left.Should()
		    .Be(new ValueRangeSplitBy(0, 1));
		middle.Should()
		      .Be(new ValueRangeSplitBy(1, 1));
		right.IsEmpty.Should()
		     .BeTrue();
	}

	[Fact]
	public void SplitBy_GivenOverlappingSplitRight_ReturnsLeftDifferenceMiddleIntersectionRightEmpty()
	{
		//Arrange
		var range = new ValueRangeSplitBy(0, 2);
		var split = new ValueRangeSplitBy(1, 2);

		//Act
		(ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) = range.SplitBy(split);

		//Assert

		left.Should()
		    .Be(new ValueRangeSplitBy(0, 1));
		middle.Should()
		      .Be(new ValueRangeSplitBy(1, 1));
		right.IsEmpty.Should()
		     .BeTrue();
	}

	[Fact]
	public void SplitBy_GivenDisjointSplitRight_ReturnsLeftOriginalMiddleEmptyRightEmpty()
	{
		//Arrange
		var range = new ValueRangeSplitBy(0, 1);
		var split = new ValueRangeSplitBy(1, 1);

		//Act
		(ValueRangeSplitBy left, ValueRangeSplitBy middle, ValueRangeSplitBy right) = range.SplitBy(split);

		//Assert

		left.Should()
		    .Be(range);
		middle.IsEmpty.Should()
		      .BeTrue();
		right.IsEmpty.Should()
		     .BeTrue();
	}
}