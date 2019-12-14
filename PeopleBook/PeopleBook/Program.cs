using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PeopleBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Boolean on = true;
           
            while (on)
            {
                char input = askInputs();

                if(input.Equals('r') || input.Equals('R'))
                {
                    Operations.ReadData();
                }
                else if(input.Equals('x') || input.Equals('X'))
                {
                    on = false;
                    Console.WriteLine("Bye");
                    Environment.Exit(0);
                }
                else if(input.Equals('i') || input.Equals('I'))
                {
                    string first_name;
                    string last_name;
                    string street_address;
                    string state;
                    string zip;
                    string country;
                    string email;

                    // Gather information
                    askFirstName(out first_name);
                    askLastName(out last_name);
                    askStreetAddress(out street_address);
                    askState(out state);
                    askZip(out zip);
                    askCountry(out country);
                    askEmail(out email);

                    // Display the entered information
                    Console.WriteLine(String.Format("\n{0} {1}", first_name, last_name));
                    Console.WriteLine(String.Format("{0}, {1}, {2} {3}", street_address, state, zip, country));
                    Console.WriteLine(String.Format("Email: {0}\n", email));

                    // Ask if anything needs to be modified before inserting to the google sheet
                    Console.WriteLine("Is all correct? Enter Y for YES, N for NO");
                    var response = Console.ReadLine();
                    char charResponse = Convert.ToChar(response);

                    if (charResponse.Equals('Y') || charResponse.Equals('y'))
                    {
                        Console.WriteLine("Person added to the spread sheet");
                    }
                    else if(charResponse.Equals('N') || charResponse.Equals('n'))
                    {
                        Console.WriteLine("What do we need to fix?");
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
            
        }

        static private char askInputs()
        {
            Console.WriteLine("\n=========== Menu ==========");
            Console.WriteLine("R | Read the entire sheet");
            Console.WriteLine("I | Add a new person to the sheet");
            Console.WriteLine("X | Exit");
            Console.WriteLine("=======================");
            var input = Console.ReadLine();
            char charInput = Convert.ToChar(input);
            return charInput;
        }

        static private void askFirstName(out string firstname)
        {
            Console.WriteLine("First name?");
            firstname = Console.ReadLine();
        }

        static private void askLastName(out string lastname)
        {
            Console.WriteLine("Last name?");
            lastname = Console.ReadLine();
        }

        static private void askStreetAddress(out string street)
        {
            Console.WriteLine("Street address?");
            street = Console.ReadLine();
        }

        static private void askState(out string state)
        {
            Console.WriteLine("State?");
            state = Console.ReadLine();
        }

        static private void askZip(out string zip)
        {
            Console.WriteLine("Zip Code?");
            zip = Console.ReadLine();
        }

        static private void askCountry(out string country)
        {
            Console.WriteLine("Country?");
            country = Console.ReadLine();
        }

        static private void askEmail(out string email)
        {
            Console.WriteLine("Email?");
            email = Console.ReadLine();
        }
    }


    
}
