using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Model.Service.Monetization
{
    public class MonetizationServiceClient : BaseServiceClient
    {
        public MonetizationServiceClient(ApiConfiguration apiConfiguration) : base(apiConfiguration)
        {
        }

        public Task<InSkillProductsResponse> GetInSkillProducts(string acceptLanguage, string purchasable = null, string entitled = null,
            string productType = null, string nextToken = null, int? maxResults = null)
        {
            if (string.IsNullOrEmpty(acceptLanguage))
                throw new ArgumentNullException(nameof(acceptLanguage));

            var query = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(purchasable))
                query.Add(nameof(purchasable), purchasable);
            if (!string.IsNullOrEmpty(entitled))
                query.Add(nameof(entitled), entitled);
            if (!string.IsNullOrEmpty(productType))
                query.Add(nameof(productType), productType);
            if (!string.IsNullOrEmpty(nextToken))
                query.Add(nameof(nextToken), nextToken);
            if (maxResults.HasValue)
                query.Add(nameof(maxResults), maxResults.Value.ToString());

            return Invoke<InSkillProductsResponse>("GET", ApiConfiguration.ApiEndpoint, "/v1/users/~current/skills/~current/inSkillProducts", query, new Dictionary<string, string>
            {
                {"Accept-Language", acceptLanguage }
            });
        }

        public Task<InSkillProduct> GetInSkillProduct(string acceptLanguage, string productId)
        {
            if (string.IsNullOrEmpty(acceptLanguage))
                throw new ArgumentNullException(nameof(acceptLanguage));
            if (string.IsNullOrEmpty(productId))
                throw new ArgumentNullException(nameof(productId));

            return Invoke<InSkillProduct>("GET", ApiConfiguration.ApiEndpoint, $"/v1/users/~current/skills/~current/inSkillProducts/{productId}", new Dictionary<string, string>()
                , new Dictionary<string, string>
            {
                {"Accept-Language", acceptLanguage }
            });
        }
    }
}
