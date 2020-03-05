using ASMembershipSystem.Core.Domain;
using ASMembershipSystem.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ASMembershipSystem.DataAccess.Tests
{
    public class SportRepositoryTests
    {
        [Fact]
        public void ShouldGetAllSports()
        {
            var options = new DbContextOptionsBuilder<ASMembershipContext>()
                              .UseInMemoryDatabase("ShouldGetAllSports")
                              .Options;

            var sports = GetTestSports();

            using(var context = new ASMembershipContext(options))
            {
                context.Sports.AddRange(sports);
                context.SaveChanges();
            }

            using (var context = new ASMembershipContext(options))
            {
                var sportRepository = new SportRepository(context);
                var result = sportRepository.GetAll();

                Assert.Equal(sports.Count, result.Count);
            }
        }

        private List<Sport> GetTestSports()
        {
            return new List<Sport>()
            {
                new Sport()
                {
                    Id = 1, 
                    Name = "Tennis",
                },
                new Sport()
                {
                    Id = 2,
                    Name = "Squash",
                },
                new Sport()
                {
                    Id = 3,
                    Name = "Football",
                },
            };
        }
    }
}
