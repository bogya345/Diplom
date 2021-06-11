import { Component, OnInit, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { HttpClient, HttpEventType } from '@angular/common/http';

import { ShareService } from '../share.service';

import { promotion_HttpService } from '../hod-promotion/_http.serviceHodPromotion';

import { DepsDto, Direction } from '../_models/deps-models';

@Component({
  selector: 'app-hod-modal-reload-ac-plan',
  templateUrl: './hod-modal-reload-ac-plan.component.html',
  styleUrls: ['./hod-modal-reload-ac-plan.component.css']
})
export class HodModalReloadAcPlanComponent implements OnInit {

  private _httpOwn: promotion_HttpService;

  public selectedDep: DepsDto;
  public selectedDir: Direction;

  public progress: number;
  public message: string;

  constructor(
    private _http: HttpClient,
    public dialogRef: MatDialogRef<HodModalReloadAcPlanComponent>,
    private share: ShareService,

  ) {
    this._httpOwn = new promotion_HttpService(_http);
  }



  ngOnInit(): void {
  }

  upload(files) {
    console.log(files);
    if (files.length === 0) return;
    this._httpOwn.postUploadRequest(files, 0, this.selectedDir.Dir_id)
      .subscribe(event => {

        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response)
          this.message = event.body.toString();

        // window.location.reload();
      });
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
