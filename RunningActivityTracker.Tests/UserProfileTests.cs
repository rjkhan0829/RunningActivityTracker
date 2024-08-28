using Microsoft.AspNetCore.Mvc;
using RunningActivityTracker.Controllers;
using RunningActivityTracker.Data;
using RunningActivityTracker.Models;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;

public class UserProfileTests
{
    [Fact]
    public void Test_GetAll_ReturnsAllUsers()
    {
        var mockContext = new Mock<ApplicationDbContext>();
        var controller = new UserProfileController(mockContext.Object);
        var result = controller.GetAll() as OkObjectResult;

        var users = result.Value as List<UserProfile>;
        Assert.NotNull(users);
    }
}
