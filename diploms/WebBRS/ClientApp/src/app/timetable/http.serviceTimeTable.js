"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.serviceTimeTable = void 0;
var serviceTimeTable = /** @class */ (function () {
    function serviceTimeTable(http) {
        this.http = http;
    }
    serviceTimeTable.prototype.getTeacherClassList = function () {
        return this.http.get("homeworks/getall", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    return serviceTimeTable;
}());
exports.serviceTimeTable = serviceTimeTable;
//# sourceMappingURL=http.serviceTimeTable.js.map