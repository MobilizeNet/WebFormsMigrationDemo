import { Component } from '@angular/core';
import { WebMapService } from '@mobilize/angularclient';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  year: number;
  master:any;
  constructor(private webmapService: WebMapService) {
    webmapService.init();
    this.year = new Date().getFullYear();
  }

  NavHome() {
    this.master?.NavHome();
  }

  NavPositionList() {
    this.master?.NavPositionList();
  }

  NavClientList() {
    this.master?.NavClientList();
  }
}
