import { Component } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  profile: Profile;
  router: Router;
  public get isLoggedIn(): boolean {
    return this.as.isAuthenticated()
  }
  getProfile(): Observable<Profile> {
    //return this.http.get<TimeTable2>(`timeTable/GetTimeTable/-1096224834/2007228761/2001-01-08T00:00:00`,
    return this.http.get<Profile>(`prortfolio/GetPortfile`,
      {
        //headers: {
        //  'Accept': 'application/json',
        //  'Authorization': 'Bearer ' + sessionStorage.getItem(environment.sessionConst.accessTokenName)
        //}
      });
  }
  constructor(private as: AuthService, router: Router,private http: HttpClient ) {

  }
  login(email: string, password: string) {
    this.as.login(email, password)
      .subscribe(res => {
        console.log(res);
        this.getProfile()
          .subscribe(result => {
            this.profile = result;
            //this.ecflct.SelectedGroup = result.SelectedGroup;
            console.log('keks', this.profile);
            console.log('result/constructor', result);

          }, error => {
            console.log('error/constructor', error);
          }
          );
        this.router.navigate(['/dashboard/profile/' + this.profile.IdPerson]);
        //console.log(res.json());
      }, error => {
          console.log(error);
          alert('неправильный логин или пароль')
      })
  }
  logout() {
    this.as.logout()
  }
}

interface Profile {
  IdPerson: number,
  PersonFIO: string
}
