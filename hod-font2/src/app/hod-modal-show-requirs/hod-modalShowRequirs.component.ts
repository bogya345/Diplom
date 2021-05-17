import { Component, OnInit, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

import { ShareService } from '../share.service';

import {
  Direction
} from '../_models/deps-models';

@Component({
  selector: 'app-hod-modalShowRequirs',
  templateUrl: './hod-modalShowRequirs.component.html',
  styleUrls: ['./hod-modalShowRequirs.component.css']
})
export class HodModalShowRequirsComponent implements OnInit {

  // @Input('selectedDir') selectedDir: Direction;
  public selectedDir: Direction;

  constructor(
    public dialogRef: MatDialogRef<HodModalShowRequirsComponent>,
    private share: ShareService
  ) {
  }

  ngOnInit(): void {
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
    alert("You have logged out.");
    this.closeModal();
  }

  // If the user clicks the cancel button a.k.a. the go back button, then\
  // just close the modal
  closeModal() {
    this.dialogRef.close();
  }

}
