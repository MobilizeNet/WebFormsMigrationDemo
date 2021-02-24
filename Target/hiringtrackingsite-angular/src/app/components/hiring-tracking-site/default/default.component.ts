import { Component, ChangeDetectorRef, ElementRef
, Output, Renderer2, ViewEncapsulation} from "@angular/core";
import { EventData, dataTransfer} from "@mobilize/base-components";
import { UserControlComponent, WebComponentsService
} from "@mobilize/winforms-components";
import { WebMapService} from "@mobilize/angularclient";
@Component({
   selector : "hiring-tracking-site-default",
   styleUrls : ["./default.component.css"],
   templateUrl : "./default.component.html",
   encapsulation : ViewEncapsulation.None
})
@dataTransfer(["frmHiringTrackingSiteDefault"])
export class DefaultComponent extends UserControlComponent {
   protected webServices : WebMapService;
   constructor (wmservice : WebMapService,
   changeDetector : ChangeDetectorRef,render2 : Renderer2
   ,elem : ElementRef,webComponents : WebComponentsService) {
      super(wmservice,changeDetector,render2,elem,webComponents);
   }
}