import { Component, Inject, OnDestroy, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ShareService } from '../share.service';

import { environment } from '../../environments/environment';

import { deps_HttpService } from './_http.serviceHodDeps';
import { DepInfo } from '../_models/deps-models';
import { User } from '../_models/accounts-models';
import { DepsDto } from '../_models/deps-models';

@Component({
  selector: 'app-hod-deps',
  templateUrl: './hod-deps.component.html',
  styleUrls: ['./hod-deps.component.css']
})
export class HodDepsComponent implements OnInit {

  private user: User;
  public depsInfo: DepsDto[];

  public pathExcel: string;

  private _httpOwn: deps_HttpService;

  constructor(
    private _router: Router,
    private _http: HttpClient,
    private share: ShareService
  ) {
    this._httpOwn = new deps_HttpService(_http);
  }

  ngOnInit(): void {
    console.log('INIT: hod-deps');

    this.user = this.share.getUser();

    this._httpOwn.getDepDirFac()
      .subscribe(result => {
        this.depsInfo = result;
        console.log(result);
      });

    console.log(this.user);


  }

  ngOnChanges(): void {
  }

  
  downloadDepLoad(item) {
    let path = this._http.get<PropertyDoc>(`${environment.hod_api_url}deps/get/load/${item.Dep_id}`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      })
      .subscribe(result => {
        console.log(result);

        if (result) {
          this.pathExcel = result.Path;
          window.open(`${environment.hod_api_url}${result.Path}`);
        }
        else {
          console.log('cant download file');
        }
      })
      ;
  }

}

interface PropertyDoc {
  Path: string
}