using kolos_próbny.Repository;
using kolos_próbny.DTOs;

namespace kolos_próbny.Services;

public class PerscriptionService : IPerscriptionService
{
    private readonly IPerscriptionRepository _perscriptionRepository;

    public PerscriptionService(IPerscriptionRepository perscriptionRepository)
    {
        _perscriptionRepository = perscriptionRepository;
    }


    public  async Task<IEnumerable<PerscriptionListDTO>> GetPerscriptions(string lastName)
    {
        return await _perscriptionRepository.GetPerscriptionsAsync(lastName);
    }

    public  async Task<PerscriptionDTO> AddPerscription(PerscriptionDTO prescription)
    {
        if (prescription.DueDate <= prescription.Date)
            return null;
        return await _perscriptionRepository.AddPerscriptionAsync(prescription);
    }
    
    
}