using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Models
{
    public class FirebaseResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class FirebaseNotificationModel
    {
        [JsonProperty("deviceId")]
        public List<string> DeviceId { get; set; }=new List<string>(){ };

        [JsonProperty("isAndroiodDevice")]
        public bool IsAndroiodDevice { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }


        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class FirebaseGoogleNotification
    {
        public class DataPayload
        {
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("body")]
            public string Body { get; set; }


        }

        [JsonProperty("priority")]
        public string Priority { get; set; } = "high";

        [JsonProperty("data")]
        public DataPayload Data { get; set; }

        [JsonProperty("notification")]
        public DataPayload Notification { get; set; }


        [JsonProperty("topic")]
        public string Topic { get; set; } = "sofico";
        
    }

    public class FcmNotificationSetting
    {
        public string SenderId { get; set; }
        public string ServerKey { get; set; }
    }
}