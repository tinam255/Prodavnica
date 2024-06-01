using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Prodavnica.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<dobavljaci> dobavljacis { get; set; }
        public virtual DbSet<kategorije> kategorijes { get; set; }
        public virtual DbSet<proizvodi> proizvodis { get; set; }
        public virtual DbSet<proizvodjaci> proizvodjacis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dobavljaci>()
                .Property(e => e.dobavljac)
                .IsUnicode(false);

            modelBuilder.Entity<dobavljaci>()
                .HasMany(e => e.proizvodis)
                .WithOptional(e => e.dobavljaci)
                .HasForeignKey(e => e.dob_id);

            modelBuilder.Entity<kategorije>()
                .Property(e => e.kategorija)
                .IsUnicode(false);

            modelBuilder.Entity<kategorije>()
                .HasMany(e => e.proizvodis)
                .WithOptional(e => e.kategorije)
                .HasForeignKey(e => e.kat_id);

            modelBuilder.Entity<proizvodi>()
                .Property(e => e.naziv)
                .IsUnicode(false);

            modelBuilder.Entity<proizvodjaci>()
                .Property(e => e.proizvodjac)
                .IsUnicode(false);

            modelBuilder.Entity<proizvodjaci>()
                .HasMany(e => e.proizvodis)
                .WithOptional(e => e.proizvodjaci)
                .HasForeignKey(e => e.pr_id);
        }
    }
}
