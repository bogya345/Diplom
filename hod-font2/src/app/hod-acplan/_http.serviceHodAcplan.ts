import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

import { BlockRec, AcPlan } from '../_models/groups-models';

export class acplan_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  /// 
  getBlockRecs(group_id): Observable<BlockRec[]> {
    return this.http.get<BlockRec[]>(`groups/blockrecs/get/${group_id}`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }
  getAcPlan(group_id): Observable<AcPlan[]> {
    return this.http.get<AcPlan[]>(`groups/acplan/get/${group_id}`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }

  getFakeAcPlan(group_id): AcPlan {
    let data: AcPlan;
    data =
    {
      BlockNums: [
        {
          BlockName: '1 blockNum',
          Subjects: [
            {
              SubjectName: 'subject 1',
              Loads: [
                {
                  atAcPlId: 1,
                  FshId: 1,
                  BlocRecId: 1,
                  SemNum: 1,
                  SubTypeId: 1,
                  SubTypeName: 'Lab',
                  LoadValue: 321
                },
                {
                  atAcPlId: 1,
                  FshId: 1,
                  BlocRecId: 1,
                  SemNum: 1,
                  SubTypeId: 1,
                  SubTypeName: 'Control',
                  LoadValue: 1234567
                }
              ]
            },
            {
              SubjectName: 'subject 2',
              Loads: [
                {
                  atAcPlId: 1,
                  FshId: 1,
                  BlocRecId: 1,
                  SemNum: 1,
                  SubTypeId: 1,
                  SubTypeName: 'Lab',
                  LoadValue: 321
                },
                {
                  atAcPlId: 1,
                  FshId: 1,
                  BlocRecId: 1,
                  SemNum: 1,
                  SubTypeId: 1,
                  SubTypeName: 'Control',
                  LoadValue: 1234567
                }
              ]
            }
          ]
        },
        {
          BlockName: '2 blockNum',
          Subjects: [
            {
              SubjectName: 'subject 1',
              Loads: [
                {
                  atAcPlId: 1,
                  FshId: 1,
                  BlocRecId: 1,
                  SemNum: 1,
                  SubTypeId: 1,
                  SubTypeName: 'Lab',
                  LoadValue: 321
                },
                {
                  atAcPlId: 1,
                  FshId: 1,
                  BlocRecId: 1,
                  SemNum: 1,
                  SubTypeId: 1,
                  SubTypeName: 'Control',
                  LoadValue: 1234567
                }
              ]
            },
            {
              SubjectName: 'subject 2',
              Loads: [
                {
                  atAcPlId: 1,
                  FshId: 1,
                  BlocRecId: 1,
                  SemNum: 1,
                  SubTypeId: 1,
                  SubTypeName: 'Lab',
                  LoadValue: 321
                },
                {
                  atAcPlId: null,
                  FshId: 1,
                  BlocRecId: 1,
                  SemNum: 1,
                  SubTypeId: 1,
                  SubTypeName: 'Control',
                  LoadValue: 1234567
                }
              ]
            }
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
