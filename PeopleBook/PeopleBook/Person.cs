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

        public void display()
        {
            Console.WriteLine(String.Format("{0} {1}", firstName, lastName));
        }

        public void askFirstName()
        {
            Console.Write("First name? ");
            setFirstName(Console.ReadLine());
        }

        public void askLastName()
        {
            Console.Write("Last name: ");
            setLastName(Console.ReadLine());
        }


        // getters and setters
        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastname()
        {
            return lastName;
        }

    }
}
