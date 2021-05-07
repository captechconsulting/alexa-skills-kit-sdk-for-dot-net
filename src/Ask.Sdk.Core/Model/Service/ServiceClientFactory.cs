using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Profile;

namespace Ask.Sdk.Core.Model.Service
{
    public class ServiceClientFactory
    {
        SkillRequest Request { get; set; }
        public ServiceClientFactory(SkillRequest request)
        {
            Request = request;
        }
        public CustomerProfileClient GetDeviceAddressServiceClient()
        {
            return new CustomerProfileClient(Request);
        }

        // TODO: Will have to implement this later as progressive responses are implemented in the Alexa.NET package differently
        // from the other clients.
        //public DirectiveServiceClient GetDirectiveServiceClient()
        //{
        //    return new DirectiveServiceClient(Request);
        //}

        // TODO: Currently not implemented
        //public ListManagementServiceClient GetListManagementServiceClient()
        //{
        //    return new ListManagementServiceClient(Request);
        //}

        public InSkillProductsClient GetMonetizationServiceClient()
        {
            return new InSkillProductsClient(Request);
        }

        public SettingsClient GetUpsServiceClient()
        {
            return new SettingsClient(Request);
        }
    }
}
