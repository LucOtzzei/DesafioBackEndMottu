using Microsoft.AspNetCore.Mvc;
using OtzzeiDesafioMottu.Domain.Interfaces.IService;
using OtzzeiDesafioMottu.Domain.Requests;

namespace Otzzei.DesafioMottu.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental([FromBody] CreateRentalRequest request)
        {
            var rental = await _rentalService.CreateRentalAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = rental.Id }, rental);
        }

        [HttpPost("{id:guid}/finish")]
        public async Task<IActionResult> FinishRental(Guid id, [FromBody] FinishRentalRequest request)
        {
            var result = await _rentalService.FinishRentalAsync(id, request.ReturnDate);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rental = await _rentalService.GetByIdAsync(id);
            if (rental == null)
                return NotFound();

            return Ok(rental);
        }
    }
}