﻿using Health3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Health3.Data;

public class ApplicationDbContext : IdentityDbContext
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor) // Relation vers Doctor
            .WithMany()            // Pas de navigation inverse
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade); // Comportement en cas de suppression
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    

}
