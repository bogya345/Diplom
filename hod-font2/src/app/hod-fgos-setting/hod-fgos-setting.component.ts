import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NavigationEnd, Router } from '@angular/router';
import { environment } from '../../environments/environment';

import { ShareService } from '../share.service';

import { User } from '../_models/accounts-models';
import { DepInfo, DepsDto } from '../_models/deps-models';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';
import { identifierModuleUrl } from '@angular/compiler';

@Component({
  selector: 'app-hod-fgos-setting',
  templateUrl: './hod-fgos-setting.component.html',
  styleUrls: ['./hod-fgos-setting.component.css']
})
export class HodFgosSettingComponent implements OnInit {

  dirFgos: any;
  user: User;

  constructor(
    private _http: HttpClient,
    private _router: Router,
    private _share: ShareService,
    private _snack: SnackBarComponent
    ) {
      this.user = _share.getUser();
     }

  ngOnInit(): void {
    this._http.get(`${environment.hod_api_url}fgos/get/dirs/${this.user.dep_id}`)
    .subscribe(result => {
      console.log(result);
      this.dirFgos = result;
    })
  }

}
