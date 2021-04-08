import { Component, Inject, OnDestroy, OnInit, Input } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { ShareService } from '../share.service';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { ThemePalette } from '@angular/material/core';
import { ProgressBarMode } from '@angular/material/progress-bar';

import { promotion_HttpService } from './_http.serviceHodPromotion';
import { DepInfo, DepsDto, Direction } from '../_models/deps-models';
import { Group } from '../_models/groups-models';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';
import { HodModalComponent } from '../hod-modal/hod-modal.component';

@Component({
  selector: 'app-hod-promotion',
  templateUrl: './hod-promotion.component.html',
  styleUrls: ['./hod-promotion.component.css']
})
export class HodPromotionComponent implements OnInit {

  public deps: DepsDto[];

  public selectedDep: DepsDto;
  public selectedDir: Direction;
  public selectedGroup: Group;

  public pathString: string;
  public selectedIndex: number;

  public progress: number;
  public message: string;

  color: ThemePalette = 'primary';
  mode: ProgressBarMode = 'determinate';
  value = 50;
  bufferValue = 75;

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
  }

  private autoSet() {
    this.selectedDep = this.deps[0];
    this.selectedDir = this.selectedDep.dirs[0];
    this.selectedGroup = this.selectedDir.groups[0];
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

    // alert();

    this.autoSet();
  }

  upload(files, item) {
    console.log(item);
    if (files.length === 0) return;
    this._httpOwn.postUploadRequest(files, this.selectedDep.dirs, item.dir_id)
      .subscribe(event => {

        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response)
          this.message = event.body.toString();

        // window.location.reload();
      });


  }

  public getPathString() {
    let path = '::/';
    if (this.selectedDep) { path += `/${this.selectedDep.dep_name}`; }
    else { return path; }
    if (this.selectedDir) { path += `/${this.selectedDir.dir_name}`; }
    else { return path; }
    if (this.selectedGroup) { path += `/${this.selectedGroup.group_name}`; }
    else { return path; }
    return path; // `::${this.selectedDep.dep_name}/${this.selectedDir.dir_name}/${this.selectedGroup.group_name}`
  }

  openModal(item) {
    // this.share.doSelectedDir(item);
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = "modal-component";
    dialogConfig.height = "350px";
    dialogConfig.width = "600px";
    dialogConfig.data = {}

    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(HodModalComponent, dialogConfig);
    modalDialog.componentInstance.selectedDir = item;
  }

  public setSelectedDepartment(item) {
    this.selectedDep = item;
    // this.pathString = `::/${item.dir_name}`;
    this.selectedIndex = 1;
  }
  public showFgosRequirs(item) {
    // show modal window with requirs

  }
  public setSelectedDirection(item) {
    this.selectedDir = item;
    if (!this.selectedDir.groups.includes(this.selectedGroup)) {
      this.selectedGroup = null;
    }
    // this.pathString = `::/${item.dir_name}`;
    this.selectedIndex = 2;
  }
  public setSelectedGroup(item) {
    this.selectedGroup = item;
    // this.pathString += `/${item.group_name}`;
    this.selectedIndex = 3;
  }

}
