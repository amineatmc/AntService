using AntalyaTaksiAccount.Models;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class AntTaksiContextDb : DbContext
    {
        //192.168.101.3LAPTOP-SN3MKSFL //Trusted_Connection=True;MultipleActiveResultSets=true User Id=sa; Password=300881_?;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=192.168.101.3; Database=patronDB; User Id=sa; Password=300881_?;");
            optionsBuilder.UseSqlServer(@"Server=192.168.2.62;Database=ATAccountDB;User Id=sa;Password=Bilge03!;TrustServerCertificate=True");
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

    }
}
