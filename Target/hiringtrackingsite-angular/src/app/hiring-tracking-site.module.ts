
import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseComponentsModule } from '@mobilize/base-components';
import { WebMapKendoModule } from '@mobilize/winforms-components';
import { WebMapService, WebMapModule } from '@mobilize/angularclient';

import * as HiringTrackingSite from './components/hiring-tracking-site';

@NgModule({
  imports: [
    CommonModule,
    BaseComponentsModule,
    WebMapKendoModule,
    WebMapModule,
  ],
  exports: [
    HiringTrackingSite.DefaultComponent,
    HiringTrackingSite.ClientDetailsComponent,
    HiringTrackingSite.ClientsListFormComponent,
    HiringTrackingSite.PositionDetailsFormComponent,
    HiringTrackingSite.PositionsListComponent,
    HiringTrackingSite.SiteMasterComponent
  ],
  declarations: [
    HiringTrackingSite.DefaultComponent,
    HiringTrackingSite.ClientDetailsComponent,
    HiringTrackingSite.ClientsListFormComponent,
    HiringTrackingSite.PositionDetailsFormComponent,
    HiringTrackingSite.PositionsListComponent,
    HiringTrackingSite.SiteMasterComponent
  ],
  bootstrap: [
    HiringTrackingSite.DefaultComponent,
    HiringTrackingSite.ClientDetailsComponent,
    HiringTrackingSite.ClientsListFormComponent,
    HiringTrackingSite.PositionDetailsFormComponent,
    HiringTrackingSite.PositionsListComponent,
    HiringTrackingSite.SiteMasterComponent
  ],
   providers: [WebMapService],
   schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class HiringTrackingSiteModule { }

