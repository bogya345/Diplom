import { Component, OnInit, Inject } from '@angular/core';
import { VERSION, MatDialogRef, MatDialog, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';

import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
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
@Component({
  selector: 'app-prikaz-curator-pdf',
  templateUrl: './prikaz-curator-pdf.component.html',
  styleUrls: ['./prikaz-curator-pdf.component.css']
})
export class PrikazCuratorPDFComponent implements OnInit {
  public baseUrl: string;
  public Url = 'https://localhost:44371/';
  public Prikaz: Prikaz;
  public ta: string;
  public idPrikaza: number;
  public dialog: MatDialog;
  public snackBar: MatSnackBar;
  public now: Date;
  constructor(private http: HttpClient, private router: Router, private _route: ActivatedRoute, private dialog2: MatDialog, private snackBar2: MatSnackBar) {
    this.dialog = dialog2;
    this.snackBar = snackBar2;
    let IdECFLCT = this._route.snapshot.paramMap.get('IdPrikaza');
    this.getPrikaz(Number(IdECFLCT))
      .subscribe(result => {
        this.Prikaz = result;
        console.log('prikazes ', this.Prikaz);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  getPrikaz(IdECFLCT: number): Observable<Prikaz> {
    return this.http.get<Prikaz>(`CuratorStatisticController/GetPikazPrint/${IdECFLCT}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  ngOnInit() {
    let IdECFLCT = this._route.snapshot.paramMap.get('IdPrikaza');
    this.getPrikaz(Number(IdECFLCT))
      .subscribe(result => {
        this.Prikaz = result;
        console.log('prikazes ', this.Prikaz);
        console.log('result/constructor', result);
        window.print();


      }, error => {
        console.log('error/constructor', error);
      }
    );
  }

}
