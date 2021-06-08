import { Component, OnInit, Inject } from '@angular/core';
import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';

import { ConfirmationDialog } from '../dialog-body/confirmation-dialog.component';
import { AlertDialogComponent } from '../dialog-body/alert-dialog/alert-dialog.component';
import { attedance_HttpService } from './http.serviceAttedance';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css']
})


export class AttendanceComponent implements OnInit {
  public selectedFile: File = null;
  public http: attedance_HttpService;
  public baseUrl: string;
  public ecflct: ExactClassForLecturerClass;
  public selectedGroup: GroupVM;
  public now: Date;
  public UrlFileUpload = 'api/fileupload';
  public Url = 'https://localhost:44371/';
  public ta: string;
  public dialog: MatDialog;
  public snackBar: MatSnackBar;
  public cw: ClassWork;
  selectChangeHandler(event: any) {
    //update the ui
    this.ecflct.SelectedGroup = event.target.value;
    console.log(this.selectedGroup.idGroup);
    this.http.getAttedanceForLecturerClass(this.ecflct.IdECFLCT, this.ecflct.IdClass, this.ecflct.SelectedGroup)
      .subscribe(result => {
        this.ecflct = result;

        //this.ecflct.SubjectName = result.SubjectName;

        //this.ecflct.Groups = result.Groups;
        //this.ecflct.Students = result.Students;
        //this.ecflct.IdClass = result.IdClass;
        this.ecflct.SelectedGroup = result.SelectedGroup;
        console.log('keks', this.ecflct);

        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  selectChangeHandler2(event: any) {
    //update the ui
    this.ta = event.target.value;
    let i = 0;
    let IdAtt = '';
    let IdTA = '';
    while (this.ta[i] != '/') {
      IdAtt = IdAtt + this.ta[i];
      i++;
      // code block to be executed
    };
    i++;
    while (this.ta.length > i) {
      IdTA = IdTA + this.ta[i];
      i++;
      // code block to be executed
    };
    //console.log(IdAtt);

    this.ecflct.Students[this.ecflct.Students.findIndex(st => st.IdAttedance == IdAtt as unknown as number)].AttedanceTypeSelected = Number(IdTA);

  }
  selectChangeHandler3(event: any) {
    //update the ui
    this.ta = event.target.value;
    let i = 0;
    let IdAtt = event.target.id;
    let Ball = event.target.value;
    //let IdTA = '';
    console.log(event.target.id);
    this.ecflct.Students[this.ecflct.Students.findIndex(st => st.IdAttedance == IdAtt as number)].Ball = Number(Ball);
    console.log(this.ecflct);
  }
  selectChangeHandler4(event: any) {

    this.cw.MaxBall = Number(event.target.value);
    console.log(event.target.value);
  }
  selectChangeHandler5(event: any) {
    //update the ui
    this.cw.DatePass = event.target.value;
    console.log(this.cw.DatePass);
    //this.http.getTeacherClassList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected)
    //  .subscribe(result => {
    //    this.TimeTable2 = result;
    //    this.TimeTable2.Days = result.Days;
    //    console.log('keks', this.TimeTable2);
    //    console.log('result/constructor', result);
    //  }, error => {
    //    console.log('error/constructor', error);
    //  }
    //  );
  }
  selectChangeHandler6(event: any) {

    this.cw.IdWT = Number(event.target.value);
    console.log(event.target.value);
  }
  postData() {

    return this.http.updateAtt(this.ecflct)
      .subscribe(result => {
        console.log(result);
      });
  }
  postDataCW() {
    console.log("Дз 1", this.cw);
    return this.http.updateCW(this.cw)
      .subscribe(result => {
        console.log(result);
      });
  }
  selectChangeHandler10(event: any) {
    //update the ui
    this.ta = event.target.value;
    let i = 0;
    let IdAtt = event.target.id;
    let Ball = event.target.value;
    //let IdTA = '';
    console.log(event.target.id);
    this.ecflct.Students[this.ecflct.Students.findIndex(st => st.IdAttedance == IdAtt as number)].BallHW = Number(Ball);
    console.log(this.ecflct);
  }
  doTextareaValueChange(ev) {
    try {
      this.cw.TextWork = ev.target.value;
      console.info(this.cw.TextWork);
    } catch (e) {
      console.info('could not set textarea-value');
    }
  }
  constructor(http: HttpClient, private router: Router, private _route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string, private dialog2: MatDialog, private snackBar2: MatSnackBar) {
    this.http = new attedance_HttpService(http);
    this.baseUrl = baseUrl;
    this.dialog = dialog2;
    this.snackBar = snackBar2;
    this.selectedGroup = { idGroup: null, GroupName: '' }
  }
  openDialog(event: any) {
    console.log('event: ', event);
    //this.idPortfolioDelete = event.target.value;
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите обновить посещаемость?',
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
      
        //this.snackBar.open('Удаляется', 'Fechar', {
        //  duration: 2000,
        //});
      }
    });
  }
  onSelectFile(fileInput: any) {
    this.cw.File = <File>fileInput.target.files[0];
    console.log('FileAdded  ', this.cw);
  }
  openDialog2(event: any) {
    console.log('event: ', event);
    //this.idPortfolioDelete = event.target.value;
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message: 'Вы хотите выдать задание?',
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

        this.postDataCW();

        //this.snackBar.open('Удаляется', 'Fechar', {
        //  duration: 2000,
        //});
      }
    });
  }
  ngOnInit() {
    let IdClass = this._route.snapshot.paramMap.get('IdClass');
    let IdECFLCT = this._route.snapshot.paramMap.get('IdECFLCT');
    let IdselectedGroup = this._route.snapshot.paramMap.get('IdselectedGroup');

    //const id = Number(this.route.snapshot);
    this.http.getAttedanceForLecturerClass(IdECFLCT, IdClass, IdselectedGroup)
      .subscribe(result => {
        this.ecflct = result;
        this.ecflct.SelectedGroup = result.SelectedGroup;
        console.log('keks', this.ecflct);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    this.http.getClassWorkExactClass(IdClass)
      .subscribe(result => {
        this.cw = result;
        this.cw.IdWT = result.IdWT;
        //if (this.cw=null) {
        //  this.cw =
        //  {
        //    IdClasss: Number(IdClass),
        //    FilePathWork: '',
        //    TextWork: '',
        //    MaxBall: 0,
        //    IdClassWork: null,
        //    DatePass: Date.now() as unknown as Date
        //  }
        //}
        //this.ecflct.SelectedGroup = result.SelectedGroup;
        this.http.getClassWorkTypes(this.cw.IdWT)
          .subscribe(result => {
            this.cw.WorkTypes = result;
            //if (this.cw=null) {
            //  this.cw =
            //  {
            //    IdClasss: Number(IdClass),
            //    FilePathWork: '',
            //    TextWork: '',
            //    MaxBall: 0,
            //    IdClassWork: null,
            //    DatePass: Date.now() as unknown as Date
            //  }
            //}
            //this.ecflct.SelectedGroup = result.SelectedGroup;
            console.log('result/constructorWT', this.cw.WorkTypes);

          }, error => {
            console.log('error/constructor2', error);
          }
          );
        console.log('result/constructor2', this.cw);

      }, error => {
        console.log('error/constructor2', error);
      }
    );

  }

}

interface ClassWork {
  IdClassWork: number,
  IdClass: number,
  TextWork: string,
  FilePathWork: string,
  MaxBall: number,
  DatePass: Date,
  IdWT: number,
  WorkType: WorkType,
  WorkTypes: WorkType[],
  File: File
}
interface WorkType {
  IdWT: number,
  WorkTypeName: string,
  ShortWorkTypeName: string

}
interface GroupVM {
  idGroup: number,
  GroupName: string
  //Specialty: string
  //Students: StudentEXC[]
}
interface ExactClassForLecturerClass {
  IdClass: number,
  IdECFLCT: number,
  Lecturer: Lecturer,
  Students: StudentEXC[],
  Groups: GroupVM[],
  SelectedGroup: number,
  SubjectName: string
  DateTime: string
}
class TypeAttedanceVM {
  IdTA: number;
  TAName: string;
  TAShortName: string;
  IdAtt: number;
}
interface StudentEXC {
  IdAttedance: number,
  IdStudent: number,
  PersonFIO: string,
  AttedanceTypeSelected: number,
  Attedanced: TypeAttedanceVM[],
  Ball: number,
  BallHW: number,
  HW: HomeWorkStudent
}
interface HomeWorkStudent {
  IdHWS: number,
  ShortTextHW: string,
  StringFilePath: string
}
interface Lecturer {
  IdLecturer: number,
  PersonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  //numberClass: number
  //Group: Group
}

