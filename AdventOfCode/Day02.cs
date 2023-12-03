using System.Text.RegularExpressions;

namespace AdventOfCode;

public sealed class Day02 : BaseDay
{
    private readonly List<Game> _input;

    public Day02()
    {
        var lines = File.ReadAllLines(InputFilePath);

        _input = lines.Select(ParseGame).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>(
            _input
                .Where(game => game.IsPossible())
                .Select(game => game.Id)
                .Sum().ToString()
        );
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>("Not implemented.");
    }

    public Game ParseGame(string line)
    {
        var separatedBySemicolon = line.Split(":");
        var gameId = separatedBySemicolon[0].Split(" ")[1];

        var subsetStrings = separatedBySemicolon[1].Split(";");
        var subsets = subsetStrings.Select(ParseSubset).ToList();
        return new Game(int.Parse(gameId), subsets);
    }

    public Subset ParseSubset(string line)
    {
        var numberOfBlue = ParseColor(line, "blue");
        var numberOfRed = ParseColor(line, "red");
        var numberOfGreen = ParseColor(line, "green");

        return new Subset(numberOfBlue, numberOfRed, numberOfGreen);
    }

    private static int ParseColor(string line, string color)
    {
        var match = Regex.Match(line, $@"(\d+) {color}").Value;
        var number = match.Split(" ")[0];

        return number.Length == 0 ? 0 : int.Parse(number);
    }
}

public class Game()
{
    private const int BlueLimit = 14;
    private const int GreenLimit = 13;
    private const int RedLimit = 12;

    public Game(int id, IEnumerable<Subset> subsets) : this()
    {
        Id = id;
        Subsets = subsets;
    }

    public int Id { get; }
    public IEnumerable<Subset> Subsets { get; }

    public bool IsPossible()
    {
        return Subsets.All(subset => subset.NumberOfBlue <= BlueLimit
                                     && subset.NumberOfRed <= RedLimit
                                     && subset.NumberOfGreen <= GreenLimit);
    }
}

public record Subset(int NumberOfBlue, int NumberOfRed, int NumberOfGreen);