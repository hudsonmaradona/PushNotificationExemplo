using Microsoft.AspNetCore.Mvc;
using WebPush;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/notifications")]
public class NotificationsController : ControllerBase
{
    private static List<PushSubscription> _subscriptions = new List<PushSubscription>();

    private readonly VapidDetails _vapidDetails;

    public NotificationsController()
    {
        _vapidDetails = new VapidDetails
        {
            Subject = "mailto: <hudson.maradona@timesharesolucoes.com.br>",
            PublicKey = "BAotc24VpUP4sVtCBUBXRRmU2UOOmYnnyqDGDKmLyhkGteFBLnECGZLG14C3944luxsz__ApcLVEzemH9Isa0ns",  // Substitua pela sua chave pública
            PrivateKey = "dpgs-5g-fVGsiZj06og-fKzvTFb8oEG8Atr-B4ulDTc"  // Substitua pela sua chave privada
        };
    }

    [HttpPost("subscribe")]
    public IActionResult Subscribe([FromBody] PushSubscription subscription)
    {
        _subscriptions.Add(subscription);
        return Ok();
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] string message)
    {
        var webPushClient = new WebPushClient();

        foreach (var subscription in _subscriptions)
        {
            await webPushClient.SendNotificationAsync(subscription, message, _vapidDetails);
        }

        return Ok();
    }

    public class NotificationMessage
    {
        public string Body { get; set; }
    }
}
