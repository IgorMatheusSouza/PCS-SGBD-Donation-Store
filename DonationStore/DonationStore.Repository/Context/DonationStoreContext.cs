﻿using DonationStore.Domain.Enities;
using DonationStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DonationStore.Repository.Context
{
    public class DonationStoreContext : IdentityDbContext<User, AspNetRoles, string>
    {
        public DonationStoreContext(DbContextOptions<DonationStoreContext> options) : base(options)
        {

        }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<DonationImage> DonationImages { get; set; }

        public DbSet<DonationAcquisition> DonationAcquisition { get; set; }
    }
}