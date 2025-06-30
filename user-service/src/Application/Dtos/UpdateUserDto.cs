using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UpdateUserDto
    {
        [Required]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? CivilStatus { get; set; }

        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? AlternatePhoneNumber { get; set; }

        public string? Street { get; set; }
        public string? Barangay { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public string? Occupation { get; set; }
        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public int? YearOfExperience { get; set; }

        public string? GovermentId { get; set; }
    }
}