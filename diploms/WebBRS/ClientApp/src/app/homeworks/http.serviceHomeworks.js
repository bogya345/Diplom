"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.homeworks_HttpService = void 0;
var homeworks_HttpService = /** @class */ (function () {
    function homeworks_HttpService(http) {
        this.http = http;
    }
    homeworks_HttpService.prototype.getClassWorksList = function () {
        return this.http.get("homeworks/getall", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    return homeworks_HttpService;
}());
exports.homeworks_HttpService = homeworks_HttpService;
//# sourceMappingURL=http.serviceHomeworks.js.map