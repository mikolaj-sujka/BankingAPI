using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class CreditCard
    {
        public CreditCard()
        {
            this.CardNumber = GenerateCardNumber();
            this.DateExpires = DateTime.Now.AddYears(4);
        }
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime DateExpires { get; set; }

        public static string GenerateCardNumber()
        {
            var random = new Random();
            string s = string.Empty;

            for (int i = 0; i < 16; i++)
                s = String.Concat(s, random.Next(9).ToString());
            return s;
        }
    }
}
