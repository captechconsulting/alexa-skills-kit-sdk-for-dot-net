using Ask.Sdk.Model.Directive;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Model.Service.Directive
{
    public class DirectiveServiceClient : BaseServiceClient
    {
        public DirectiveServiceClient(ApiConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        public Task Enqueue(SendDirectiveRequest sendDirectiveRequest)
        {
            if (sendDirectiveRequest == null)
                throw new ArgumentNullException(nameof(sendDirectiveRequest));

            return Invoke("POST", ApiConfiguration.ApiEndpoint, $"/v1/directives", new Dictionary<string, string>(),
                new Dictionary<string, string>(), JsonConvert.SerializeObject(sendDirectiveRequest));
        }
    }
}
