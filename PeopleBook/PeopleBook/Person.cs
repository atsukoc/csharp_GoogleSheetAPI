using System;
namespace PeopleBook
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        //private Address address;
        private Email email;

        /**********************
         * Default Constructor
         **********************/
        public Person()
        {
            firstName = null;
            lastName = null;
            //address = null;
            email = new Email();
        }

        /**************************
         * Non-default constructor
         **************************/
        public Person(string first_name, string last_name, Email email)
        {
            firstName = first_name;
            lastName = last_name;
            this.email = email;
        }

        /**************************************************
        * Displays the person's information to the console
        ***************************************************/
        public void Display()
        {
            
            Console.WriteLine(String.Format("\n{0} {1} | {2}\n", firstName, lastName, email.GetEmail())) ;
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


        public void AskEmail()
        {
            bool isValidAddress = false;
            string emailAddress = null;

            while (!isValidAddress)
            {
                Console.Write("Email address: ");
                emailAddress = Console.ReadLine();
                isValidAddress = this.email.IsValid(emailAddress);
            }
        
            SetEmail(emailAddress);
        }


        public void UpdatePerson()
        {
            int input = 0;

            Console.WriteLine("1 | Fix first name");
            Console.WriteLine("2 | Fix last name");
            Console.WriteLine("3 | Fix email address");
            Console.WriteLine("4 | Never mind, don't need to fix anything");
            input = Convert.ToInt16(Console.ReadLine());

            // check the input number
            if (input < 1 || input > 4)
                Console.WriteLine("Please choose 1-4");

            if (input == 1)
                AskFirstName();
            if (input == 2)
                AskLastName();
            if (input == 3)
                AskEmail();
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


        public void SetEmail(string email)
        {
            this.email.SetEmail(email);

        }
        
        public string GetFirstName()
        {
            return firstName;
        }


        public string GetLastname()
        {
            return lastName;
        }

        public string GetEmail()
        {
            return email.GetEmail();
        }

    }
}
