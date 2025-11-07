using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace próbne_kolokwium.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
    
    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }
    
    [ForeignKey(nameof(IdPatient))]
    public Patient Patients { get; set; }
    
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctors { get; set; }
    
    public ICollection<Perscription_Medicament> PerscriptionMedicaments { get; set; }
}