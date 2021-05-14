import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

import { BlockRec, AcPlan, BlockNum } from '../_models/groups-models';
import { DepDepDto, SubDepModal, DepDepModal } from '../_models/admin-models';

import { MapSubDepDto, SubDepDto } from '../_models/admin-models';
import { DepsDto } from '../_models/deps-models';

export class mapSubDep_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  /// 
  getMapSubDep(): Observable<MapSubDepDto> {
    return this.http.get<MapSubDepDto>(`${environment.hod_api_url}admin/get/mapper/subDeps`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }

  // getSubAcDep(): Observable<SubDepDto[]> {
  //   return this.http.get<SubDepDto[]>(`${environment.hod_api_url}acplans/get/subDep`,
  //     {
  //       // headers: {
  //       //   'Accept': 'application/json',
  //       //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
  //       // }
  //     });
  // }

  // getAllDeps(): Observable<DepsDto[]> {
  //   return this.http.get<DepsDto[]>(`${environment.hod_api_url}deps/get/cathedras/all`,
  //     {
  //       // headers: {
  //       //   'Accept': 'application/json',
  //       //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
  //       // }
  //     });

  // }

  /////// GET REGION END ///////


  /////// POST REGION START ///////

  postMapDepDep(items: DepDepModal[]): any {
    let t = this.http.post(
      `${environment.hod_api_url}admin/post/mapper/depDeps`,
      items,
      {
        headers: new HttpHeaders
          ({
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName),
            // 'Accept': '*/*',
            // 'Content-Type': 'undefined',
            // 'Content-Type': 'multipart/form-data; boundary=------WebKitFormBoundaryqy14R5oY6FqgxfWA',//charset=utf-8;
            // 'Content-Type': 'multipart/form-data',
            // 'Content-Type': 'application/json',
            // 'Content-Type': 'application/json; charset=utf-8',
            // 'Content-Type': 'application/x-www-form-urlencoded',
            'X-Content-Type-Options': 'nosniff',
            'Connetion': 'keep-alive'
          })
      }
    );

    console.log(t);

    console.log('send');

    return t;
  }

  postMapSubDep(items: SubDepModal[]): any {
    let t = this.http.post(
      `${environment.hod_api_url}admin/post/mapper/subDeps`,
      items,
      {
        headers: new HttpHeaders
          ({
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName),
            // 'Accept': '*/*',
            // 'Content-Type': 'undefined',
            // 'Content-Type': 'multipart/form-data; boundary=------WebKitFormBoundaryqy14R5oY6FqgxfWA',//charset=utf-8;
            // 'Content-Type': 'multipart/form-data',
            // 'Content-Type': 'application/json',
            // 'Content-Type': 'application/json; charset=utf-8',
            // 'Content-Type': 'application/x-www-form-urlencoded',
            'X-Content-Type-Options': 'nosniff',
            'Connetion': 'keep-alive'
          })
      }
    );

    console.log(t);

    console.log('send');

    return t;
  }

  /////// POST REGION END ///////

}
