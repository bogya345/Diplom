import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { MethodCall } from '@angular/compiler';

//import { Cath } from './cathedras.component';

import { DepsDto, Direction } from '../_models/deps-models';
import { Group } from '../_models/groups-models';

export class promotion_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  /// 
  getDepFacDir(): Observable<DepsDto[]> {
    return this.http.get<DepsDto[]>(`${environment.hod_api_url}deps/getall/dirfac`,
      {
        // headers: {
        //   'Accept': 'application/json',
        //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        // }
      });
  }

  getFaceDeps(): DepsDto[] {
    let dep = new DepCl()[1];
    dep = [{
      'dep_id': 1,
      'dep_name': '1 dep',
      'headTeach_id': 1,
      'headTeach_name': '1 head name',
      'dirs': [
        {
          'dir_id': 1,
          'dir_name': 'direction 1',
          'startYear': 2020,
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
    }];
    return dep;
  }

  /////// GET REGION END ///////


  /////// POST REGION START ///////

  postUploadRequest(files, dep_id, dir_id): any {
    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);


    const req = new HttpRequest(
      'POST',
      `deps/${dep_id}/${dir_id}`,
      {

        formData: {
          reportProgress: true,
        },

        // headers: {
        //   'Accept': 'application/json',
        //   'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        // }
      }
    );

    return this.http.request(req);
  }

  /////// POST REGION END ///////

}

class DepCl {
  public dep_id: number;
  public dep_name: string;
  //dateCreated: Date;
  //dateEnd: Dat;
  public headTeach_id: number;
  public headTeach_name: string;

  public dirs: Direction[];
}