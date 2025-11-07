namespace próbne_kolokwium.DTOs;

public record PrescriptionMedicamentDTO(int IdMedicament, int IdPrescription, int? Dose, string Details);