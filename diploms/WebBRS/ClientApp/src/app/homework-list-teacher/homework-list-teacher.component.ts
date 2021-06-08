import { Component, OnInit, Inject } from '@angular/core';
import { ConfirmationDialog } from '../dialog-body/confirmation-dialog.component';
import { AlertDialogComponent } from '../dialog-body/alert-dialog/alert-dialog.component';
import { homeworkListTeacher_HttpService } from './http.serviceHomeworkListTeacher';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';

import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';
@Component({
  selector: 'app-homework-list-teacher',
  templateUrl: './homework-list-teacher.component.html',
  styleUrls: ['./homework-list-teacher.component.css']
})
export class HomeworkListTeacherComponent implements OnInit {
  public http: homeworkListTeacher_HttpService;
  public IdSelectedDraft: number;
  public IdSelectedDraftType: number;
  public IdSelectedSubject = 0;
  public IdDateSelected: string;
  public baseUrl: string;
  public conf: boolean;
  
  public Url = 'https://localhost:44371/';
  public DateTimeStart: string;
  public DateTimeEnd: string;
  public dialog: MatDialog;
  public snackBar: MatSnackBar;
  public idPortfolioUpdate: 0;
  public TimeTable2: AttedanceForWork[];
  public DraftTimeTables: DraftTimeTable[];
  public Subjects: SubjectForGroup[];
  public TypesTimeTable: TypeTimeTable[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private dialog2: MatDialog, private snackBar2: MatSnackBar) {
    this.http = new homeworkListTeacher_HttpService(http);
    this.baseUrl = baseUrl;
    this.dialog = dialog2;
    this.IdSelectedDraftType = -1045036686;
    this.IdSelectedDraft = -1096224834;
    this.conf = true;
  }
  selectChangeHandler10(event: any) {
    //update the ui
    //this.ta = event.target.value;
    let i = 0;
    let IdAtt = event.target.id;
    let Ball = event.target.value;
    //let IdTA = '';
    console.log(event.target.id);
    this.TimeTable2[this.TimeTable2.findIndex(st => st.IdAtt == IdAtt as number)].BallHW = Number(Ball);
    console.log(this.TimeTable2);
  }

