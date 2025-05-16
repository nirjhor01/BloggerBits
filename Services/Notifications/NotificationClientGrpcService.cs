using System;
using System.Threading.Channels;
using AutoMapper.Configuration.Annotations;
using BloggerBits.DTOS.Requests;
using BloggerBits.Grpc;
using Grpc.Net.Client;

namespace BloggerBits.Services.Notifications;

public class NotificationClientGrpcService : INotificationClientGrpcService
{
    private readonly GrpcChannel _channel;
    private readonly NotificationService.NotificationServiceClient _client;
    public NotificationClientGrpcService()
    {
        _channel = GrpcChannel.ForAddress("http://localhost:5000");
        _client = new NotificationService.NotificationServiceClient(_channel);
    }
    public Task<bool> PushNotificationAsync(NotificationsRequest request)
    {
        var req = new NotificationRequest()
        {
            Title = request.Title,
            Message = request.Message,
            UserId = request.UserId
        };

        try
        {
            var result = _client.CreatePushNotification(req);
            var res = result;
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
}
