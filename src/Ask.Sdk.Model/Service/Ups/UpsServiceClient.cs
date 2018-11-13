using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ask.Sdk.Model.Helpers;

namespace Ask.Sdk.Model.Service.Ups
{
    public class UpsServiceClient : BaseServiceClient
    {
        private static string SETTINGSPATH = "/v2/accounts/~current/settings/";
        public UpsServiceClient(ApiConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        public Task<string> GetProfileEmail()
        {
            return Invoke("GET", ApiConfiguration.ApiEndpoint, $"{SETTINGSPATH}Profile.email", 
                new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }

        public Task<string> GetProfileGivenName()
        {
            return Invoke("GET", ApiConfiguration.ApiEndpoint, $"{SETTINGSPATH}Profile.givenName",
                new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }

        public Task<PhoneNumber> GetProfileMobileNumber()
        {
            return Invoke<PhoneNumber>("GET", ApiConfiguration.ApiEndpoint, $"{SETTINGSPATH}Profile.mobileNumber",
                new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }

        public Task<string> GetProfileName()
        {
            return Invoke("GET", ApiConfiguration.ApiEndpoint, $"{SETTINGSPATH}Profile.name",
                new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }

        public Task<DistanceUnits> GetSystemDistanceUnits(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
                throw new ArgumentNullException(nameof(deviceId));

            var distance = Invoke("GET", ApiConfiguration.ApiEndpoint, $"/v2/devices/{deviceId}/settings/System.distanceUnits",
                new Dictionary<string, string>(),
                new Dictionary<string, string>()).Result;

            return Task.FromResult(distance.ToEnum<DistanceUnits>());
        }

        public Task<TemperatureUnit> GetSystemTemperatureUnit(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
                throw new ArgumentNullException(nameof(deviceId));

            var unit = Invoke("GET", ApiConfiguration.ApiEndpoint, $"/v2/devices/{deviceId}/settings/System.temperatureUnit",
                new Dictionary<string, string>(),
                new Dictionary<string, string>()).Result;

            return Task.FromResult(unit.ToEnum<TemperatureUnit>());
        }

        public Task<string> GetSystemTimeZone(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
                throw new ArgumentNullException(nameof(deviceId));

            return Invoke("GET", ApiConfiguration.ApiEndpoint, $"/v2/devices/{deviceId}/settings/System.timeZone",
                new Dictionary<string, string>(),
                new Dictionary<string, string>());
        }
    }
}
