using System;
namespace PeopleBook
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        //private Address address;
        private string email;

        /**********************
         * Default Constructor
         **********************/
        public Person()
        {
            firstName = null;
            lastName = null;
            //address = null;
            email = null;
        }

        /**************************
         * Non-default constructor
         **************************/
        public Person(string first_name, string last_name)
        {
            firstName = first_name;
            lastName = last_name;
        }

        /**************************************************
        * Displays the person's information to the console
        ***************************************************/
        public void Display()
        {
            Console.WriteLine(String.Format("\n{0} {1}\n", firstName, lastName));
        }

        /**************************************************
        * Used to ask for the person's first name and store
        * the value to the person's object
        ***************************************************/
        public void AskFirstName()
        {
            Console.Write("First name? ");
            SetFirstName(Console.ReadLine());
        }

        /**************************************************
        * Used to ask for the person's last name and store
        * the value to the person's object
        ***************************************************/
        public void AskLastName()
        {
            Console.Write("Last name: ");
            SetLastName(Console.ReadLine());
        }

        /*************************************************
         * Getters and Setters are defined below
         ***********************************************/
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
