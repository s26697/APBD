using System.ComponentModel.DataAnnotations;

namespace próbne_kolokwium.Models;

public class Doctor
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }
    [MaxLength(100)]
    [Required]
    public string Email { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
}