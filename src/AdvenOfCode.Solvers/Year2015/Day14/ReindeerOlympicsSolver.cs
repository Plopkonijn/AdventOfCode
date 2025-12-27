using System.Globalization;
using System.Text.RegularExpressions;

namespace AdvenOfCode.Solvers.Year2015.Day14;

public sealed class ReindeerOlympicsSolver(string[] Input)
{
    public long SolvePart1(long totalTime)
    {
        long result = 0;
        List<Reindeer> reindeers = ParseReindeers();
        foreach (Reindeer reindeer in reindeers)
        {
            long distance = totalTime / reindeer.TotalTime * reindeer.FlyDistance * reindeer.FlyTime;
            long remainingTime = totalTime % reindeer.TotalTime;
            if (remainingTime <= reindeer.FlyTime)
            {
                distance += remainingTime * reindeer.FlyDistance;
            }
            else
            {
                distance += reindeer.FlyTime * reindeer.FlyDistance;
            }
            if (distance > result)
            {
                result = distance;
            }
        }
        return result;
    }

    private List<Reindeer> ParseReindeers()
    {
        List<Reindeer> reindeers = [];
        foreach (string line in Input)
        {
            Match match = Regex.Match(line, @"^(\w+) can fly (\d+) km/s for (\d+) seconds, but then must rest for (\d+) seconds.$");
            if (!match.Success)
            {
                throw new InvalidOperationException();
            }
            string name = match.Groups[1].Value;
            long flyDistance = long.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
            long flyTime = long.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            long restTime = long.Parse(match.Groups[4].Value, CultureInfo.InvariantCulture);
            Reindeer reindeer = new(name, flyDistance, flyTime, restTime);
            reindeers.Add(reindeer);
        }
        return reindeers;
    }

    public long SolvePart2(long totalTime)
    {
        Dictionary<Reindeer, State> reindeerStates = ParseReindeers().ToDictionary(r => r, r =>
        new State { Position = 0, Score = 0, IsFlying = true, RemainingTime = r.FlyTime });
        for (int i = 0; i < totalTime; i++)
        {
            IncrementTime(reindeerStates);
            IncrementScore(reindeerStates);
        }
        return reindeerStates.Values.Max(s => s.Score);
    }

    private static void IncrementScore(Dictionary<Reindeer, State> reindeerStates)
    {
        long maxPosition = reindeerStates.Values.Max(s => s.Position);
        IEnumerable<State> maxStates = reindeerStates.Values.Where(s => s.Position == maxPosition);
        foreach (State? state in maxStates)
        {
            state.Score++;
        }
    }

    private static void IncrementTime(Dictionary<Reindeer, State> reindeerStates)
    {
        foreach ((Reindeer reindeer, State? state) in reindeerStates)
        {
            if (state.IsFlying)
            {
                state.Position += reindeer.FlyDistance;
            }
            state.RemainingTime--;
            if (state.RemainingTime == 0)
            {
                state.IsFlying = !state.IsFlying;
                state.RemainingTime = state.IsFlying ? reindeer.FlyTime : reindeer.RestTime;
            }
        }
    }
}

internal sealed class State
{
    public long Position { get; set; }
    public long Score { get; set; }
    public bool IsFlying { get; set; }
    public long RemainingTime { get; set; }
}

internal sealed record Reindeer(string Name, long FlyDistance, long FlyTime, long RestTime)
{
    public long TotalTime => FlyTime + RestTime;
}