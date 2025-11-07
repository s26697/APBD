using kolos_próbny.DTOs;
using kolos_próbny.Models;
namespace kolos_próbny.Services;

public interface IPerscriptionService
{
     public Task<IEnumerable<PerscriptionListDTO>> GetPerscriptions(string firstName);


     public Task<PerscriptionDTO> AddPerscription(PerscriptionDTO prescription);

}