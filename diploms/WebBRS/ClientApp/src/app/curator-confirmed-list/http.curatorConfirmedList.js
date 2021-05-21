"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.confirmedList_HttpService = void 0;
var confirmedList_HttpService = /** @class */ (function () {
    function confirmedList_HttpService(http) {
        this.http = http;
        this.url = "/prortfolio";
    }
    confirmedList_HttpService.prototype.getPortfolio = function (IdECFLCT) {
        return this.http.get("prortfolio/GetPortfolio/" + IdECFLCT, {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    //getProfile(): Observable<ProfileVM> {
    //  return this.http.get<ProfileVM>(`prortfolio/GetPortfile`,
    //    {
    //      //headers: {
    //      //  'Accept': 'application/json',
    //      //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
    //      //}
    //    });
    //}
    confirmedList_HttpService.prototype.execute = function (portfolioAdd) {
        console.log('нажали ', portfolioAdd);
        //let dataToSend = { data: { 'IdPortfolio': IdPortfolio } }; 
        //console.log('нажали 2222', this.http.post(this.url + '/DeletePortfolio', IdPortfolio, { observe: 'response' }));
        //const body = { name: user.name, age: user.age };
        //return this.http.post(this.url + '/DeletePortfolio', dataToSend, { observe: 'response' });
        return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
    };
    confirmedList_HttpService.prototype.getPortfolios = function (conf) {
        return this.http.get("prortfolio/GetPortfoliosForConfirm/" + conf, {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    confirmedList_HttpService.prototype.postData = function (portfolioAdd) {
        console.log('нажали ', portfolioAdd);
        //const body = { name: user.name, age: user.age };
        return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
    };
    return confirmedList_HttpService;
}());
exports.confirmedList_HttpService = confirmedList_HttpService;
//# sourceMappingURL=http.curatorConfirmedList.js.map