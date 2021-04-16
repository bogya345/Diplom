import { stringify } from '@angular/compiler/src/util';
import { ComponentFactoryResolver, EventEmitter } from '@angular/core';

import { User } from './_models/accounts-models';

import { DepInfo, Direction } from './_models/deps-models';

export class ShareService {

  // private deps: DepsInfo[];
  // public doDep(items: DepsInfo[]) {
  //   this.deps = items;
  //   this.printLogs('deps', this.deps);
  // }
  // public shareDep() {
  //   return this.deps;
  // }

  private selectedDep: number;
  public doSelectedDep(items: number) {
    this.selectedDep = items;
    this.printLogs('selectedDep (id) == ', this.selectedDep);
  }
  public shareSelectedDep() { return this.selectedDep; }


  private selectedDir: Direction;
  public doSelectedDir(items: Direction) {
    this.selectedDir = items;
    this.printLogs('selectedDir', this.selectedDir);
  }
  public shareSelectedDir(): Direction {
    return this.selectedDir;
  }


  private deps: DepInfo[];
  public doDeps(items: DepInfo[]) {
    this.deps = items;
    this.printLogs('deps', this.deps);
  }
  public shareDeps() {
    return this.deps;
  }

  private user: User;
  public doUser(item: User) {
    this.user = new UserCl();
    this.printLogs('user', this.user);
  }
  public shareUser(token: string) {
    if(this.user == null)
    {
      console.log('user is null');
      this.user = new UserCl();
    }
    return this.user;
  }

  private printLogs(title, item) {
    console.log(`${title} saved`);
    console.log(item);
  }

}

class UserCl implements User {
  public name: string;
  public login: string;
  public role_id: number;
  public role_name: string;
  public dep_id: number;
  public dep_name: string;
  /**
   *
   */
  constructor() {
    this.name = 'def_username';
    this.login = 'def_login';
    this.dep_id = -1;
    this.dep_name = 'def_dep';
    this.role_id = 0;
    this.role_name = 'def_role';
  }
}

export class ShareService2 {
  private clickCnt: number = 0;
  onClick: EventEmitter<number> = new EventEmitter();

  public doClick() {
    this.clickCnt++;
    this.onClick.emit(this.clickCnt);
  }

}