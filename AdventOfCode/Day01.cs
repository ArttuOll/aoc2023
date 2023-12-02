using System.Text.RegularExpressions;

namespace AdventOfCode;

public sealed class Day01 : BaseDay
{
    private readonly string[] _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath).Split("\n");
    }

    public override ValueTask<string> Solve_1() => new(
        _input
            .Select(CalculateCalibrationValue)
            .Sum()
            .ToString()
        );

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");

    private static int CalculateCalibrationValue(string line)
    {
        var firstDigit = FindFirstDigit(line) ?? 0;
        var lastDigit = FindFirstDigit(new string(line.Reverse().ToArray())) ?? 0;
        return int.Parse($"{firstDigit}{lastDigit}");
    }

    private static int? FindFirstDigit(string line)
    {
        const string pattern = @"\d";
        var match = Regex.Match(line, pattern);
        return match.Success ? int.Parse(match.Value) : null;
    }
}
