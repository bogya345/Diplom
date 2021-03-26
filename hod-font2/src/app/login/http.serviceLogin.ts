import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

export class login_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  /////// GET REGION END ///////


  /////// POST REGION START ///////

  ///
  postLogin1(body_): any {

    return this.http.post(
      ``,
      body_,
      {
        // headers: {
        //   'Accept': 'application/json',
        //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        // }
      }
    );

  }

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
