﻿![img](assets/csharpDeconstructing.png)

# Overview

In this article with code samples provides additional ways to return data from methods, iterating foreach statements, how to work with date time objects to have cleaner code. An important consideration is every developer has their own style of coding and with that keep an open mind, if something learned looks inviting but not your style than modify the code to suite you’re or a team’s style.

> **Note**
> Code was originally written using .NET 5 and has been updated to .NET 7. The only trick for this was to update EF Core 5 to EF Core 7 else some code would not function which was expected.

## The art of Deconstructing

What is deconstruct in C#?

Deconstruction is a process of splitting a variable value into parts and storing them into new variables. 

This could be useful when a variable stores multiple values such as a [Tuple](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples) and different ways to work with `foreach` statements or create language extensions for returning smaller sets of information from third party methods.

Most developers know about how to return informaton with Tuples but many don't know about other benefits which will be gone over in this article.

**Microsoft documentation** Deconstructing tuples and other types [![](assets/Link_16x.png)](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct)

## Warm and fuzzy

Pretty much at one time or another a developer needs to break apart a DateTime or DateTimeOffset as shown below.

```csharp
var date = new DateTimeOffset(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0, TimeSpan.Zero);
int year = date.Year;
```

We can deconstruct a DateTime or a DateTimeOffset using an extension method.

```csharp
public static class Extensions
{
    public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year) 
        => (day, month, year) = (date.Day, date.Month, date.Year);
}
```

Example usage

```csharp
var date = new DateTimeOffset(Now.Year, Now.Month, Now.Day, 0, 0, 0, 0, TimeSpan.Zero);

date.Deconstruct(out int day, out int month, out int year);

Console.WriteLine($"Year: {year} Month: {month} Day: {day}");
```

How about a `DateOnly`? Yes we can do this also along with `TimeOnly`

```csharp
public static void Deconstruct(this DateOnly date, out int day, out int month, out int year) =>
    (day, month, year) = (date.Day, date.Month, date.Year);
```

This means a developer who works with dates can have cleaner code. But wait, why not a language extension method like below? Because this article focues on deconstructing :wink:

```csharp
public static class Extensions
{
    public static (int day, int month, int year) Chunk(this DateTimeOffset sender) 
        => (sender.Day, sender.Month, sender.Year);
}
```

## Basics

The following shows different ways to return data from a method.

In conventional coding returning information typically looks like the following which is devoid of any exception handling.

```csharp
public class DataOperations
{
    public static async Task<List<Customers>> GetCustomersList()
    {
        await using NorthContext context = new();
        return await context
            .Customers
            .Include(c => c.ContactTypeIdentifierNavigation)
            .ToListAsync();
    }
}
```

But we all know that at anytime an exception may be thrown, in the above case perhaps the server where the database resides is not available.

So what can be done? Write to a log file and return `null` when an exception is thrown.

```csharp
public class DataOperations
{
    public static async Task<List<Customers>> GetCustomersList()
    {
        try
        {
            await using NorthContext context = new();
            return await context
                .Customers
                .Include(c => c.ContactTypeIdentifierNavigation)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            // write to error log
            return null;
        }
    }
}
```

The above although works is not a nice solution, let's try using deconstruction.

```csharp
public class DataOperations
{
    public static async Task<(List<Customers> customers, Exception exception)> GetCustomersList()
    {
        try
        {
            await using NorthContext context = new();
            return 
                (
                    await context.
                        Customers
                        .Include(c => c.ContactTypeIdentifierNavigation)
                        .ToListAsync(), 
                    null
                );
        }
        catch (Exception ex)
        {
            // write to error log
            return (null, ex);
        }
    }
}
```

Usage

```csharp
var (customers, exception) = await DataOperations.GetCustomersList();
if (exception is null)
{
    // use customers
}
else
{
    // we have an exception object to see what happened
}
```

In this case we have returned either a list of customers and null or null and an exception.

Can we do better? Yes and no, it depends on your programming style. Here an the first value is a bool which represents success or failure.

```csharp
public class DataOperations
{
    public static async Task<(bool success, List<Customers> customers, Exception exception)> GetCustomersList()
    {
        try
        {
            await using NorthContext context = new();
            return 
                (
                    true,
                    await context.
                        Customers
                        .Include(c => c.ContactTypeIdentifierNavigation)
                        .ToListAsync(), 
                    null
                );
        }
        catch (Exception ex)
        {
            // write to error log
            return (false,null, ex);
        }
    }
}
```

Personally, it's clearer adding the bool.

```csharp
var (success, customers, exception) = await DataOperations.GetCustomersList();
if (success)
{
    // use customers
}
else
{
    // check out exception
}
```

Each of the above examples perform the same operations with varying ways to return data. The first should be avoided unless it’s never going to fail. To be honest, the second is what an uneducated coder might come up with and is not recommended. The final two are personal choices along with showing we can return information and name them like local variables.

