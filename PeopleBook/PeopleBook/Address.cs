using System;
namespace PeopleBook
{
    public class Address
    {
        private int id;
        private string street;
        private string state;
        private string zip;
        private string country;

        // constructors
        public Address() { }
        public Address(int id, string street, string state, string zip, string country)
        {
            this.id = id;
            this.street = street;
            this.state = state;
            this.zip = zip;
            this.country = country;
        }

        // getters

    }
}
