"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.attedance_HttpService = void 0;
var attedance_HttpService = /** @class */ (function () {
    function attedance_HttpService(http) {
        this.http = http;
    }
    attedance_HttpService.prototype.getAttedanceForLecturerClasses = function () {
        return this.http.get("attedance/ECFLC/1", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName) ng generate component pokemon-list --module=app
        //}
        });
    };
    attedance_HttpService.prototype.getAttedanceExactClass = function () {
        return this.http.get("attedance/getExactClass/1/2/1", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    return attedance_HttpService;
}());
exports.attedance_HttpService = attedance_HttpService;
//# sourceMappingURL=http.serviceAttedance.js.map