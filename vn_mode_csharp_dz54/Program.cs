using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Player> players = Player.CreateSamplePlayers();

        PlayerService playerService = new PlayerService();
        playerService.DisplayTopPlayersByLevel(players, 3);
        playerService.DisplayTopPlayersByStrength(players, 3);
    }
}

public class Player
{
    public string Name { get; }
    private int _level;
    private int _strength;

    public Player(string name, int level, int strength)
    {
        Name = name;
        _level = level;
        _strength = strength;
    }

    public int Level
    {
        get { return _level; }
    }

    public int Strength
    {
        get { return _strength; }
    }

    public static List<Player> CreateSamplePlayers()
    {
        return new List<Player>
        {
            new Player("Алексей", 10, 100),
            new Player("Иван", 20, 200),
            new Player("Пётр", 30, 300),
            new Player("Николай", 40, 400),
            new Player("Томас", 50, 500),
            new Player("Максим", 25, 250),
            new Player("Андрей", 35, 350),
            new Player("Виктор", 45, 450),
            new Player("Михаил", 55, 550),
            new Player("Джон", 65, 650)
        };
    }
}

public class PlayerService
{
    private const string OutputFormat = "{0} - Уровень: {1} - Сила: {2}";

    public void DisplayTopPlayersByLevel(List<Player> players, int topPlayersCount)
    {
        Console.WriteLine("Топ " + topPlayersCount + " игроков по уровню:");

        IEnumerable<Player> topPlayers = players.OrderByDescending(p => p.Level).Take(topPlayersCount);

        DisplayPlayers(topPlayers);
    }

    public void DisplayTopPlayersByStrength(List<Player> players, int topPlayersCount)
    {
        Console.WriteLine("Топ " + topPlayersCount + " игроков по силе:");

        IEnumerable<Player> topPlayers = players.OrderByDescending(p => p.Strength).Take(topPlayersCount);

        DisplayPlayers(topPlayers);
    }

    private void DisplayPlayers(IEnumerable<Player> players)
    {
        foreach (Player player in players)
        {
            Console.WriteLine(string.Format(OutputFormat, player.Name, player.Level, player.Strength));
        }
    }
}
