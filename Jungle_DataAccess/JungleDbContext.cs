﻿using Jungle_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jungle_DataAccess 
{
    public class JungleDbContext : IdentityDbContext<ApplicationUser>
    {
        public JungleDbContext(DbContextOptions<JungleDbContext> options) : base(options)
        {

        }

        public DbSet<Guide> Guide { get; set; }
        public DbSet<Travel> Travel { get; set; }
        public DbSet<TravelRecommendation> TravelRecommendation { get; set; }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<Country> Country { get; set; }
        

        public DbSet<ApplicationUser> Users { get; set; }

    }
}
