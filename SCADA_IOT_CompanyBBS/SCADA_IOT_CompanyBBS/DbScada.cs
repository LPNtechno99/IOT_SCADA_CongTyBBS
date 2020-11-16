using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SCADA_IOT_CompanyBBS.Models;

namespace SCADA_IOT_CompanyBBS
{
    public class DbScadaContext : DbContext
    {
        public DbSet<CacCaLamViec> CacCaLamViec { get; set; }
        public DbSet<ThoiGianChayMay01> ThoiGianChayMay01 { get; set; }
        public DbSet<ThoiGianDungMay01> ThoiGianDungMay01 { get; set; }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DBScadaIOT.db");
        }
    }
}
