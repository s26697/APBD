using System.ComponentModel.DataAnnotations;

namespace próbne_kolokwium.Models;

public class Medicament
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    [MaxLength(100)]
    [Required]
    public string Description { get; set; }
    [MaxLength(100)]
    [Required]
    public string Type { get; set; }
    
    public ICollection<Perscription_Medicament> PerscriptionMedicaments { get; set; }
    
}