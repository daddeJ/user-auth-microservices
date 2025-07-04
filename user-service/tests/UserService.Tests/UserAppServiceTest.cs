using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using UserService.Application.Dtos;
using UserService.Application.Intefaces.Common;
using UserService.Application.Services;
using UserService.Domain.Entities;
using UserService.Tests.Mock;

namespace UserService.Tests
{
    public class UserAppServiceTest
    {
        private readonly Mock<IBaseRepository<User>> _baseRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserAppService _userAppService;
        public UserAppServiceTest()
        {
            _baseRepositoryMock = new Mock<IBaseRepository<User>>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _userAppService = new UserAppService(_baseRepositoryMock.Object, _mapperMock.Object, _userRepositoryMock.Object);
        }
        [Fact]
        public async Task CreateAsync_MaspsAndSavesEntity_ReturnsDTO()
        {
            // Given
            var createDto = MockUserData.GetVailidCreateUserDto();
            var entities = MockUserData.GetUser();
            var expectedUser = MockUserData.GetValidUserDto();

            _mapperMock.Setup(m => m.Map<User>(It.IsAny<CreateUserDto>())).Returns(entities);
            _baseRepositoryMock.Setup(b => b.AddAsync(It.IsAny<User>())).ReturnsAsync(entities);
            _mapperMock.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(expectedUser);
            // When
            var result = await _userAppService.CreateAsync(createDto);

            // ThenCreateAsyncCreateAsync
            Assert.NotNull(result);
            Assert.Equal(expectedUser.Id, result.Id);
            Assert.Equal(expectedUser.FirstName, result.FirstName);
            Assert.Equal(expectedUser.LastName, result.LastName);
            Assert.Equal(expectedUser.MiddleName, result.MiddleName);
            Assert.Equal(expectedUser.Gender, result.Gender);
            Assert.Equal(expectedUser.DateOfBirth, result.DateOfBirth);
            Assert.Equal(expectedUser.Nationality, result.Nationality);
            Assert.Equal(expectedUser.CivilStatus, result.CivilStatus);
            Assert.Equal(expectedUser.Email, result.Email);
            Assert.Equal(expectedUser.MobileNumber, result.MobileNumber);
            Assert.Equal(expectedUser.Street, result.Street);
            Assert.Equal(expectedUser.Barangay, result.Barangay);
            Assert.Equal(expectedUser.City, result.City);
            Assert.Equal(expectedUser.Province, result.Province);
            Assert.Equal(expectedUser.PostalCode, result.PostalCode);
            Assert.Equal(expectedUser.Country, result.Country);
            Assert.Equal(expectedUser.Occupation, result.Occupation);
            Assert.Equal(expectedUser.Industry, result.Industry);

            _baseRepositoryMock.Verify(b => b.AddAsync(It.IsAny<User>()), Times.Once);
            _mapperMock.Verify(m => m.Map<User>(It.IsAny<CreateUserDto>()), Times.Once);
            _mapperMock.Verify(m => m.Map<UserDto>(It.IsAny<User>()), Times.Once);
        }
        [Fact]
        public async Task UpdateAsync_UpdatesEntity_ReturnsDTO()
        {
            // Given
            var user = MockUserData.GetUser();
            var updateDto = new UpdateUserDto()
            {
                Id = user.Id,
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                MiddleName = "UpdatedMiddleName",
            };
            var expectedUser = MockUserData.GetValidUserDto();

            _baseRepositoryMock.Setup(b => b.GetByIdAsync(user.Id)).ReturnsAsync(user);
            _mapperMock.Setup(m => m.Map(It.IsAny<UpdateUserDto>(), It.IsAny<User>())).Callback<UpdateUserDto, User>((dto, entity) =>
            {
                entity.FirstName = dto.FirstName;
                entity.LastName = dto.LastName;
                entity.MiddleName = dto.MiddleName;
            });
            _baseRepositoryMock.Setup(b => b.UpdateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
            _mapperMock.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(expectedUser);

            var result = await _userAppService.UpdateAsync(user.Id, updateDto);
            Assert.Equal(expectedUser.Id, result.Id);
            Assert.Equal(expectedUser.FirstName, result.FirstName);
            Assert.Equal(expectedUser.LastName, result.LastName);
            Assert.Equal(expectedUser.MiddleName, result.MiddleName);
            _baseRepositoryMock.Verify(b => b.GetByIdAsync(user.Id), Times.Once);
            _baseRepositoryMock.Verify(b => b.UpdateAsync(It.IsAny<User>()), Times.Once);
            _mapperMock.Verify(m => m.Map(It.IsAny<UpdateUserDto>(), It.IsAny<User>()), Times.Once);
            _mapperMock.Verify(m => m.Map<UserDto>(It.IsAny<User>()), Times.Once);
        }

        [Theory]
        [InlineData("sample@test.com")]
        [InlineData("test@sample.com")]
        public async Task GetByEmailAsync_ReturnsUser_WhenFound(string email)
        {
            // Given
            var expectedUser = new User { Email = email };
            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(email)).ReturnsAsync(expectedUser);
            // When
            var result = await _userAppService.GetByEmailAsync(email);
            // Then
            Assert.NotNull(result);
            Assert.Equal(email, result.Email);
            _userRepositoryMock.Verify(repo => repo.GetByEmailAsync(email), Times.Once);
        }
        [Theory]
        [InlineData("ghost@nowhere.com")]
        public async Task GetByEmailAsync_ReturnsNull_WhenNotFound(string email)
        {
            // Given
            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(email)).ReturnsAsync((User)null);
            // When
            var result = await _userAppService.GetByEmailAsync(email);
            // Then
            Assert.Null(result);
            _userRepositoryMock.Verify(repo => repo.GetByEmailAsync(email), Times.Once);
        }
        [Fact]
        public async Task GetByIdAsync_ReturnsUser_WhenFound()
        {
            var userId = MockUserData.GetUser().Id;
            var expectedUser = MockUserData.GetValidUserDto();
            _baseRepositoryMock.Setup(b => b.GetByIdAsync(userId)).ReturnsAsync(MockUserData.GetUser());
            _mapperMock.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(expectedUser);

            var result = await _userAppService.GetByIdAsync(userId);

            Assert.NotNull(result);
            Assert.Equal(expectedUser.Id, result.Id);
            Assert.Equal(expectedUser.FirstName, result.FirstName);
            Assert.Equal(expectedUser.LastName, result.LastName);
            Assert.Equal(expectedUser.MiddleName, result.MiddleName);
            Assert.Equal(expectedUser.Gender, result.Gender);
            Assert.Equal(expectedUser.DateOfBirth, result.DateOfBirth);
            Assert.Equal(expectedUser.Nationality, result.Nationality);
            Assert.Equal(expectedUser.CivilStatus, result.CivilStatus);
            Assert.Equal(expectedUser.Email, result.Email);
            Assert.Equal(expectedUser.MobileNumber, result.MobileNumber);
            Assert.Equal(expectedUser.Street, result.Street);
            Assert.Equal(expectedUser.Barangay, result.Barangay);
            Assert.Equal(expectedUser.City, result.City);
            Assert.Equal(expectedUser.Province, result.Province);
            Assert.Equal(expectedUser.PostalCode, result.PostalCode);
            Assert.Equal(expectedUser.Country, result.Country);
            Assert.Equal(expectedUser.Occupation, result.Occupation);
            Assert.Equal(expectedUser.Industry, result.Industry);
            _baseRepositoryMock.Verify(b => b.GetByIdAsync(userId), Times.Once);
            _mapperMock.Verify(m => m.Map<UserDto>(It.IsAny<User>()), Times.Once);
        }
        [Fact]
        public async Task DeleteAsync_DeletesEntity_ReturnsTrue()
        {
            var userId = MockUserData.GetUser().Id;
            _baseRepositoryMock.Setup(b => b.GetByIdAsync(userId)).ReturnsAsync(MockUserData.GetUser());

            var result = await _userAppService.DeleteAsync(userId);

            Assert.True(result);
            _baseRepositoryMock.Verify(b => b.GetByIdAsync(userId), Times.Once);
        }
        [Fact]
        public async Task DeleteAsync_DeleteEntity_ReturnsFalse()
        {
            var userId = Guid.NewGuid();
            _baseRepositoryMock.Setup(b => b.GetByIdAsync(userId)).ReturnsAsync((User)null);

            var result = await _userAppService.DeleteAsync(userId);

            Assert.False(result);
            _baseRepositoryMock.Verify(b => b.GetByIdAsync(userId), Times.Once);
        }
    }
}