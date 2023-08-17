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

    public string Name => _name;
    public int Level => _level;
    public int Strength => _strength;

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
    public void DisplayTopSoldiers(List<Soldier> soldiers)
    {
        int topSoldiersCount = 3;
        const string outputFormat = "{0} - Уровень: {1} - Сила: {2}";

        IEnumerable<Soldier> topSoldiersByLevel = soldiers.OrderByDescending(soldiers => soldiers.Level).Take(topSoldiersCount);
        IEnumerable<Soldier> topSoldiersByStrength = soldiers.OrderByDescending(soldiers => soldiers.Strength).Take(topSoldiersCount);

        Console.WriteLine("Топ {0} солдат по уровню:", topSoldiersCount);

        foreach (Soldier soldier in topSoldiersByLevel)
        {
            Console.WriteLine(string.Format(outputFormat, soldier.Name, soldier.Level, soldier.Strength));
        }

        Console.WriteLine("\nТоп {0} солдат по силе:", topSoldiersCount);

        foreach (Soldier soldier in topSoldiersByStrength)
        {
            Console.WriteLine(string.Format(outputFormat, soldier.Name, soldier.Level, soldier.Strength));
        }
    }
}
