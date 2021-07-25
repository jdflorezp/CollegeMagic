using CollegeApi.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApi.Repository.EF.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<TblInscription> TblInscription { get; set; }
        public virtual DbSet<TblCandidateHouse> TblCandidateHouse { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblInscription>(entity =>
            {
                entity.ToTable("TblInscription", "dbo");
            });
            modelBuilder.Entity<TblCandidateHouse>(entity =>
            {
                entity.ToTable("TblCandidateHouse", "dbo");
            });
        }
      
        
    }
}


