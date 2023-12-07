using AdventOfCode.util;

namespace AdventOfCode;

public sealed class Day03 : BaseDay
{
    private readonly Grid<char> _inputGrid;

    public Day03()
    {
        var lines = File.ReadAllLines(InputFilePath).Select(line => line.ToCharArray()).ToArray();

        _inputGrid = new Grid<char>(lines);
    }

    public override ValueTask<string> Solve_1()
    {
        var partNumbers = new List<PartNumber>();
        while (_inputGrid.MoveNext())
        {
            if (!char.IsDigit(_inputGrid.Get())) continue;
            var partNumber = ParsePartNumber();
            partNumbers.Add(partNumber);
        }

        return new ValueTask<string>(partNumbers.Where(partNumber => partNumber.IsValid())
            .Select(partNumber => partNumber.ToInt()).Sum().ToString());
    }

    private PartNumber ParsePartNumber()
    {
        var digits = new List<char>();
        var neighbors = new List<char>();

        while (char.IsDigit(_inputGrid.Get()))
        {
            digits.Add(_inputGrid.Get());
            neighbors.AddRange(_inputGrid.GetNeighbors());
            if (!_inputGrid.MoveNext()) break;
        }

        return new PartNumber(digits, neighbors);
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>(Task.FromResult("Not implemented"));
    }
}

internal class PartNumber(IEnumerable<char> digits, IEnumerable<char> neighbors)
{
    private IEnumerable<char> Digits { get; } = digits;
    private IEnumerable<char> Neighbors { get; } = neighbors;

    public bool IsValid()
    {
        return Neighbors.Any(neighbor => neighbor != '.' && !char.IsDigit(neighbor));
    }

    public int ToInt()
    {
        return int.Parse(string.Join("", Digits));
    }
}