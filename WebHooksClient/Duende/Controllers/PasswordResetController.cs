﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuendeWebHooksClient.Controllers;

[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]

[Route("api/[controller]")]
[ApiController]
public class PasswordResetController(ILogger<PasswordResetController> logger) : ControllerBase
{
    [Authorize("webhook")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PasswordResetResponse>> ResetPassword([FromBody] PasswordResetDTO dto, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Processing password reset for email: {Email}", dto.Email);
            
            // Process password reset asynchronously
            await Task.Delay(100, cancellationToken); // Simulating async work, replace with actual implementation

            return Ok(new PasswordResetResponse(Success: true));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to process password reset for {Email}", dto.Email);
            return Problem(
                title: "Password Reset Failed",
                detail: "An error occurred while processing your password reset request",
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
}

public sealed record PasswordResetDTO(
    [Required]
    [EmailAddress]
    string Email);

public sealed record PasswordResetResponse(
    bool Success,
    string? Error = null);
