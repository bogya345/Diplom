
import { Component, OnInit, Inject } from '@angular/core';
import { ConfirmationDialog } from '../dialog-body/confirmation-dialog.component';
import { AlertDialogComponent } from '../dialog-body/alert-dialog/alert-dialog.component';
import { Router } from '@angular/router';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';

import { Observable } from 'rxjs';
@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  profile: Profile;
  router: Router;
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
  constructor(private http: HttpClient, router: Router) {
    this.router = router;
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
    router.navigate(['/dashboard/profile/' + this.profile.IdPerson]);
  }
  ngOnInit() {
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
  }

}

interface Profile {
  IdPerson: number,
  PersonFIO: string
}
