using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TeamTProject.Models
{
    public class leaderboardModelContext : DbContext
    {
       public leaderboardModelContext() : base("leaderboardModelContext")
        {

        } 

        public DbSet<Score> Score { get; set; }

      //  protected override void OnModelCreating(DbModelBuilder modelBuilder)
      //  {
       //     modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
       // }
    }
}