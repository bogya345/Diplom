import { Component, Inject, OnDestroy, OnInit, Input } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { environment } from '../../environments/environment';

import { ShareService } from '../share.service';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { ThemePalette } from '@angular/material/core';
import { ProgressBarMode } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { promotion_HttpService } from './_http.serviceHodPromotion';
import { DepInfo, DepsDto, Direction } from '../_models/deps-models';
import { Group } from '../_models/groups-models';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';

import { HodModalShowRequirsComponent } from '../hod-modal-show-requirs/hod-modalShowRequirs.component';
import { HodModalReloadAcPlanComponent } from '../hod-modal-reload-ac-plan/hod-modal-reload-ac-plan.component';
import { HodModalShowGroupStatusComponent } from '../hod-modal-show-group-status/hod-modal-show-group-status.component';
import { HodShowDirPropertyComponent } from '../hod-show-dir-property/hod-show-dir-property.component';
import { ProgressModalComponent } from '../progress-modal/progress-modal.component';

import { GroupAnalysDto, DirAnalysDto, Marks } from '../_models/analys-models';
import { CDK_CONNECTED_OVERLAY_SCROLL_STRATEGY_PROVIDER_FACTORY } from '@angular/cdk/overlay/overlay-directives';
import { User } from '../_models/accounts-models';

@Component({
  selector: 'app-hod-promotion',
  templateUrl: './hod-promotion.component.html',
  styleUrls: ['./hod-promotion.component.css']
})
export class HodPromotionComponent implements OnInit {

  public user: User;

  public deps: DepsDto[];

  public selectedDep: DepsDto;
  public selectedDir: Direction;
  public selectedGroup: Group;

  public pathString: string;
  public selectedIndex: number;

  public progress: number;
  public message: string;

  public pathExcel: string;

  groupStatus: GroupAnalysDto[];
  dirStatus: DirAnalysDto;

  colorPrimary: ThemePalette = 'primary';
  colorWarn: ThemePalette = 'warn';
  colorAccent: ThemePalette = 'accent';
  mode: ProgressBarMode = 'determinate';
  value = 50;
  bufferValue = 75;

  spinnerIsOn: boolean;

  private _httpOwn: promotion_HttpService;
  constructor(
    private _router: Router,
    private _http: HttpClient,
    private _route: ActivatedRoute,
    private share: ShareService,
    private snack: SnackBarComponent,
    private matDialog: MatDialog
  ) {
    this._httpOwn = new promotion_HttpService(_http);
    this.user = share.getUser();
  }

  private autoSet() {
    this.selectedDep = this.deps[0];
    this.selectedDir = this.selectedDep.Dirs[0];
    this.selectedGroup = this.selectedDir.Groups[0];
    this.selectedIndex = 3;
  }

  ngOnInit(): void {
    // alert();
    // this.deps = this._httpOwn.getFaceDeps();
    this._httpOwn.getDepFacDir()
      .subscribe(result => {
        this.deps = result;
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
        this.snack.openSnackBarWithMsg('Using fake data');
      }
      );

    // this.openModalProgress();

    // alert();
  }

  ngDoCheck() {
    // this.autoSet();
  }

