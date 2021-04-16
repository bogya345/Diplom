import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { MatDialogRef } from '@angular/material/dialog';

import { ShareService } from '../share.service';
// import { promotion_HttpService } from '../hod-promotion/_http.serviceHodPromotion';

import { Direction, DepInfo } from '../_models/deps-models';
import { Group } from '../_models/groups-models';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-hod-modal-promote',
  templateUrl: './hod-modal-promote.component.html',
  styleUrls: ['./hod-modal-promote.component.css']
})
export class HodModalPromoteComponent implements OnInit {

  isUnmappedSubject: boolean;
  subjectDepId: number;
  // selectedDep: DepInfo;
  selectedDir: Direction;
  selectedGroup: Group;
  selectedAcPl: any;
  selectedSubject: any;
  selectedAttRec: any;

  constructor(
    private _http: HttpClient,
    public dialogRef: MatDialogRef<HodModalPromoteComponent>,
    private share: ShareService,
  ) {

  }

  ngOnInit(): void {
    console.log('inited', this.selectedSubject, this.selectedAttRec);

    if (this.isUnmappedSubject) { // this.subjectDepId == null
      this._http.get(`${environment.hod_api_url}teachers/get/all`)
        .subscribe(result => {
        });
    }
    else {  // this.subjectDepId != null
      this._http.get(`${environment.hod_api_url}teachers/get/${this.subjectDepId}`)
        .subscribe(result => {
        });
    }

  }


  // When the user clicks the action button a.k.a. the logout button in the\
  // modal, show an alert and followed by the closing of the modal
  actionFunction() {
    alert("You have logged out.");
    this.closeModal();
  }

  // If the user clicks the cancel button a.k.a. the go back button, then\
  // just close the modal
  closeModal() {
    this.dialogRef.close();
  }

}
