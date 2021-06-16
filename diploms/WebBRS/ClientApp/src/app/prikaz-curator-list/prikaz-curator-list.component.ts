import { Component, OnInit, Inject } from '@angular/core';
import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';

import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
class PrikazRow {
  public IdPrikazRow: number;

  public CuratorID: number;
  public Curator: Person;

  public IdGroup: number;

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
  public  IdPrikaz: number;
  public DekanFIO: string;
  public TextPrikaz: string;
  public IdStudyYear: number;
  public StudyYear: StudyYear;
  public Rows: PrikazRow[];
}
interface StudyYear {
  IdStudyYear: number,
  _Description: string
}
@Component({
  selector: 'app-prikaz-curator-list',
  templateUrl: './prikaz-curator-list.component.html',
  styleUrls: ['./prikaz-curator-list.component.css']
})
export class PrikazCuratorListComponent implements OnInit {
  public prikazes: Prikaz[];
  constructor(private http: HttpClient, private router: Router, private _route: ActivatedRoute, private dialog2: MatDialog, private snackBar2: MatSnackBar) {
    this.getPrikaz()
      .subscribe(result => {
        this.prikazes = result;

        console.log('prikazes ', this.prikazes);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  getPrikaz(): Observable<Prikaz[]> {
    return this.http.get<Prikaz[]>(`CuratorStatisticController/GetPikazes`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  ngOnInit() {
 
  }

}
