using Ask.Sdk.Model.Service.DeviceAddress;
using Ask.Sdk.Model.Service.Directive;
using Ask.Sdk.Model.Service.ListManagement;
using Ask.Sdk.Model.Service.Monetization;
using Ask.Sdk.Model.Service.Ups;
using System;

namespace Ask.Sdk.Model.Service
{
    public class ServiceClientFactory
    {
        ApiConfiguration ApiConfiguration { get; set; }

        public ServiceClientFactory(ApiConfiguration apiConfiguration) {
            ApiConfiguration = apiConfiguration;
        }
        public DeviceAddressServiceClient GetDeviceAddressServiceClient() {
            return new DeviceAddressServiceClient(ApiConfiguration);
        }

        public DirectiveServiceClient GetDirectiveServiceClient()
        {
            return new DirectiveServiceClient(ApiConfiguration);
        }

        public ListManagementServiceClient GetListManagementServiceClient()
        {
            return new ListManagementServiceClient(ApiConfiguration);
        }

        public MonetizationServiceClient GetMonetizationServiceClient()
        {
            return new MonetizationServiceClient(ApiConfiguration);
        }
        
        public UpsServiceClient GetUpsServiceClient()
        {
            return new UpsServiceClient(ApiConfiguration);
        }
    }
}