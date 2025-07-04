using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Application.Dtos;
using UserService.Domain.Entities;

namespace UserService.Tests.Mock
{
    public static class MockUserData
    {
        public static User GetUser()
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                MiddleName = "X",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                Nationality = "Filipino",
                CivilStatus = "Single",
                Email = "john@example.com",
                MobileNumber = "09171234567",
                Street = "123 Street",
                Barangay = "Barangay 1",
                City = "Quezon City",
                Province = "Metro Manila",
                PostalCode = "1100",
                Country = "Philippines",
                Occupation = "Engineer",
                CompanyName = "Sample Corp",
                Industry = "IT",
                YearOfExperience = 5,
                GovermentId = "ABC123456"
            };
        }
        public static CreateUserDto GetVailidCreateUserDto()
        {
            return new CreateUserDto
            {
                FirstName = "John",
                LastName = "Doe",
                MiddleName = "X",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                Nationality = "Filipino",
                CivilStatus = "Single",
                Email = "john@example.com",
                MobileNumber = "09171234567",
                Street = "123 Street",
                Barangay = "Barangay 1",
                City = "Quezon City",
                Province = "Metro Manila",
                PostalCode = "1100",
                Country = "Philippines",
                Occupation = "Engineer",
                CompanyName = "Sample Corp",
                Industry = "IT",
                YearOfExperience = 5,
                GovermentId = "ABC123456"
            };
        }
        public static UserDto GetValidUserDto()
        {
            return new UserDto
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                MiddleName = "X",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                Nationality = "Filipino",
                CivilStatus = "Single",
                Email = "john@example.com",
                MobileNumber = "09171234567",
                Street = "123 Street",
                Barangay = "Barangay 1",
                City = "Quezon City",
                Province = "Metro Manila",
                PostalCode = "1100",
                Country = "Philippines",
                Occupation = "Engineer",
                Industry = "IT",
            };
        }
        public static UpdateUserDto GetUpdateUserDto()
        {
            return new UpdateUserDto
            {
                FirstName = "John",
                LastName = "Doe",
                MiddleName = "X",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                Nationality = "Filipino",
                CivilStatus = "Single",
                Email = "john@example.com",
                MobileNumber = "09171234567",
                Street = "123 Street",
                Barangay = "Barangay 1",
                City = "Quezon City",
                Province = "Metro Manila",
                PostalCode = "1100",
                Country = "Philippines",
                Occupation = "Engineer",
                CompanyName = "Sample Corp",
                Industry = "IT",
                YearOfExperience = 5,
                GovermentId = "ABC123456",
            };
        }
    }
}