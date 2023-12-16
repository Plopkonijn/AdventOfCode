using TheFloorWillBeLava;

internal class Contraption
{
	private readonly string[] _tiles;

	public Contraption(string[] tiles)
	{
		if (tiles.Select(row => row.Length).Distinct().Count() > 1)
			throw new ArgumentException();
		_tiles = tiles;
	}

	public int Width => _tiles.FirstOrDefault(string.Empty).Length;
	public int Height => _tiles.Length;

	public int CountEnergizedTiles(Beam startBeam)
	{
		var energizedTiles = new HashSet<(int x, int y, int dx, int dy)>
			{ (startBeam.PositionX, startBeam.PositionY, startBeam.DirectionX, startBeam.DirectionY) };
		var beams = new HashSet<Beam> { startBeam };
		while (beams.Count > 0)
		{
			Beam[] newBeams = UpdateBeams(beams).ToArray();
			beams.UnionWith(newBeams);
			int removedOutsideBounds = beams.RemoveWhere(IsOutsideBounds);
			int removedDuplicate = beams.RemoveWhere(IsAlreadyEnergized(energizedTiles));
			energizedTiles.UnionWith(beams.Select(beam => (beam.PositionX, beam.PositionY, beam.DirectionX, beam.DirectionY)));
		}

		return energizedTiles.Select(tuple => (tuple.x, tuple.y)).Distinct().Count();
	}

	private static Predicate<Beam> IsAlreadyEnergized(HashSet<(int x, int y, int dx, int dy)> energizedTiles)
	{
		return beam => energizedTiles.Contains((beam.PositionX, beam.PositionY, beam.DirectionX, beam.DirectionY));
	}

	private IEnumerable<Beam> UpdateBeams(IEnumerable<Beam> beams)
	{
		foreach (Beam beam in beams)
		{
			Beam? splitBeam = UpdateBeam(beam);
			if (splitBeam is not null)
				yield return splitBeam;
		}
	}

	private Beam? UpdateBeam(Beam beam)
	{
		Beam splitBeam = null;
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
				splitBeam = beam with { };
				beam.ChangeDirection(0, -1);
				splitBeam.ChangeDirection(0, 1);
				splitBeam.Move();
				break;
			case '-' when beam.DirectionX is 0:
				splitBeam = beam with { };
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
}