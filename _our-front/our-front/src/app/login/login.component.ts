import { Component, EventEmitter, Output, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Validators, FormBuilder } from '@angular/forms';

import { environment } from '../../environments/environment';

import { login_HttpService } from './http.serviceLogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private http: login_HttpService;
  private baseUrl: string;

  public tokenKey: string;

  //public form: FormBuilder;
  public email: string;
  public password: string;


  @Output("onAuth") onAuth: EventEmitter<any> = new EventEmitter();

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.http = new login_HttpService(http);
    this.baseUrl = baseUrl;

    // bogya
    this.email = environment.hod_auth.email;
    this.password = environment.hod_auth.pass;

    // semka
    // this.email = environment.brs_auth.email;
    // this.password = environment.brs_auth.pass;

    // втисит
    //this.email = "teach1@ugtu.net"; this.password = "qwer";

    // пгс
    // this.email = "teach6@ugtu.net"; this.password = "qwer";

    this.tokenKey = 'accessToken';
  }

  ngOnInit(): void {
  }

  update_email(value: string) { this.email = value; console.log(value); }
  update_password(value: string) { this.password = value; console.log(value); }

  async login() {

    console.log(`email:${this.email}\tpass:{this.password}`)

    // пусть будет тут, не буду переносить
    const formData = new FormData();
    formData.append("grant_type", "password");
    formData.append("username", this.email);
    formData.append("password", this.password);

    // отправляет запрос и получаем ответ
    const response = await fetch("/token", {
      method: "POST",
      headers: { "Accept": "application/json" },
      body: formData
    });
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

      sessionStorage.setItem(environment.hod_sessionConst.role, data.access_role);
      console.log(data.access_role);

      // сохраняем в хранилище sessionStorage токен доступа
      sessionStorage.setItem(environment.hod_sessionConst.accessTokenName, data.access_token);
      console.log(data.access_token);

      this.onAuth.emit(this.tokenKey);

      console.log(environment);

      //window.location.reload();
    }
    else {
      // если произошла ошибка, из errorText получаем текст ошибки
      console.log("Error: ", response.status, data.errorText);
    }

  }

}
