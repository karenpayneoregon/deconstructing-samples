using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCodeSamples.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Lines => $"{FirstName}\n{LastName}\n{Phone}";
        public override string ToString() => $"{FirstName} {LastName} {Phone}";

        public void Deconstruct(out int id, out string firstName, out string lastName, out string phone)
        {
            id = Id;
            firstName = FirstName;
            lastName = LastName;
            phone = Phone;
        }
        public void Deconstruct(out string firstName, out string lastName, out string phone)
        {
            firstName = FirstName;
            lastName = LastName;
            phone = Phone;
        }

        internal void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
}