Suppose we want to simply check success and not access the exception in regards to the last example? We can use a [discard](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards).

![x](assets/discard.png)


## Deconstructing non-tuples for classes/models 

This feature is great, but it is actually not limited to just tuples - you can add deconstructors to all your classes. Using the following syntax we can return and deconstruct only the information needed for an operation. The benefit is not needing to return all properties of a model and that there may be several different operations needing different sets of data.

```csharp
public class PersonEntity
{
    public int PersonID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public ICollection<StudentGrade> Grades { get; set; }
    public override string ToString() => $"{FirstName} {LastName}";

    public void Deconstruct(out int id, out string firstName, out string lastName)
    {
        id = PersonID;
        firstName = FirstName;
        lastName = LastName;
    }
    public void Deconstruct(out int id, out string fullName)
    {
        id = PersonID;
        fullName = FullName;
    }
    public void Deconstruct(out int id, out string firstName, string lastName, ICollection<StudentGrade> grades)
    {
        id = PersonID;
        firstName = FirstName;
        lastName = LastName;
        grades =Grades;
    }
}
```

Usage using a discard which means we don't want first name, only the primary key and last name.

```csharp
var (id, _, last) = (PersonEntity)SomeControl.SelectedItem;
```

Caveat, the above can only be done with classes you have access too. Suppose there is a class you don't have source code too? The solution is to create a language extension.

Here is a model in a third party library

```csharp

namespace SomeThirdPartyLibrary.Classes
{
    public class Customer
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public int? ContactId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        public override string ToString() => CompanyName;
    }
}
```

In your project we create an extension method for `Customer`.

```csharp
using SomeThirdPartyLibrary.Classes;

namespace DeconstructCodeSamples.Extensions
{
    public static class ThirdPartyExtensions
    {
        /// <summary>
        ///  Extension for third party class
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="id">customer key</param>
        /// <param name="companyName">customer's company name</param>
        /// <param name="contactIdentifier">customer's contact identifier</param>
        /// <param name="countryIdentifier">country identifier for customer</param>
        public static void Deconstruct(this Customer customer, out int id, out string companyName, out int? contactIdentifier, out int? countryIdentifier)
        {
            id = customer.CustomerIdentifier;
            companyName = customer.CompanyName;
            contactIdentifier = customer.ContactId;
            countryIdentifier = customer.CountryIdentifier;
        }
    }
}
```

## Deconstucting other code

Let's look at a simple dictionary

```csharp
var peopleDictionary = new Dictionary<string, int>
{
    ["Mary"] = 32, 
    ["Frank"] = 17
};
```

Convental method to iterate the key and values.

```csharp
foreach (var pair in peopleDictionary)
{
    Console.WriteLine($"{pair.Key} is {pair.Value} years old");
}
```

Minor issue when looking at the code is say the dictionary definition is not visible, it can be difficult to tell what key and value are, and in a little bit I will drive this home with a more complex example using a switch and grouping.

Next level, deconstruct and provide meaningful variable names.

```csharp
foreach (var (name, age) in peopleDictionary)
{
    Console.WriteLine($"{name} is {age} years old");
}
```

The above is easy to understand. Now for those who like the cool factor here you go.

```csharp
foreach (var (name, age) in peopleDictionary.Select(x => (x.Key, x.Value)))
{
    Console.WriteLine($"{name} is {age} years old.");
}
```

:question: Which to use? the second example, it's clear and easy to read.

## Dictionary/IGrouping deconstruct

In this example the model where the task is to group by price, Cheap, Medium and Expensive.

```csharp
public partial class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal? Price { get; set; }
}
```

Code to read and group.

```csharp
var books = await context.Book.ToListAsync();

Dictionary<string, IGrouping<string, Book>> results = books
    .GroupBy(book => book.Price switch
    {
        <= 10 => "Cheap",
        > 10 and <= 20 => "Medium",
        _ => "Expensive"
    })
    .ToDictionary(gb =>
            gb.Key,
        g => g);
```

Conventional `foreach` where like the prior conventional `foreach` we have is Key and Value which can make understand the code hard.

```csharp
foreach (KeyValuePair<string, IGrouping<string, Book>> pair in results)
{
    Console.WriteLine(pair.Key);
    foreach (var book in pair.Value)
    {
        Console.WriteLine($"\t{book.Title,-25}{book.Price:C0}");
    }
}
```

Using Deconstruct the code is much easier to read.

```csharp
foreach (var (pricingCategory, bookGrouping) in results)
{
    Console.WriteLine(pricingCategory);
    foreach (var book in bookGrouping)
    {
        Console.WriteLine($"\t{book.Title, -25}{book.Price:C0}");
    }
}
```

And we can specify each variable type too.


```csharp
foreach ((string pricingCategory, IGrouping<string, Book> bookGrouping) in results)
{
    Console.WriteLine(pricingCategory);
    foreach (var book in bookGrouping)
    {
        Console.WriteLine($"\t{book.Title, -25}{book.Price:C0}");
    }
}
```

