"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.cathedras_HttpService = void 0;
var environment_1 = require("../../environments/environment");

var app_HttpService = /** @class */ (function () {

    function app_HttpService(http) {
        this.http = http;
    }

    /////// GET REGION START ///////
    /// 
    app_HttpService.prototype.get = function () {
        return this.http.get("cathedra/getall", {
            headers: {
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem(environment_1.environment.hod_sessionConst.accessTokenName)
            }
        });
    };
    ///
    /////// GET REGION ENDS ///////

    return app_HttpService;

}());
exports.app_HttpService = app_HttpService;
