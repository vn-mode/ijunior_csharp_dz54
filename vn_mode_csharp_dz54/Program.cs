using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Player> players = new List<Player>
        {
            new Player("Игрок 1", 10, 100),
            new Player("Игрок 2", 15, 200),
            new Player("Игрок 3", 20, 150),
        };

        var topPlayersByLevel = GetTopPlayers(players, "Уровень", p => p.Level);
        PrintTopPlayers(topPlayersByLevel, "Уровень");

        var topPlayersByPower = GetTopPlayers(players, "Сила", p => p.Power);
        PrintTopPlayers(topPlayersByPower, "Сила");
    }

    public static List<Player> GetTopPlayers<T>(List<Player> players, string criteriaName, Func<Player, T> criteriaSelector)
    {
        return players.OrderByDescending(criteriaSelector).Take(3).ToList();
    }

    public static void PrintTopPlayers(List<Player> topPlayers, string criteriaName)
    {
        Console.WriteLine($"Топ 3 игроков по {criteriaName}:");

        foreach (var player in topPlayers)
        {
            Console.WriteLine($"Имя: {player.Name}, {criteriaName}: {player.GetCriteria(criteriaName)}");
        }
    }
}

public class Player
{
    private string _name;
    private int _level;
    private int _power;

    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

    public int Level
    {
        get { return _level; }
        private set { _level = value; }
    }

    public int Power
    {
        get { return _power; }
        private set { _power = value; }
    }

    public Player(string name, int level, int power)
    {
        Name = name;
        Level = level;
        Power = power;
    }

    public object GetCriteria(string criteriaName)
    {
        switch (criteriaName)
        {
            case "Уровень":
                return Level;

            case "Сила":
                return Power;

            default:
                throw new ArgumentException("Неверное имя критерия");
        }
    }
}
