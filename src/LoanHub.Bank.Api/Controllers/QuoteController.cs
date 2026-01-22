using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

using LoanHub.Bank.Application.DTOs;
using LoanHub.Bank.Application.Interfaces;

namespace LoanHub.Bank.Api.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class QuoteController : ControllerBase
{
    private readonly IQuoteService _quoteService;

    public QuoteController(IQuoteService quoteService)
    {
        _quoteService = quoteService;
    }

    [HttpPost]
    public async Task<ActionResult<QuoteResponseDto>> CreateQuote(CreateQuoteRequestDto request)
    {
        var result = await _quoteService.CreateQuoteAsync(request);

        return CreatedAtAction(nameof(GetQuote), new { version = "1", quoteId = result.QuoteId }, result);
    }

    [HttpGet("{quoteId}")]
    public async Task<ActionResult<QuoteResponseDto>> GetQuote(Guid quoteId)
    {
        var result = await _quoteService.GetQuoteAsync(quoteId);

        if (result == null) return NotFound();
        return Ok(result);
    }
}
