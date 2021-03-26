"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.attedanceTable_HttpService = void 0;
var attedanceTable_HttpService = /** @class */ (function () {
    function attedanceTable_HttpService(http) {
        this.http = http;
    }
    attedanceTable_HttpService.prototype.getAttedanceForLecturerClasses = function () {
        return this.http.get("attedance/getAttdance/1/2/1", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    attedanceTable_HttpService.prototype.getAttedanceExactClass = function () {
        return this.http.get("attedance/getExactClass/1/2/1", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    return attedanceTable_HttpService;
}());
exports.attedanceTable_HttpService = attedanceTable_HttpService;
//# sourceMappingURL=http.serviceAttedanceTable.js.map