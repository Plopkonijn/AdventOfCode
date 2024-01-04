namespace Year2023.Day16;

internal class Contraption
{
	private readonly string[] _tiles;

	public Contraption(string[] tiles)
	{
		if (tiles.Select(row => row.Length)
		         .Distinct()
		         .Count() > 1)
		{
			throw new ArgumentException();
		}

		_tiles = tiles;
	}

	private int Width => _tiles.FirstOrDefault(string.Empty)
	                           .Length;

	private int Height => _tiles.Length;

	public int CountEnergizedTiles(Beam startBeam)
	{
		if (IsOutsideBounds(startBeam))
		{
			throw new ArgumentException();
		}

		var energizedTiles = new HashSet<(int x, int y, int dx, int dy)>
			{ (startBeam.PositionX, startBeam.PositionY, startBeam.DirectionX, startBeam.DirectionY) };
		var beams = new HashSet<Beam> { startBeam };
		while (beams.Count > 0)
		{
			var newBeams = UpdateBeams(beams)
				.ToArray();
			beams.UnionWith(newBeams);
			energizedTiles.UnionWith(beams.Select(beam => (beam.PositionX, beam.PositionY, beam.DirectionX, beam.DirectionY)));
			var outsideBounds = beams.Where(IsOutsideBounds)
			                         .ToList();
			if (outsideBounds.Count > 0)
			{
				throw new InvalidOperationException();
			}
		}

		return energizedTiles.Select(tuple => (tuple.x, tuple.y))
		                     .Distinct()
		                     .Count();
	}

	private IEnumerable<Beam> UpdateBeams(IEnumerable<Beam> beams)
	{
		return beams.Select(UpdateBeam)
		            .OfType<Beam>();
	}

	private Beam? UpdateBeam(Beam beam)
	{
		Beam? splitBeam = null;
		switch (_tiles[beam.PositionY][beam.PositionX])
		{
			case '.':
				break;
			case '\\':
				beam.ChangeDirection(beam.DirectionY, beam.DirectionX);
				break;
			case '/':
				beam.ChangeDirection(-beam.DirectionY, -beam.DirectionX);
				break;
			case '|' when beam.DirectionY is 0:
				splitBeam = beam with { Id = Guid.NewGuid() };
				beam.ChangeDirection(0, -1);
				splitBeam.ChangeDirection(0, 1);
				splitBeam.Move();
				break;
			case '-' when beam.DirectionX is 0:
				splitBeam = beam with { Id = Guid.NewGuid() };
				beam.ChangeDirection(-1, 0);
				splitBeam.ChangeDirection(1, 0);
				splitBeam.Move();
				break;
		}

		beam.Move();
		return splitBeam;
	}

	private bool IsOutsideBounds(Beam beam)
	{
		return beam.PositionX < 0 || beam.PositionX >= Width ||
		       beam.PositionY < 0 || beam.PositionY >= Height;
	}

	public int CountMaximumEnergizedTiles()
	{
		return GetPossibleBeams()
		       .Select(CountEnergizedTiles)
		       .Max();
	}

	private IEnumerable<Beam> GetPossibleBeams()
	{
		for (var i = 0; i < Width; i++)
		{
			yield return new Beam(i, 0, 0, 1);
			yield return new Beam(i, Height - 1, 0, -1);
		}

		for (var i = 0; i < Height; i++)
		{
			yield return new Beam(0, i, 1, 0);
			yield return new Beam(Width - 1, i, -1, 0);
		}
	}
}