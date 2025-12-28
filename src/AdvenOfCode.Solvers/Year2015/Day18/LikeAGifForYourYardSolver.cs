namespace AdvenOfCode.Solvers.Year2015.Day18;

public sealed class LikeAGifForYourYardSolver(string[] Input)
{
    public long SolvePart1(int steps)
    {
        LightGrid gridCurrent = ParseInput();
        LightGrid gridNext = new(gridCurrent.Width, gridCurrent.Height);
        for (int step = 0; step < steps; step++)
        {
            for (int x = 0; x < gridCurrent.Width; x++)
            {
                for (int y = 0; y < gridCurrent.Height; y++)
                {
                    var turnedOnNeighbours = gridCurrent.TurnedOnNeighbours(x, y);
                    if (gridCurrent.IsOn(x, y))
                    {
                        if (turnedOnNeighbours is 2 or 3)
                        {
                            gridNext.TurnOn(x, y);
                        }
                        else
                        {
                            gridNext.TurnOff(x, y);
                        }
                    }
                    else
                    {
                        if (turnedOnNeighbours is 3)
                        {
                            gridNext.TurnOn(x, y);
                        }
                        else
                        {
                            gridNext.TurnOff(x, y);
                        }
                    }
                }
            }
            (gridCurrent, gridNext) = (gridNext, gridCurrent);
        }

        return gridCurrent.LitLightCount();
    }

    private LightGrid ParseInput()
    {
        LightGrid grid = new(Input[0].Length, Input.Length);
        for (int y = 0; y < Input.Length; y++)
        {
            string line = Input[y];
            for (int x = 0; x < line.Length; x++)
            {
                char light = line[x];
                switch (light)
                {
                    case '#':
                        grid.TurnOn(x, y);
                        break;
                    case '.':
                        grid.TurnOff(x, y);
                        break;
                }
            }
        }
        return grid;
    }

    public long SolvePart2()
    {
        throw new NotImplementedException();
    }
}
