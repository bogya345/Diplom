"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.personList_HttpService = void 0;
var personList_HttpService = /** @class */ (function () {
    function personList_HttpService(http) {
        this.http = http;
    }
    personList_HttpService.prototype.getPersonList = function () {
        return this.http.get("person/getall", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    return personList_HttpService;
}());
exports.personList_HttpService = personList_HttpService;
//# sourceMappingURL=http.servicePersonList.js.map