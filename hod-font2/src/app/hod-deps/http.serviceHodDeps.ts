import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

//import { Cath } from './cathedras.component';

export class cathedras_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  /// 
  getCathsInfo(): Observable<CathInfo[]> {
    return this.http.get<CathInfo[]>(`cathedra/getall`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }

  /////// GET REGION END ///////


  /////// POST REGION START ///////


  /////// POST REGION END ///////

}

interface CathInfo {
  id_department: number,
  name_department: string,
  //dateCreated: Date,
  //dateEnd: Date
  Head_id_teacherCath: number,
  Head_id_teacher: number,
  Head_name_teacher: string,
  count_groups: number
}

//export class 
