using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string FullName => string.Join(" ", new[] { FirstName, MiddleName, LastName }
    .Where(name => !string.IsNullOrWhiteSpace(name)));
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? Nationality { get; set; }
        public string? CivilStatus { get; set; }

        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string? AlternatePhoneNumber { get; set; }

        public string Street { get; set; }
        public string? Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string? Occupation { get; set; }
        public string? Industry { get; set; }
    }

}