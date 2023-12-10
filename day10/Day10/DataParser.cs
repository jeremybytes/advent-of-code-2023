namespace Day10;

public static class DataParser
{
    // | - L J 7 F . S

    public static long GetPathLength(this List<List<char>> grid)
    {
        long count = 0;

        var start = grid.GetStartingPoint();

        var current = start.GetFirstCell(grid);
        count++;

        (int, int) next = current;
        (int, int) previous = start;

        while(next != start)
        {
            next = current.GetNextCell(previous, grid);
            previous = current;
            current = next;
            count++;
        }

        return count;
    }

    public static (int, int) GetNextCell(this (int, int) current, (int, int) previous, List<List<char>> grid)
    {
        // | - L J 7 F . S
        var (currRow, currCol) = current;

        if (grid[currRow][currCol] == '|')
        {
            var next1 = (currRow - 1, currCol);
            var next2 = (currRow + 1, currCol);
            if (next1 != previous)
                return next1;
            return next2;
        }

        if (grid[currRow][currCol] == '-')
        {
            var next1 = (currRow, currCol-1);
            var next2 = (currRow, currCol+1);
            if (next1 != previous)
                return next1;
            return next2;
        }

        if (grid[currRow][currCol] == 'L')
        {
            var next1 = (currRow-1, currCol);
            var next2 = (currRow, currCol+1);
            if (next1 != previous)
                return next1;
            return next2;
        }

        if (grid[currRow][currCol] == 'J')
        {
            var next1 = (currRow - 1, currCol);
            var next2 = (currRow, currCol - 1);
            if (next1 != previous)
                return next1;
            return next2;
        }

        if (grid[currRow][currCol] == '7')
        {
            var next1 = (currRow + 1, currCol);
            var next2 = (currRow, currCol - 1);
            if (next1 != previous)
                return next1;
            return next2;
        }

        if (grid[currRow][currCol] == 'F')
        {
            var next1 = (currRow + 1, currCol);
            var next2 = (currRow, currCol + 1);
            if (next1 != previous)
                return next1;
            return next2;
        }

        return (-1, -1); 
    }

    public static (int, int) GetFirstCell(this (int, int) start, List<List<char>> grid)
    {
        // | - L J 7 F . S
        var (row, col) = start;

        // Above
        if (row > 0 && "7F|".Contains(grid[row - 1][col]))
        {
            return (row - 1, col);
        }
        // Left
        if (col > 0 && "-LF".Contains(grid[row][col-1]))
        {
            return (row, col - 1);
        }
        // Right
        if (col < grid[0].Count && "-J7".Contains(grid[row][col+1]))
        {
            return (row, col + 1);
        }
        // Below
        if (row < grid.Count && "|LJ".Contains(grid[row + 1][col]))
        {
            return (row - 1, col);
        }
        return (-1, -1); // force and index out of range on next step
    }

    public static (int, int) GetStartingPoint(this List<List<char>> grid)
    {
        int row = 0;
        int col = 0;
        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[0].Count; j++)
            {
                if (grid[i][j] == 'S')
                {
                    row = i;
                    col = j;
                    break;
                }
            }
        }
        return (row, col);
    }
}
