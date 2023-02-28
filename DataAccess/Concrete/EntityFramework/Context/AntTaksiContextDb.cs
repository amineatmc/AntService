using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class AntTaksiContextDb : DbContext
    {
        //192.168.101.3LAPTOP-SN3MKSFL //Trusted_Connection=True;MultipleActiveResultSets=true User Id=sa; Password=300881_?;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              optionsBuilder.UseSqlServer(@"Server=tcp:taxi7x24-mssql-prod.database.windows.net,1433;Initial Catalog=Taxi7x24_db_Prod;Persist Security Info=False;User ID=ipos;Password=XGh:r2!7ZUv*BU:r;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserALL>().HasNoKey().ToView(null);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverVehicle> DriverVehicles { get; set; }
        public DbSet<VehicleOwner> VehicleOwners { get; set; }
        public DbSet<AllUser> AllUsers { get; set; }
        public DbSet<Boundary> Boundarys { get; set; }
        public DbSet<TravelHistory> TravelHistories { get; set; }
        public DbSet<DriverRequest>DriverRequests { get; set; }
        public DbSet<PassengerRequest>PassengerRequests { get; set; }
        public DbSet<StationRequest>StationRequests { get; set; }
        public DbSet<PaymentType> PaymentTypes{ get; set; }
        public DbSet<Reservation> Reservations{ get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<StationVehicle> StationVehicles { get; set; }
        public DbSet<Voip> Voips { get; set; }
        public DbSet<UserALL> UserALL { get; set; }
        public DbSet<VehicleOwnerVehicle> VehicleOwnerVehicles{ get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<CancelText> CancelTexts { get; set; }
        public DbSet<DriverCancelTravel> DriverCancelTravels { get; set;}
        public DbSet<PassengerCancelTravel> PassengerCancelTravels { get; set;}
        
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<PermitImage> PermitImages{ get; set; }
    }
}
