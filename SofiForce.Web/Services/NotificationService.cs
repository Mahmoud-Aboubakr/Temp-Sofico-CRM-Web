using CorePush.Google;
using Microsoft.Extensions.Options;
using Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static Models.FirebaseGoogleNotification;

namespace SofiForce.Web.Services
{
    public interface INotificationService
    {
        Task<FirebaseResponseModel> SendNotification(FirebaseNotificationModel notificationModel);
    }

    public class NotificationService : INotificationService
    {
        private readonly FcmNotificationSetting _fcmNotificationSetting;
        public NotificationService(IOptions<FcmNotificationSetting> settings)
        {
            _fcmNotificationSetting = settings.Value;
        }

        public async Task<FirebaseResponseModel> SendNotification(FirebaseNotificationModel notificationModel)
        {
            FirebaseResponseModel response = new FirebaseResponseModel();
            try
            {
                if (notificationModel.IsAndroiodDevice)
                {
                    /* FCM Sender (Android Device) */
                    FcmSettings settings = new FcmSettings()
                    {
                        SenderId = _fcmNotificationSetting.SenderId,
                        ServerKey = _fcmNotificationSetting.ServerKey
                    };
                    HttpClient httpClient = new HttpClient();

                    string authorizationKey = string.Format("key={0}", settings.ServerKey);
                    

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                    httpClient.DefaultRequestHeaders.Accept
                            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    DataPayload dataPayload = new DataPayload();
                    dataPayload.Title = notificationModel.Title;
                    dataPayload.Body = notificationModel.Body;

                    FirebaseGoogleNotification notification = new FirebaseGoogleNotification();
                    notification.Data = dataPayload;
                    notification.Notification = dataPayload;
                    
                    var fcm = new FcmSender(settings, httpClient);

                    foreach (var device in notificationModel.DeviceId)
                    {
                        var fcmSendResponse = await fcm.SendAsync(device, notification);
                        if (fcmSendResponse.IsSuccess())
                        {
                            response.IsSuccess = true;
                            response.Message = "Notification sent successfully";
                            return response;
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = fcmSendResponse.Results[0].Error;
                            return response;
                        }
                    }
                    
                    
                }
                else
                {
                    /* Code here for APN Sender (iOS Device) */
                    //var apn = new ApnSender(apnSettings, httpClient);
                    //await apn.SendAsync(notification, deviceToken);
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong";
                return response;
            }
        }
    }
}
