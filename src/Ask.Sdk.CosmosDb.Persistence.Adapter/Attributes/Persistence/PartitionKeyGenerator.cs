using Ask.Sdk.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.CosmosDb.Persistence.Adapter.Attributes.Persistence
{
    public class PartitionKeyGenerator
    {
        public static string UserId(RequestEnvelope requestEnvelope)
        {
            var userId = requestEnvelope?.Context?.System?.User?.UserId;
            if (string.IsNullOrEmpty(requestEnvelope?.Context?.System?.User?.UserId))
            {
                throw new ArgumentNullException("UserId");
            }

            return userId;
        }

        public static string DeviceId(RequestEnvelope requestEnvelope)
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
