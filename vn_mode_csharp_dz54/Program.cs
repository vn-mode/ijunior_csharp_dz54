using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Player> players = new List<Player>
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

        PlayerService playerService = new PlayerService(players);
        int topPlayersCount = 3;

        playerService.DisplayTopPlayersByLevel(topPlayersCount);
        playerService.DisplayTopPlayersByStrength(topPlayersCount);
    }
}

public class Player
{
    public Player(string name, int level, int strength)
    {
        Name = name;
        Level = level;
        Strength = strength;
    }

    public string Name { get; }
    public int Level { get; }
    public int Strength { get; }
}

public class PlayerService
{
    private string _outputFormat = "{0} - Уровень: {1} - Сила: {2}";
    private List<Player> _players;

    public PlayerService(List<Player> players)
    {
        this._players = players;
    }

    public void DisplayTopPlayersByLevel(int topPlayersCount)
    {
        Console.WriteLine("Топ " + topPlayersCount + " игроков по уровню:");

        IEnumerable<Player> topPlayers = _players.OrderByDescending(player => player.Level).Take(topPlayersCount);

        DisplayPlayers(topPlayers);
    }

    public void DisplayTopPlayersByStrength(int topPlayersCount)
    {
        Console.WriteLine("Топ " + topPlayersCount + " игроков по силе:");

        IEnumerable<Player> topPlayers = _players.OrderByDescending(player => player.Strength).Take(topPlayersCount);

        DisplayPlayers(topPlayers);
    }

    private void DisplayPlayers(IEnumerable<Player> players)
    {
        foreach (Player player in players)
        {
            Console.WriteLine(string.Format(_outputFormat, player.Name, player.Level, player.Strength));
        }
    }
}