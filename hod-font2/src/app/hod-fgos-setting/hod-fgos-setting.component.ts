import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NavigationEnd, Router } from '@angular/router';
import { environment } from '../../environments/environment';

import { ShareService } from '../share.service';
import { CommonResponse } from '../_models/app-models';

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

  flag: boolean;

  constructor(
    private _http: HttpClient,
    private _router: Router,
    private _share: ShareService,
    private _snack: SnackBarComponent
  ) {
    this.user = _share.getUser();
    this.flag = true;
  }

  ngOnInit(): void {
    this._http.get<any[]>(`${environment.hod_api_url}fgos/get/dirs/${this.user.dep_id}`)
      .subscribe(result => {
        console.log(result);
        console.log(result.length);
        if (result.length != 0) {
          this.dirFgos = result;
        }
        else {
          this.flag = false
        }
      })
  }

  changeFgos(item) {
    console.log(item);
    let req = {
      DirId: item.DirId,
      DirName: item.DirName,
      Fgos443: item.Fgos443,
      Fgos444: item.Fgos444,
      Fgos445: item.Fgos445,
      StartYear: item.StartYear
    };
    console.log(req);
    this._http.post<CommonResponse>(`${environment.hod_api_url}fgos/change`, req)
      .subscribe(result => {
        console.log(result);
        this._snack.openSnackBarFull(result.Message, 'right', 'left', 1000);
      });
    console.log(item);
  }

}
