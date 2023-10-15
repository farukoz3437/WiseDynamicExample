using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
                
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {


                string json = File.ReadAllText("appsettings.json");
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                string connectionString = jsonObj.ConnectionStrings.ConnStr.ToString();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<User> Users { get; set; }
    }
}
