
public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string LastName { get; set; } = "";
    public string Job { get; set; } = "";
}

internal class Program
{
    static void Main(string[] args)
    {
        Person sadra = new Person()
        {
            Age = 12,
            Job = "Developer",
            Name = "Sadra",
            LastName = "Yousefi",
        };
        
        Console.WriteLine("this is name :{0} , this is lastname: {1}" , sadra.Name , sadra.LastName);
    }
}