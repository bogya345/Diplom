import { Component, OnInit, Inject, ViewChild } from '@angular/core';
//import { ConfirmDialogService } from '../dialog-body/confirm-dialog.service';
import { ConfirmationDialog } from '../dialog-body/confirmation-dialog.component';
import { AlertDialogComponent } from '../dialog-body/alert-dialog/alert-dialog.component';
import { profile_HttpService } from './http.serviceProfile';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';
@Component({
  selector: 'app-profileforview',
  templateUrl: './profileforview.component.html',
  styleUrls: ['./profileforview.component.css']
})
export class ProfileforviewComponent implements OnInit {
  version = VERSION;
  public Groups: GroupVM[];
  public http: profile_HttpService;
  public baseUrl: string;
  public portfolioAdd: PortfolioVM;
  public attedanceReason: AttedanceReason;
  public Url = 'https://localhost:44371/';
  public profile: ProfileVM;
  public portfolios: PortfolioVM[];
  public attedanceReasons: AttedanceReason[];
  public SelectedGroup: GroupVM;
  //@ViewChild('deleteModal', { static: false }) public deleteModal: YesNoModalComponent;
  public dialog: MatDialog;
  public snackBar: MatSnackBar;
  public idPortfolioDelete: 0;
  //private confirmDialogService: ConfirmDialogService;

  constructor(http: HttpClient, private router: Router, private _route: ActivatedRoute, private dialog2: MatDialog, private snackBar2: MatSnackBar) {
    this.http = new profile_HttpService(http);
    //this.baseUrl = baseUrl; , private snackBar: MatSnackBar
    this.dialog = dialog2;
    this.snackBar = snackBar2;

  }

  selectChangeHandler4(event: any) {

    this.portfolioAdd.Name = event.target.value;
    console.log(event.target.value);
  }
  selectChangeHandler5(event: any) {

    this.attedanceReason.DocName = event.target.value;
    console.log(event.target.value);
  }
  selectChangeHandler6(event: any) {

    this.attedanceReason.DateTimeStart = event.target.value;
    console.log(event.target.value);
  }
  selectChangeHandler7(event: any) {

    this.attedanceReason.DateTimeEnd = event.target.value;
    console.log(event.target.value);
  }

  doTextareaValueChange(ev) {
    try {
      this.portfolioAdd.Description = ev.target.value;
      console.info(this.portfolioAdd.Description);
    } catch (e) {
      console.info('could not set textarea-value');
    }
  }
  onSelectFile(fileInput: any) {
    this.portfolioAdd.File = <File>fileInput.target.files[0];
    console.log('FileAdded  ', this.portfolioAdd);
  }
  onSelectFile2(fileInput: any) {
    this.attedanceReason.File = <File>fileInput.target.files[0];
    console.log('FileAdded  2', this.attedanceReason);
  }


  openAlertDialog() {
    const dialogRef = this.dialog.open(AlertDialogComponent, {
      data: {
        message: 'HelloWorld',
        buttonText: {
          cancel: 'Done'
        }
      },
    });
  }

  //showDialog() {
  //  this.confirmDialogService.confirmThis("Are you sure to delete?", function () {
  //    alert("Yes clicked");
  //    //this.idPortfolioDelete = event.target.value;
  //    //this.http.execute(this.idPortfolioDelete);
  //  }, function () {
  //    alert("No clicked");
  //  })
  //}  
  //delete(data) {
  //  this.deleteModal.showAsync(data).then(result => {
  //   
  //  });
  //}


  ngOnInit() {
    let Id = this._route.snapshot.paramMap.get('IdPerson');
    console.log('ID:  ', Id);
    this.http.getPortfolio(Id)
      .subscribe(result => {
        this.portfolioAdd = result;

        console.log('keks', this.portfolioAdd = result);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    this.http.getPortfolio2(Id)
      .subscribe(result => {
        this.Groups = result;
        this.SelectedGroup = this.Groups[0];
        console.log('keks', this.Groups);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );

    this.http.getPortfolios(Id)
      .subscribe(result => {
        this.portfolios = result;

        console.log('portfolios', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    this.http.getAttedanceReason(Id)
      .subscribe(result => {
        this.attedanceReasons = result;

        console.log('portfolios', this.attedanceReasons);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    this.http.getProfile(Id)
      .subscribe(result => {
        this.profile = result;
        console.log('portfolios', this.profile);
        //console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }

}
interface ProfileVM {
  IdPerson: number,
  PersonFIO: string,
  NopeAttedanceConfirmed: number,
  NopeAttedanceProc: number,
  NopeAttedance: number,
  Group: string,
  Portfolios: PortfolioVM[]
}
interface PortfolioVM {
  IdPortfolio: number,
  IdPerson: number,
  Description: string,
  Name: string,
  FilePath: string,
  PersonFIOconfirmed: string,
  DateAdded: string,
  DateConfirmed: string,
  Confirmed: string,
  File: File

}
interface GroupVM {
  idGroup: number,
  GroupName: string,
  studentVMs: Student[],
  SubjectVMs: SubjectGroup[]
}
interface Student {
  IdStudent: number,
  PersonFIO: string,
  Balls: number,
  Attedanced: AttedancedVMType[]
}
interface SubjectGroup {
  IdSubject: number,
  SubjectName: string
}
interface AttedancedVMType {

  attedanced: string,
  Ball: string,
  BallHW: string
}
interface AttedanceReason {

  IdAttReas: number,
  DocName: string,
  IdPerson: number,
  IdSGH: number,
  IdCurator: number,
  PersonFIO: string,
  CuratorFIO: string,
  FilePath: string,
  DateTimeStart: string,
  DateTimeEnd: string,
  DateAdded: string,
  DateConfirmed: string,
  DateNotConfirmed: string,
  File: File
}