  selectChangeHandler4(event: any) {

    this.conf = event.target.checked;
    console.log('кликлак', this.conf);
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.DateTimeStart, this.DateTimeEnd, this.IdSelectedSubject, this.conf)
      .subscribe(result => {
        this.TimeTable2 = result;

        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  selectChangeHandler(event: any) {
    //update the ui
    this.IdSelectedDraft = event.target.value;
    console.log(this.IdSelectedDraft);
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.DateTimeStart, this.DateTimeEnd, this.IdSelectedSubject, this.conf)
      .subscribe(result => {
        this.TimeTable2 = result;
      
        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getSubjects(this.IdSelectedDraft)
      .subscribe(result => {
        this.Subjects = result;

        console.log('Subjects ', this.Subjects);
        console.log('result/constructor2', result);

      }, error => {
          console.log('Subjects error', error);
      }
      );
  }
  selectChangeHandler2(event: any) {
    //update the ui
    this.IdSelectedDraftType = event.target.value;
    console.log(this.IdSelectedDraftType);
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.DateTimeStart, this.DateTimeEnd, this.IdSelectedSubject, this.conf)
      .subscribe(result => {
        this.TimeTable2 = result;
        console.log('IdSelectedType', this.IdSelectedDraftType);
        console.log('IdSelectedType', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getSubjects(this.IdSelectedDraft)
      .subscribe(result => {
        this.Subjects = result;

        console.log('Subjects ', this.Subjects);
        console.log('result/constructor2', result);

      }, error => {
        console.log('error/constructor2', error);
      }
      );
  }
  selectChangeHandler3(event: any) {
    //update the ui
    this.IdDateSelected = event.target.value;
    console.log(this.IdSelectedDraft);
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.DateTimeStart, this.DateTimeEnd, this.IdSelectedSubject, this.conf)
      .subscribe(result => {
        this.TimeTable2 = result;
        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  selectChangeHandler6(event: any) {

    this.DateTimeStart = event.target.value;
    //this.http.getPortfolios(this.conf, this.DateTimeStart, this.DateTimeEnd)
    //  .subscribe(result => {
    //    this.portfolios = result;

    //    console.log('portfolios', this.portfolios);
    //    console.log('result/constructor', result);

    //  }, error => {
    //    console.log('error/constructor', error);
    //  }
    //  );
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.DateTimeStart, this.DateTimeEnd, this.IdSelectedSubject, this.conf)
      .subscribe(result => {
        this.TimeTable2 = result;

        console.log('TimeTable2 ', this.TimeTable2);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    console.log(event.target.value);
  }
  selectChangeHandler7(event: any) {

    this.DateTimeEnd = event.target.value;
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.DateTimeStart, this.DateTimeEnd, this.IdSelectedSubject, this.conf)
      .subscribe(result => {
        this.TimeTable2 = result;

        console.log('TimeTable2 ', this.TimeTable2);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    console.log(event.target.value);
  }
  selectChangeHandler8(event: any) {

    this.IdSelectedSubject = event.target.value;
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.DateTimeStart, this.DateTimeEnd, this.IdSelectedSubject, this.conf)
      .subscribe(result => {
        this.TimeTable2 = result;

        console.log('TimeTable2 ', this.TimeTable2);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    console.log(event.target.value);
  }
  openDialog(event: any) {
    console.log('event IdAtt: ', event);
    this.idPortfolioUpdate = event.target.value;

    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите подтвердить задание?',
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
          console.log("факт", this.TimeTable2[this.TimeTable2.findIndex(st => st.IdAtt == this.idPortfolioUpdate as number)]);

          //this.TimeTable2[this.TimeTable2.findIndex(st => st.IdAtt == this.idPortfolioUpdate as number)] = 'true';
          //console.log("подтверждение", this.portfolios[this.portfolios.findIndex(st => st.IdPortfolio == this.idPortfolioUpdate as number)]);
          this.http.execute(this.TimeTable2[this.TimeTable2.findIndex(st => st.IdAtt == this.idPortfolioUpdate as number)])
            .subscribe(result => {
              console.log(result);
              this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.DateTimeStart, this.DateTimeEnd, this.IdSelectedSubject, this.conf)
                .subscribe(result => {
                  this.TimeTable2 = result;

                  console.log('TimeTable2 ', this.TimeTable2);
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
  ngOnInit() {
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.DateTimeStart, this.DateTimeEnd, this.IdSelectedSubject, this.conf)
      .subscribe(result => {
        this.TimeTable2 = result;

        console.log('keks', this.TimeTable2);
        console.log('result/constructor1', result);

      }, error => {
        console.log('error/constructor1', error);
      }
    );
    this.http.getDrafts(this.IdSelectedDraft)
      .subscribe(result => {
        this.DraftTimeTables = result;

        console.log('keks', this.DraftTimeTables);
      console.log('result/constructor2', result);

    }, error => {
      console.log('error/constructor2', error);
    }
    );
    this.http.getSubjects(this.IdSelectedDraft)
      .subscribe(result => {
        this.Subjects = result;

        console.log('keks', this.Subjects);
      console.log('result/constructor2', result);

    }, error => {
      console.log('error/constructor2', error);
    }
    );
    this.http.getDraftTypes(this.IdSelectedDraftType)
      .subscribe(result => {
        this.TypesTimeTable = result;

        console.log('TypesTimeTable', this.TypesTimeTable);
      console.log('result/constructor3', result);

    }, error => {
      console.log('error/constructor', error);
    }
    );
  }

}
interface SubjectForGroup {
  IdSFG: number,
  ID_reff: number,
  IdSubject: number,
  NameSubject: string
}

interface AttedanceForWork {
  IdAtt: number,
  TextDoClassWork: string,
  FilePath: string,
  PersonFIO: string,
  BallHW: number,
  Done: string,
  DatePass: string
}
interface DraftTimeTable {
  IdDFTT: number,
  _Description: string
}
interface TypeTimeTable {
  IdDTTT: number,
  _Description: string
} 
