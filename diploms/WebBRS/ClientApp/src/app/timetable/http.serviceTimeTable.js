"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.serviceTimeTable = void 0;
var serviceTimeTable = /** @class */ (function () {
    function serviceTimeTable(http) {
        this.http = http;
    }
    serviceTimeTable.prototype.getStudentClassList = function (IdSelectedDraft, IdSelectedDraftType, DateTimeExact) {
        //return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
        return this.http.get("timeTable/GetTimeTableStudent/" + 1584633406 + "/" + -1045036686 + "/" + DateTimeExact + "/1363575543", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    serviceTimeTable.prototype.getStudentWorksList = function (IdSelectedDraft, IdSelectedDraftType, DateTimeExact) {
        //return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
        return this.http.get("homeworks/getClassWork/" + 1584633406 + "/" + -1045036686 + "/" + DateTimeExact + "/1363575543", {
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