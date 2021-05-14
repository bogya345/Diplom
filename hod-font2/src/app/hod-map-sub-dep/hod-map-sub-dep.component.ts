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
import {
  MapSubDepDto,
  SubDepDto, SubDepModal,
  DepDepDto, DepDepModal
} from '../_models/admin-models';
import { DepsDto } from '../_models/deps-models';

import { SnackBarComponent } from '../snack-bar/snack-bar.component';
import { range } from 'rxjs';


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

  mapSubDep: MapSubDepDto;

  subDepDtos: SubDepDto[];
  dataSource_subdepdto: any;
  displayedColumns_subdepdto: string[] =
    ['SubId', 'SubName', 'AcDepId'
      , 'AcDepName', 'DepId', 'DepName'];

  depsList: DepsDto[];
  disableSelect = new FormControl(false);

  depDepDtos: DepDepDto[];
  dataSource_depDepdto: any;
  displayedColumns_depDepdto: string[] =
    ['AcDepId_', 'AcDepName_', 'DepId_', 'DepName_'];

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

    this._httpOwn.getMapSubDep()
      .subscribe(result => {

        this.mapSubDep = result;
        this.subDepDtos = result.subDeps;
        this.depsList = result.deps;
        this.depDepDtos = result.depDep;
        // this.subDepDtos = this.mapSubDep.
        this.dataSource_subdepdto = new MatTableDataSource(result.subDeps);
        this.dataSource_depDepdto = new MatTableDataSource(result.depDep);
      });

    // this._httpOwn.getSubAcDep()
    //   .subscribe(result => {
    //     this.subDepDtos = result;
    //     this.dataSource_subdepdto = new MatTableDataSource(result);
    //   });
    // this._httpOwn.getAllDeps()
    //   .subscribe(result => {
    //     this.depsList = result;
    //     console.log(result);
    //   });

    // this.dataSource_subdepdto = new MatTableDataSource(this.subDepDtos);
  }

  saveChangesDep() {
    let res: DepDepModal[];
    res = [];
    for (let i of this.depDepDtos) {
      if (i.dep_id != 0) {
        res.push({
          acPlDep_id: i.acPlDep_id,
          dep_id: i.dep_id
        });
      }
    }
    console.log(res);
    this._httpOwn.postMapDepDep(res)
      .subscribe(event => {

        // if (event.type === HttpEventType.UploadProgress)
        //   this.progress = Math.round(100 * event.loaded / event.total);
        // else if (event.type === HttpEventType.Response)
        //   this.message = event.body.toString();

        // this.selectedDep.
        console.log(event);
        this.snack.openSnackBarWithMsg(event);
      });
  }

  saveChanges() {
    let res: SubDepModal[];
    res = [];
    for (let i of this.subDepDtos) {
      if (i.dep_id != 0) {
        res.push({
          sub_id: i.sub_id,
          acPlDep_id: i.acPlDep_id,
          dep_id: i.dep_id
        });
      }
    }
    console.log(res);
    this._httpOwn.postMapSubDep(res)
      .subscribe(event => {

        // if (event.type === HttpEventType.UploadProgress)
        //   this.progress = Math.round(100 * event.loaded / event.total);
        // else if (event.type === HttpEventType.Response)
        //   this.message = event.body.toString();

        // this.selectedDep.
        console.log(event);
        this.snack.openSnackBarWithMsg(event);
      });
  }

  applyFilter_depdep(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource_depDepdto.filter = filterValue.trim().toLowerCase();
    // console.log(this.dataSource_subdepdto.data[0]);
    // console.log(this.subDepDtos[0]);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource_subdepdto.filter = filterValue.trim().toLowerCase();
    // console.log(this.dataSource_subdepdto.data[0]);
    // console.log(this.subDepDtos[0]);
  }

  acceptChanges() {
    // for(let i in )
  }

}
