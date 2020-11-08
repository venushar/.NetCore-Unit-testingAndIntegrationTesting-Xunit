using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingServices.Common.Models
{
  public   class ClientConfigurationModel
    {

        public string EnvironmentName { get; internal set; }

        public bool EnableHostAuthentication { get; set; }

        public string GoogleTagManagerId { get; set; }

        public AuthConfigurationModel AuthConfiguration { get; set; }

        public string SearchResultPage { get; set; }

        public string ProfileImagePath { get; set; }

        public string ProfilePage { get; set; }
    }
}
