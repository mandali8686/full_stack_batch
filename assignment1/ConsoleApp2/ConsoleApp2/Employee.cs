namespace ConsoleApp2;

public abstract class Employee
{
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public abstract void PerformWork();

}

public class FullTimeEmployee : Employee
{
    public decimal BiweeklyPay { get; set; }
    public string Benefits { get; set; }

    public FullTimeEmployee(int id, string name, decimal biweeklyPay) : base(id, name)
    {
        BiweeklyPay = biweeklyPay;
    }

    public override void PerformWork()
    {
        Console.WriteLine("Full Time Employee work 40 hours each week.");
    }
}

public class PartTimeEmployee : Employee
{
    public decimal HourlyPay { get; set; }

    public PartTimeEmployee(int id, string name) : base(id, name)
    {
        
    }

    public override void PerformWork()
    {
        Console.WriteLine("Part Time Employee work 20 hours each week.");
    }
}

public class Manager : FullTimeEmployee
{
    public decimal Bonus { get; set; }

    public Manager(int id, string name, decimal biweeklyPay) : base(id, name, biweeklyPay)
    {
        
    }

    public void AttendMeeting()
    {
        Console.WriteLine("Attending meeting to manager");
    }
}