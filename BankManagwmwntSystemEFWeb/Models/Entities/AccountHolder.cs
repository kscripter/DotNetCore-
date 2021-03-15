using System;
using System.Collections.Generic;

namespace BankManagwmwntSystemEFWeb.Models.Entities
{
    public class AccountHolder : Details
    {

        public AccountHolder()
        {
            Loans = new List<Loan>();

            Overdrafts = new List<Overdraft>();
        }




        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public IList<Loan> Loans { get; set; }

        public IList<Overdraft> Overdrafts { get; set; }

        public Account Account { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }


    }
}
