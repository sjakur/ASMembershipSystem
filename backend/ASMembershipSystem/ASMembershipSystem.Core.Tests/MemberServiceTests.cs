using ASMembershipSystem.Core.Contracts;
using ASMembershipSystem.Core.Domain;
using ASMembershipSystem.Core.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ASMembershipSystem.Core.Tests
{
    public class MemberServiceTests
    {
        private readonly Mock<IMemberRepository> _memberRepositoryMock;
        private readonly MemberService _memberService;

        public MemberServiceTests()
        {
            _memberRepositoryMock = new Mock<IMemberRepository>();
            _memberService = new MemberService(_memberRepositoryMock.Object);
        }

        [Fact]
        public void ShouldAddMember()
        {
            var member = new Member
            {
                Id = 1,
                FirstName = "Ronaldinho",
                LastName = "Gaucho"
            };

            Member savedMember = null;
            _memberRepositoryMock.Setup(x => x.Add(It.IsAny<Member>()))
                                 .Callback<Member>(m => savedMember = m);

            _memberService.AddMember(member);

            _memberRepositoryMock.Verify(x => x.Add(member), Times.Once);
            Assert.Equal(member, savedMember);
        }

        [Fact]
        public void ShouldGetMember()
        {
            var member = new Member
            {
                Id = 1,
                FirstName = "Ronaldinho",
                LastName = "Gaucho"
            };

            _memberRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                                 .Returns(member);

            var result = _memberService.GetMemberById(member.Id);

            _memberRepositoryMock.Verify(x => x.GetById(member.Id), Times.Once);

            Assert.Equal(member, result);
        }

        [Fact]
        public void ShouldGetAllMembers()
        {
            var members = new List<Member>
            {
                new Member(),
                new Member(),
                new Member()
            };

            _memberRepositoryMock.Setup(x => x.GetAll())
                     .Returns(members);

            var result = _memberService.GetAllMembers();

            Assert.Equal(members.Count, result.Count);
        }

        [Fact]
        public void ShouldUpdateMember()
        {
            var member = new Member
            {
                Id = 1,
                FirstName = "Ronaldinho",
                LastName = "Gaucho"
            };
            _memberRepositoryMock.Setup(x => x.Update(It.IsAny<Member>()));

            _memberService.UpdateMember(member);

            _memberRepositoryMock.Verify(x => x.Update(member), Times.Once);
        }
    }
}
