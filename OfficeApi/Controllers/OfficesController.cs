using Microsoft.AspNetCore.Mvc;

namespace OfficeApi.Controllers;

// контроллер который отвечает за ресурс Office. он занимается HTTP
[ApiController] // атрибут - добавляет дополнительное поведение/метаданные к классу 
[Route("api/[controller]")]
public class OfficesController : ControllerBase
{
    [HttpGet] // атрибут - который добавяет HTTP GET
    public IActionResult GetAll()
    {
        // GET /api/offices
        return Ok("office api works");
    }
}