import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpRequest, HttpHeaders } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { FormBuilder, FormGroup } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// import 'rxjs/Rx';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';

import { ShareService } from '../share.service';

import { DepDepDto } from '../_models/admin-models';
import { DepsDto, Direction } from '../_models/deps-models';
import { environment } from 'src/environments/environment';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';

@Component({
  selector: 'app-hod-show-dir-property',
  templateUrl: './hod-show-dir-property.component.html',
  styleUrls: ['./hod-show-dir-property.component.css']
})
export class HodShowDirPropertyComponent implements OnInit {

  selectedDep: DepsDto;
  selectedDir: Direction;

  constructor(
    private _http: HttpClient,
    private _formBuilder: FormBuilder,
    private snack: SnackBarComponent,
    public dialogRef: MatDialogRef<HodShowDirPropertyComponent>,
  ) { }

  ngOnInit(): void {
  }

  // downloadFile(data: Response) {
  //   const blob = new Blob([data], { type: 'text/csv' });
  //   const url = window.URL.createObjectURL(blob);
  //   window.open(url);
  // }

  // private downloadFile(data: any) {
  //   console.log('downloadFile ran');
  //   const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
  //   const url = window.URL.createObjectURL(blob);
  //   window.open(url);
  // }

  /**
     * Method is use to download file.
     * @param data - Array Buffer data
     * @param type - type of the document.
     */
  // downLoadFile(data: any, type: string) {
  //   let blob = new Blob([data], { type: type });
  //   let url = window.URL.createObjectURL(blob);
  //   let pwa = window.open(url);
  //   if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
  //     alert('Please disable your Pop-up blocker and try again.');
  //   }
  // }

  pathExcel: any;
  downloadProperty() {

    let path = this._http.get<PropertyDoc>(`${environment.hod_api_url}dirs/get/property-doc/${this.selectedDir.Dir_id}`)
      .subscribe(result => {
        // path = result;
        console.log(result);

        if (result) {
          this.pathExcel = result.path;
          window.open(`${environment.hod_api_url}${result.path}`);
        }
        else{
          console.log('cant download file');
          this.snack.openSnackBarFull(`Сервер недоступен.`, 'center', '', 3000);
        }

        // return path;
      })
      ;

    // let info = this._http.get<DirStatus>

    // console.log('path', path);
    // console.log('this.pathExcel', this.pathExcel);

    // window.close();

    // this._http.get(`${environment.hod_api_url}dirs/get/property-doc/${this.selectedDir.dir_id}`)
    //   .subscribe(response => this.downLoadFile(response, "application/ms-excel"));
    // .subscribe(result => {
    //   console.log('here is a property doc', result);
    //   // this.downloadFile(result);
    // })
    // , error => console.log('error download file', error)
    // , () => console.info('ok then');
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


}

interface PropertyDoc {
  path: string
}