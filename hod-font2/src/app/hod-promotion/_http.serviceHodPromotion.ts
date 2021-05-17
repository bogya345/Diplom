import { HttpClient, HttpRequest, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

//import { Cath } from './cathedras.component';

import { CommonResponse } from '../_models/app-models';
import { DepsDto, Direction } from '../_models/deps-models';
import { GroupAnalysDto, DirAnalysDto } from '../_models/analys-models';

export class promotion_HttpService {

  constructor(private http: HttpClient) { }

  /////// GET REGION START ///////

  /// 
  getDepFacDir(): Observable<DepsDto[]> {
    return this.http.get<DepsDto[]>(`${environment.hod_api_url}deps/getall/dirfac`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }

  getGroupsInfo(dir_id): Observable<GroupAnalysDto[]> {
    return this.http.get<GroupAnalysDto[]>(`${environment.hod_api_url}analyser/get/dir-groups/${dir_id}`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }

  getDirStatus(dir_id): Observable<DirAnalysDto> {
    return this.http.get<DirAnalysDto>(`${environment.hod_api_url}analyser/get/fgos-requirs/${dir_id}/7-2`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }

  getAcPlan(dir_id): Observable<CommonResponse> {
    return this.http.get<CommonResponse>(`${environment.hod_api_url}acplans/get/${dir_id}`,
      {
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
        }
      });
  }

  // getFaceDeps(): DepsDto[] {
  //   let dep = new DepCl()[1];
  //   dep = [{
  //     'dep_id': 1,
  //     'dep_name': '1 dep',
  //     'headTeach_id': 1,
  //     'headTeach_name': '1 head name',
  //     'dirs': [
  //       {
  //         'dir_id': 1,
  //         'dir_name': 'direction 1',
  //         'startYear': 2020,
  //         'groups': [
  //           {
  //             'group_name': 'group name 11',
  //             'group_id': 11,
  //             'group_acPlan_id': 1,
  //           },
  //           {
  //             'group_name': 'group name 12',
  //             'group_id': 12,
  //             'group_acPlan_id': 1,
  //           },
  //         ],
  //       },
  //       {
  //         'dir_id': 2,
  //         'dir_name': 'direction 2',
  //         'startYear': 2020,
  //         'groups': [
  //           {
  //             'group_name': 'group name 21',
  //             'group_id': 21,
  //             'group_acPlan_id': 1,
  //           },
  //           {
  //             'group_name': 'group name 22',
  //             'group_id': 22,
  //             'group_acPlan_id': 1,
  //           },
  //         ],
  //       },
  //       {
  //         'dir_id': 3,
  //         'dir_name': 'direction 3',
  //         'startYear': 2020,
  //         'groups': [
  //           {
  //             'group_name': 'group name 31',
  //             'group_id': 31,
  //             'group_acPlan_id': 1,
  //           },
  //           {
  //             'group_name': 'group name 32',
  //             'group_id': 32,
  //             'group_acPlan_id': 1,
  //           },
  //         ],
  //       }
  //     ]
  //   }];
  //   return dep;
  // }

  /////// GET REGION END ///////


  /////// POST REGION START ///////

  postUploadRequest(files, dep_id, dir_id): any {

    let fileToUpload = <File>files[0];
    console.log(fileToUpload);

    let form = new FormData();
    form.append('file', fileToUpload);
    form.append('reportProgress', 'true');
    form.append('message', 'message#1');

    console.log(form.get('message'));

    // let opts = new Http

    let t = this.http.post(
      `${environment.hod_api_url}acplans/post/${dep_id}/${dir_id}`,
      form,
      {
        headers: new HttpHeaders
          ({
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName),
            // 'Accept': '*/*',
            // 'Content-Type': 'undefined',
            // 'Content-Type': 'multipart/form-data; boundary=------WebKitFormBoundaryqy14R5oY6FqgxfWA',//charset=utf-8;
            // 'Content-Type': 'multipart/form-data',
            // 'Content-Type': 'application/x-www-form-urlencoded',
            'X-Content-Type-Options': 'nosniff',
            'Connetion': 'keep-alive'
          })
      }
    );


    console.log();

    return t;

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
