import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

//import { Cath } from './cathedras.component';

import { DepsDto } from '../_models/deps-models';

export class deps_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  getDepDirFac(): Observable<DepsDto[]> {
    return this.http.get<DepsDto[]>(`${environment.hod_api_url}deps/getall/dirfac`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }

  /// 
  // getDepsInfo(): Observable<DepsInfo[]> {
  //   return this.http.get<DepsInfo[]>(`cathedra/getall`,
  //     {
  //       headers: {
  //         'Accept': 'application/json',
  //         'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
  //       }
  //     });
  // }

  /////// GET REGION END ///////


  /////// POST REGION START ///////


  /////// POST REGION END ///////

}
