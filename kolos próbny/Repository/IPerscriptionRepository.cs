using kolos_próbny.DTOs;

namespace kolos_próbny.Repository;

public interface IPerscriptionRepository
{
     Task<IEnumerable<PerscriptionListDTO>> GetPerscriptionsAsync(string firstName);
     Task<PerscriptionDTO> AddPerscriptionAsync(PerscriptionDTO prescription);
}