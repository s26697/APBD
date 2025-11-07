using próbne_kolokwium.DTOs;
using próbne_kolokwium.Enums;

namespace próbne_kolokwium.repositories;

public interface IPharmacyRepository
{
    Task<bool> DoesPatientExist(int idPatient);
    Task<Errors> AddPatient(PatientDTO patientDto);
    
    Task<bool> DoesMedicamentExist(int idMedicament);
    
    Task<int> AddPrescription(PrescriptionInDTO prescriptionInDto);
    
    Task<Errors> AddPrescriptionMedicament(PrescriptionMedicamentDTO prescriptionMedicamentDto);
    
    Task<PatientDataDTO> GetPatientData(int IdPatient);
}