  upload(files, item) {
    console.log(files);
    if (files.length === 0) return;

    // this.spinnerIsOn = true;

    this.openModalProgress();

    this.snack.openSnackBarFull('?????????????????? ???????????????? ??????????. ?????? ?????????? ???????????? ?????????????????? ??????????...', 'right', 'bottom', 50000);

    this._httpOwn.postUploadRequest(files, this.selectedDep.Dep_id, item.Dir_id)
      .subscribe(event => {

        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response)
          this.message = event.body.toString();

        // this.selectedDep.

        this.spinnerIsOn = false;
        this.snack.openSnackBarWithMsg('?????????????? ???????? ?????? ???????????????? ?? ??????????????????.');
        setTimeout(() => { window.location.reload(); }, 2000)
      });
  }

  // reloadAcPlan(item){

  // }

  openAcPlan(item) {
    // window.open('ms-excel:ofe|u|http://localhost:4200/assets/PlanIST16.xlsx', "_blank");
    if (!this.pathExcel) {
      this._httpOwn.getAcPlan(item.Dir_id)
        .subscribe(result => {
          console.log(result);
          if (result.Done) {
            this.pathExcel = result.Path;
            window.open(`${environment.hod_api_url}${result.Path}`);
          }
          else {
            this.snack.openSnackBarWithMsg(result.Message);
          }
        })
    }
    else {
      console.log('without request');
      window.open(`${environment.hod_api_url}${this.pathExcel}`);
    }
  }

  public getPathString() {
    let path = '::/';
    if (this.selectedDep) { path += `/${this.selectedDep.Dep_name}`; }
    else { return path; }
    if (this.selectedDir) { path += `/${this.selectedDir.Dir_name}`; }
    else { return path; }
    if (this.selectedGroup) { path += `/${this.selectedGroup.Group_name}`; }
    else { return path; }
    return path; // `::${this.selectedDep.dep_name}/${this.selectedDir.dir_name}/${this.selectedGroup.group_name}`
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
          this.snack.openSnackBarFull(`???????????? ????????????????????.`, 'center', '', 3000);
        }
      })
      ;
  }
  openModal(item) {
    // this.share.doSelectedDir(item);
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = "modalShowRequirs-component";
    dialogConfig.height = "350px";
    dialogConfig.width = "600px";
    dialogConfig.data = {}

    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(HodModalShowRequirsComponent, dialogConfig);
    modalDialog.componentInstance.selectedDir = item;
  }
  openModalShowDirProperty(item) {
    // this.share.doSelectedDir(item);
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = "modalShowGroupStatus-component";
    dialogConfig.height = "350px";
    dialogConfig.width = "600px";
    dialogConfig.data = {}

    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(HodShowDirPropertyComponent, dialogConfig);
    modalDialog.componentInstance.selectedDep = this.selectedDep;
    modalDialog.componentInstance.selectedDir = item;
  }
  openModalReloadAcPlan(item) {
    // this.share.doSelectedDir(item);
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = "modalReloadAcPlan-component";
    dialogConfig.height = "350px";
    dialogConfig.width = "600px";
    dialogConfig.data = {}

    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(HodModalReloadAcPlanComponent, dialogConfig);
    modalDialog.componentInstance.selectedDep = this.selectedDep;
    modalDialog.componentInstance.selectedDir = item;
  }
  openModalGroupStatus(item) {
    // this.share.doSelectedDir(item);
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = "modalShowGroupStatus-component";
    dialogConfig.height = "350px";
    dialogConfig.width = "600px";
    dialogConfig.data = {}

    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(HodModalShowGroupStatusComponent, dialogConfig);
    modalDialog.componentInstance.selectedDep = this.selectedDep;
    modalDialog.componentInstance.selectedDir = this.selectedDir;
    modalDialog.componentInstance.selectedGroup = item;
  }

  openModalProgress() {
    // this.share.doSelectedDir(item);
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = "modalProgress-component";
    dialogConfig.height = "180px";
    dialogConfig.width = "600px";

    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(ProgressModalComponent, dialogConfig);
    modalDialog.componentInstance.title = "?????????????? ?????????????????????????????? ????????????";
    modalDialog.componentInstance.message = "???????????????????? ?????????????????? ???????????????? ??????????, ????????????????????, ??????????????????...";
  }

  public setSelectedDepartment(item) {
    this.selectedDep = item;
    // this.pathString = `::/${item.dir_name}`;
    this.selectedIndex = 1;
  }
  public showFgosRequirs(item) {
    // show modal window with requirs

  }

  public async setSelectedDirection(item) {
    this.selectedDir = item;
    if (!this.selectedDir.Groups.includes(this.selectedGroup)) {
      this.selectedGroup = null;
    }

    //this.groupStatus.filter(x => {return x.group_id == item.group_id})[0].getStatus();
    // this.pathString = `::/${item.dir_name}`;
    this.selectedIndex = 2;

    console.log('dir_id is ', item.Dir_id);

    this._httpOwn.getGroupsInfo(item.Dir_id)
      .subscribe(result => {
        console.log(result);
        this.groupStatus = result;
      });

    this._http.get<DirAnalysDto>(`${environment.hod_api_url}analyser/get/fgos-requirs/${this.selectedDir.Dir_id}/7-2`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      }).subscribe(result => {
        console.log(result);
        this.dirStatus = result;
      });

    // setTimeout(() => {
    //   this._httpOwn.getDirStatus(item.dir_id)
    //     .subscribe(result => {
    //       console.log(result);
    //       this.dirStatus = result;
    //     });
    // }, 1000);



  }
  public getDirInfo() {
    if (!this.dirStatus) {
      this._httpOwn.getDirStatus(this.selectedDir.Dir_id)
        .subscribe(result => {
          console.log(result);
          this.dirStatus = result;
        });
    }
    else {
      console.log(this.dirStatus);
    }
  }
  public getGroupInfo() {
    this._httpOwn.getGroupsInfo(this.selectedDir.Dir_id)
      .subscribe(result => {
        // console.log(result);
        this.groupStatus = result;
      });
  }

  public getGroupStatus(item) {
    if (item == null) { console.log(this.selectedDir); console.log('item is null'); }
    // console.log(this.groupStatus, item);
    // console.log(this.groupStatus.filter(x => { return x.group_id == item.group_id }));
    // console.log(this.groupStatus.filter(x => { return x.group_id == item.group_id })[0]);
    // console.log('groupStatus', this.groupStatus);
    // console.log('item', item); console.log('x', x.Group_id);
    let tmp = this.groupStatus.filter(x => { return x.Group_id == item.Group_id; })[0];

    if (tmp.NumberAll == 0) { return 0; }

    let x = (tmp.NumberSubmitted * 100) / tmp.NumberAll;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    // console.log(x);
    return x;
  }

  public getColorForRequirs(mark) {
    // console.log(mark);
    if (mark == "+") { return this.colorPrimary; }
    return this.colorWarn;
  }


  public getDirStatus722Full() {
    let tmp = this.dirStatus;
    if (tmp.Full.NumberSubmitted722 == tmp.Full.NumberAll722) { return 100; }
    let x = (tmp.Full.NumberSubmitted722 * 100) / tmp.Full.NumberAll722;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    return x;
  }
  public getDirStatus723Full() {
    let tmp = this.dirStatus;
    if (tmp.Full.NumberSubmitted723 == tmp.Full.NumberAll723) { return 100; }
    let x = (tmp.Full.NumberSubmitted723 * 100) / tmp.Full.NumberAll723;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    return x;
  }
  public getDirStatus724Full() {
    let tmp = this.dirStatus;
    if (tmp.Full.NumberSubmitted724 == tmp.Full.NumberAll724) { return 100; }
    let x = (tmp.Full.NumberSubmitted724 * 100) / tmp.Full.NumberAll724;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    return x;
  }
  public getMark722Full() {
    // let tmp = this.groupStatus.filter(x => { return x.group_id == item.group_id })[0];
    let tmp = this.dirStatus;
    return tmp.Full.Mark722;
  }
  public getMark723Full() {
    // let tmp = this.groupStatus.filter(x => { return x.group_id == item.group_id })[0];
    let tmp = this.dirStatus;
    return tmp.Full.Mark723;
  }
  public getMark724Full() {
    // let tmp = this.groupStatus.filter(x => { return x.group_id == item.group_id })[0];
    let tmp = this.dirStatus;
    return tmp.Full.Mark724;
  }


  public getDirStatus722Part() {
    let tmp = this.dirStatus;
    if (tmp.Partial.NumberAll722 == 0) { return 0; }
    if (tmp.Partial.NumberSubmitted722 == tmp.Partial.NumberAll722) { return 100; }
    let x = (tmp.Partial.NumberSubmitted722 * 100) / tmp.Partial.NumberAll722;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    return x;
  }
  public getDirStatus723Part() {
    let tmp = this.dirStatus;
    if (tmp.Partial.NumberAll723 == 0) { return 0; }
    if (tmp.Partial.NumberSubmitted723 == tmp.Partial.NumberAll723) { return 100; }
    let x = (tmp.Partial.NumberSubmitted723 * 100) / tmp.Partial.NumberAll723;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    return x;
  }
  public getDirStatus724Part() {
    let tmp = this.dirStatus;
    if (tmp.Partial.NumberAll724 == 0) { return 0; }
    if (tmp.Partial.NumberSubmitted724 == tmp.Partial.NumberAll724) { return 100; }
    let x = (tmp.Partial.NumberSubmitted724 * 100) / tmp.Partial.NumberAll724;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    return x;
  }
  public getMark722Part() {
    // let tmp = this.groupStatus.filter(x => { return x.group_id == item.group_id })[0];
    let tmp = this.dirStatus;
    if (tmp.Partial.NumberAll722 == 0) { return "-"; }
    return tmp.Partial.Mark722;
  }
  public getMark723Part() {
    // let tmp = this.groupStatus.filter(x => { return x.group_id == item.group_id })[0];
    let tmp = this.dirStatus;
    if (tmp.Partial.NumberAll723 == 0) { return "-"; }
    return tmp.Partial.Mark723;
  }
  public getMark724Part() {
    // let tmp = this.groupStatus.filter(x => { return x.group_id == item.group_id })[0];
    let tmp = this.dirStatus;
    if (tmp.Partial.NumberAll724 == 0) { return "-"; }
    return tmp.Partial.Mark724;
  }


  public setSelectedGroup(item) {
    this.selectedGroup = item;
    // this.pathString += `/${item.group_name}`;
    this.selectedIndex = 3;
  }

  // public debugger(item) { console.log(item); }

}

interface PropertyDoc {
  Path: string
}