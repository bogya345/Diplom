"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.attedance_HttpService = void 0;
var attedance_HttpService = /** @class */ (function () {
    function attedance_HttpService(http) {
        this.http = http;
        this.url = "/attedance";
        this.url2 = "/homeworks";
    }
    attedance_HttpService.prototype.getAttedanceForLecturerClass = function (IdECFLCT, IdClass, group_id) {
        return this.http.get("attedance/getLecturerClass/" + IdECFLCT + "/" + IdClass + "/" + group_id + "/true", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    //createProduct(product: Product) {
    //  return this.http.post(this.url, product, );
    //}
    attedance_HttpService.prototype.updateAtt = function (product) {
        console.log('нажали 2', this.http.post(this.url + "/UpdateAttedance", product));
        return this.http.post(this.url + "/UpdateAttedance", product);
    };
    attedance_HttpService.prototype.updateCW = function (data) {
        console.log('Дз 2 http', data);
        return this.http.post(this.url2 + "/UpdateClassWork", data);
    };
    attedance_HttpService.prototype.postData = function (ExactClass) {
        console.log('нажали ', ExactClass);
        //const body = { name: user.name, age: user.age };
        return this.http.post(this.url, ExactClass, { observe: 'response' });
    };
    attedance_HttpService.prototype.getAttedanceExactClass = function () {
        return this.http.get("attedance/getExactClass/1/2/1", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    attedance_HttpService.prototype.getClassWorkExactClass = function (IdClass) {
        return this.http.get("homeworks/GetClassWork/" + IdClass, {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    attedance_HttpService.prototype.getClassWorkTypes = function (IdWT) {
        return this.http.get("homeworks/getWorkTypes/" + IdWT, {
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