using Alexa.NET.Request;
using System;

namespace Ask.Sdk.DynamoDb.Persistence.Adapter.Attributes.Persistence
{
    public class PartitionKeyGenerator
    {
        public static string UserId(SkillRequest requestEnvelope)
        {
            var userId = requestEnvelope?.Context?.System?.User?.UserId;
            if (string.IsNullOrEmpty(requestEnvelope?.Context?.System?.User?.UserId))
            {
                throw new ArgumentNullException("UserId");
            }

            return userId;
        }

        public static string DeviceId(SkillRequest requestEnvelope)
        {
            var deviceId = requestEnvelope?.Context?.System?.Device?.DeviceID;
            if (string.IsNullOrEmpty(deviceId))
            {
                throw new ArgumentNullException("DeviceId");
            }

            return deviceId;
        }
    }
}
