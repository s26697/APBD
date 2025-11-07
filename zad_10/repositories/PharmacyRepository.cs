using Microsoft.EntityFrameworkCore;
using próbne_kolokwium.Context;
using próbne_kolokwium.DTOs;
using próbne_kolokwium.Enums;
using próbne_kolokwium.Models;

namespace próbne_kolokwium.repositories;

public class PharmacyRepository : IPharmacyRepository
{
    private readonly MyDbContext _dbContext;

    public PharmacyRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<bool> DoesPatientExist(int idPatient)
    {
        bool result;

        result = await _dbContext.Patients.AnyAsync(x => x.Id == idPatient);

        return result;
    }

    public async Task<Errors> AddPatient(PatientDTO patientDto)
    {
        var newPatient = new Patient
        {
            Id = patientDto.IdPatient,
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            Birthdate = patientDto.BirthDate
        };

        await _dbContext.Patients.AddAsync(newPatient);
        await _dbContext.SaveChangesAsync();

        return Errors.Good;

    }

    public async Task<bool> DoesMedicamentExist(int idMedicament)
    {
        bool result = await _dbContext.Medicaments.AnyAsync(x => x.Id == idMedicament);
        ;

        return result;
    }

    public async Task<int> AddPrescription(PrescriptionInDTO prescriptionInDto)
    {
        int idPrescription;

        var newPrescription = new Prescription
        {
            Date = prescriptionInDto.Date,
            DueDate = prescriptionInDto.DueDate,
            IdPatient = prescriptionInDto.patient.IdPatient,
            IdDoctor = prescriptionInDto.IdDoctor
        };

        await _dbContext.Prescriptions.AddAsync(newPrescription);
        await _dbContext.SaveChangesAsync();

        idPrescription = newPrescription.IdPrescription;

        return idPrescription;
    }

    public async Task<Errors> AddPrescriptionMedicament(PrescriptionMedicamentDTO prescriptionMedicamentDto)
    {
        var newPrescriptionMedicament = new Perscription_Medicament
        {
            IdMedicament = prescriptionMedicamentDto.IdMedicament,
            IdPrescription = prescriptionMedicamentDto.IdPrescription,
            Dose = prescriptionMedicamentDto.Dose,
            Details = prescriptionMedicamentDto.Details
        };

        await _dbContext.PrescriptionMedicaments.AddAsync(newPrescriptionMedicament);
        await _dbContext.SaveChangesAsync();

        return Errors.Good;
    }

    public async Task<PatientDataDTO> GetPatientData(int IdPatient)
    {
        var patient = await _dbContext.Patients
            .AsNoTracking() // Assuming this data is read-only
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.PerscriptionMedicaments)
            .ThenInclude(pm => pm.Medicaments)
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.Doctors)
            .FirstOrDefaultAsync(p => p.Id == IdPatient);

        if (patient != null)
        {
            var patientDataDto = new PatientDataDTO
            (
                Patient: new PatientDTO(patient.Id, patient.FirstName, patient.LastName, patient.Birthdate),
                Prescriptions: patient.Prescriptions
                    .OrderBy(p => p.DueDate)
                    .Select(p => new PrescriptionOutDTO
                    (
                        IdPrescription: p.IdPrescription,
                        Date: p.Date,
                        DueDate: p.DueDate,
                        Medicaments: p.PerscriptionMedicaments.Select(pm => new MedicamentDTO
                        (
                            IdMedicament: pm.Medicaments.Id,
                            Dose: pm.Dose,
                            Description: pm.Medicaments.Description
                        )).ToList(),
                        Doctor: new DoctorDTO
                        (
                            p.Doctors.Id,
                            p.Doctors.FirstName
                        )
                    )).ToList()
            );

            return patientDataDto;
        }

        return null; // Or handle the case where the patient is not found appropriately
    }
}