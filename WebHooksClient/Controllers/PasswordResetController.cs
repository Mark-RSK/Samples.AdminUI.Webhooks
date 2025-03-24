using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebHooksClient.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PasswordResetController : ControllerBase
{
    private readonly ILogger<PasswordResetController> _logger;

    public PasswordResetController(ILogger<PasswordResetController> logger)
    {
        _logger = logger;
    }

    [Authorize("webhook")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PasswordResetResponse>> PasswordReset([FromBody] PasswordResetDTO dto)
    {
        try
        {
            _logger.LogInformation("Processing password reset for email: {Email}", dto.Email);
            
            // Process password reset asynchronously
            await Task.Delay(100); // Simulating async work, replace with actual implementation

            return Ok(new PasswordResetResponse { Success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing password reset");
            return BadRequest(new PasswordResetResponse 
            { 
                Success = false, 
                Error = "Failed to process password reset" 
            });
        }
    }
}

public class PasswordResetDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}

public class PasswordResetResponse
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}