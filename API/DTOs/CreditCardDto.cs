using System;

namespace API.DTOs
{
    public class CreditCardDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime DateExpires { get; set; }
        public string Pin { get; set; }
        public string Cvc { get; set; }
    }
}
