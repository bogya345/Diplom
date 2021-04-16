import { Component, OnInit } from '@angular/core';
import {
  MatSnackBar,
  MatSnackBarConfig,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition,
} from '@angular/material/snack-bar';

@Component({
  selector: 'app-snack-bar',
  templateUrl: './snack-bar.component.html',
  styleUrls: ['./snack-bar.component.css']
})
export class SnackBarComponent implements OnInit {

  horizontalPosition_right: MatSnackBarHorizontalPosition = 'right';
  horizontalPosition_left: MatSnackBarHorizontalPosition = 'left';
  horizontalPosition_center: MatSnackBarHorizontalPosition = 'center';

  verticalPosition_bottom: MatSnackBarVerticalPosition = 'bottom';
  verticalPosition_top: MatSnackBarVerticalPosition = 'top';

  constructor(private _snackBar: MatSnackBar) { }

  openSnackBar() {
    this._snackBar.open('Cannonball!!', 'End now', {
      duration: 5000,
      horizontalPosition: this.horizontalPosition_right,
      verticalPosition: this.verticalPosition_bottom,
    });
  }

  openSnackBarFull(msg: string, hor: string, ver: string, durationMs: number) {
    
    let hor_;
    switch(hor){
      case 'right': hor_ = this.horizontalPosition_right; break;
      case 'left': hor_ = this.horizontalPosition_left; break;
      case 'center': hor_ = this.horizontalPosition_center; break;
      default:
        console.log('wrong horizontal position')
        hor_ = this.horizontalPosition_center; break;
    }

    let ver_;
    switch(ver_){
      case 'right': ver_ = this.verticalPosition_top; break;
      case 'left': ver_ = this.verticalPosition_bottom; break;
      default:
        console.log('wrong vertical position')
        ver_ = this.verticalPosition_bottom; break;
    }

    this._snackBar.open(`${msg}`, 'Close', {
      duration: durationMs,
      horizontalPosition: hor_,
      verticalPosition: ver_,
    });
  }

  openSnackBarWithMsg(msg: string) {
    this._snackBar.open(`${msg}`, 'Close', {
      duration: 2000,
      horizontalPosition: this.horizontalPosition_right,
      verticalPosition: this.verticalPosition_bottom,
    });
  }
  

  ngOnInit(): void { }

}
