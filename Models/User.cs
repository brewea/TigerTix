﻿using System.ComponentModel.DataAnnotations;

namespace TigerTix.Web.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string CreditCard { get; set; }

        public string AccountType { get; set; }
    }
}
