import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class attedance_HttpService {

  constructor(private http: HttpClient) { }
  getAttedanceForLecturerClasses(): Observable<ExactClassForLecturerClass> {
    return this.http.get<ExactClassForLecturerClass>(`attedance/ECFLC/1`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName) ng generate component pokemon-list --module=app
        //}
      });
  }
  getAttedanceExactClass(): Observable<ExactClass> {
    return this.http.get<ExactClass>(`attedance/getExactClass/1/2/1`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }

  //uploadFileToActivity() {
  //  this.fileUploadService.postFile(this.fileToUpload).subscribe(data => {
  //    // do something, if upload success
  //  }, error => {
  //    console.log(error);
  //  });
  //}
  //postFile(fileToUpload: File): Observable<boolean> {
  //  const endpoint = 'your-destination-url';
  //  const formData: FormData = new FormData();
  //  formData.append('fileKey', fileToUpload, fileToUpload.name);
  //  return this.httpClient
  //    .post(endpoint, formData, { headers: yourHeadersConfig })
  //    .map(() => { return true; })
  //    .catch((e) => this.handleError(e));
  //}
}
interface ClassWork {
  IdCW: number,
  TextWork: string,
  FilePathWork: string,
  MaxBall: number,
}
interface Group {
  idGroup: number,
  GroupName: string,
  Specialty: string,
  Students: Student[]
}
interface ExactClassForLecturerClass {
  IdECFLC: number,
  Lecturer: Lecturer,
  Students: Student[],
  Groups: Group[],
  SubjectName: string
}
interface Student {
  IdStudent: number,
  PersonFIO: string,
  Attedanced: string[],
  Ball: number,
  HW: HomeWorkStudent
}
interface HomeWorkStudent {
  IdHWS: number,
  ShortTextHW: string,
  StringFilePath: string
}
interface Lecturer {
  IdLecturer: number,
  PesonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  numberClass: number,
  Group: Group
}
