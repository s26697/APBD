using próbne_kolokwium.DTOs;
using próbne_kolokwium.Enums;

namespace próbne_kolokwium.services;

public interface IPharmacyService
{
    Task<Errors> AddPrescription(PrescriptionInDTO prescriptionInDto);
    Task<PatientDataDTO> GetPatientData(int IdPatient);
}