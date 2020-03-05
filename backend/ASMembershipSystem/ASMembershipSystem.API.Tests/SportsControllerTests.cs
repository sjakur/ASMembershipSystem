using ASMembershipSystem.API.Controllers;
using ASMembershipSystem.API.Models;
using ASMembershipSystem.Core.Domain;
using ASMembershipSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ASMembershipSystem.API.Tests
{
    public class SportsControllerTests
    {
        private readonly Mock<ISportService> _sportServiceMock;
        private readonly SportsController _sportsController;

        public SportsControllerTests()
        {
            _sportServiceMock = new Mock<ISportService>();
            _sportsController = new SportsController(_sportServiceMock.Object);
        }

        [Fact]
        public void Get_ReturnsAllMembers()
        {
            var sports = GetTestSports();
            _sportServiceMock.Setup(x => x.GetAllSports())
                              .Returns(sports);

            var actionResult = _sportsController.GetAllSports();

            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var objectResultValue = Assert.IsAssignableFrom<List<SportDto>>(objectResult.Value);
            Assert.Equal(sports.Count, objectResultValue.Count);
        }

        private List<Sport> GetTestSports()
        {
            return new List<Sport>
            {
                new Sport
                {
                    Id = 1,
                    Name = "Squash"
                },
                new Sport
                {
                    Id = 2,
                    Name = "Tennis"
                },
                new Sport
                {
                    Id = 3,
                    Name = "Football"
                }
            };
        }
    }
}
