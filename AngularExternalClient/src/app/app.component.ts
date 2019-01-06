import {Component} from '@angular/core';
import {ApiResourceService} from './services/api-resource.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularExternalClient';

  constructor(
    private _apiResourceService: ApiResourceService
  ) {
    this.getCustomers();
  }

  public getCustomers() {
    this._apiResourceService.getCustomers().subscribe(result => {
      debugger;
      console.log(result);
    });
  }

}
