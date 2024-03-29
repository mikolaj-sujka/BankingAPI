﻿using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string UserName { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Can only contain letters")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Can only contain letters")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{2}(-\d{3})?$", ErrorMessage = "Invalid Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Can only contain letters")]
        public string City { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Can only contain letters")]
        public string Country { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}
