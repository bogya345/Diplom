import { Component, OnInit, Inject, ViewChild } from '@angular/core';
//import { ConfirmDialogService } from '../dialog-body/confirm-dialog.service';
import { ConfirmationDialog } from '../dialog-body/confirmation-dialog.component';
import { AlertDialogComponent } from '../dialog-body/alert-dialog/alert-dialog.component';
import { confirmedList_HttpService } from './http.curatorConfirmedList';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';

import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-curator-confirmed-list',
  templateUrl: './curator-confirmed-list.component.html',
  styleUrls: ['./curator-confirmed-list.component.css']
})
export class CuratorConfirmedListComponent implements OnInit {
  version = VERSION;
  public conf: boolean;
  public http: confirmedList_HttpService;
  public baseUrl: string;
  public Url =  'https://localhost:44371/';
  public portfolioAdd: PortfolioVM;
  public profile: ProfileVM;
  public portfolios: PortfolioVM[];
  public attedances: AttedanceReason[];
  //@ViewChild('deleteModal', { static: false }) public deleteModal: YesNoModalComponent;
  public dialog: MatDialog;
  public snackBar: MatSnackBar;
  public idPortfolioUpdate: 0;
  public DateTimeStart: string;
  public DateTimeEnd: string;
  public notConfirmed: boolean;
  //private confirmDialogService: ConfirmDialogService;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router, private _route: ActivatedRoute, private dialog2: MatDialog, private snackBar2: MatSnackBar) {
    this.http = new confirmedList_HttpService(http);
    this.baseUrl = baseUrl; /*, private snackBar: MatSnackBar*/
    this.dialog = dialog2;
    this.snackBar = snackBar2;
    this.conf = false;
  }

  selectChangeHandler4(event: any) {

    this.conf = event.target.checked;
    console.log('кликлак',this.conf );
    this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.portfolios = result;

        console.log('portfolios', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getAttedanceReasons(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.attedances = result;

        console.log('attedance', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }

  doTextareaValueChange(ev) {
    try {
      this.portfolioAdd.Description = ev.target.value;
      console.info(this.portfolioAdd.Description);
    } catch (e) {
      console.info('could not set textarea-value');
    }
  }
  openDialog(event: any) {
    console.log('event: ', event.target.value);
    this.idPortfolioUpdate = event.target.value;

    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите подтвердить активность?',
        buttonText: {
          ok: 'Да',
          cancel: 'Нет'
        }
      }
    });
    //const snack = this.snackBar.open('Snack bar open before dialog');

    dialogRef.afterClosed()
      .subscribe((confirmed: boolean) => {
      if (confirmed) {
        //snack.dismiss();
        //const a = document.createElement('a');
        //a.click();
        //a.remove();
        //snack.dismiss();
        console.log("факт", this.portfolios[this.portfolios.findIndex(st => st.IdPortfolio == this.idPortfolioUpdate as number)].Confirmed);

        this.portfolios[this.portfolios.findIndex(st => st.IdPortfolio == this.idPortfolioUpdate as number)].Confirmed = 'true';
        console.log("подтверждение",this.portfolios[this.portfolios.findIndex(st => st.IdPortfolio == this.idPortfolioUpdate as number)]);
        this.http.execute(this.portfolios[this.portfolios.findIndex(st => st.IdPortfolio == this.idPortfolioUpdate as number)])
          .subscribe(result => {
            console.log(result);
            this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
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
  selectChangeHandler6(event: any) {

    this.DateTimeStart = event.target.value;
    this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.portfolios = result;

        console.log('portfolios', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getAttedanceReasons(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.attedances = result;

        console.log('attedance', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    console.log(event.target.value);
  }
  selectChangeHandler7(event: any) {

    this.DateTimeEnd = event.target.value;
    this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.portfolios = result;

        console.log('portfolios', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getAttedanceReasons(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.attedances = result;

        console.log('attedance', this.attedances);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    console.log(event.target.value);
  }
  openDialog2(event: any) {
    console.log('event: ', event);
    this.idPortfolioUpdate = event.target.id;
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите отклонить активность?',
        buttonText: {
          ok: 'Да',
          cancel: 'Нет'
        }
      }
    });
    //const snack = this.snackBar.open('Snack bar open before dialog');

    dialogRef.afterClosed()
      .subscribe((confirmed: boolean) => {
        if (confirmed) {
          //snack.dismiss();
          //const a = document.createElement('a');
          //a.click();
          //a.remove();
          //snack.dismiss();
          this.portfolios[this.portfolios.findIndex(st => st.IdPortfolio == this.idPortfolioUpdate as number)].Confirmed = 'false';

          this.http.execute(this.portfolios[this.portfolios.findIndex(st => st.IdPortfolio == this.idPortfolioUpdate as number)])
            .subscribe(result => {
              console.log(result);
              this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
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
  openDialog3(event: any) {
    console.log('event: ', event);
    this.idPortfolioUpdate = event.target.value;
   console.log ('Idatt ', this.idPortfolioUpdate as number);
    console.log('event.target ', event.target);
   console.log ('att ',this.attedances.findIndex(st => st.IdAttReas == this.idPortfolioUpdate as number));

    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите подтвердить справку?',
        buttonText: {
          ok: 'Да',
          cancel: 'Нет'
        }
      }
    });
    //const snack = this.snackBar.open('Snack bar open before dialog');

    dialogRef.afterClosed()
      .subscribe((confirmed: boolean) => {
        if (confirmed) {
          //snack.dismiss();
          //const a = document.createElement('a');
          //a.click();
          //a.remove();
          //snack.dismiss();
          
          this.attedances[this.attedances.findIndex(st => st.IdAttReas == this.idPortfolioUpdate as number)].Confirmed = 'true';

          this.http.execute2(this.attedances[this.attedances.findIndex(st => st.IdAttReas == this.idPortfolioUpdate as number)])
            .subscribe(result => {
              console.log(result);
              this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
                .subscribe(result => {
                  this.portfolios = result;

                  console.log('portfolios', this.portfolios);
                  console.log('result/constructor', result);

                }, error => {
                  console.log('error/constructor', error);
                }
              );
     
                this.http.getAttedanceReasons(this.conf, this.DateTimeStart, this.DateTimeEnd)
                  .subscribe(result => {
                    this.attedances = result;

                    console.log('attedance', this.portfolios);
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
  openDialog4(event: any) {
    console.log('event: ', event);
    this.idPortfolioUpdate = event.target.value;
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите отклонить справку?',
        buttonText: {
          ok: 'Да',
          cancel: 'Нет'
        }
      }
    });
    //const snack = this.snackBar.open('Snack bar open before dialog');

    dialogRef.afterClosed()
      .subscribe((confirmed: boolean) => {
        if (confirmed) {
          //snack.dismiss();
          //const a = document.createElement('a');
          //a.click();
          //a.remove();
          //snack.dismiss();
          this.attedances[this.attedances.findIndex(st => st.IdAttReas == this.idPortfolioUpdate as number)].Confirmed = 'false';

          this.http.execute2(this.attedances[this.attedances.findIndex(st => st.IdAttReas == this.idPortfolioUpdate as number)])
            .subscribe(result => {
              console.log(result);
              this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
                .subscribe(result => {
                  this.portfolios = result;

                  console.log('portfolios', this.portfolios);
                  console.log('result/constructor', result);

                }, error => {
                  console.log('error/constructor', error);
                }
              );
              this.http.getAttedanceReasons(this.conf, this.DateTimeStart, this.DateTimeEnd)
                .subscribe(result => {
                  this.attedances = result;

                  console.log('attedance', this.portfolios);
                  console.log('result/constructor', result);

                }, error => {
                  console.log('error/constructor', error);
                }
                );
            });
 
        }
      });
  }
  postData() {

    return this.http.postData(this.portfolioAdd)
      .subscribe(result => {
        console.log(result);
      });
  }
  update() {
    this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.portfolios = result;

        console.log('portfolios', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    this.http.getAttedanceReasons(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.attedances = result;

        console.log('attedance', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
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
    this.DateTimeStart = String(Date.now());
    this.DateTimeEnd = String(Date.now());
    this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.portfolios = result;

        console.log('portfolios', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getAttedanceReasons(this.conf, this.DateTimeStart, this.DateTimeEnd)
      .subscribe(result => {
        this.attedances = result;

        console.log('attedance', this.portfolios);
        console.log('result/constructor', result);

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
  Portfolios: PortfolioVM[];
}
interface PortfolioVM {
  IdPortfolio: number,
  IdPerson: number,
  IdCourator: number,
  Description: string,
  Name: string,
  FilePath: string,
  PersonFIOconfirmed: string,
  PersonFIO: string,
  DateAdded: string,
  DateConfirmed: string,
  DateNotConfirmed: string,
  Confirmed: string

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
  Confirmed: string
}
