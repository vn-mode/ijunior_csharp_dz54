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

        var topPlayersByLevel = players.OrderByDescending(p => p.Level).Take(3);
        Console.WriteLine("Топ 3 игроков по уровню:");

        foreach (var player in topPlayersByLevel)
        {
            Console.WriteLine($"Имя: {player.Name}, Уровень: {player.Level}");
        }

        var topPlayersByPower = players.OrderByDescending(p => p.Power).Take(3);
        Console.WriteLine("\nТоп 3 игроков по силе:");

        foreach (var player in topPlayersByPower)
        {
            Console.WriteLine($"Имя: {player.Name}, Сила: {player.Power}");
        }
    }
}

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Power { get; set; }
}