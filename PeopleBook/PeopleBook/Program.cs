
using System;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace PeopleBook
{
    public class Program
    {

        static void Main(string[] args)
        {
            Boolean on = true;
            List<Person> people = new List<Person>();

            while (on)
            {
               
                char input = AskOperation();


                if (input.Equals('r') || input.Equals('R'))
                {
                    Operations.ReadData(ref people);


                    Operations.GmailApi();

                }
                else if (input.Equals('x') || input.Equals('X'))
                {
                    on = false;
                    Console.WriteLine("Bye");
                    Environment.Exit(0);
                }
                else if (input.Equals('i') || input.Equals('I'))
                {
                    Person person = new Person();
                    Boolean done = false;

                    while (!done)
                    {
                        // Gather information
                        person.SetId(people.Count + 1);
                        person.AskFirstName();
                        person.AskLastName();
                        person.AskEmail();

                        // Display the entered information
                        person.Display();

                        // Ask if anything needs to be modified before inserting to the google sheet
                        char validate = ConfirmData();

                        if (validate.Equals('Y') || validate.Equals('y'))
                        {
                            done = true;
                            Operations.WriteData(ref person);
                            people.Add(person);
                        }
                        else
                        {
                            bool updated = false;

                            while (!updated)
                            {
                                person.UpdatePerson();
                                person.Display();
                                char confirmation = ConfirmData();
                                if (confirmation.Equals('y') || confirmation.Equals('Y'))
                                {
                                    updated = true;
                                    Operations.WriteData(ref person);
                                    done = true;
                                    people.Add(person);
                                }
                            }
                        }
                    }
                }
            }


        }

        static private char AskOperation()
        {
            bool done = false;
            char charInput = '\0';

            if (!done)
            {
                Console.WriteLine("\n=========== Menu ==========");
                Console.WriteLine("R | Read the entire sheet");
                Console.WriteLine("I | Add a new person to the sheet");
                Console.WriteLine("X | Exit");
                Console.WriteLine("=======================");
                var input = Console.ReadLine();
                charInput = Convert.ToChar(input);
                if (charInput == 'R' ||
                    charInput == 'r' ||
                    charInput == 'I' ||
                    charInput == 'i' ||
                    charInput == 'X' ||
                    charInput == 'x')
                    done = true;
            }

            return charInput;
        }

        static private char ConfirmData()
        {
            Console.WriteLine("Is everything correct? Enter Y for YES, N for NO");
            var r = Console.ReadLine();
            char response = Convert.ToChar(r);
            return response;
        }
    }
}
    
    

