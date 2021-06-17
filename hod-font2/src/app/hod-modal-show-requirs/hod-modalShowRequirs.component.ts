import { Component, OnInit, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { HttpClient, HttpEventType } from '@angular/common/http';

import { ThemePalette } from '@angular/material/core';
import { ProgressBarMode } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { environment } from '../../environments/environment';

import { ShareService } from '../share.service';

import {
  Direction, DirRequir, PackageRequirs
} from '../_models/deps-models';

@Component({
  selector: 'app-hod-modalShowRequirs',
  templateUrl: './hod-modalShowRequirs.component.html',
  styleUrls: ['./hod-modalShowRequirs.component.css']
})
export class HodModalShowRequirsComponent implements OnInit {

  // @Input('selectedDir') selectedDir: Direction;
  public selectedDir: Direction;
  public requirs: PackageRequirs;

  colorPrimary: ThemePalette = 'primary';
  colorWarn: ThemePalette = 'warn';
  colorAccent: ThemePalette = 'accent';
  mode: ProgressBarMode = 'determinate';
  value = 50;
  bufferValue = 75;

  constructor(
    public dialogRef: MatDialogRef<HodModalShowRequirsComponent>,
    private _http: HttpClient,
    private share: ShareService
  ) {
  }

  ngOnInit(): void {
    this._http.get<PackageRequirs>(`${environment.hod_api_url}analyser/get/requirs/${this.selectedDir.Dir_id}`,
      {
        headers: {
          'Accept': 'application/json', 
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      }).subscribe(result => {
        console.log(result);
        // console.log(result.Requirs.length);
        this.requirs = result;
      });
  }

  ngOnChanged(): void {
    if (this.selectedDir != null) {
      console.log('works');
      this.selectedDir.Requirs.length
    }
  }

  // When the user clicks the action button a.k.a. the logout button in the\
  // modal, show an alert and followed by the closing of the modal
  actionFunction() {
    // alert("You have logged out.");
    this.closeModal();
  }

  // If the user clicks the cancel button a.k.a. the go back button, then\
  // just close the modal
  closeModal() {
    this.dialogRef.close();
  }

  public getColorForRequirs1() {
    if (this.requirs.Mark722) { return this.colorPrimary; }
    return this.colorPrimary;
  }
  public getColorForRequirs2() {
    if (this.requirs.Mark723) { return this.colorPrimary; }
    return this.colorWarn;
  }
  public getColorForRequirs3() {
    if (this.requirs.Mark724) { return this.colorPrimary; }
    return this.colorWarn;
  }

  public getDirStatus722Full() {
    let tmp = this.requirs;
    if (tmp.NumA722 == tmp.NumS722) { return 100; }
    let x = (tmp.NumS722 * 100) / tmp.NumA722;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    return x;
  }
  public getDirStatus723Full() {
    let tmp = this.requirs;
    if (tmp.NumA723 == tmp.NumS723) { return 100; }
    let x = (tmp.NumS723 * 100) / tmp.NumA723;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    return x;
  }
  public getDirStatus724Full() {
    let tmp = this.requirs;
    if (tmp.NumA724 == tmp.NumS724) { return 100; }
    let x = (tmp.NumS724 * 100) / tmp.NumA724;
    x = Math.round((x + Number.EPSILON) * 100) / 100;
    return x;
  }
  public getMark722Full() {
    // let tmp = this.groupStatus.filter(x => { return x.group_id == item.group_id })[0];
    let tmp = this.requirs;
    return tmp.Mark722;
  }
  public getMark723Full() {
    // let tmp = this.groupStatus.filter(x => { return x.group_id == item.group_id })[0];
    let tmp = this.requirs;
    return tmp.Mark723;
  }
  public getMark724Full() {
    // let tmp = this.groupStatus.filter(x => { return x.group_id == item.group_id })[0];
    let tmp = this.requirs;
    return tmp.Mark724;
  }

}
