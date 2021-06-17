import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { NavigationEnd, Router } from '@angular/router';
import { environment } from '../../environments/environment';

import { ShareService } from '../share.service';

import { User } from '../_models/accounts-models';
import { DepInfo, DepsDto } from '../_models/deps-models';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';
import { identifierModuleUrl } from '@angular/compiler';

import { NgxChartsModule } from '@swimlane/ngx-charts';

@Component({
  selector: 'app-hod-home',
  templateUrl: './hod-home.component.html',
  styleUrls: ['./hod-home.component.css']
})
export class HodHomeComponent implements OnInit {

  // private _http: HttpClient;
  // private router: Router;
  // private share: ShareService;

  public user: User;

  public dep: DepInfo;

  multi: any[];
  view: any[] = [700, 400];

  // options
  showXAxis: boolean = true;
  showYAxis: boolean = true;
  gradient: boolean = true;
  showLegend: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Направления';
  showYAxisLabel: boolean = true;
  yAxisLabel: string = 'Проценты';
  legendTitle: string = 'Требования';

  colorScheme = {
    // domain: ['#5AA454', '#C7B42C', '#AAAAAA']
    domain: ['#1424E2', '#10D383', '#A412BE']
  };

  selectedDir: any;

  emptyDirs: boolean;

  constructor(
    private _http: HttpClient,
    private _router: Router,
    private _share: ShareService,
    private _snack: SnackBarComponent
  ) {

    this.user = _share.getUser();

    console.log(this.user);

    this._http.get<DepInfo>(`${environment.hod_api_url}deps/info/${this.user.dep_id}`, {
      headers: {
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
      }
    })
      .subscribe(result => {
        this.dep = result;
      });
  }

  ngOnInit(): void {

    this._http.get<any[]>(`${environment.hod_api_url}analyser/get/home/dirs/${this.user.dep_id}`)
      .subscribe(result => {
        console.log(result);
        console.log(result.length);
        if(result.length != 0){
          this.multi = result;
        }
        else{
          this.emptyDirs = true;
        }
      });

  }

  onSelect(data): void {
    console.log('Item clicked', JSON.parse(JSON.stringify(data)));
    this.selectedDir = data;
    console.log(data);
  }

  onActivate(data): void {
    console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate(data): void {
    console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }

}

// this.multi = [
//   {
//     "name": "ИСТ-2016",
//     "series": [
//       {
//         "name": "4.4.3",
//         "value": 10
//       },
//       {
//         "name": "4.4.4",
//         "value": 30
//       },
//       {
//         "name": "4.4.5",
//         "value": 50
//       },
//     ]
//   },

//   {
//     "name": "ИСТ-2017",
//     "series": [
//       {
//         "name": "4.4.3",
//         "value": 10
//       },
//       {
//         "name": "4.4.4",
//         "value": 30
//       },
//       {
//         "name": "4.4.5",
//         "value": 50
//       },
//     ]
//   }

// ];