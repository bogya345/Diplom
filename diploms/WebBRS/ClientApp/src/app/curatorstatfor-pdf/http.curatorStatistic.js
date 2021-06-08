"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.statistic_HttpService = void 0;
var statistic_HttpService = /** @class */ (function () {
    function statistic_HttpService(http) {
        this.http = http;
        this.url = "/prortfolio";
        this.url2 = "/attedanceReason";
    }
    statistic_HttpService.prototype.getPortfolio = function (dateTimeStart, dateTimeEnd) {
        return this.http.get("CuratorStatisticController/GetCharts/" + dateTimeStart + "/" + dateTimeEnd, {
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
    statistic_HttpService.prototype.execute = function (portfolioAdd) {
        console.log('нажали ', portfolioAdd);
        //let dataToSend = { data: { 'IdPortfolio': IdPortfolio } }; 
        //console.log('нажали 2222', this.http.post(this.url + '/DeletePortfolio', IdPortfolio, { observe: 'response' }));
        //const body = { name: user.name, age: user.age };
        //return this.http.post(this.url + '/DeletePortfolio', dataToSend, { observe: 'response' });
        return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
    };
    statistic_HttpService.prototype.postData = function (portfolioAdd) {
        console.log('нажали ', portfolioAdd);
        //const body = { name: user.name, age: user.age };
        return this.http.post(this.url + '/UpdatePortfolioWork', portfolioAdd, { observe: 'response' });
    };
    return statistic_HttpService;
}());
exports.statistic_HttpService = statistic_HttpService;
//# sourceMappingURL=http.curatorStatistic.js.map