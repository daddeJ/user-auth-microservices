using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        // ───── Basic Personal Information ─────
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? MiddleName { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        public int? Age => DateTime.Now.Year - DateOfBirth.Year;
        [MaxLength(50)]
        public string? Nationality { get; set; }
        [MaxLength(50)]
        public string? CivilStatus { get; set; }

         // ───── Contact Information ─────
        [Required]
        [EmailAddress]
        [MaxLength(225)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        [MaxLength(225)]
        public string MobileNumber { get; set; } = string.Empty;
        [Phone]
        [MaxLength(225)]
        public string? AlternatePhoneNumber { get; set; }

        // ───── Address ─────
        [Required]
        [MaxLength(255)]
        public string Street { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Barangay { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Province { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        // ───── Professional Information (Optional) ─────
        [MaxLength(100)]
        public string? Occupation { get; set; }

        [MaxLength(100)]
        public string? CompanyName { get; set; }

        [MaxLength(100)]
        public string? Industry { get; set; }

        [Range(0, 100)]
        public int? YearOfExperience { get; set; }

        // ───── Government IDs ─────
        [MaxLength(100)]
        public string? GovermentId { get; set; }
    }
}