import { Component, EventEmitter, Output, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Validators, FormBuilder, FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ShareService } from '../share.service';

import { environment } from '../../environments/environment';

import { login_HttpService } from './http.serviceLogin';

import { User } from '../_models/accounts-models';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private _http: HttpClient;
  private _httpOwn: login_HttpService;
  private baseUrl: string;

  public tokenKey: string;

  //public form: FormBuilder;
  public email: string;
  public password: string;

  public loginError: string;
  public passError: string;
  public authError: string;


  @Output("onAuth") onAuth: EventEmitter<any> = new EventEmitter();

  constructor(
    _http: HttpClient,

    private share: ShareService
  ) {
    this._http = _http;
    this._httpOwn = new login_HttpService(_http);

    // bogya
    this.email = environment.hod_auth.email;
    this.password = environment.hod_auth.pass;

    this.tokenKey = 'accessToken';
  }

  ngOnInit(): void {
    console.log('INIT: login');
    let user: User;
    this.share.shareUser(user);
    // this.loginForm = this.formBuilder.group({
    //   username: ['', Validators.required],
    //   password: ['', Validators.required]
    // });
    // alert();
  }
  // get f() { return this.loginForm.controls; }

  update_email(value: string) { this.email = value; console.log(value); }
  update_password(value: string) { this.password = value; console.log(value); }

  async login() {
    if (!this.email && !this.passError) {
      this.loginError = "Необходимо ввести логин";
      this.passError = "Необходимо ввести пароль";
      return;
    }
    if (!this.email) { this.loginError = "Необходимо ввести логин"; return; }
    else { this.loginError = undefined; }
    if (!this.password) { this.passError = "Необходимо ввести пароль"; return; }
    else { this.passError = undefined; }

    // console.log()
    // alert(`email:${this.email}\tpass:${this.password}`);


    // пусть будет тут, не буду переносить в services
    const formData = new FormData();
    formData.append("grant_type", "password");
    formData.append("username", this.email);
    formData.append("password", this.password);

    // отправляет запрос и получаем ответ
    // const response = await this._http.post(`${environment.hod_api_url}token`, {
    //   method: "POST",
    //   headers: { "Accept": "application/json" },
    //   body: formData
    // });
    const response = await fetch(`${environment.hod_api_url}token`, {
      method: "POST",
      headers: { "Accept": "application/json" },
      body: formData
    });

    // проверка на 
    if (!response.ok) { console.log('Something wrong with /token request'); }

    // получаем данные 
    const data = await response.json();

    // если запрос прошел нормально
    if (response.ok === true) {

      //// изменяем содержимое и видимость блоков на странице
      //document.getElementById("userName").innerText = data.username;
      //document.getElementById("userInfo").style.display = "block";
      //document.getElementById("loginForm").style.display = "none";

      sessionStorage.setItem(environment.hod_sessionConst.username, this.email);
      console.log(this.email);

      sessionStorage.setItem(environment.hod_sessionConst.access_role, data.access_role);
      console.log(data.access_role);

      sessionStorage.setItem(environment.hod_sessionConst.access_role_id, data.access_role_id);
      console.log(data.access_role_id);

      sessionStorage.setItem(environment.hod_sessionConst.dep, data.dep_name);
      console.log(data.dep_name);

      sessionStorage.setItem(environment.hod_sessionConst.dep_id, data.dep_id);
      console.log(data.dep_id);

      
      // сохраняем в хранилище sessionStorage токен доступа
      sessionStorage.setItem(environment.hod_sessionConst.accessTokenName, data.access_token);
      console.log(data.access_token);

      sessionStorage.setItem(environment.hod_sessionConst.date, data.dateExpired);
      console.log(data.dateExpired);

      this.onAuth.emit(this.tokenKey);

      console.log(environment);

      //window.location.reload();
    }
    else {
      // если произошла ошибка, из errorText получаем текст ошибки
      console.log("Error: ", response.status, data.errorText);
      this.authError = `${data.errorText}`;
    }

  }

}
