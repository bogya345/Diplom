"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.profile_HttpService = void 0;
var profile_HttpService = /** @class */ (function () {
    function profile_HttpService(http) {
        this.http = http;
        this.url = "/prortfolio";
    }
    profile_HttpService.prototype.getPortfolio = function (IdECFLCT) {
        return this.http.get("prortfolio/GetPortfolio/" + IdECFLCT, {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    profile_HttpService.prototype.execute = function (portfolioId) {
        console.log('нажали ', portfolioId);
        //const body = { name: user.name, age: user.age };
        return this.http.post(this.url + '/DeletePortfolio', portfolioId, { observe: 'response' });
    };
    profile_HttpService.prototype.getPortfolios = function () {
        return this.http.get("prortfolio/GetPortfolios", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    profile_HttpService.prototype.postData = function (portfolioAdd) {
        console.log('нажали ', portfolioAdd);
        //const body = { name: user.name, age: user.age };
        return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
    };
    return profile_HttpService;
}());
exports.profile_HttpService = profile_HttpService;
//# sourceMappingURL=http.serviceProfile.js.map