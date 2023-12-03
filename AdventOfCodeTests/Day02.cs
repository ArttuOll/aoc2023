using AdventOfCode;

namespace TestProject1;

public class Day02Test
{
    [Fact]
    public void IdentifiesPossibleGames()
    {
        const string input = """
                             Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                             Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                             Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                             """;

        var game = new Day02().ParseGame(input);

        Assert.True(game.IsPossible());
    }

    [Fact]
    public void IdentifiesImpossibleGames()
    {
        const string input = """
                             Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                             Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                             """;

        var game = new Day02().ParseGame(input);

        Assert.False(game.IsPossible());
    }

    [Fact]
    public void CorrectlyParsesGames()
    {
        const string line = "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
        var game = new Day02().ParseGame(line);

        Assert.Equal(3, game.Id);
        Assert.Equal(3, game.Subsets.Count());
    }

    [Fact]
    public void CorrectlyParsesSubsets()
    {
        const string line = "8 green, 6 blue, 20 red";
        var subset = new Day02().ParseSubset(line);

        Assert.Equal(8, subset.NumberOfGreen);
        Assert.Equal(6, subset.NumberOfBlue);
        Assert.Equal(20, subset.NumberOfRed);
    }
}