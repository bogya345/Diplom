import { Component, OnInit, Inject  } from '@angular/core';
import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';

import { ConfirmationDialog } from '../dialog-body/confirmation-dialog.component';
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';
class PrikazRow {
  public IdPrikazRow: number;

  public CuratorID: number;
  public Curator: Person;
  public Curators: Person[];
  public IdGroup: number;
  public Groups: GroupVM[];
}

class GroupVM {
  idGroup: number;
  GroupName: string;
  //Specialty: string
  //Students: StudentEXC[]
}
class Person {
  IdPerson: number;
  PersonFIO: string;
  Rabota: string;
}

class Prikaz {
  IdPrikaz: number;
  DekanFIO: string;
  TextPrikaz: string;
  IdStudyYear: number;
  StudyYear: StudyYear;
  Rows: PrikazRow[];
}
interface StudyYear {
  IdStudyYear: number,
  _Description: string
}


//import { PrikazRow } from '../prikaz-curator/'
@Component({
  selector: 'app-prikaz-curator',
  templateUrl: './prikaz-curator.component.html',
  styleUrls: ['./prikaz-curator.component.css']
})


export class PrikazCuratorComponent implements OnInit {
  public groups: GroupVM[];
  public curators: Person[];
  public Prikaz: Prikaz;
  public ta: string;
  public dialog: MatDialog;
  public snackBar: MatSnackBar;

  private url = "/CuratorStatisticController";
  constructor(private http: HttpClient, private router: Router, private _route: ActivatedRoute, private dialog2: MatDialog, private snackBar2: MatSnackBar) {
    this.dialog = dialog2;
    this.snackBar = snackBar2;
    this.getCurators()
      .subscribe(result => {
        this.curators = result;

        console.log('curators ', this.curators);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    
    this.getGroups()
      .subscribe(result => {
        this.groups = result;

        console.log('groups  ', this.groups);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.getPrikaz()
      .subscribe(result => {
        this.Prikaz = result;
        this.Prikaz.Rows = result.Rows;
        let prikazRow = new PrikazRow();
        let Person: Person;
        console.log('приказ', this.Prikaz);
        console.log('приказ строка', prikazRow);
        prikazRow.Curator = this.curators[0];
        prikazRow.Curators = this.curators;
        prikazRow.Groups = this.groups;
        prikazRow.CuratorID = this.curators[0].IdPerson;
        console.log('prikazRow ', prikazRow);
        this.Prikaz.Rows = Array<PrikazRow>(0);
        this.Prikaz.Rows.push(prikazRow);

        //this.Prikaz.PrikazRows = new PrikazRow[];
        console.log('Prikaz  ', this.Prikaz);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    
  }
  doTextareaValueChange2(ev) {
    try {
      this.Prikaz.TextPrikaz = ev.target.value;
      console.info(this.Prikaz.TextPrikaz);
    } catch (e) {
      console.info('could not set textarea-value');
    }
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
  postData() {
    console.log('приказ на создание: ', this.Prikaz);
    return this.http.post(this.url + "/CreatePrikaz", this.Prikaz)
      .subscribe(result => {
        console.log(result);
      });
  }
  addNewRow() {
    let prikazRow = new PrikazRow();
    let Person: Person;
    console.log('приказ', this.Prikaz);
    console.log('приказ строка', prikazRow);
    prikazRow.Curator = this.curators[0];
    prikazRow.CuratorID = this.curators[0].IdPerson;
    prikazRow.IdGroup = this.groups[0].idGroup;
    prikazRow.Curators = this.curators;
    prikazRow.Groups = this.groups;
    prikazRow.CuratorID = this.curators[0].IdPerson;
    prikazRow.IdPrikazRow = this.Prikaz.Rows.length;
    this.Prikaz.Rows.push(prikazRow);
    //this.ngOnInit();
  }
  selectChangeHandler2(event: any) {
    //update the ui
    this.ta = event.target.id;
    let i = 0;
    let IdAtt = '';
    let IdTA = '';

    console.log('event ', event);

    this.Prikaz.Rows[this.ta].CuratorID = this.curators[event.target.options.selectedIndex].IdPerson;
    this.Prikaz.Rows[this.ta].Curator = this.curators[event.target.options.selectedIndex];
    console.log(' this.Prikaz.Rows[this.ta ].CuratorID  ', this.Prikaz.Rows[this.ta] )
    console.log(' this.curators[event.target.options.selectedIndex].IdLecturer', this.curators[event.target.options.selectedIndex])
  }
  selectChangeHandler3(event: any) {
    //update the ui
    this.ta = event.target.id;
    let i = 0;
    let IdAtt = '';
    let IdTA = '';

    console.log('event ', event);
    console.log('Prikaz.Rows[this.ta] ', this.Prikaz.Rows);

    this.Prikaz.Rows[this.ta].IdGroup = this.groups[event.target.options.selectedIndex].idGroup;
    //this.Prikaz.Rows[this.ta]. = this.groups[event.target.options.selectedIndex];
    //console.log(' this.Prikaz.Rows[this.ta ].CuratorID  ', this.Prikaz.Rows[this.ta])
    //console.log(' this.curators[event.target.options.selectedIndex].IdLecturer', this.curators[event.target.options.selectedIndex])
  }
  getCurators(): Observable<Person[]> {
    return this.http.get<Person[]>(`CuratorStatisticController/GetCuratorsForPrikaz`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getPrikaz(): Observable<Prikaz> {
    return this.http.get<Prikaz>(`CuratorStatisticController/GetPrikaz`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getGroups(): Observable<GroupVM[]> {
    return this.http.get<GroupVM[]>(`CuratorStatisticController/GetGroupsForPrikaz`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  ngOnInit() {
    this.getCurators()
      .subscribe(result => {
        this.curators = result;

        console.log('curators ', this.curators);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );

    this.getGroups()
      .subscribe(result => {
        this.groups = result;

        console.log('groups  ', this.groups);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
    this.getPrikaz()
      .subscribe(result => {
        this.Prikaz = result;
        this.Prikaz.Rows = result.Rows;
        let prikazRow = new PrikazRow();
        let Person: Person;
        console.log('приказ', this.Prikaz);
        console.log('приказ строка', prikazRow);
        prikazRow.Curator = this.curators[0];
        prikazRow.Curators = this.curators;
        prikazRow.Groups = this.groups;
        prikazRow.IdGroup = this.groups[0].idGroup;
        prikazRow.CuratorID = this.curators[0].IdPerson;
        prikazRow.IdPrikazRow = 0;
        console.log('prikazRow ', prikazRow);
        this.Prikaz.Rows = Array<PrikazRow>(0);
        this.Prikaz.Rows.push(prikazRow);

        //this.Prikaz.PrikazRows = new PrikazRow[];
        console.log('Prikaz  ', this.Prikaz);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }

}
