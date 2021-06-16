import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Token } from '../_models/token';
//import { Token } from '@angular/compiler/src/ml_parser/lexer';
import { AUTH_API_URL } from '../app-injection-tokens';
import { BehaviorSubject, Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { tap, map } from 'rxjs/operators';
import { User } from '../_models/user';
import { environment } from '../../environments/environment';
//изменить
export const ACCESS_TOKEN_KEY = 'WebBRS_access_token'

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  constructor(
    private http: HttpClient,
    @Inject(AUTH_API_URL) private apiUrl: string,
    private jwtHelper: JwtHelperService,
    private router: Router,

  ) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  };
  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }
  login(email: string, password: string): Observable<Token> {
    return this.http.post<Token>(`${this.apiUrl}api/auth/login`, {
      email, password
    }).pipe(
      tap(token => {
        localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token);
        //localStorage.setItem(environment.client_kind_request, environment.sessionConst.ownCookie);
        //console.log(environment.sessionConst.ownCookie);

        localStorage.setItem(environment.sessionConst.username, email);
        console.log(email);

        localStorage.setItem(environment.sessionConst.role, token.role);
        localStorage.setItem(environment.sessionConst.roleId, String(token.roleId));
        console.log('role: ', token.role);

        // сохраняем в хранилище sessionStorage токен доступа
        //localStorage.setItem('hod_accessToken', data.access_token);
        //console.log(data.access_token);

        console.log(environment);
        //this.currentUserSubject.next(token);
      }),
      
    
    )

  }
  isAuthenticated(): boolean {
    var token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return token && !this.jwtHelper.isTokenExpired(token)
  }
  inRole(): string {
    var token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return environment.sessionConst.role;
}
  logout(): void {
    localStorage.removeItem(ACCESS_TOKEN_KEY);
    this.router.navigate(['']);

  }
}
