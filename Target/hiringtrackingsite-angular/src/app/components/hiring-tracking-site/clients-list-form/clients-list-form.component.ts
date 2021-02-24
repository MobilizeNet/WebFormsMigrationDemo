import { Component, ChangeDetectorRef, ElementRef
, Output, Renderer2, ViewEncapsulation} from "@angular/core";
import { EventData, dataTransfer, serverEvent} from "@mobilize/base-components";
import { UserControlComponent, WebComponentsService
} from "@mobilize/winforms-components";
import { WebMapService, NotifyChange} from "@mobilize/angularclient";
@Component({
   selector : "hiring-tracking-site-clients-list-form",
   styleUrls : ["./clients-list-form.component.css"],
   templateUrl : "./clients-list-form.component.html",
   encapsulation : ViewEncapsulation.None
})
@dataTransfer(["frmHiringTrackingSiteClientsListForm"])
export class ClientsListFormComponent extends UserControlComponent {
   protected webServices : WebMapService;
   constructor (private wmservice : WebMapService,
   changeDetector : ChangeDetectorRef,render2 : Renderer2
   ,elem : ElementRef,webComponents : WebComponentsService) {
      super(wmservice,changeDetector,render2,elem,webComponents);
   }

      /* New property to hold URL */
      url: string = 'api/datalist';

   ngOnInit() {
      if (this.model && this.model.DataList1)
      {
         this.model.DataList1.items = [];
         this.wmservice.fetch<object>(this.url, this.model.DataList1.id).subscribe( data => {
            this.model.DataList1.items = data;
        });

      }
   }

   
   @NotifyChange('CommandArgument')
   set CommandArgument(value:string) {
      this.model.CommandArgument = value;
   }


   @serverEvent('Details_Click')
   Details_Click() {
      
   }

   SetCommandArgumentAndClick(argument) {
      this.CommandArgument = argument;
      this.Details_Click();
   }
}