using System.ComponentModel.DataAnnotations;

namespace próbne_kolokwium.Models;

public class Patient
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public DateTime Birthdate { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
}