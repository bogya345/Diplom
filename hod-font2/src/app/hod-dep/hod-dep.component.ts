import { Component, Inject, OnDestroy, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

import { ShareService } from '../share.service';

import { dep_HttpService } from './_http.serviceHodDep';
import { DepsDto, Direction } from '../_models/deps-models';
import { Group } from '../_models/groups-models';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';

@Component({
  selector: 'app-hod-dep',
  templateUrl: './hod-dep.component.html',
  styleUrls: ['./hod-dep.component.css']
})
export class HodDepComponent implements OnInit {

  public dep: DepsDto;
  public selectedDir: Direction;
  public selectedGroup: Group;

  public pathString: string;
  public selectedIndex: number;

  private _httpOwn: dep_HttpService;
  constructor(
    private _router: Router,
    private _http: HttpClient,
    private _route: ActivatedRoute,
    private share: ShareService,
    private snack: SnackBarComponent
  ) {
    this._httpOwn = new dep_HttpService(_http);

    let dep_id = this._route.snapshot.paramMap.get('id');

    // this.dep = this._httpOwn.getFaceDep(dep_id);
    this._httpOwn.getDepInfo(dep_id)
      .subscribe(result => {
        this.dep = result;
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
        //this.snack.openSnackBarWithMsg('Using fake data');
      }
      );

  }

  ngOnInit(): void {
    let item = this.dep.Dirs[0];
    this.selectedDir = this.dep.Dirs[0];
    this.selectedGroup = this.selectedDir.Groups[0];
    // this.pathString = ;
  }

  public getPathString() {
    return `::Ваша кафедра(${this.dep.Dep_name})/${this.selectedDir.Dir_name}/${this.selectedGroup.Group_name}`;
  }

  public setSelectedDirection(item) {
    this.selectedDir = item;
    // this.pathString = `::/${item.dir_name}`;
    this.selectedIndex = 1;
  }
  public setSelectedGroup(item) {
    this.selectedGroup = item;
    // this.pathString += `/${item.group_name}`;
    this.selectedIndex = 2;
  }

  // public 

}
