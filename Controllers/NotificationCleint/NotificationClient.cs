using BloggerBits.DTOS.Requests;
using BloggerBits.Services.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggerBits.Controllers.NotificationCleint
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationClient : ControllerBase
    {
        private readonly INotificationClientGrpcService _ncgs;
        public NotificationClient(INotificationClientGrpcService ncgs)
        {
            _ncgs = ncgs;
            
        } 
        [HttpPost]
        public Task<IActionResult> PushNotification(NotificationsRequest request)
        {
            var res = _ncgs.PushNotificationAsync(request);
            return null;
        }
    }
}
