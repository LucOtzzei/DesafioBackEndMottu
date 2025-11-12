using Microsoft.AspNetCore.Mvc;
using OtzzeiDesafioMottu.Domain.Interfaces.IService;
using OtzzeiDesafioMottu.Domain.Requests;

namespace Otzzei.DesafioMottu.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryManController : ControllerBase
    {
        private readonly IDeliveryManService _deliveryManService;
        private readonly IFileService _fileService;
        public DeliveryManController(IDeliveryManService deliveryManService, IFileService fileService)
        {
            _deliveryManService = deliveryManService;
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeliveryManRequest request)
        {
            var driver = await _deliveryManService.CreateAsync(request);
            return CreatedAtAction(nameof(GetByCnpj), new { cnpj = driver.Cnpj }, driver);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _deliveryManService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{deliveryManCnpj}")]
        public async Task<IActionResult> GetByCnpj(string deliveryManCnpj)
        {
            var deliveryMan = await _deliveryManService.GetByCnpjAsync(deliveryManCnpj);
            if (deliveryMan == null)
                return NotFound();
            return Ok(deliveryMan);
        }

        [HttpPut("{id}/update-cnh-image")]
        public async Task<IActionResult> UpdateCnhImage(Guid id, IFormFile cnhImage)
        {
            if (cnhImage == null) return BadRequest("Image file is required.");

            var filePath = await _fileService.SaveAsync(cnhImage.OpenReadStream(), cnhImage.FileName);
            var request = new UpdateCnhImageRequest { DeliverymanId = id, CnhImagePath = filePath };

            await _deliveryManService.UpdateCnhImageAsync(id, request);
            return Ok("CNH image updated successfully.");
        }


    }
}
