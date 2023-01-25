﻿using AntalyaTaksiAccount.Models;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
