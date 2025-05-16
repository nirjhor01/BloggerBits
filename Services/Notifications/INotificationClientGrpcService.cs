using System;
using BloggerBits.DTOS.Requests;

namespace BloggerBits.Services.Notifications;

public interface INotificationClientGrpcService
{
    Task<bool> PushNotificationAsync(NotificationsRequest request);

}
