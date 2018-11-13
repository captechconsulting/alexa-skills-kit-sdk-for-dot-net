using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ask.Sdk.Model.Service.DeviceAddress
{
    public class DeviceAddressServiceClient : BaseServiceClient {

        public DeviceAddressServiceClient(ApiConfiguration apiConfiguration) : base(apiConfiguration) {}

        public Task<Address> GetFullAddress(string deviceId) {
            var queryParams = new Dictionary<string, string>();
            var headerParams = new Dictionary<string, string>();

            return Invoke<Address>("GET", ApiConfiguration.ApiEndpoint, $"/v1/devices/{deviceId}/settings/address", queryParams, headerParams);
        }

        public Task<ShortAddress> GetCountryAndPostalCode(string deviceId) {
            var queryParams = new Dictionary<string, string>();
            var headerParams = new Dictionary<string, string>();

            return Invoke<ShortAddress>("GET", ApiConfiguration.ApiEndpoint, $"/v1/devices/{deviceId}/settings/address/countryAndPostalCode", queryParams, headerParams);
        }

    }
}