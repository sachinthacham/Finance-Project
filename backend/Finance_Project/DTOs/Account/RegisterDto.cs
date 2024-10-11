﻿using System.ComponentModel.DataAnnotations;

namespace Finance_Project.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        public string? UserName {  get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
