using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECAN_CRF.Context
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }

        public DbSet<ECAN_CRF.Models.Centers> centes { get; set; }
        public DbSet<ECAN_CRF.Models.Events> events { get; set; }
        public DbSet<ECAN_CRF.Models.Schools> schools { get; set; }
        public DbSet<ECAN_CRF.Models.Sponsers> sponsers { get; set; }
        public DbSet<ECAN_CRF.Models.Studens> studens { get; set; }
        public DbSet<ECAN_CRF.Models.Users> Users { get; set; }
    }
}
