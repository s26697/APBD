namespace kolos_próbny.DTOs;

public record PerscriptionListDTO(int IdPrescription, DateTime Date, DateTime DueDate, string PatientLastName, string DoctorLastName);