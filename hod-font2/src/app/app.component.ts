import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NavigationEnd, Router } from '@angular/router';
import { environment } from '../environments/environment';

import { app_HttpService } from './http.serviceApp';

import { ShareService } from './share.service';

import { User } from './_models/accounts-models';
import { DepInfo } from './_models/deps-models';
import { SnackBarComponent } from './snack-bar/snack-bar.component';
import { identifierModuleUrl } from '@angular/compiler';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public title = 'our-front';
  public isAuth = 0;

  public user: User;
  public depsInfo: DepInfo[];

  private _http: HttpClient;
  private httpOwn: app_HttpService;

  /**
   *
   */
  constructor(
    http: HttpClient,
    private router: Router,
    private share: ShareService,
    private snack: SnackBarComponent
  ) {

    this._http = http;

    this.httpOwn = new app_HttpService(http);
    // this.depsInfo = this.httpOwn.getFakeDepsInfo();

    // this.share.shareUser(this.user);
    // this.share.doDeps(this.depsInfo);

    // this.user = this.share.getUser('token');

    this.httpOwn.getDepsInfo()
      .subscribe(result => {
        this.depsInfo = result;
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
        // this.depsInfo = nu
        this.depsInfo = null;
        this.snack.openSnackBarWithMsg('Нет соединения с сервером...');
      }
      );
  }

  ngOnInit(): void {
    console.log('INIT: app');

    if (true) {
      // this.isAuth = 1;

      console.log(sessionStorage.length);

      this.isAuth = this.hod_auth();

      // this.share.shareUser(this.user);
      // this.share.doDeps(this.depsInfo);
  
      // this.user = this.share.getUser('token');

      // alert();

      // switch (sessionStorage.getItem(environment.client_kind_request)) {

      //   // hod's users
      //   case environment.hod_sessionConst.ownCookie:
      //     {
      //       this.isAuth = this.hod_auth();
      //     };

      //   // not autherizated
      //   default:
      //     {
      //       this.isAuth = -1;
      //     };

      // }

      // if (this.isAuth == -1) {
      //   this.hod_fakeAuth();
      // }
    }

    this.share.shareUser(this.user);

    //var tmp = this.authentication().then((value) => { return value; });

    //console.log('FCK2:', this.authentication().then((value) => { return value; }));
    //console.log(tmp);

    //var promise = new Promise((resolve, reject) => {

    //  const res = fetch('testing/getlogin', {
    //    method: 'GET',
    //    headers: {
    //      'Accept': 'application/json',
    //      'Authorization': 'Bearer ' + this.token
    //    }
    //  });

    //  if (res) {
    //    resolve(true); // pass values
    //  } else {
    //    reject(false); // pass values
    //  }

    //});

    //var promise = Promise.resolve(false);
    //console.log('PLS', promise.then((value) => { return value; }));
    //promise.then((value) => { this.isAuth = value ? true : false; return value; });
    //console.log('isAuth == ', this.isAuth);

    //this.isAuth = this.authentication().then(value => {
    //  console.log('inner value', value);
    //  return value;
    //}) ? true : false;

    //this.authentication().then((value) => {
    //  console.log('inner value:', value);
    //  //this.isAuth = value ? true : false;
    //  return value ? true : false;
    //}).then(value, error);

    //this.authentication().then((value) => {
    //  console.log(value);
    //});

    //console.log(this.authentication().then(function (value) { return value; }, function (value) { console.log('error'); }));

  }

  ngAfterContentInit(): void {
  }

  // bogya
  hod_auth(): number {

    const token = sessionStorage.getItem(environment.hod_sessionConst.accessTokenName);
    console.log(token);

    if (!token) {
      console.log('no token');
      this.hod_authentication();
      return -1;
    }

    const checkDate_ = sessionStorage.getItem(environment.hod_sessionConst.date);
    let checkDate = new Date(checkDate_);
    const now = new Date();
    console.log(checkDate, now);
    checkDate.setMinutes(checkDate.getMinutes() + 30);

    var thirtyMinutesLater = new Date();
    // thirtyMinutesLater.setMinutes(thirtyMinutesLater.getMinutes() + 30);

    console.log(checkDate, thirtyMinutesLater);
    if (now > checkDate) {
      console.log('too long bro');
      alert();
      return -1;
    }

    // let check = this._http.get(`${environment.hod_api_url}check-token`, {
    //   headers: {
    //     'Accept': 'application/json',
    //     'Authorization': 'Bearer ' + token
    //   }
    // }).subscribe(result => {
    //   console.log(result);
    //   return result;
    // });
    // alert();

    // const check = fetch(`${environment.hod_api_url}check-token`, {
    //   method: 'GET',
    //   headers: {
    //     'Accept': 'application/json',
    //     'Authorization': 'Bearer ' + token
    //   }
    // })
    //   .then(function (response) {
    //     if (!response.ok) {
    //       throw Error(response.statusText);
    //     }
    //     return response;
    //   }).then(function (response) {
    //     console.log("ok");
    //   }).catch(function (error) {
    //     console.log(error);
    //   });
    // alert();

    const role = sessionStorage.getItem(environment.hod_sessionConst.role);
    console.log('role is ', role)

    // console.log('token is exist ==', token);
    // const res = fetch('testing/getlogin', {
    //   method: 'GET',
    //   headers: {
    //     'Accept': 'application/json',
    //     'Authorization': 'Bearer ' + token
    //   }
    // });
    // console.log('result of authentification:', res);

    if (token) {
      return 0; // pass values
    } else {
      return -1; // pass values
    }

  }

  hod_fakeAuth() {
    // Debug auto auth

    const email = environment.hod_auth.email;
    const pass = environment.hod_auth.pass;

    const formData = new FormData();
    formData.append("grant_type", "password");
    formData.append("username", email);
    formData.append("password", pass);

    const response = fetch("/token", {
      method: "POST",
      headers: { "Accept": "application/json" },
      body: formData
    })
      .then(x => x.json())
      .then(data => {
        sessionStorage.setItem(environment.client_kind_request, environment.hod_sessionConst.ownCookie);
        console.log(environment.hod_sessionConst.ownCookie);

        sessionStorage.setItem(environment.hod_sessionConst.username, email);
        console.log(email);

        sessionStorage.setItem(environment.hod_sessionConst.role, data.access_role);
        console.log(data.access_role);

        // сохраняем в хранилище sessionStorage токен доступа
        sessionStorage.setItem('hod_accessToken', data.access_token);
        console.log(data.access_token);

        console.log(environment);
      });

    // window.location.reload();
    // alert('await');
    if (true) {
      // ok
    }
    else {
      // auth failed - need to authorizate
      this.router.navigate(['hod/home']);
    }
  }

  async hod_authentication(): Promise<any> {

    return (await new Promise((resolve, reject) => {

      const token = sessionStorage.getItem(environment.hod_sessionConst.accessTokenName);

      // no token
      if (!token) {
        console.log('no token');
        resolve(false);
        return;
      }

      console.log('token is exist');
      const res = fetch(`${environment.hod_api_url}check-token`, {
        method: 'GET',
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + token
        }
      });

      console.log('result of authentification:', res);

      if (res) {
        resolve(true); // pass values
      } else {
        reject(false); // pass values
      }

    }));

  };

  /// 
  onAuth(event: any) {

    console.log('Authentication works');
    window.location.reload();
  }

}
