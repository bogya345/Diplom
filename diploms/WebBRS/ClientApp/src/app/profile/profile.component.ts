import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { YesNoModalComponent } from '../yes-no-modal/yes-no-modal.component';

import { profile_HttpService } from './http.serviceProfile';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  public http: profile_HttpService;
  public baseUrl: string;
  public portfolioAdd: PortfolioVM;
  public portfolios: PortfolioVM[];
  @ViewChild('deleteModal', { static: false }) public deleteModal: YesNoModalComponent;
  constructor(http: HttpClient, private router: Router, private _route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {
    this.http = new profile_HttpService(http);
    this.baseUrl = baseUrl;
  }
  selectChangeHandler4(event: any) {

    this.portfolioAdd.Name = event.target.value;
    console.log(event.target.value);
  }
  doTextareaValueChange(ev) {
    try {
      this.portfolioAdd.Description = ev.target.value;
      console.info(this.portfolioAdd.Description);
    } catch (e) {
      console.info('could not set textarea-value');
    }
  }
  delete(data) {
    this.deleteModal.showAsync(data).then(result => {
      this.http.execute(result);
    });
  }
  postData(event: any) {

    return this.http.postData(this.portfolioAdd)
      .subscribe(result => {
        console.log(result);
      });
  }
  ngOnInit() {
    this.http.getPortfolio(0)
      .subscribe(result => {
        this.portfolioAdd = result;
       
        console.log('keks', this.portfolioAdd = result);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getPortfolios()
      .subscribe(result => {
        this.portfolios = result;
       
        console.log('portfolios', this.portfolios);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }

}
interface ProfileVM {
  IdPerson: number,
  PersonFIO: string,
  Portfolios: PortfolioVM[];
}
interface PortfolioVM {
  IdPortfolio: number,
  IdPerson: number,
  Description: string,
  Name: string,
  FilePath: string,
  PersonFIOconfirmed: string,
  DateAdded: string,
  DateConfirmed: string,
  Confirmed: string

}
