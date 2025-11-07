namespace próbne_kolokwium.DTOs;

public record PrescriptionOutDTO(int IdPrescription, DateTime Date, DateTime DueDate, List<MedicamentDTO> Medicaments, DoctorDTO Doctor);