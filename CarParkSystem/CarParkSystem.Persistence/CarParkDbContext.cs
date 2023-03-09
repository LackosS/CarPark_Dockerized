using CarParkSystem.Persistence.Records;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarParkSystem.Persistence
{
    public class CarParkDbContext : IdentityDbContext
    {
        public CarParkDbContext(DbContextOptions<CarParkDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //1-n Company Users
            modelBuilder.Entity<Company>().HasMany<User>(p => p.Users).WithOne(p => p.Company)
                .HasForeignKey(p => p.CompanyId);
            //1-n Company ParkingHouses
            modelBuilder.Entity<ParkingHouse>().HasOne(p => p.Company).WithMany(p => p.ParkingHouses)
                .HasForeignKey(p => p.CompanyId);
            //1-n ParkingHouse Levels
            modelBuilder.Entity<Level>().HasOne(p => p.ParkingHouse).WithMany(p => p.Levels)
                .HasForeignKey(p => p.ParkingHouseId);
            //1-n Level Slots
            modelBuilder.Entity<Slot>().HasOne(p => p.Level).WithMany(p => p.Slots).HasForeignKey(p => p.LevelId);
            //1-n User Reservation
            modelBuilder.Entity<Reservation>().HasOne(p => p.User).WithMany(p => p.Reservations)
                .HasForeignKey(p => p.UserId);
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ParkingHouse> ParkingHouse { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Slot> Slot { get; set; }
        public DbSet<Reservation> Reservation { get; set; }        
    }
}
