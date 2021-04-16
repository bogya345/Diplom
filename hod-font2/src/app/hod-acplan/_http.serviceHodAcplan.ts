import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

import { BlockRec, AcPlan, BlockNum } from '../_models/groups-models';

export class acplan_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  /// 
  getBlockNums(acPl_id, group_id): Observable<BlockNum[]> {
    return this.http.get<BlockNum[]>(`${environment.hod_api_url}acplans/get/${acPl_id}/${group_id}`,
      {
        // headers: {
        //   'Accept': 'application/json',
        //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        // }
      });
  }

  getCorrespondBlockNums(dep_id = -1, acPl_id, group_id): Observable<BlockNum[]> {
    return this.http.get<BlockNum[]>(`${environment.hod_api_url}acplans/get/${acPl_id}/${group_id}/correspond/${dep_id}`,
      {
        // headers: {
        //   'Accept': 'application/json',
        //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        // }
      });
  }

  getAcPlan(group_id): Observable<BlockNum[]> {
    return this.http.get<BlockNum[]>(`groups/acplan/get/${group_id}`,
      {
        // headers: {
        //   'Accept': 'application/json',
        //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        // }
      });
  }

  getFakeAcPlan(group_id): AcPlan {
    let data: AcPlan;
    data =
    {
      blockNums: [
        {
          blockName: '1 blockNum',
          subjects: [
            {
              subjectName: 'subject 1',
              depsDto: null,
              semestrNum: 1,
              loads: [
                {
                  atAcPlId: 1,
                  fshId: 1,
                  blocRecId: 1,
                  semNum: 1,
                  subTypeId: 1,
                  subTypeName: 'Lab',
                  loadValue: 321
                },
                {
                  atAcPlId: 1,
                  fshId: 1,
                  blocRecId: 1,
                  semNum: 1,
                  subTypeId: 1,
                  subTypeName: 'Lab',
                  loadValue: 321
                }
              ]
            }, {
              subjectName: 'subject 1',
              depsDto: null,
              semestrNum: 1,
              loads: [
                {
                  atAcPlId: 1,
                  fshId: 1,
                  blocRecId: 1,
                  semNum: 1,
                  subTypeId: 1,
                  subTypeName: 'Lab',
                  loadValue: 321
                },
                {
                  atAcPlId: 1,
                  fshId: 1,
                  blocRecId: 1,
                  semNum: 1,
                  subTypeId: 1,
                  subTypeName: 'Lab',
                  loadValue: 321
                }
              ]
            },
          ]
        },
        {
          blockName: '1 blockNum',
          subjects: [
            {
              subjectName: 'subject 1',
              depsDto: null,
              semestrNum: 1,
              loads: [
                {
                  atAcPlId: 1,
                  fshId: 1,
                  blocRecId: 1,
                  semNum: 1,
                  subTypeId: 1,
                  subTypeName: 'Lab',
                  loadValue: 321
                },
                {
                  atAcPlId: 1,
                  fshId: 1,
                  blocRecId: 1,
                  semNum: 1,
                  subTypeId: 1,
                  subTypeName: 'Lab',
                  loadValue: 321
                }
              ]
            }, {
              subjectName: 'subject 1',
              depsDto: null,
              semestrNum: 1,
              loads: [
                {
                  atAcPlId: 1,
                  fshId: 1,
                  blocRecId: 1,
                  semNum: 1,
                  subTypeId: 1,
                  subTypeName: 'Lab',
                  loadValue: 321
                },
                {
                  atAcPlId: 1,
                  fshId: 1,
                  blocRecId: 1,
                  semNum: 1,
                  subTypeId: 1,
                  subTypeName: 'Lab',
                  loadValue: 321
                }
              ]
            },
          ]
        }
      ]
    };

    return data;
  }

  /////// GET REGION END ///////


  /////// POST REGION START ///////


  /////// POST REGION END ///////

}
