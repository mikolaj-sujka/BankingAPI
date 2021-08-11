using System;

namespace API.Entities
{
    public class CreditCard
    {
        public CreditCard()
        {
            this.CardNumber = GenerateNumber(16);
            this.DateExpires = DateTime.Now.AddYears(4);
            this.Pin = GenerateNumber(4);
            this.Cvc = GenerateNumber(3);
        }
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime DateExpires { get; set; }
        public string Pin { get; set; }
        public string Cvc { get; set; }

        public static string GenerateNumber(int length)
        {
            var random = new Random();
            string s = string.Empty;

            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(9).ToString());
            return s;
        }
    }
}
