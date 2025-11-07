using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace próbne_kolokwium.Models.Configuration;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasData(
            new Doctor
            {
                Id = 1,
                FirstName = "john",
                LastName = "doe",
                Email = "yahoo",
                
            }
        );
    }
}