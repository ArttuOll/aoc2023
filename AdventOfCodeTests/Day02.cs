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

        var game = Day02.ParseGame(input);

        Assert.True(game.IsPossible());
    }

    [Fact]
    public void IdentifiesImpossibleGames()
    {
        const string input = """
                             Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                             Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                             """;

        var game = Day02.ParseGame(input);

        Assert.False(game.IsPossible());
    }

    [Fact]
    public void CorrectlyParsesGames()
    {
        const string line = "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
        var game = Day02.ParseGame(line);

        Assert.Equal(3, game.Id);
        Assert.Equal(3, game.Subsets.Count());
    }

    [Fact]
    public void CorrectlyParsesSubsets()
    {
        const string line = "8 green, 6 blue, 20 red";
        var subset = Day02.ParseSubset(line);

        Assert.Equal(8, subset.NumberOfGreen);
        Assert.Equal(6, subset.NumberOfBlue);
        Assert.Equal(20, subset.NumberOfRed);
    }

    [Fact]
    public void GetsMinimumSubset()
    {
        var subset1 = new Subset(1, 4, 5);
        var subset2 = new Subset(3, 1, 4);
        var subset3 = new Subset(4, 3, 1);
        var game = new Game(1, new List<Subset> { subset1, subset2, subset3 });

        var result = game.GetMinimumSetOfCubes();

        Assert.Equal(4, result.NumberOfBlue);
        Assert.Equal(4, result.NumberOfRed);
        Assert.Equal(5, result.NumberOfGreen);
    }

    [Fact]
    public void CalculatesPower()
    {
        var subset = new Subset(6, 4, 2);

        var result = subset.Power();

        Assert.Equal(48, result);
    }
}