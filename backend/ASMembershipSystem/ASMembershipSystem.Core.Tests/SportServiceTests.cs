using ASMembershipSystem.Core.Contracts;
using ASMembershipSystem.Core.Domain;
using ASMembershipSystem.Core.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ASMembershipSystem.Core.Tests
{
    public class SportServiceTests
    {
        private readonly Mock<ISportRepository> _sportRepositoryMock;
        private readonly SportService _sportService;

        public SportServiceTests()
        {
            _sportRepositoryMock = new Mock<ISportRepository>();
            _sportService = new SportService(_sportRepositoryMock.Object);
        }

        [Fact]
        public void ShouldGetAllSports()
        {
            var sports = new List<Sport>
            {
                new Sport(),
                new Sport(),
                new Sport()
            };

            _sportRepositoryMock.Setup(x => x.GetAll())
                     .Returns(sports);

            var result = _sportService.GetAllSports();

            Assert.Equal(sports.Count, result.Count);
        }
    }
}
