using System.Collections;

namespace AdventOfCode.util;

public class Grid<T>(T[][] rows) : IEnumerator<Coordinate>
{
    private T[][] Rows { get; } = rows;
    public int RowLength { get; } = rows.First().Length;
    public int ColumnLength { get; } = rows.Length;

    public Coordinate Current { get; set; } = new(0, -1);

    public bool MoveNext()
    {
        var nextColumnIndex = Current.Column + 1;
        if (nextColumnIndex < RowLength)
        {
            Current = new Coordinate(Current.Row, nextColumnIndex);
            return true;
        }

        var nextRowIndex = Current.Row + 1;

        // ReSharper disable once InvertIf
        if (nextRowIndex < ColumnLength)
        {
            Current = new Coordinate(nextRowIndex, 0);
            return true;
        }

        return false;
    }

    public void Reset()
    {
        Current = new Coordinate(0, -1);
    }

    object IEnumerator.Current => Current;

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public T Get(Coordinate position)
    {
        if (IsWithinBounds(position)) return Rows[position.Row][position.Column];

        throw new ArgumentException("Coordinate is out of bounds");
    }

    public T Get()
    {
        return Get(Current);
    }

    public List<T> GetNeighbors(Coordinate position)
    {
        var neighbors = new List<T>();

        if (!IsWithinBounds(position)) throw new ArgumentException("Coordinate is out of bounds");

        if (IsWithinBounds(position.MoveLeft())) neighbors.Add(GetLeftNeighbor(position));

        if (IsWithinBounds(position.MoveRight())) neighbors.Add(GetRightNeighbor(position));

        if (IsWithinBounds(position.MoveUp())) neighbors.Add(GetTopNeighbor(position));

        if (IsWithinBounds(position.MoveDown())) neighbors.Add(GetBottomNeighbor(position));

        if (IsWithinBounds(position.MoveUp().MoveLeft())) neighbors.Add(GetTopLeftNeighbor(position));

        if (IsWithinBounds(position.MoveUp().MoveRight())) neighbors.Add(GetTopRightNeighbor(position));

        if (IsWithinBounds(position.MoveDown().MoveLeft())) neighbors.Add(GetBottomLeftNeighbor(position));

        if (IsWithinBounds(position.MoveDown().MoveRight())) neighbors.Add(GetBottomRightNeighbor(position));

        return neighbors;
    }

    public List<T> GetNeighbors()
    {
        return GetNeighbors(Current);
    }

    private T GetLeftNeighbor(Coordinate position)
    {
        return Get(position.MoveLeft());
    }

    private T GetRightNeighbor(Coordinate position)
    {
        return Get(position.MoveRight());
    }

    private bool IsWithinBounds(Coordinate position)
    {
        return position.Row >= 0 && position.Row < ColumnLength && position.Column >= 0 && position.Column < RowLength;
    }

    private T GetTopNeighbor(Coordinate position)
    {
        return Get(position.MoveUp());
    }

    private T GetBottomNeighbor(Coordinate position)
    {
        return Get(position.MoveDown());
    }

    private T GetTopLeftNeighbor(Coordinate position)
    {
        return Get(position.MoveUp().MoveLeft());
    }

    private T GetTopRightNeighbor(Coordinate position)
    {
        return Get(position.MoveUp().MoveRight());
    }

    private T GetBottomLeftNeighbor(Coordinate position)
    {
        return Get(position.MoveDown().MoveLeft());
    }

    private T GetBottomRightNeighbor(Coordinate position)
    {
        return Get(position.MoveDown().MoveRight());
    }
}

public class Coordinate(int row, int column)
{
    public int Row { get; } = row;
    public int Column { get; } = column;

    public Coordinate MoveRight()
    {
        return new Coordinate(Row, Column + 1);
    }

    public Coordinate MoveLeft()
    {
        return new Coordinate(Row, Column - 1);
    }

    public Coordinate MoveUp()
    {
        return new Coordinate(Row - 1, Column);
    }

    public Coordinate MoveDown()
    {
        return new Coordinate(Row + 1, Column);
    }
}