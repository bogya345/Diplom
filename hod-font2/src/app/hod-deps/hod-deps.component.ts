import { Component, Inject, OnDestroy, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ShareService } from '../share.service';

import { deps_HttpService } from './_http.serviceHodDeps';
import { DepInfo } from '../_models/deps-models';
import { User } from '../_models/accounts-models';

@Component({
  selector: 'app-hod-deps',
  templateUrl: './hod-deps.component.html',
  styleUrls: ['./hod-deps.component.css']
})
export class HodDepsComponent implements OnInit {

  private user: User;
  public depsInfo: DepInfo[];

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
    this.depsInfo = this.share.shareDeps();
    
    console.log(this.user);


  }

  ngOnChanges(): void {
  }

}

