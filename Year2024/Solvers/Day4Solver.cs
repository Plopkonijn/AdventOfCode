namespace Year2024.Solvers;

public sealed class Day4Solver(string[] input) : DefaultAdventOfCodeSolver(input)
{
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
        (int endRow, int endColumn) = (start.Row + (word.Length - 1) * direction.Drow, start.Column + (word.Length - 1) * direction.Dcolumn);

        if (endRow < 0 || endRow >= _input.Length ||
            endColumn < 0 || endColumn >= _input[start.Row].Length)
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
        long total = 0;
        for (int row = 0; row < _input.Length; row++)
        {
            for (int column = 0; column < _input[row].Length; column++)
            {
                total += CountCrossWordOccurrences("MAS", row, column);
            }
        }

        return total;
    }

    private long CountCrossWordOccurrences(string word, int row, int column)
    {
        long total = 0;
        for (int dRow = -1; dRow <= 1; dRow++)
        {
            for (int dColumn = -1; dColumn <= 1; dColumn++)
            {
                if (dRow == 0 && dColumn == 0 || dRow != 0 && dColumn != 0)
                {
                    continue;
                }

                if (InputContainsCrossWord(word, (row, column), (dRow, dColumn)))
                {
                    total++;
                }
            }
        }

        return total;
    }

    private bool InputContainsCrossWord(string word, (int Row, int Column) start, (int dRow, int dColumn) direction)
    {
        int crossLength = (word.Length - 1) / 2;
        int left = start.Column - crossLength;
        if (left < 0 || left >= _input[start.Row].Length)
        {
            return false;
        }

        int right = start.Column + crossLength;
        if (right < 0 || right >= _input[start.Row].Length)
        {
            return false;
        }

        int top = start.Row - crossLength;
        if (top < 0 || top >= _input.Length)
        {
            return false;
        }

        int bottom = start.Row + crossLength;
        if (bottom < 0 || bottom >= _input.Length)
        {
            return false;
        }

        (int row, int column) = (start.Row - crossLength * direction.dRow, start.Column - crossLength * direction.dColumn);
        for (int i = 0; i < word.Length; i++)
        {
            int rowOffset = (i - crossLength) * direction.dColumn;
            int columnOffset = (i - crossLength) * direction.dRow;
            if (_input[row + rowOffset][column + columnOffset] != word[i] ||
                _input[row - rowOffset][column - columnOffset] != word[i])
            {
                return false;
            }

            row += direction.dRow;
            column += direction.dColumn;
        }

        return true;
    }
}