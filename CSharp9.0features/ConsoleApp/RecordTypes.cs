using System;

namespace ConsoleApp1
{
    /// <summary>
    /// This is full declaration: this automatically defines properties and way to create record,
    /// as well as to deconstruct it.
    /// </summary>
    public record Person(string FirstName, string LastName);

    public static class RecordTypes
    {
        public static void RecordsInAction()
        {
            var person = new Person("Michal", "Turczyn");
            (var fName, var lName) = person;

            Console.WriteLine($"{nameof(person)} = {person}");
            Console.WriteLine($"{nameof(fName)} = {fName}");
            Console.WriteLine($"{nameof(lName)} = {lName}");

            // Output:
            // person = Person { FirstName = Michal, LastName = Turczyn }
            // fName = Michal
            // lName = Turczyn
        }
    }

}
