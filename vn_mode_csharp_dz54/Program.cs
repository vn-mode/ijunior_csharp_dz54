using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var soldiers = Soldier.CreateSampleSoldiers();

        var soldierService = new SoldierService();
        soldierService.DisplayTopSoldiers(soldiers);
    }
}

public class SoldierService
{
    private const string OutputFormat = "{0} - Level: {1} - Strength: {2}";

    public void DisplayTopSoldiers(List<Soldier> soldiers)
    {
        var topSoldiersByLevel = soldiers.OrderByDescending(s => s.Level).Take(3);
        var topSoldiersByStrength = soldiers.OrderByDescending(s => s.Strength).Take(3);

        Console.WriteLine("Top 3 soldiers by level:");

        foreach (var soldier in topSoldiersByLevel)
        {
            Console.WriteLine(string.Format(OutputFormat, soldier.Name, soldier.Level, soldier.Strength));
        }

        Console.WriteLine("\nTop 3 soldiers by strength:");

        foreach (var soldier in topSoldiersByStrength)
        {
            Console.WriteLine(string.Format(OutputFormat, soldier.Name, soldier.Level, soldier.Strength));
        }
    }
}

public class Soldier
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Strength { get; private set; }

    public Soldier(string name, int level, int strength)
    {
        Name = name;
        Level = level;
        Strength = strength;
    }

    public static List<Soldier> CreateSampleSoldiers()
    {
        return new List<Soldier>
        {
            new Soldier("Alex", 10, 100),
            new Soldier("Ivan", 20, 200),
            new Soldier("Petr", 30, 300),
            new Soldier("Nikolai", 40, 400),
            new Soldier("Thomas", 50, 500),
            new Soldier("Max", 25, 250),
            new Soldier("Andrew", 35, 350),
            new Soldier("Victor", 45, 450),
            new Soldier("Michael", 55, 550),
            new Soldier("John", 65, 650)
        };
    }
}
