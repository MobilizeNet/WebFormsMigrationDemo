namespace HiringTrackingSite
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using Mobilize.WebMap.Common.Attributes;

    [Observable]
    public partial class SiteMaster : Mobilize.Web.UI.MasterPage
    {

        [Intercepted]
        public EventHandler NavHome { get; set; }

        [Intercepted]
        public EventHandler NavClientList { get; set; }

        [Intercepted]
        public EventHandler NavPositionList { get; set; }
    }



}