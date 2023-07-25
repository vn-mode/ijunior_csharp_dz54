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

        var topPlayersByLevel = GetTopPlayers(players, "Уровень", p => p.Level, 3);
        PrintTopPlayers(topPlayersByLevel, "Уровень");

        var topPlayersByPower = GetTopPlayers(players, "Сила", p => p.Power, 3);
        PrintTopPlayers(topPlayersByPower, "Сила");
    }

    public static List<Player> GetTopPlayers<T>(List<Player> players, string criteriaName, Func<Player, T> criteriaSelector, int topCount)
    {
        return players.OrderByDescending(criteriaSelector).Take(topCount).ToList();
    }

    public static void PrintTopPlayers(List<Player> topPlayers, string criteriaName)
    {
        Console.WriteLine($"Топ {topPlayers.Count} игроков по {criteriaName}:");

        foreach (var player in topPlayers)
        {
            Console.WriteLine($"Имя: {player.Name}, {criteriaName}: {player.GetCriteria(criteriaName)}");
        }
    }
}

public class Player
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Power { get; private set; }

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
