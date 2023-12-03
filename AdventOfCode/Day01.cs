using System.Text.RegularExpressions;

namespace AdventOfCode;

public sealed class Day01 : BaseDay
{
    private readonly string[] _input;

    public Day01()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>(
            _input
                .Select(line => CalculateCalibrationValue(line, @"(\d)"))
                .Sum()
                .ToString()
        );
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>(
            _input
                .Select(line => CalculateCalibrationValue(line,
                    @"(\d)|((one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine))"))
                .Sum()
                .ToString());
    }

    private static int CalculateCalibrationValue(string line, string pattern)
    {
        if (line.Length == 0) return 0;

        var firstDigit = SpelledDigitToInt(Regex.Match(line, pattern).Value);
        var lastDigit = SpelledDigitToInt(Regex.Match(line, pattern, RegexOptions.RightToLeft).Value);
        return int.Parse($"{firstDigit}{lastDigit}");
    }

    private static int SpelledDigitToInt(string digit)
    {
        return digit switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => int.Parse(digit)
        };
    }
}