
namespace HiringTrackingSite
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Security.Principal;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.DependencyInjection;
    using Mobilize.Web;
    using Mobilize.WebMap.Common.Core;
    using Mobilize.WebMap.Common.DCP;

    public class ExtApplication : Mobilize.Web.UI.Application
    {
        public ExtApplication(IServiceProvider provider)
            : base(provider)
        {
            this.MasterPages.Add(new SiteMaster());
        }

        public IDictionary Cache { get; set; }

        public IServerUtils Server { get; set; }
        public IEmailService Mail { get; set; }
        public GenericPrincipal User { get; set; }

    }
}

