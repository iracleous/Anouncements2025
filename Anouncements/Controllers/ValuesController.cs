using Anouncements.Factory;
using Anouncements.Singleton;
using Anouncements.Strategy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anouncements.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InfoController : ControllerBase
{
    private readonly IAppConfigService _config;
    private readonly INotifierFactory _notifierFactory;
    private readonly IPaymentStrategy _strategy;

    public InfoController(IAppConfigService config, INotifierFactory notifierFactory, IPaymentStrategy strategy)
    {
        _config = config;
        _notifierFactory = notifierFactory;
        _strategy = strategy;
    }

    [HttpGet("app-name")]
    public IActionResult GetAppName()
    {
        var name = _config.GetAppName(); // Lazy initializes here!
        return Ok(new { appName = name });
    }

    [HttpPost("notify/{type}")]
    public IActionResult Send(string type, [FromBody] string message)
    {
        try
        {
            var notifier = _notifierFactory.CreateNotifier(type);
            notifier.Send(message);
            return Ok("Notification sent.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("pay")]
    public IActionResult Pay()
    {
        try
        {
            _strategy.ProcessPayment(); // Uses the injected payment strategy
            return Ok("Payment processed successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
 
