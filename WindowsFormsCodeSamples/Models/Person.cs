using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCodeSamples.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Contents => $"{FirstName}\n{LastName}\n{Phone}";
        public override string ToString() => $"{FirstName} {LastName} {Phone}";

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
