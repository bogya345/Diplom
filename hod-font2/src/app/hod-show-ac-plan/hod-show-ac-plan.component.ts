import { Component, Inject, OnDestroy, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { ShareService } from '../share.service';

import { DepsDto, Direction } from '../_models/deps-models';
import { Group } from '../_models/groups-models';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';

@Component({
  selector: 'app-hod-show-ac-plan',
  templateUrl: './hod-show-ac-plan.component.html',
  styleUrls: ['./hod-show-ac-plan.component.css']
})
export class HodShowAcPlanComponent implements OnInit {

  constructor(
    private _router: Router,
    private _http: HttpClient,
    private _route: ActivatedRoute,
    private share: ShareService,
  ) {
    let acPlId = this._route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
  }

}
