import { Component, ChangeDetectorRef, ElementRef
, Output, Renderer2, ViewEncapsulation} from "@angular/core";
import { EventData, dataTransfer} from "@mobilize/base-components";
import { UserControlComponent, WebComponentsService
} from "@mobilize/winforms-components";
import { WebMapService, NotifyChange} from "@mobilize/angularclient";
@Component({
   selector : "hiring-tracking-site-client-details",
   styleUrls : ["./client-details.component.css"],
   templateUrl : "./client-details.component.html",
   encapsulation : ViewEncapsulation.None
})
@dataTransfer(["frmHiringTrackingSiteClientDetails"])
export class ClientDetailsComponent extends UserControlComponent {
   protected webServices : WebMapService;
   constructor (wmservice : WebMapService,
   changeDetector : ChangeDetectorRef,render2 : Renderer2
   ,elem : ElementRef,webComponents : WebComponentsService) {
      super(wmservice,changeDetector,render2,elem,webComponents);
   }


   @NotifyChange('ScriptExecuted')
   set ScriptExecuted(executed:boolean)
   {
      this.model.ClientScript.Executed = executed;
   }

   
   ngDoCheck(){
      if (this.model && this.model.ClientScript && !this.model.ClientScript.Executed)
      {
         this.ScriptExecuted = true;
         eval(this.model.ClientScript.Script);
      }
    }
}