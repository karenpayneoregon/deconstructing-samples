namespace ConsoleApp_csharp10.Models;

public class Person
{
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public override string ToString() => $"{Id} {FullName}";

    public void Deconstruct(out string firstName, out string lastName) =>
        (firstName, lastName) = (FirstName, LastName);

}