import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class homework_HttpService {

  constructor(private http: HttpClient) { }
  
  private url = "/attedance";
  private url2 = "/homeworks";
  //createProduct(product: Product) {
  //  return this.http.post(this.url, product, );
  //}
 
  updateCW(data: ClassWork) {
    console.log('Дз 2 http', data);

    return this.http.post<ClassWork>(this.url2 + "/UpdateClassWork", data);
  }
  //postData(ExactClass: ExactClassForLecturerClass) {
  //  console.log('нажали ', ExactClass);
  //  //const body = { name: user.name, age: user.age };
  //  return this.http.post(this.url, ExactClass, { observe: 'response' });
  //}
  //getAttedanceExactClass(): Observable<ExactClass> {
  //  return this.http.get<ExactClass>(`attedance/getExactClass/1/2/1`,
  //    {
  //      //headers: {
  //      //  'Accept': 'application/json',
  //      //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
  //      //}
  //    });
  //}
  getClassWorkExactClass(IdClass): Observable<ClassWork> {
    return this.http.get<ClassWork>(`homeworks/GetClassWorkStudent/${IdClass}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  getClassWorkStudentAnswer(IdClass): Observable<AttedanceForWork> {
    return this.http.get<AttedanceForWork>(`homeworks/GetClassWorkStudentAnswer/${IdClass}`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  updateHW(data: AttedanceForWork) {
    console.log('Дз 2 http', data);

    return this.http.post<AttedanceForWork>(this.url2 + "/UpdateHomeWork", data);
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
  IdClassWork: number,
  IdClasss: number,
  TextWork: string,
  SubjectName: string,
  FilePathWork: string,
  MaxBall: number,
  DatePass: Date
}
interface AttedanceForWork {
  IdAtt: number,
  TextDoClassWork: string,
  PersonFIO: string,
  FilePath: string,
  BallHW: number,
  Done: string,
  DatePass: string
}
