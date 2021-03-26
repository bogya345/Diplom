import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NavigationEnd, Router } from '@angular/router';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'our-front';

  public isAuth = -1;

  /**
   *
   */
  constructor(http: HttpClient, private router: Router) {

  }

  ngOnInit(): void {

    this.isAuth = -1;

    switch (sessionStorage.getItem(environment.client_kind_request)) {

      // bogya's users
      case environment.hod_sessionConst.ownCookie:
        {
          this.isAuth = this.hod_auth();
        };

      // semkas's users
      case environment.brs_sessionConst.ownCookie:
        {
          this.isAuth = this.brs_auth();
        };

      // not autherizated
      default:
        {
          this.isAuth = -1;
        };

    }

    if (this.isAuth == -1) {
      this.hod_fakeAuth();
    }

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

  // bogya
  hod_auth(): number {

    const token = sessionStorage.getItem(environment.hod_sessionConst.accessTokenName);

    if (!token) {
      console.log('no token');
      this.router.events
      return -1;
    }

    const role = sessionStorage.getItem(environment.hod_sessionConst.role);
    console.log('role is ', role)

    console.log('token is exist ==', token);
    const res = fetch('testing/getlogin', {
      method: 'GET',
      headers: {
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + token
      }
    });

    console.log('result of authentification:', res);

    if (res) {
      return 0; // pass values
    } else {
      return -1; // pass values
    }

  }

  // semka
  brs_auth(): number {

    const token = sessionStorage.getItem(environment.brs_sessionConst.accessTokenName);

    if (!token) {
      console.log('no token');
      this.router.events
      return -1;
    }

    const role = sessionStorage.getItem(environment.brs_sessionConst.role);
    console.log('role is ', role)

    console.log('token is exist ==', token);
    const res = fetch('testing/getlogin', {
      method: 'GET',
      headers: {
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + token
      }
    });

    console.log('result of authentification:', res);

    if (res) {
      return 1; // pass values
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
    alert('await');
    this.router.navigate(['hod/home']);
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
      const res = fetch('testing/getlogin', {
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

  }

}
