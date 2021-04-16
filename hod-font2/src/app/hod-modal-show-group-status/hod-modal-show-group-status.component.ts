import { Component, OnInit, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { HttpClient, HttpEventType } from '@angular/common/http';

import { ShareService } from '../share.service';

import { promotion_HttpService } from '../hod-promotion/_http.serviceHodPromotion';

import { DepsDto, Direction } from '../_models/deps-models';
import { Group } from '../_models/groups-models';

@Component({
  selector: 'app-hod-modal-show-group-status',
  templateUrl: './hod-modal-show-group-status.component.html',
  styleUrls: ['./hod-modal-show-group-status.component.css']
})
export class HodModalShowGroupStatusComponent implements OnInit {

  private _httpOwn: promotion_HttpService;

  public selectedDep: DepsDto;
  public selectedDir: Direction;
  public selectedGroup: Group;

  public progress: number;
  public message: string;

  constructor(
    private _http: HttpClient,
    public dialogRef: MatDialogRef<HodModalShowGroupStatusComponent>,
    private share: ShareService,

  ) {
    // this._httpOwn = new promotion_HttpService(_http);
  }



  ngOnInit(): void {
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
