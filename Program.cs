using System;
using System.Collections.Generic;

public abstract class Employee
{
    public int Experience { get; set; }
    public abstract double GetSalary();
    public virtual int GetDaysOff() { return 0; }
}

public class Manager : Employee
{
    public List<Employee> Subordinates { get; set; }

    public Manager(int experience)
    {
        Experience = experience;
        Subordinates = new List<Employee>();
    }

    public override double GetSalary()
    {
        return 60000 + 1000 * Experience;
    }

    public int CountSubordinates()
    {
        return Subordinates.Count;
    }
}

public class Executive : Manager
{
    public Executive(int experience) : base(experience) { }

    public override double GetSalary()
    {
        return 80000 + 1500 * Experience;
    }
}

public class Head : Manager
{
    public Head(int experience) : base(experience) { }

    public override double GetSalary()
    {
        return 100000 + 2000 * Experience;
    }
}

public class Manager2 : Manager
{
    public Manager2(int experience) : base(experience) { }

    public override double GetSalary()
    {
        return 55000 + 800 * Experience;
    }
}

public class Engineer : Employee
{
    public Engineer(int experience)
    {
        Experience = experience;
    }

    public override double GetSalary()
    {
        return 50000 + 750 * Experience;
    }

    public override int GetDaysOff()
    {
        return 20;
    }
}

public class Mechanic : Engineer
{
    public Mechanic(int experience) : base(experience) { }

    public override double GetSalary()
    {
        return 45000 + 600 * Experience;
    }
}

public class EngineerArchitect : Engineer
{
    public EngineerArchitect(int experience) : base(experience) { }

    public override double GetSalary()
    {
        return 55000 + 800 * Experience;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager(5);
        Executive executive = new Executive(10);
        Head head = new Head(15);
        Manager2 manager2 = new Manager2(7);
        Engineer engineer = new Engineer(4);
        Mechanic mechanic = new Mechanic(6);
        EngineerArchitect engineerArchitect = new EngineerArchitect(9);

        manager.Subordinates.Add(engineer);
        manager.Subordinates.Add(mechanic);
        manager.Subordinates.Add(engineerArchitect);

        Console.WriteLine($"Manager's salary: {manager.GetSalary()}");
        Console.WriteLine($"Executive's salary: {executive.GetSalary()}");
        Console.WriteLine($"Head's salary: {head.GetSalary()}");
        Console.WriteLine($"Manager2's salary: {manager2.GetSalary()}");
        Console.WriteLine($"Engineer's salary: {engineer.GetSalary()}, days off: {engineer.GetDaysOff()}");
        Console.WriteLine($"Mechanic's salary: {mechanic.GetSalary()}, days off: {mechanic.GetDaysOff()}");
        Console.WriteLine($"EngineerArchitect's salary: {engineerArchitect.GetSalary()}, days off: {{engineerArchitect.GetDaysOff()}}");
        Console.WriteLine($"Manager's number of subordinates: {manager.CountSubordinates()}");
    } 
}
