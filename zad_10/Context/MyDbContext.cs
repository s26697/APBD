using Microsoft.EntityFrameworkCore;
using próbne_kolokwium.Models;
using próbne_kolokwium.Models.Configuration;

namespace próbne_kolokwium.Context;

public class MyDbContext : DbContext
{
    public MyDbContext()
    {
        
    }
    
    public MyDbContext(DbContextOptions< MyDbContext> options)
        : base(options)
    {
       
    }
    
    //definicja tabel dla contextu
    
    public DbSet<Doctor> Doctors { get; set; }
    
    public DbSet<Patient> Patients { get; set; }
    
    public DbSet<Prescription> Prescriptions { get; set; }
    
    public DbSet<Medicament> Medicaments { get; set; }
    
    public DbSet<Perscription_Medicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Perscription_Medicament>().HasKey(pm => new { pm.IdPrescription, pm.IdMedicament });
        
        
        
        
        
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());

        
    }
    
}