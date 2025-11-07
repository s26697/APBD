namespace próbne_kolokwium.DTOs;

public record PatientDataDTO(PatientDTO Patient, List<PrescriptionOutDTO> Prescriptions);