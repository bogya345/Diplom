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
  selector: 'app-hod-home',
  templateUrl: './hod-home.component.html',
  styleUrls: ['./hod-home.component.css']
})
export class HodHomeComponent implements OnInit {

  // private _http: HttpClient;
  // private router: Router;
  // private share: ShareService;

  public user: User;

  public dep: DepInfo;

  constructor(
    private _http: HttpClient,
    private _router: Router,
    private _share: ShareService,
    private _snack: SnackBarComponent
  ) {

    this.user = _share.getUser();

    console.log(this.user);

    this._http.get<DepInfo>(`${environment.hod_api_url}deps/info/${this.user.dep_id}`, {
      headers: {
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
      }
    })
      .subscribe(result => {
        this.dep = result;
      });
  }

  ngOnInit(): void {
    // if(this._share.getUser())
    // this._http.get
  }

}
