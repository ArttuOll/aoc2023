using AdventOfCode.util;

namespace TestProject1;

public class GridTest
{
    private const string ExampleInput = """
                                        467..114..
                                        ...*......
                                        ..35..633.
                                        ......#...
                                        617*......
                                        .....+.58.
                                        ..592.....
                                        ......755.
                                        ...$.*....
                                        .664.598..
                                        """;

    private readonly Grid<char> _inputGrid;

    public GridTest()
    {
        _inputGrid = new Grid<char>(ExampleInput.Split("\r\n").Select(line => line.ToCharArray()).ToArray());
    }

    [Fact]
    public void PropertiesInitializedCorrectly()
    {
        Assert.Equal(10, _inputGrid.ColumnLength);
        Assert.Equal(10, _inputGrid.RowLength);
        Assert.Equal(-1, _inputGrid.Current.Column);
        Assert.Equal(0, _inputGrid.Current.Row);
    }

    [Fact]
    public void MovesNextWithinRow()
    {
        Assert.True(_inputGrid.MoveNext());
        Assert.Equal(0, _inputGrid.Current.Column);
        Assert.Equal(0, _inputGrid.Current.Row);
    }

    [Fact]
    public void MovesNextWithinColumn()
    {
        _inputGrid.Current = new Coordinate(0, 9);

        Assert.True(_inputGrid.MoveNext());
        Assert.Equal(0, _inputGrid.Current.Column);
        Assert.Equal(1, _inputGrid.Current.Row);
    }

    [Fact]
    public void GetReturnsCorrectValue()
    {
        Assert.Equal('4', _inputGrid.Get(new Coordinate(0, 0)));
        Assert.Equal('6', _inputGrid.Get(new Coordinate(0, 1)));
        Assert.Equal('7', _inputGrid.Get(new Coordinate(0, 2)));
        Assert.Equal('1', _inputGrid.Get(new Coordinate(0, 5)));
        Assert.Equal('1', _inputGrid.Get(new Coordinate(0, 6)));
        Assert.Equal('4', _inputGrid.Get(new Coordinate(0, 7)));
        Assert.Equal('.', _inputGrid.Get(new Coordinate(0, 8)));
        Assert.Equal('.', _inputGrid.Get(new Coordinate(0, 9)));
    }

    [Fact]
    public void GetNeighbors()
    {
        var neighbors = _inputGrid.GetNeighbors(new Coordinate(0, 2));

        Assert.Equal(5, neighbors.Count);
        Assert.Equal(['6', '.', '.', '.', '*'], neighbors);
    }
}