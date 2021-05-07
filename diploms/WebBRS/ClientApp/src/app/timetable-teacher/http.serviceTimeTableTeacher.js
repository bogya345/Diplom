"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.serviceTimeTableTeacher = void 0;
var serviceTimeTableTeacher = /** @class */ (function () {
    function serviceTimeTableTeacher(http) {
        this.http = http;
    }
    serviceTimeTableTeacher.prototype.getTeacherClassList = function (IdSelectedDraft, IdSelectedDraftType, DateTimeExact) {
        //return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
        return this.http.get("timeTable/GetTimeTable/" + IdSelectedDraft + "/" + IdSelectedDraftType + "/" + DateTimeExact, {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    return serviceTimeTableTeacher;
}());
exports.serviceTimeTableTeacher = serviceTimeTableTeacher;
//# sourceMappingURL=http.serviceTimeTableTeacher.js.map