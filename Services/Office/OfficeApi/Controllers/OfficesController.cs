using Microsoft.AspNetCore.Mvc;
using OfficeApi.Application.DTOs;
using OfficeApi.Application.Services;
using FluentValidation;

namespace OfficeApi.Controllers;

// контроллер который отвечает за ресурс Office. он занимается HTTP
[ApiController] // атрибут - добавляет дополнительное поведение/метаданные к классу 
[Route("api/[controller]")]
public class OfficesController : ControllerBase
{
    private readonly OfficeService _officeService;
    private readonly IValidator<CreateOfficeRequest> _validator;
    public OfficesController(OfficeService officeService, IValidator<CreateOfficeRequest> validator)
    {
        _officeService = officeService;
        _validator = validator;
    }

    [HttpGet] // атрибут - который добавяет HTTP GET
    public async Task<ActionResult<List<OfficeResponse>>> GetAll()
    {
        var offices = await _officeService.GetAllAsync();
        return Ok(offices);
    }

    [HttpPost]
    public async Task<ActionResult<OfficeResponse>> Create(CreateOfficeRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var office = await _officeService.CreateAsync(request);
        return Ok(office);
    }
}