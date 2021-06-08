"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.profile_HttpService = void 0;
var profile_HttpService = /** @class */ (function () {
    function profile_HttpService(http) {
        this.http = http;
        this.url = "/prortfolio";
        this.url2 = "/attedanceReason";
    }
    profile_HttpService.prototype.getPortfolio = function (IdECFLCT) {
        return this.http.get("prortfolio/GetPortfolio/" + IdECFLCT, {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    profile_HttpService.prototype.getAttedance = function (IdECFLCT) {
        return this.http.get("attedanceReason/GetAttedanceReason/" + IdECFLCT, {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    profile_HttpService.prototype.getProfile = function () {
        return this.http.get("prortfolio/GetPortfile", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    profile_HttpService.prototype.execute = function (IdPortfolio) {
        console.log('нажали ', IdPortfolio);
        //let dataToSend = { data: { 'IdPortfolio': IdPortfolio } }; 
        //console.log('нажали 2222', this.http.post(this.url + '/DeletePortfolio', IdPortfolio, { observe: 'response' }));
        //const body = { name: user.name, age: user.age };
        //return this.http.post(this.url + '/DeletePortfolio', dataToSend, { observe: 'response' });
        return this.http.delete(this.url + '/' + IdPortfolio);
    };
    profile_HttpService.prototype.execute2 = function (IdPortfolio) {
        console.log('нажали удалить справку: ', IdPortfolio);
        //let dataToSend = { data: { 'IdPortfolio': IdPortfolio } }; 
        //console.log('нажали 2222', this.http.post(this.url + '/DeletePortfolio', IdPortfolio, { observe: 'response' }));
        //const body = { name: user.name, age: user.age };
        //return this.http.post(this.url + '/DeletePortfolio', dataToSend, { observe: 'response' });
        return this.http.delete(this.url2 + '/' + IdPortfolio);
    };
    profile_HttpService.prototype.getPortfolios = function () {
        return this.http.get("prortfolio/GetPortfolios", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    profile_HttpService.prototype.getAttedanceReason = function () {
        return this.http.get("attedanceReason/GetAttedanceReason", {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
        });
    };
    profile_HttpService.prototype.postData = function (portfolioAdd) {
        console.log('нажали ', portfolioAdd);
        var formData = new FormData();
        // optional you can pass a file name as third parameter
        formData.append('file', portfolioAdd.File);
        formData.append('IdPortfolio', String(portfolioAdd.IdPortfolio));
        formData.append('IdPerson', String(portfolioAdd.IdPerson));
        formData.append('Description', String(portfolioAdd.Description));
        formData.append('Name', String(portfolioAdd.Name));
        formData.append('PersonFIOconfirmed', String(portfolioAdd.PersonFIOconfirmed));
        formData.append('DateAdded', String(portfolioAdd.DateAdded));
        formData.append('DateConfirmed', String(portfolioAdd.DateConfirmed));
        formData.append('Confirmed', String(portfolioAdd.Confirmed));
        //const body = { name: user.name, age: user.age };
        return this.http.post(this.url + '/UpdatePortfolioWork', formData, { observe: 'response' });
    };
    profile_HttpService.prototype.postDataReason = function (portfolioAdd) {
        console.log('нажали ', portfolioAdd);
        var formData = new FormData();
        // optional you can pass a file name as third parameter
        formData.append('file', portfolioAdd.File);
        formData.append('IdAttReas', String(portfolioAdd.IdAttReas));
        formData.append('IdPerson', String(portfolioAdd.IdPerson));
        formData.append('DocName', String(portfolioAdd.DocName));
        formData.append('PersonFIO', String(portfolioAdd.PersonFIO));
        //formData.append('PersonFIOconfirmed', String(portfolioAdd.PersonFIOconfirmed));
        formData.append('DateAdded', String(portfolioAdd.DateAdded));
        formData.append('DateConfirmed', String(portfolioAdd.DateConfirmed));
        //formData.append('Confirmed', String(portfolioAdd.Confirmed));
        //const body = { name: user.name, age: user.age };
        return this.http.post(this.url2 + '/UpdateAttedanceReason', formData, { observe: 'response' });
    };
    return profile_HttpService;
}());
exports.profile_HttpService = profile_HttpService;
//# sourceMappingURL=http.serviceProfile.js.map