import { Component, OnInit, Inject } from '@angular/core';

import { personList_HttpService } from './http.servicePersonList';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {

  public http: personList_HttpService;
  public baseUrl: string;
  public personinfo: Person[];
  public currentCount = 0;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = new personList_HttpService(http);
    this.baseUrl = baseUrl;

   
   
  }

  ngOnInit() {
    this.http.getPersonList()
      .subscribe(result => {
        this.personinfo = result;
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }


}
interface Person {
  IdPerson: number,
  //GuidPerson: string,
  //dateCreated: Date,
  //dateEnd: Date
  FirstName: string,
  LastName: string,
  PatronicName: string,
  Email: string
  //DateTimeReg: Date,
  //BirthDate: Date
}
