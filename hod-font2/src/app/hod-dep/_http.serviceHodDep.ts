import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

//import { Cath } from './cathedras.component';

import { DepsDto, Direction } from '../_models/deps-models';
import { Group } from '../_models/groups-models';

export class dep_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  /// 
  getDepInfo(dep_id): Observable<DepsDto> {
    return this.http.get<DepsDto>(`${environment.hod_api_url}deps/get/${dep_id}`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }

  getFaceDep(dep_id): DepsDto {
    let dep = new DepCl();
    dep = {
      'dep_id': 1,
      'dep_name': '1 dep',
      'dep_shortName': '1 dep_short',
      'headTeach_id': 1,
      'headTeach_name': '1 head name',
      'dirs': [
        {
          'dir_id': 1,
          'dir_name': 'direction 1',
          'startYear': 2020,
          'acPl_id': null,
          'requirs': null,
          'groups': [
            {
              'group_name': 'group name 11',
              'group_id': 11,
              'group_acPlan_id': 1,
            },
            {
              'group_name': 'group name 12',
              'group_id': 12,
              'group_acPlan_id': 1,
            },
          ],
        },
        {
          'dir_id': 2,
          'dir_name': 'direction 2',
          'startYear': 2020,
          'acPl_id': null,
          'requirs': null,
          'groups': [
            {
              'group_name': 'group name 21',
              'group_id': 21,
              'group_acPlan_id': 1,
            },
            {
              'group_name': 'group name 22',
              'group_id': 22,
              'group_acPlan_id': 1,
            },
          ],
        },
        {
          'dir_id': 3,
          'dir_name': 'direction 3',
          'startYear': 2020,
          'acPl_id': null,
          'requirs': null,
          'groups': [
            {
              'group_name': 'group name 31',
              'group_id': 31,
              'group_acPlan_id': 1,
            },
            {
              'group_name': 'group name 32',
              'group_id': 32,
              'group_acPlan_id': 1,
            },
          ],
        }
      ]
    };

    return dep;
  }

  /////// GET REGION END ///////


  /////// POST REGION START ///////


  /////// POST REGION END ///////

}

class DepCl {
  public dep_id: number;
  public dep_name: string;
  public dep_shortName: string;
  //dateCreated: Date;
  //dateEnd: Dat;
  public headTeach_id: number;
  public headTeach_name: string;

  public dirs: Direction[];
}
