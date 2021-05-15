import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class attedance_HttpService {

  constructor(private http: HttpClient) { }
  getAttedanceForLecturerClass(IdECFLCT, IdClass, group_id): Observable<ExactClassForLecturerClass> {
    return this.http.get<ExactClassForLecturerClass>(`attedance/getLecturerClass/${IdECFLCT}/${IdClass}/${group_id}/true`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  private url = "/attedance";
  private url2 = "/homeworks";
  //createProduct(product: Product) {
  //  return this.http.post(this.url, product, );
  //}
  updateAtt(product: ExactClassForLecturerClass) {
    console.log('нажали 2', this.http.post(this.url +"/UpdateAttedance", product));

    return this.http.post(this.url + "/UpdateAttedance", product);
  }
  updateCW(data: ClassWork) {
    console.log('Дз 2 http', data);

    return this.http.post<ClassWork>(this.url2 + "/UpdateClassWork", data);
  }
  postData(ExactClass: ExactClassForLecturerClass) {
    console.log('нажали ', ExactClass);
    //const body = { name: user.name, age: user.age };
    return this.http.post(this.url, ExactClass, { observe: 'response' });
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
  getClassWorkExactClass(IdClass): Observable<ClassWork> {
    return this.http.get<ClassWork>(`homeworks/GetClassWork/${IdClass}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getClassWorkTypes(IdWT): Observable<WorkType[]> {
    return this.http.get<WorkType[]>(`homeworks/getWorkTypes/${IdWT}`,
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
interface TypeAttedanceVM {
  IdTA: number,
  TAName: string,
  TAShortName: string,
  IdAtt: number
}
interface StudentEXC {
  IdAttedance: number,
  IdStudent: number,
  PersonFIO: string,
  AttedanceTypeSelected: number,
  Attedanced: TypeAttedanceVM[],
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
  PersonFIO: string

}

interface ClassWork {
  IdClassWork: number,
  IdClasss: number,
  TextWork: string,
  FilePathWork: string,
  MaxBall: number,
  DatePass: Date
  IdWT: number,
  WorkTypes: WorkType[]
}
interface WorkType {
  IdWT: number,
  WorkTypeName: string,
  ShortWorkTypeName: string

}
interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  //numberClass: number
  //Group: Group
}

