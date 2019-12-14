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
                char input = askOperation();

                if (input.Equals('r') || input.Equals('R'))
                {
                    Operations.ReadData();
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
                        person.askFirstName();
                        person.askLastName();

                        // Display the entered information
                        person.display();

                        // Ask if anything needs to be modified before inserting to the google sheet
                        char validate = validateData();

                        if (validate.Equals('Y') || validate.Equals('y'))
                        {
                            done = true;
                            Console.Write("Information is added to the google sheet");
                        }
                        else
                        {
                            bool test = false;

                            while (!test)
                            {
                                Console.WriteLine("1 | Fix first name");
                                Console.WriteLine("2 | Fix last name");
                                int inputNum = Convert.ToInt16(Console.ReadLine());

                                if (inputNum == 1)
                                    person.askFirstName();
                                else if (inputNum == 2)
                                    person.askLastName();
                                else
                                    Console.WriteLine("Not implemented yet");

                                person.display();
                                char doneyet = validateData();
                                if(doneyet.Equals('y') || doneyet.Equals('Y'))
                                {
                                    test = true;
                                    Console.Write("Information is added to the google sheet");
                                    done = true;
                                }


                            }
                            


                                    


                        }
                    }
                }
            }
            
        }

        static private char askOperation()
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

        static private char validateData()
        {
            Console.WriteLine("Is everything correct? Enter Y for YES, N for NO");
            var r = Console.ReadLine();
            char response = Convert.ToChar(r);
            return response;
        }
        
    }


    
}
