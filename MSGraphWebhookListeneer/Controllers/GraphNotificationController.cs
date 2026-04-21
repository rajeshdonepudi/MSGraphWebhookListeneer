using Microsoft.AspNetCore.Mvc;
using MSGraphWebhookListeneer.Models;

namespace MSGraphWebhookListeneer.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class GraphNotificationController : ControllerBase
    {
        private readonly ILogger<GraphNotificationController> _logger;

        public GraphNotificationController(ILogger<GraphNotificationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string? validationToken = null, [FromBody] GraphNotificationPayload? notifications = null)
        {
            // 1. Handle Microsoft Graph validation handshake
            if (!string.IsNullOrWhiteSpace(validationToken))
            {
                _logger.LogInformation("Received validation token: {Token}", validationToken);

                // Graph expects plain text response, not JSON
                return Content(validationToken, "text/plain");
            }

            // 2. Basic request logging
            var host = Request.Host;
            var referer = Request.Headers["Referer"].ToString();

            _logger.LogInformation(
                "Incoming notification | Host: {Host} | Port: {Port} | Referer: {Referer}",
                host.Host, host.Port, referer
            );

            // 3. Validate payload
            if (notifications?.Value == null || !notifications.Value.Any())
            {
                _logger.LogWarning("Received empty or invalid notification payload.");
                return BadRequest("Invalid payload");
            }

            // 4. Process notifications
            foreach (var notification in notifications.Value)
            {
                _logger.LogInformation(
                    "SubscriptionId: {SubscriptionId}, ChangeType: {ChangeType}, Resource: {Resource}, TenantId: {TenantId}",
                    notification.SubscriptionId,
                    notification.ChangeType,
                    notification.Resource,
                    notification.TenantId
                );

                if (notification.ResourceData != null)
                {
                    _logger.LogInformation(
                        "ResourceData Id: {Id}",
                        notification.ResourceData.Id
                    );
                }

                // TODO: Add actual business logic here (queue, db, processing, etc.)
            }

            // 5. Always respond quickly (Graph expects fast ACK)
            return Ok();
        }

    }
}