## Records

We can deconstruct `records` also, given the following record `Deconstruct` provides us a way to return all information in a compact form.

```csharp
public record Person()
{
    public int Id { get; init; }
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public string FullName => $"{Firstname} {Lastname}";

    public override string ToString() => $"{Id} {FullName}";

    public void Deconstruct(out int id, out string fullName)
        => (id, fullName) = (Id, FullName);

}
```

Usage with mocked data using [Bogus](https://www.nuget.org/packages/Bogus) NuGet package.

```csharp
namespace ForWritingArticle.Classes
{
    public class Operations
    {
        public static List<Person> PeopleList(int count = 5)
        {
            var faker = new Faker<Person>()
                .WithRecord()
                .RuleFor(p => p.Id, f => f.IndexVariable++)
                .RuleFor(p => p.Lastname, f => f.Person.LastName)
                .RuleFor(p => p.Firstname, f => f.Person.FirstName);

            return faker.Generate(count);
        }

        public static void PeopleDeconstruct()
        {
            var list = PeopleList();

            foreach (Person person in list)
            {
                var (id, fullName) = person;
                Console.WriteLine($"{id,-4}{fullName}");
            }

        }
    }
}

```

---

## Resharper

Generate Deconstructors `ReSharper_GenerateDeconstructor`

**Before generation**
```csharp
public class Version
{
    public int Major { get; }
    public int Minor { get; }
}
```

**After generation**
```csharp
public class Version
{
    public int Major { get; }
    public int Minor { get; }

    public void Deconstruct(out int major, out int minor)
    {
        major = this.Major;
        minor = this.Minor;
    }
}
```

In the above example the developer may choice all properties or select only those they want.

Like most of my Resharper shortcuts they have been changed from standard so I created a markdown file to remember them as from time to time I forget them but the following is available via a Visual Studio external tool.

| Description        |   Shortcut    | Keyboard Reference
|:------------- |:-------------|:-------------|
|  Extract Interface| <kbd>ctrl</kbd> + <kbd>O</kbd> <kbd>G</kbd>| [ReSharper_ExtractInterface](https://www.jetbrains.com/help/resharper/Refactorings__Extract_Interface.html) |
|  Extract Superclass| <kbd>ctrl</kbd> + <kbd>O</kbd> <kbd>E</kbd> |[ReSharper_ExtractSuperclass](https://www.jetbrains.com/help/resharper/Refactorings__Extract_Superclass.html) |
|  Change Signature| <kbd>ctrl</kbd> + <kbd>O</kbd> <kbd>S</kbd>| [ReSharper_ChangeSignature](https://www.jetbrains.com/help/resharper/Refactorings__Change_Signature.html) |
|  Convert Anonymous to Named Type refactoring| <kbd>ctrl</kbd> + <kbd>O</kbd> <kbd>P</kbd> | [ReSharper_Anonymous2Declared](https://www.jetbrains.com/help/resharper/Refactorings__Convert_Anonymous_to_Named_Type.html) |
| Extract Method refactoring | <kbd>ctrl</kbd> + <kbd>O</kbd> <kbd>I</kbd> | [ReSharper_ExtractMethod](https://www.jetbrains.com/help/resharper/Refactorings__Extract_Method.html) |
| Generate Deconstructors﻿ | <kbd>ctrl</kbd> + <kbd>T</kbd> <kbd>Y</kbd> | [ReSharper_GenerateDeconstructor](https://www.jetbrains.com/help/resharper/Code_Generation_Deconstructors.html) |


## Notes

- If using a framework prior to 4.8, you will need the following NuGet package [System.ValueTuple](https://www.nuget.org/packages/System.ValueTuple), otherwise the package is included in new projects

## Credits

- DateTime extension Adam Storr [![](assets/Link_16x.png)](https://adamstorr.azurewebsites.net/blog/playing-with-csharp-7-deconstruct)

## References

- Quickstart guide for deconstructions (C# 7.0) [![](assets/Link_16x.png)](https://github.com/dotnet/roslyn/blob/main/docs/features/deconstruction.md)
- C# 10: Mix declarations and expressions in a deconstruction [![](assets/Link_16x.png)](https://anthonygiretti.com/2021/07/23/introducing-c-10-mix-declarations-and-expressions-in-a-deconstruction/)
- JetBrains Rider Generate Deconstructors [![](assets/Link_16x.png)](https://www.jetbrains.com/help/rider/Code_Generation_Deconstructors.html)
- Using Tuples in C# to Initialize Properties in the Constructor and to Deconstruct Your Object [![](assets/Link_16x.png)](https://www.thomasclaudiushuber.com/2021/03/25/csharp-using-tuples-to-initialize-properties/)
- Avoid C# 9 Record Gotchas [![](assets/Link_16x.png)](https://khalidabuhakmeh.com/avoid-csharp-9-record-gotchas)