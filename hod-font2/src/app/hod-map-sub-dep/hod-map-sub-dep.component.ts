import { Component, Inject, OnDestroy, OnInit, Input, ViewChild } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { MatTableDataSource } from '@angular/material/table';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { FormControl } from '@angular/forms';

import { ShareService } from '../share.service';

import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { animate, state, style, transition, trigger } from '@angular/animations';

import { mapSubDep_HttpService } from './_http.serviceHodMapSubDep';
import { SubDepDto } from '../_models/admin-models';
import { DepsDto } from '../_models/deps-models';

import { SnackBarComponent } from '../snack-bar/snack-bar.component';


@Component({
  selector: 'app-hod-map-sub-dep',
  templateUrl: './hod-map-sub-dep.component.html',
  styleUrls: ['./hod-map-sub-dep.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class HodMapSubDepComponent implements OnInit {

  subDepDtos: SubDepDto[];

  dataSource_subdepdto: any;
  displayedColumns_subdepdto: string[] =
    ['SubId', 'SubName', 'AcDepId'
      , 'AcDepName', 'DepId', 'DepName'];
  dataSource_loads: any;

  depsList: DepsDto[];
  disableSelect = new FormControl(false);

  private _httpOwn: mapSubDep_HttpService;
  constructor(
    private _router: Router,
    private _http: HttpClient,
    private share: ShareService,
    private matDialog: MatDialog,
    private snack: SnackBarComponent,
  ) {
    this._httpOwn = new mapSubDep_HttpService(_http);
  }

  ngOnInit(): void {

    this._httpOwn.getSubAcDep()
      .subscribe(result => {
        this.subDepDtos = result;
        this.dataSource_subdepdto = new MatTableDataSource(result);
      });

    this._httpOwn.getAllDeps()
      .subscribe(result => {
        this.depsList = result;
        console.log(result);
      });

    // this.dataSource_subdepdto = new MatTableDataSource(this.subDepDtos);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource_subdepdto.filter = filterValue.trim().toLowerCase();
  }

}
