//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using PaymentSystem;
//using PaymentSystem.Core.Models;
//using PaymentSystem.Core.Repositories;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;

//namespace PaymentSystemTests
//{
//    public class PaymentTests
//    {
//        //private readonly ILogger<UserController> _logger;
//        private readonly Mock<IUserRepository> service;
//        public PaymentTests()
//        {
//            service = new Mock<IUserRepository>();
//        }

//        [Fact]
//        public async void GetUserById_UserObject_UserwithSpecificeIdExists()
//        {
//            //arrange
//            var users = GetSampleUser();
//            var firstUser = users[0];
//            service.Setup(x => x.GetWithPaymentsByIdAsync(1))
//                .Returns(firstUser);
//            var controller = new UserController((PaymentSystem.Core.Services.IUserService)service.Object);

//            //act
//            var actionResult = controller.GetUserById(1);
//            var result = actionResult.Result as OkObjectResult;

//            //Assert
//            Assert.IsType<OkObjectResult>(result);
//        }

//        [Fact]
//        public void GetUserById_shouldReturnBadRequest_UserWithIDNotExists()
//        {
//            //arrange
//            var users = GetSampleUser();
//            var firstUser = users[0];
//            service.Setup(x => x.GetWithPaymentsByIdAsync(1))
//                .Returns(firstUser);

//            var controller = new UserController((PaymentSystem.Core.Services.IUserService)service.Object);

//            //act
//            var actionResult = controller.GetUserById(2);

//            //assert
//            var result = actionResult.Result;
//            Assert.IsType<NotFoundObjectResult>(result);
//        }


//        private Task<ActionResult<User>> GetSampleUser()
//        {
//            List<User> user = new List<User>
//            {
//                new User
//                {
//                    Id = 1,
//                    AccountBalance = 100000

//                },
//                new User
//                {
//                    Id =2,
//                    AccountBalance = 200000
//                  },

//                new User
//                {
//                    Id = 3,
//                    AccountBalance = 300000

//                }
//        };
//            return user;
//        }
//    }
//}

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem;
using PaymentSystem.Core.Models;
using PaymentSystem.Data;
using PaymentSystem.Data.Repositories;
using PaymentSystem.Services;
using Xunit;

public class PaymentSystemTest
{
    private UserRepository userRepository;
    private UserService userService;
    public static DbContextOptions<UserDbContext> dbContextOptions { get; }
    public static string connectionString = "Data Source=RhoyzylAquinoBD;Integrated Security=True;Connect Timeout=30;";

    static PaymentSystemTest()
    {
        dbContextOptions = new DbContextOptionsBuilder<UserDbContext>()
            .UseSqlServer(connectionString)
            .Options;
    }

    public PaymentSystemTest()
    {
        var context = new UserDbContext(dbContextOptions);

        userService = new UserService(context);
        //userRepository = new UserRepository(context);

    }

    #region Get By Id

    [Fact]
    public async void Task_GetPostById_Return_OkResult()
    {
        //Arrange
        var controller = new UserController(userService);
        var Id = 2;

        //Act
        var data = await controller.GetUserById(Id);

        //Assert
        Assert.IsType<OkObjectResult>(data);
    }

    [Fact]
    public async void Task_GetPostById_Return_NotFoundResult()
    {
        //Arrange
        var controller = new UserController(userService);
        var Id = 3;

        //Act
        var data = await controller.GetUserById(Id);

        //Assert
        Assert.IsType<NotFoundResult>(data);
    }

    [Fact]
    public async void Task_GetPostById_Return_BadRequestResult()
    {
        //Arrange
        var controller = new UserController(userService);
        int? Id = null;

        //Act
        var data = await controller.GetUserById((int)Id);

        //Assert
        Assert.IsType<BadRequestResult>(data);
    }

    //[Fact]
    //public async void Task_GetPostById_MatchResult()
    //{
    //    //Arrange
    //    var controller = new UserController(service);
    //    int? postId = 1;

    //    //Act
    //    var data = await controller.GetUserById((int)postId);

    //    //Assert
    //    Assert.IsType<OkObjectResult>(data);

    //    var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
    //    var post = okResult.Value.Should().BeAssignableTo<User>().Subject;

    //    Assert.Equal("Test Title 1", post.);
    //    Assert.Equal("Test Description 1", post.Description);
    //}

    #endregion
}