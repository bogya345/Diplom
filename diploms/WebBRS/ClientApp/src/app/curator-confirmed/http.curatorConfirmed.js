"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.confirmed_HttpService = void 0;
var confirmed_HttpService = /** @class */ (function () {
    function confirmed_HttpService(http) {
        this.http = http;
        this.url = "/prortfolio";
    }
    confirmed_HttpService.prototype.getPortfolio = function (IdECFLCT) {
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
    confirmed_HttpService.prototype.execute = function (IdPortfolio) {
        console.log('нажали ', IdPortfolio);
        //let dataToSend = { data: { 'IdPortfolio': IdPortfolio } }; 
        //console.log('нажали 2222', this.http.post(this.url + '/DeletePortfolio', IdPortfolio, { observe: 'response' }));
        //const body = { name: user.name, age: user.age };
        //return this.http.post(this.url + '/DeletePortfolio', dataToSend, { observe: 'response' });
        return this.http.delete(this.url + '/' + IdPortfolio);
    };
    confirmed_HttpService.prototype.getPortfolios = function () {
        return this.http.get("prortfolio/GetPortfolios", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    confirmed_HttpService.prototype.postData = function (portfolioAdd) {
        console.log('нажали ', portfolioAdd);
        //const body = { name: user.name, age: user.age };
        return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
    };
    return confirmed_HttpService;
}());
exports.confirmed_HttpService = confirmed_HttpService;
//# sourceMappingURL=http.curatorConfirmed.js.map