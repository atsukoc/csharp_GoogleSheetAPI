
using System;

namespace PeopleBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Boolean on = true;

            while (on)
            {
                char input = AskOperation();

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
                        }
                        else
                        {
                            bool updated = false;

                            while (!updated)
                            {
                                int inputNum = WhatToFix();

                                if(inputNum == 1)
                                    person.AskFirstName();
                                if(inputNum == 2)
                                    person.AskLastName();
                                if(inputNum == 3)
                                    person.AskEmail();

                                person.Display();
                                char doneyet = ConfirmData();
                                if(doneyet.Equals('y') || doneyet.Equals('Y'))
                                {
                                    updated = true;
                                    Operations.WriteData(ref person);
                                    done = true;
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

        static private int WhatToFix()
        {
            bool done = false;
            int inputNum = 0;

            while (!done)
            {
                Console.WriteLine("1 | Fix first name");
                Console.WriteLine("2 | Fix last name");
                Console.WriteLine("3 | Fix email address");
                Console.WriteLine("4 | Never mind, don't need to fix anything");
                inputNum = Convert.ToInt16(Console.ReadLine());

                // check the input number
                if (inputNum < 0 || inputNum > 4)
                    Console.WriteLine("Please choose 1-4");
                else
                    done = true;
            }

            return inputNum;
       
        }
    }


    
}
