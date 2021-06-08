import { Component, OnInit, Inject, ViewChild } from '@angular/core';
//import { ConfirmDialogService } from '../dialog-body/confirm-dialog.service';
import { ConfirmationDialog } from '../dialog-body/confirmation-dialog.component';
import { AlertDialogComponent } from '../dialog-body/alert-dialog/alert-dialog.component';
import { profile_HttpService } from './http.serviceProfile';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  version = VERSION;

  public http: profile_HttpService;
  public baseUrl: string;
  public portfolioAdd: PortfolioVM;
  public attedanceReason: AttedanceReason;
  public Url = 'https://localhost:44371/';
  public profile: ProfileVM;
  public portfolios: PortfolioVM[];
  public attedanceReasons: AttedanceReason[];
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

  openDialog(event: any) {
    console.log('event: ', event);
    this.idPortfolioDelete = event.target.value;
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите удалить активность',
        buttonText: {
          ok: 'Да',
          cancel: 'Нет'
        }
      }
    });
    //const snack = this.snackBar.open('Snack bar open before dialog');

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        //snack.dismiss();
        //const a = document.createElement('a');
        //a.click();
        //a.remove();
        //snack.dismiss();

        this.http.execute(this.idPortfolioDelete)
          .subscribe(result => {
            console.log(result);
            this.http.getPortfolios()
              .subscribe(result => {
                this.portfolios = result;

                console.log('portfolios', this.portfolios);
                console.log('result/constructor', result);

              }, error => {
                console.log('error/constructor', error);
              }
              );
          });
       
        //this.snackBar.open('Удаляется', 'Fechar', {
        //  duration: 2000,
        //});
      }
    });
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
  openDialog2(event: any) {
    console.log('event: ', event);
    //this.idPortfolioDelete = event.target.value;
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите добавить активность',
        buttonText: {
          ok: 'Да',
          cancel: 'Нет'
        }
      }
    });
    //const snack = this.snackBar.open('Snack bar open before dialog');

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        //snack.dismiss();
        //const a = document.createElement('a');
        //a.click();
        //a.remove();
        //snack.dismiss();

        this.postData();
        this.http.getPortfolios()
          .subscribe(result => {
            this.portfolios = result;

            console.log('portfolios', this.portfolios);
            console.log('result/constructor', result);

          }, error => {
            console.log('error/constructor', error);
          }
          );
        //this.snackBar.open('Удаляется', 'Fechar', {
        //  duration: 2000,
        //});
      }
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
  postData() {

    return this.http.postData(this.portfolioAdd)
      .subscribe(result => {
        console.log(result);
      });
  }
  openDialog3(event: any) {
    console.log('event: ', event);
    //this.idPortfolioDelete = event.target.value;
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите добавить справку?',
        buttonText: {
          ok: 'Да',
          cancel: 'Нет'
        }
      }
    });
    //const snack = this.snackBar.open('Snack bar open before dialog');

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        //snack.dismiss();
        //const a = document.createElement('a');
        //a.click();
        //a.remove();
        //snack.dismiss();

        this.postDataAtt();
        this.http.getPortfolios()
          .subscribe(result => {
            this.portfolios = result;

            console.log('portfolios', this.portfolios);
            console.log('result/constructor', result);

          }, error => {
            console.log('error/constructor', error);
          }
          );
        //this.snackBar.open('Удаляется', 'Fechar', {
        //  duration: 2000,
        //});
      }
    });
  }
  openDialog4(event: any) {
    console.log('event: ', event);
    this.idPortfolioDelete = event.target.value;
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите удалить справку?',
        buttonText: {
          ok: 'Да',
          cancel: 'Нет'
        }
      }
    });
    //const snack = this.snackBar.open('Snack bar open before dialog');

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        //snack.dismiss();
        //const a = document.createElement('a');
        //a.click();
        //a.remove();
        //snack.dismiss();

        this.http.execute2(this.idPortfolioDelete).subscribe(result => {
          console.log(result);
          this.http.getPortfolios()
            .subscribe(result => {
              this.portfolios = result;

              console.log('portfolios', this.portfolios);
              console.log('result/constructor', result);

            }, error => {
              console.log('error/constructor', error);
            }
            );
        });
        this.http.getPortfolios()
          .subscribe(result => {
            this.portfolios = result;

            console.log('portfolios', this.portfolios);
            console.log('result/constructor', result);

          }, error => {
            console.log('error/constructor', error);
          }
          );
        //this.snackBar.open('Удаляется', 'Fechar', {
        //  duration: 2000,
        //});
      }
    });
  }
  postDataAtt() {

    return this.http.postDataReason(this.attedanceReason)
      .subscribe(result => {
        console.log(result);
      });
  }
  ngOnInit() {
    this.http.getPortfolio(0)
      .subscribe(result => {
        this.portfolioAdd = result;

        console.log('keks', this.portfolioAdd = result);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getAttedance(0)
      .subscribe(result => {
        this.attedanceReason = result;

        console.log('keks', this.attedanceReason = result);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    this.http.getPortfolios()
      .subscribe(result => {
        this.portfolios = result;

        console.log('portfolios', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getAttedanceReason()
      .subscribe(result => {
        this.attedanceReasons = result;

        console.log('portfolios', this.attedanceReasons);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getProfile()
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
