using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Player> players = new List<Player>
        {
            new Player { Name = "Игрок 1", Level = 10, Power = 100 },
            new Player { Name = "Игрок 2", Level = 15, Power = 200 },
            new Player { Name = "Игрок 3", Level = 20, Power = 150 },
        };

        PrintTopPlayers(players, "Уровень", p => p.Level);
        PrintTopPlayers(players, "Сила", p => p.Power);
    }

    public static void PrintTopPlayers<T>(List<Player> players, string criteriaName, Func<Player, T> criteriaSelector)
    {
        var topPlayers = players.OrderByDescending(criteriaSelector).Take(3);

        Console.WriteLine($"Топ 3 игроков по {criteriaName}:");

        foreach (var player in topPlayers)
        {
            Console.WriteLine($"Имя: {player.Name}, {criteriaName}: {criteriaSelector(player)}");
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
        set { _name = value; }
    }

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Power
    {
        get { return _power; }
        set { _power = value; }
    }
}
