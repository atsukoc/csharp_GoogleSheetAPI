using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleBook
{
    public class Email
    {
        private string email;

        public Email()
        {
            email = null;
        }

        public Email(string email)
        {
            this.email = email;
        }

        public bool IsValid(string email)
        {
            EmailAddressAttribute a = new EmailAddressAttribute();
            return a.IsValid(email);
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }
    }
}
