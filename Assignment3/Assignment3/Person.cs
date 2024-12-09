using System.Globalization;

namespace Assignment3;
using System;
using System.Collections.Generic;

public abstract class Person
{
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public List<string> Addresses { get; set; } = new List<string>();

    protected Person(string name, DateTime birthday, List<string> addresses)
    {
        Name = name;
        Birthday = birthday;
        Addresses = addresses;
    }

    public int GetAge()
    {
        return DateTime.Now.Year - Birthday.Year;
    }

    public void AddAddress(string address)
    {
        Addresses.Add(address);
    }

    public List<string> GetAddresses()
    {
        return Addresses;
    }

    public virtual decimal GetSalary()
    {
        return 0m;
    }
}

public class Instructor : Person
{
    public string Department{ get; set; }
    public DateTime JoinDate { get; set; }
    public Instructor(string name, DateTime birthday, List<string> addresses, string department, DateTime joinDate) : base(name, birthday, addresses)
    {
        Department = department;
        JoinDate = joinDate;
    }

    public int GetExperience()
    {
        return DateTime.Now.Year - JoinDate.Year;
    }
    public override decimal GetSalary()
    {
        return (5000m + 1000 * GetSalary());
    }
}

public class Student : Person
{
    public List<string>Courses { get; set; } = new List<string>();

    public Student(string name, DateTime birthday, List<string> courses, List<string> department, DateTime joinDate):base(name, birthday, department)
    {
    }

    public void AddCourses(string course)
    {
        Courses.Add(course);
    }

    public double CalculateGPA(Dictionary<string, char> grades)
    {
        double GPA = 0;
        foreach (char grade in grades.Values)
        {
            switch (grade)
            {
                case 'A': GPA += 4.0; break;
                case 'B': GPA += 3.0; break;
                case 'C': GPA += 2.0; break;
                case 'D': GPA += 1.0; break;
            }
            
        }
        return GPA/grades.Count;
    }
    
}

interface IPersonService
{
    int CalculateAge();
    List<string> GetAddresses();
}

interface IStudentService : IPersonService
{
    double CalculateGPA(Dictionary<string, char> grades);
}

interface IInstructorService : IPersonService
{
    int GetExperience();
}

class Department
{
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public Instructor Head { get; set; }
    public List<string> CoursesOffered { get; set; } = new List<string>();
}