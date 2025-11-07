using kolos_próbny.DTOs;
using kolos_próbny.Services;

using Microsoft.AspNetCore.Mvc;

namespace kolos_próbny.Controllers;


[Route("api/[controller]")]
[ApiController]



public class PerscripcionController : ControllerBase
{
    private IPerscriptionService _perscriptionService;

    PerscripcionController(IPerscriptionService perscriptionService)
    {

        _perscriptionService = perscriptionService;
    }

    [HttpGet]
    public async Task<IActionResult> getPerscriptions(string Lastname = "none")
    {
        var perscriptions = await _perscriptionService.GetPerscriptions(Lastname);

        return Ok(perscriptions);
    }

    [HttpPost]
    public async Task<IActionResult> AddPerscription(PerscriptionDTO prescription)
    {
        var result = await _perscriptionService.AddPerscription(prescription);
        
        if (result == null)
            return StatusCode(StatusCodes.Status400BadRequest);
        return Ok(result);
        
    }
    


}