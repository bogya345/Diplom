
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from './../environments/environment';
import { MethodCall } from '@angular/compiler';

import { DepInfo } from './_models/deps-models';

export class app_HttpService {

    constructor(private http: HttpClient) {
    }

    /////// GET REGION START ///////

    getDepsInfo(): Observable<DepInfo[]> {

        let t = this.http.get<DepInfo[]>(`${environment.hod_api_url}deps/info`,
        {
            // headers: new HttpHeaders().set('Hui', 'nahioy')
            headers: {
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
            }
        });

        console.log(t);
        // console.log(t)

        return t;
    }

    getFakeDepsInfo(): DepInfo[] {
        let deps = new DepsInfoCL()[3];
        deps = [
            {
                'dep_id': 1,
                'dep_name': '1 dep',
                'headTeach_id': 1,
                'headTeach_name': '1 head name',
                'count_groups': 2,
            },
            {
                'dep_id': 2,
                'dep_name': '1 dep',
                'headTeach_id': 1,
                'headTeach_name': '1 head name',
                'count_groups': 5
            },
            {
                'dep_id': 2,
                'dep_name': '1 dep',
                'headTeach_id': 1,
                'headTeach_name': '1 head name',
                'count_groups': 2
            }
        ];
        return deps;
    }

    /////// GET REGION END ///////


    /////// POST REGION START ///////


    /////// POST REGION END ///////

}

class DepsInfoCL {
    public dep_id: number;
    public dep_name: string;
    // public dateCreated: Date;
    // public dateEnd: Date;
    public headTeach_id: number;
    public headTeach_name: string;
    public count_groups: number;
}


// "use strict";
// Object.defineProperty(exports, "__esModule", { value: true });
// exports.cathedras_HttpService = void 0;
// var environment_1 = require("../../environments/environment");

// var app_HttpService = /** @class */ (function () {

//     function app_HttpService(http) {
//         this.http = http;
//     }

//     /////// GET REGION START ///////
//     /// 
//     app_HttpService.prototype.get = function () {
//         return this.http.get("cathedra/getall", {
//             headers: {
//                 'Accept': 'application/json',
//                 'Authorization': 'Bearer ' + sessionStorage.getItem(environment_1.environment.hod_sessionConst.accessTokenName)
//             }
//         });
//     };
//     ///
//     /////// GET REGION ENDS ///////

//     return app_HttpService;

// }());
// exports.app_HttpService = app_HttpService;