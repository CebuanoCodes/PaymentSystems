using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using PaymentSystem;
using PaymentSystem.Core.Models;
using PaymentSystem.Core.Repositories;
using PaymentSystem.Core.Services;
using PaymentSystem.Data;
using PaymentSystem.Data.Repositories;
using PaymentSystem.Services;
using Xunit;

namespace PaymentSystemTests
{
    public class PaymentTests
    {
        private UserRepository userRepository;
        public static DbContextOptions<UserDbContext> dbContextOptions { get; }
        public static string connectionString = "Data Source=RhoyzylAquinoBD;Integrated Security=True;Connect Timeout=30;";


        static PaymentTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public PaymentTests()
        {
            var context = new UserDbContext(dbContextOptions);

            userRepository = new UserRepository(context);

        }

        [Fact]
        public async void Task_GetPostById_MatchResult()

        {
            //Arrange
            var service = new UserService(userRepository);
            int? userId = 1;

            //Act
            var data = await service.GetUserById((int)userId);

            //Assert
            Assert.IsType<User>(data);

            var okResult = data.Should().BeOfType<User>().Subject;
            var user = okResult.Should().BeAssignableTo<User>().Subject;

            Assert.Equal(500000, user.AccountBalance);
            Assert.Equal(1, user.Id);
        }

        [Fact]
        public async void Task_GetPostById_Return_BadRequestResult()
        {
            //Arrange
            var service = new UserService(userRepository);
            int? userId = null;

            //Act
            var data = await service.GetUserById((int)userId);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }


        [Fact]
        public async void Task_GetPostById_Return_NotFoundResult()
        {
            //Arrange
            var service = new UserService(userRepository);
            var userId = 100;

            //Act
            var data = await service.GetUserById(userId);

            //Assert
            Assert.IsType<NotFoundResult>(data);

        }


        [Fact]
        public void Task_GetPostById_Return_OkResult()
        {
            //Arrange
            var service = new UserService(userRepository);
            var userId = 2;

            //Act
            var data = service.GetUserById(userId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }


    }
}
