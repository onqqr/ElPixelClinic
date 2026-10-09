using Microsoft.AspNetCore.Mvc;
using OfficeApi.Application.DTOs;
using OfficeApi.Application.Services;
using FluentValidation;
using OfficeApi.Domain.Enums;

namespace OfficeApi.Controllers;

[ApiController]
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

    [HttpGet]
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
        return CreatedAtAction(
            nameof(GetById),
            new { id = office.Id },
            office);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OfficeResponse>> GetById(Guid id)
    {
        var office = await _officeService.GetByIdAsync(id);
        if (office is null)
        {
            return NotFound();
        }
        return Ok(office);
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<ActionResult<OfficeResponse>> ChangeStatus(
        Guid id,
        ChangeOfficeStatusRequest request)
    {
        if (!Enum.IsDefined(typeof(OfficeStatus), request.Status))
        {
            return BadRequest("invalid office status");
        }

        var office = await _officeService.ChangeStatusAsync(id, request);
        if (office is null)
        {
            return NotFound();
        }
        return Ok(office);
    }
}