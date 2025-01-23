using System.Linq.Expressions;
using DeconstructCodeSamples.Classes;

// ReSharper disable once CheckNamespace - do not change!!!
namespace Switches.Models;

public partial class Person
{

    public static Expression<Func<Person, PersonEntity>> Projection =>
        (student) => new PersonEntity()
        {
            PersonID = student.PersonID,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Grades = student.StudentGrade
        };

    public static Expression<Func<Person, PersonEntity>> ListBoxSource =>
        (student) => new PersonEntity()
        {
            PersonID = student.PersonID,
            FirstName = student.FirstName,
            LastName = student.LastName
        };

    public void Deconstruct(out int id, out string firstName, out string lastName)
    {
        id = PersonID;
        firstName = FirstName;
        lastName = LastName;
    }

    public override string ToString() => $"{FirstName} {LastName}";

}