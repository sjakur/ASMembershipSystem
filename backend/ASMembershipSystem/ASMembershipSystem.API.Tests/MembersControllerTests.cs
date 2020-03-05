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
    public class MembersControllerTests
    {
        private readonly Mock<IMemberService> _memberServiceMock;
        private readonly MembersController _membersController;

        public MembersControllerTests()
        {
            _memberServiceMock = new Mock<IMemberService>();
            _membersController = new MembersController(_memberServiceMock.Object);
        }

        [Fact]
        public void Get_ReturnsAllMembers()
        {
            var members = GetTestMembers();
            _memberServiceMock.Setup(x => x.GetAllMembers())
                              .Returns(members);

            var actionResult = _membersController.GetAllMembers();

            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var objectResultValue = Assert.IsAssignableFrom<List<MemberDto>>(objectResult.Value);
            Assert.Equal(members.Count, objectResultValue.Count);
        }

        [Fact]
        public void Get_ReturnsSingleMember()
        {
            var member = new Member
            {
                Id = 1,
                FirstName = "Player",
                LastName = "One",
                MemberSports = new List<MemberSport>
                {
                    new MemberSport
                    {
                        MemberId = 1,
                        SportId = 1,
                        Sport = new Sport
                        {
                            Id = 1,
                            Name = "Squash"
                        }
                    }
                }
            };

            _memberServiceMock.Setup(x => x.GetMemberById(It.IsAny<int>()))
                   .Returns(member);

            var actionResult = _membersController.GetMember(member.Id);

            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var objectResultValue = Assert.IsAssignableFrom<MemberDetailDto>(objectResult.Value);
            Assert.Equal(member.Id, objectResultValue.Id);
            Assert.Equal(member.MemberSports.Count, objectResultValue.Sports.Count);
        }

        [Fact]
        public void Get_ReturnsNotFound_WhenMemberDoesNotExist()
        {
            _memberServiceMock.Setup(x => x.GetMemberById(It.IsAny<int>()))
                               .Returns((Member)null);

            var actionResult = _membersController.GetMember(1);

            Assert.IsType<NotFoundResult>(actionResult.Result);
        }


        [Fact]
        public void Post_ReturnsCreatedMember()
        {
            var member = new MemberDetailDto
            {
                Id = 1,
                FirstName = "Player",
                LastName = "One",
                Sports = new List<SportDto>
                {
                    new SportDto
                    {
                        Id = 1,
                        Name = "Squash"
                    }
                }
            };

            _memberServiceMock.Setup(x => x.AddMember(It.IsAny<Member>()))
                              .Callback<Member>(m => m.Id = member.Id);

            var actionResult = _membersController.PostMember(member);

            var objectResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var objectResultValue = Assert.IsAssignableFrom<MemberDto>(objectResult.Value);
            Assert.Equal(member.Id, objectResultValue.Id);
            Assert.Equal(member.FirstName, objectResultValue.FirstName);
            Assert.Equal(member.LastName, objectResultValue.LastName);
        }

        [Fact]
        public void Put_ReturnsNoContent()
        {
            var member = new MemberDetailDto
            {
                Id = 1,
                FirstName = "Player",
                LastName = "One",
                Sports = new List<SportDto>
                {
                    new SportDto
                    {
                        Id = 1,
                        Name = "Squash"
                    }
                }
            };

            _memberServiceMock.Setup(x => x.GetMemberById(It.IsAny<int>()))
                              .Returns(new Member());
            _memberServiceMock.Setup(x => x.UpdateMember(It.IsAny<Member>()));

            var actionResult = _membersController.PutMember(member.Id, member);

            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public void Put_ReturnsNotFound_WhenMemberDoesNotExist()
        {
            var member = new MemberDetailDto
            {
                Id = 1,
                FirstName = "Player",
                LastName = "One",
                Sports = new List<SportDto>
                {
                    new SportDto
                    {
                        Id = 1,
                        Name = "Squash"
                    }
                }
            };

            _memberServiceMock.Setup(x => x.GetMemberById(It.IsAny<int>()))
                               .Returns((Member)null);

            var actionResult = _membersController.PutMember(member.Id, member);

            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public void Put_ReturnsBadRequest_WhenIdsDoNotMatch()
        {
            var member = new MemberDetailDto
            {
                Id = 1,
                FirstName = "Player",
                LastName = "One",
                Sports = new List<SportDto>
                {
                    new SportDto
                    {
                        Id = 1,
                        Name = "Squash"
                    }
                }
            };

            var actionResult = _membersController.PutMember(2, member);

            Assert.IsType<BadRequestResult>(actionResult);
        }

        private List<Member> GetTestMembers()
        {
            return new List<Member>
            {
                new Member
                {
                    Id = 1,
                    FirstName = "Player",
                    LastName = "One"
                },
                new Member
                {
                    Id = 2,
                    FirstName = "Player",
                    LastName = "Two"
                },
                new Member
                {
                    Id = 3,
                    FirstName = "Player",
                    LastName = "Three"
                }
            };
        }
    }
}
