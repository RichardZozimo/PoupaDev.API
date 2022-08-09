using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Entities;

namespace PoupaDev.API.Percistence
{
    public class PoupaDevDbContext : DbContext
    {
        public DbSet<ObjetivoFinanceiro> Objetivos { get; set; }
        public PoupaDevDbContext(DbContextOptions<PoupaDevDbContext> options) : base(options){}
        
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<ObjetivoFinanceiro>(o => {
                o.HasKey(of => of.Id);

                o.Property(of => of.ValorObjetivo)
                    .HasColumnType("decimal(18,4)");

                o.HasMany(of => of.Operacoes)
                    .WithOne()
                    .HasForeignKey(op => op.ObjetivoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Operacao>(e => {
                e.HasKey(op => op.Id);
            });
        }
        
    }
}