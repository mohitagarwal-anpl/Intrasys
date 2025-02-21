
namespace KudosityMessaging.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KudosityMessageController : ControllerBase
{
    private readonly KudosityService _kudosityService;

    public KudosityMessageController(KudosityService kudosityService)
    {
        _kudosityService = kudosityService;
    }

    // Endpoint to send a message
    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
    {
        var result = await _kudosityService.SendMessageAsync(request.To, request.Message).ConfigureAwait(false);

        if (result)
        {
            return Ok("Message sent successfully.");
        }

        return BadRequest("Failed to send message.");
    }

    // Endpoint to receive messages (webhook)
    [HttpPost("receive")]
    public async Task<IActionResult> ReceiveMessage([FromBody] WebhookPayload payload)
    {
        var result = await _kudosityService.ReceiveMessageAsync(JsonSerializer.Serialize(payload)).ConfigureAwait(false);
        return Ok(result);
    }
}
