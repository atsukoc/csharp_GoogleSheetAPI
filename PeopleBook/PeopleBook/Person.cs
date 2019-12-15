using System;
namespace PeopleBook
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        //private Address address;
        //private Email email;
        
        public Person()
        {
            firstName = null;
            lastName = null;
            //address = null;
            //email = null;
        }

        public Person(string first_name, string last_name)
        {
            firstName = first_name;
            lastName = last_name;
        }

        public void Display()
        {
            Console.WriteLine(String.Format("{0} {1}", firstName, lastName));
        }

        public void AskFirstName()
        {
            Console.Write("First name? ");
            SetFirstName(Console.ReadLine());
        }

        public void AskLastName()
        {
            Console.Write("Last name: ");
            SetLastName(Console.ReadLine());
        }


        // getters and setters
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastname()
        {
            return lastName;
        }

    }
}
