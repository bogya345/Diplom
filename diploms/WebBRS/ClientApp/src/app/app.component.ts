import { Component } from '@angular/core';
import { AuthService } from './_services/auth.service'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  public get isLoggedIn(): boolean {
    return this.as.isAuthenticated()
  }

  constructor(private as: AuthService) {

  }
  login(email: string, password: string) {
    this.as.login(email, password)
      .subscribe(res => {
        console.log(res);
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
