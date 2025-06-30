using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Application.Dtos
{
    public class CreateUserDto
    {
        // Basic Information
        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string? MiddleName { get; set; }

        [Required, MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string? Nationality { get; set; }

        [MaxLength(50)]
        public string? CivilStatus { get; set; }

        // Contact
        [Required, EmailAddress, MaxLength(225)]
        public string Email { get; set; }

        [Required, Phone, MaxLength(225)]
        public string MobileNumber { get; set; }

        [Phone, MaxLength(225)]
        public string? AlternatePhoneNumber { get; set; }

        // Address
        [Required, MaxLength(255)]
        public string Street { get; set; }

        [MaxLength(100)]
        public string? Barangay { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required, MaxLength(100)]
        public string Province { get; set; }

        [Required, MaxLength(10)]
        public string PostalCode { get; set; }

        [Required, MaxLength(100)]
        public string Country { get; set; }

        // Optional Professional Info
        [MaxLength(100)]
        public string? Occupation { get; set; }

        [MaxLength(100)]
        public string? CompanyName { get; set; }

        [MaxLength(100)]
        public string? Industry { get; set; }

        [Range(0, 100)]
        public int? YearOfExperience { get; set; }

        [MaxLength(100)]
        public string? GovermentId { get; set; } 
    }
}