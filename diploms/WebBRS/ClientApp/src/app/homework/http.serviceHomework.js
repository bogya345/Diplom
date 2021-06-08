"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.homework_HttpService = void 0;
var homework_HttpService = /** @class */ (function () {
    function homework_HttpService(http) {
        this.http = http;
        this.url = "/attedance";
        this.url2 = "/homeworks";
    }
    //createProduct(product: Product) {
    //  return this.http.post(this.url, product, );
    //}
    homework_HttpService.prototype.updateCW = function (data) {
        console.log('Дз 2 http', data);
        return this.http.post(this.url2 + "/UpdateClassWork", data);
    };
    //postData(ExactClass: ExactClassForLecturerClass) {
    //  console.log('нажали ', ExactClass);
    //  //const body = { name: user.name, age: user.age };
    //  return this.http.post(this.url, ExactClass, { observe: 'response' });
    //}
    //getAttedanceExactClass(): Observable<ExactClass> {
    //  return this.http.get<ExactClass>(`attedance/getExactClass/1/2/1`,
    //    {
    //      //headers: {
    //      //  'Accept': 'application/json',
    //      //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
    //      //}
    //    });
    //}
    homework_HttpService.prototype.getClassWorkExactClass = function (IdClass) {
        return this.http.get("homeworks/GetClassWorkStudent/" + IdClass, {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    homework_HttpService.prototype.getClassWorkStudentAnswer = function (IdClass) {
        return this.http.get("homeworks/GetClassWorkStudentAnswer/" + IdClass, {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    homework_HttpService.prototype.updateHW = function (data) {
        console.log('Дз 2 http', data);
        var formData = new FormData();
        // optional you can pass a file name as third parameter
        formData.append('file', data.File);
        formData.append('TextDoClassWork', data.TextDoClassWork);
        formData.append('DatePass', String(data.DatePass));
        formData.append('IdAtt', String(data.IdAtt));
        formData.append('PersonFIO', String(data.PersonFIO));
        formData.append('Email', String(data.Email));
        formData.append('FilePath', String(data.FilePath));
        formData.append('BallHW', String(data.BallHW));
        //formData.append('IdClass', String(data.IdClass));
        return this.http.post(this.url2 + "/UpdateHomeWork", formData);
    };
    return homework_HttpService;
}());
exports.homework_HttpService = homework_HttpService;
//# sourceMappingURL=http.serviceHomework.js.map