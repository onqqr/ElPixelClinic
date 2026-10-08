using Microsoft.AspNetCore.Mvc;
using OfficeApi.Application.DTOs;
using OfficeApi.Application.Services;
using OfficeApi.Domain.Entities;

namespace OfficeApi.Controllers;

// контроллер который отвечает за ресурс Office. он занимается HTTP
[ApiController] // атрибут - добавляет дополнительное поведение/метаданные к классу 
[Route("api/[controller]")]
public class OfficesController : ControllerBase
{
    private readonly OfficeService _officeService;
    public OfficesController(OfficeService officeService)
    {
        _officeService = officeService;
    }

    [HttpGet] // атрибут - который добавяет HTTP GET
    public async Task<ActionResult<List<OfficeResponse>>> GetAll()
    {
        var offices = await _officeService.GetAllAsync();
        return Ok(offices);
    }
}