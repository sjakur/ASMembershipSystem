using ASMembershipSystem.Core.Domain;
using ASMembershipSystem.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ASMembershipSystem.DataAccess.Tests
{
    public class MemberRepositoryTests
    {
        [Fact]
        public void ShouldSaveMember()
        {
            var member = new Member
            {
                Id = 1,
                FirstName = "Ronaldinho",
                LastName = "Gaucho",
                MemberSports = new List<MemberSport>
                {
                    new MemberSport
                    {
                        MemberId = 1,
                        SportId = 1
                    }
                }
            };

            var options = new DbContextOptionsBuilder<ASMembershipContext>()
                            .UseInMemoryDatabase("ShouldSaveMember")
                            .Options;

            using (var context = new ASMembershipContext(options))
            {
                context.Sports.AddRange(GetTestSports());
                context.SaveChanges();
                var memberRepository = new MemberRepository(context);
                memberRepository.Add(member);
            }

            using (var context = new ASMembershipContext(options))
            {
                var memberRepository = new MemberRepository(context);
                var result = memberRepository.GetById(member.Id);

                Assert.Equal(member.FirstName, result.FirstName);
                Assert.Equal(member.LastName, result.LastName);
                Assert.Single(result.MemberSports);
            }
        }

        [Fact]
        public void ShouldGetAllMembers()
        {
            var members = new List<Member>
            {
                new Member
                {
                    Id = 1,
                    FirstName = "Ronaldinho",
                    LastName = "Gaucho",
                    MemberSports = new List<MemberSport>
                    {
                        new MemberSport
                        {
                            MemberId = 1,
                            SportId = 1
                        }
                    }
                },
                new Member
                {
                    Id = 2,
                    FirstName = "Ronaldinho",
                    LastName = "Gaucho",
                    MemberSports = new List<MemberSport>
                    {
                        new MemberSport
                        {
                            MemberId = 1,
                            SportId = 1
                        }
                    }
                }
            };
            var options = new DbContextOptionsBuilder<ASMembershipContext>()
                            .UseInMemoryDatabase("ShouldGetAllMembers")
                            .Options;

            using (var context = new ASMembershipContext(options))
            {
                context.Sports.AddRange(GetTestSports());
                context.SaveChanges();
                var memberRepository = new MemberRepository(context);
                foreach (var member in members)
                {
                    memberRepository.Add(member);
                }
            }

            using (var context = new ASMembershipContext(options))
            {
                var memberRepository = new MemberRepository(context);

                var result = memberRepository.GetAll();

                Assert.Equal(2, result.Count);
            }
        }

        [Fact]
        public void ShouldUpdateMember()
        {
            var member = new Member
            {
                Id = 1,
                FirstName = "Ronaldinho",
                LastName = "Gaucho",
                MemberSports = new List<MemberSport>
                {
                    new MemberSport
                    {
                        MemberId = 1,
                        SportId = 1
                    }
                }
            };

            var options = new DbContextOptionsBuilder<ASMembershipContext>()
                            .UseInMemoryDatabase("ShouldUpdateMember")
                            .Options;

            using (var context = new ASMembershipContext(options))
            {
                context.Sports.AddRange(GetTestSports());
                context.SaveChanges();
                var memberRepository = new MemberRepository(context);
                memberRepository.Add(member);
            }

            using (var context = new ASMembershipContext(options))
            {
                var memberRepository = new MemberRepository(context);
                member.FirstName = "Mo";
                member.LastName = "Salah";
                member.MemberSports.First().SportId = 2;

                memberRepository.Update(member);
                var result = memberRepository.GetById(member.Id);

                Assert.Equal("Mo", result.FirstName);
                Assert.Equal("Salah", result.LastName);
                Assert.Equal("Tennis", result.MemberSports.First().Sport.Name);
            }
        }

        private List<Sport> GetTestSports()
        {
            return new List<Sport>
            {
              new Sport { Id = 1, Name = "Squash" },
              new Sport { Id = 2, Name = "Tennis" },
              new Sport { Id = 3, Name = "Football" }
            };
        }
    }
}
