using System.Collections.Generic;

namespace OnlineShoppingServices.Common.Models
{
    public class AuthConfigurationModel
    {

        public string Tenant { get; set; }

        public string ClientId { get; set; }

        public IDictionary<string, string> Endpoints { get; set; }
    }
}