import { Component, ChangeDetectorRef, ElementRef
, Output, Renderer2, ViewEncapsulation} from "@angular/core";
import { EventData, dataTransfer, serverEvent} from "@mobilize/base-components";
import { UserControlComponent, WebComponentsService
} from "@mobilize/winforms-components";
import { WebMapService} from "@mobilize/angularclient";
import { AppComponent } from "../../../app.component";
@Component({
   selector : "hiring-tracking-site-master",
   styleUrls : ["./site-master.component.css"],
   templateUrl : "./site-master.component.html",
   encapsulation : ViewEncapsulation.None
})
@dataTransfer(["frmHiringTrackingSiteSiteMaster"])
export class SiteMasterComponent extends UserControlComponent {

   protected webServices : WebMapService;
   constructor (wmservice : WebMapService,
   changeDetector : ChangeDetectorRef,render2 : Renderer2
   ,elem : ElementRef,webComponents : WebComponentsService, app:AppComponent) 
   {
      super(wmservice,changeDetector,render2,elem,webComponents);
      app.master = this;
   }

   @serverEvent('NavHome')
   NavHome() {
   }

   @serverEvent('NavClientList')
   NavClientList() {
   }

   @serverEvent('NavPositionList')
   NavPositionList() {
   }

}