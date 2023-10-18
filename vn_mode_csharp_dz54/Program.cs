using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Soldier> soldiers = Soldier.CreateSampleSoldiers();

        SoldierService soldierService = new SoldierService();
        soldierService.DisplayTopSoldiersByLevel(soldiers, 3);
        soldierService.DisplayTopSoldiersByStrength(soldiers, 3);
    }
}

public class Soldier
{
    private string _name;
    private int _level;
    private int _strength;

    public Soldier(string name, int level, int strength)
    {
        _name = name;
        _level = level;
        _strength = strength;
    }

    public string Name
    {
        get { return _name; }
    }

    public int Level
    {
        get { return _level; }
    }

    public int Strength
    {
        get { return _strength; }
    }

    public static List<Soldier> CreateSampleSoldiers()
    {
        return new List<Soldier>
        {
            new Soldier("Алексей", 10, 100),
            new Soldier("Иван", 20, 200),
            new Soldier("Пётр", 30, 300),
            new Soldier("Николай", 40, 400),
            new Soldier("Томас", 50, 500),
            new Soldier("Максим", 25, 250),
            new Soldier("Андрей", 35, 350),
            new Soldier("Виктор", 45, 450),
            new Soldier("Михаил", 55, 550),
            new Soldier("Джон", 65, 650)
        };
    }
}

public class SoldierService
{
    public void DisplayTopSoldiersByLevel(List<Soldier> soldiers, int topSoldiersCount)
    {
        Console.WriteLine("Топ " + topSoldiersCount + " солдат по уровню:");

        IEnumerable<Soldier> topSoldiers = soldiers.OrderByDescending(s => s.Level).Take(topSoldiersCount);

        const string outputFormat = "{0} - Уровень: {1} - Сила: {2}";

        foreach (Soldier soldier in topSoldiers)
        {
            Console.WriteLine(string.Format(outputFormat, soldier.Name, soldier.Level, soldier.Strength));
        }
    }

    public void DisplayTopSoldiersByStrength(List<Soldier> soldiers, int topSoldiersCount)
    {
        Console.WriteLine("Топ " + topSoldiersCount + " солдат по силе:");

        IEnumerable<Soldier> topSoldiers = soldiers.OrderByDescending(s => s.Strength).Take(topSoldiersCount);

        const string outputFormat = "{0} - Уровень: {1} - Сила: {2}";

        foreach (Soldier soldier in topSoldiers)
        {
            Console.WriteLine(string.Format(outputFormat, soldier.Name, soldier.Level, soldier.Strength));
        }
    }
}
