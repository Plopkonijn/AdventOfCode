namespace Year2024.Solvers;
public sealed class Day4Solver : AdventOfCodeSolver
{
    public Day4Solver(string[] input) : base(input) { }
    public override long SolvePart1()
    {
        long total = 0;
        for (int row = 0; row < _input.Length; row++)
        {
            for (int column = 0; column < _input[row].Length; column++)
            {
                total += CountWordOccurrences("XMAS", row, column);
            }
        }

        return total;
    }

    private long CountWordOccurrences(string word, int row, int column)
    {
        long total = 0;
        for (int dRow = -1; dRow <= 1; dRow++)
        {
            for (int dColumn = -1; dColumn <= 1; dColumn++)
            {
                if (dRow == 0 && dColumn == 0)
                {
                    continue;
                }

                if (InputContainsWord(word, (row, column), (dRow, dColumn)))
                {
                    total++;
                }
            }
        }

        return total;
    }

    private bool InputContainsWord(string word, (int Row, int Column) start, (int Drow, int Dcolumn) direction)
    {
        (int Row, int Column) = (start.Row + ((word.Length - 1) * direction.Drow), start.Column + ((word.Length - 1) * direction.Dcolumn));

        if (Row < 0 || Row >= _input.Length ||
            Column < 0 || Column >= _input[start.Row].Length)
        {
            // The word would go out of bounds
            return false;
        }

        (int row, int column) = start;
        for (int i = 0; i < word.Length; i++)
        {
            if (_input[row][column] != word[i])
            {
                // i-th character of the word does not match the character in the input
                return false;
            }

            row += direction.Drow;
            column += direction.Dcolumn;
        }

        return true;
    }

    public override long SolvePart2()
    {
        throw new NotImplementedException();
    }
}
