namespace kolos_próbny.DTOs;


public record PerscriptionDTO(int IdPrescription, DateTime Date, DateTime DueDate, int IdPatient, int IdDoctor);
