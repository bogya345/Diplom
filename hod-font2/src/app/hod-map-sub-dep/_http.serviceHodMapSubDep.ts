import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

import { BlockRec, AcPlan, BlockNum } from '../_models/groups-models';
import { SubDepDto } from '../_models/admin-models';
import { DepsDto } from '../_models/deps-models';

export class mapSubDep_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  /// 
  getSubAcDep(): Observable<SubDepDto[]> {
    return this.http.get<SubDepDto[]>(`${environment.hod_api_url}acplans/get/subDep`,
      {
        // headers: {
        //   'Accept': 'application/json',
        //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        // }
      });
  }

  getAllDeps(): Observable<DepsDto[]> {
    return this.http.get<DepsDto[]>(`${environment.hod_api_url}deps/get/all`,
      {
        // headers: {
        //   'Accept': 'application/json',
        //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        // }
      });
  }

  /////// GET REGION END ///////


  /////// POST REGION START ///////


  /////// POST REGION END ///////

}
