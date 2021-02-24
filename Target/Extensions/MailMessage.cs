
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

    public class MailMessage
    {
        private string v;
        private string email;

        public MailMessage() { }

        public MailMessage(string v, string email)
        {
            this.v = v;
            this.email = email;
        }

        public MailAddress From { get; internal set; }
        public List<string> To { get; internal set; }
        public string Subject { get; internal set; }
        public string Body { get; internal set; }
        public bool IsBodyHtml { get; internal set; }
        public Encoding BodyEncoding { get; internal set; }
    }
}

