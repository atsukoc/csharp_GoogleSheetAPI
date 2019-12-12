using System;
namespace PeopleBook
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private Address address;
        private Email email;
        
        public Person()
        {
            firstName = null;
            lastName = null;
            address = null;
            email = null;
        }
    }
}
