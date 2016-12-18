namespace TeamTProject.Models
{
    using System.Data.SqlClient;
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            SqlConnection conn = new SqlConnection("Model1");

            SqlCommand cmd = new SqlCommand("SELECT FirstName, Score FROM AspNetUsers ORDER BY Score DESC", conn);

            conn.Open();

            SqlDataReader query1 = cmd.ExecuteReader();

            while (query1.Read())
            {
                var player = new AspNetUser();
                player.FirstName = (string)query1["FirstName"];
                player.Score = (int)query1["Score"];

                
            }
            

            
              
            // query = Get(AspNetUser);

           // var db = Database.SqlQuery'(SELECT FirstName, Score FROM AspNetUsers ORDER BY Score DESC)';
           // var selectedData = db.sq("SELECT * FROM Movies");
           // var grid = new WebGrid(source: selectedData);
        }

        private object Get(AspNetUser aspNetUser)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Table>()
                .Property(e => e.user_name)
                .IsFixedLength();
        }
    }
}
