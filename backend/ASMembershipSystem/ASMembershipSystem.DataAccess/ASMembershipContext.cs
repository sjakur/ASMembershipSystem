using ASMembershipSystem.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASMembershipSystem.DataAccess
{
    public class ASMembershipContext : DbContext
    {
        public ASMembershipContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<MemberSport> MemberSports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            modelBuilder.Entity<MemberSport>()
                .HasKey(ms => new { ms.MemberId, ms.SportId });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sport>().HasData(
              new Sport { Id = 1, Name = "Squash" },
              new Sport { Id = 2, Name = "Tennis" },
              new Sport { Id = 3, Name = "Football" }
            );

            modelBuilder.Entity<Member>().HasData(
               new Member { Id = 1, FirstName = "Mohd", LastName = "El Shorbagy" },
               new Member { Id = 2, FirstName = "Rafael", LastName = "Nadal"},
               new Member { Id = 3, FirstName = "Ronaldinho", LastName = "Gaucho"}
            );  

            modelBuilder.Entity<MemberSport>().HasData(
               new MemberSport { MemberId = 1, SportId = 1 },
               new MemberSport { MemberId = 2, SportId = 2 },
               new MemberSport { MemberId = 3, SportId = 3 }
            );
        }
    }
}