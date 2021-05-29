import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { sidebar_HttpService } from '../main-sidebar/http.serviceMainSidebar';
import { AuthService } from '../_services/auth.service'
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent implements OnInit {
  public http: sidebar_HttpService;
  public name: string;
  public roleId: string;
  public profile: Profile;
  constructor(http: HttpClient, public router: Router, private as: AuthService) {
    this.name = String(as.login);
    this.http = new sidebar_HttpService(http);

    this.roleId = localStorage.getItem(environment.sessionConst.roleId);
    console.log(this.roleId);
  }
  public get isLoggedIn(): boolean {
    return this.as.isAuthenticated()
  }
  logout() {
    this.as.logout()
  }
  ngOnInit(): void {
    this.http.getProfile()
      .subscribe(result => {
        this.profile = result;
        console.log('profile', this.profile);
 
        console.log('result', result);
      }, error => {
        console.log('error/constructor', error);
      }
      );
  }

  redirectToHome() {
    this.router.navigateByUrl('dashboard/mainpage');
  }
  redirectToProfile() {
    this.router.navigateByUrl('/dashboard/profile/1739436577');
  }
}
interface Profile {
  IdPerson: number,
  PersonFIO: string
}
