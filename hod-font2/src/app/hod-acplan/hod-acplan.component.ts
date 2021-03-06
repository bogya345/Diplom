import { Component, Inject, OnDestroy, OnInit, Input, ViewChild } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { MatTableDataSource } from '@angular/material/table';

import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// import { NgbdModalOptions } from './modal-options';

import { ShareService } from '../share.service';

import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { animate, state, style, transition, trigger } from '@angular/animations';

import { acplan_HttpService } from './_http.serviceHodAcPlan';
import {
  Group, BlockRec, AcPlan,
  BlockNum, Subject, Semester, Load
} from '../_models/groups-models';
import { Direction } from '../_models/deps-models';
import { User } from '../_models/accounts-models';

import { HodPromoteComponent } from '../hod-promote/hod-promote.component'

import { HodModalPromoteComponent } from '../hod-modal-promote/hod-modal-promote.component';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';
import { UniqueSelectionDispatcher } from '@angular/cdk/collections';
import { AnonymousSubject } from 'rxjs/internal/Subject';

// @NgModule({
//   imports: [BrowserModule, NgbModule],
//   declarations: [NgbdModalOptions],
//   exports: [NgbdModalOptions],
//   bootstrap: [NgbdModalOptions]
// })
// export class NgbdModalOptionsModule {}

@Component({
  selector: 'app-hod-acplan',
  templateUrl: './hod-acplan.component.html',
  styleUrls: ['./hod-acplan.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class HodAcplanComponent implements OnInit {

  @ViewChild('') accordion: MatAccordion;

  @Input() direction: Direction;
  @Input() group: Group;

  dataSource_subjects: any;
  displayedColumns_subjects: string[] = ['SubjectName'];

  dataSource_loads: any;

  expandedElement: Subject | null;

  public selectedIndex_plan: number;
  public selectedBlockNum: BlockNum;
  public selectedSubject: Subject;
  public selectedLoad: Load;

  public blockRecs: BlockRec[];
  // public acPlan: AcPlan;
  public acPlan: BlockNum[];

  private submittedTeacher: any;

  private _httpOwn: acplan_HttpService;
  private _user: User;
  public _userDepId: number;

  public isAdmin: boolean;
  public isYmy: boolean;

  constructor(
    private _router: Router,
    private _http: HttpClient,
    private share: ShareService,
    // private _user: User,
    private matDialog: MatDialog,
    private snack: SnackBarComponent,
  ) {
    this._httpOwn = new acplan_HttpService(_http);
  }

  ngOnInit(): void {
    this._user = this.share.getUser();
    this._userDepId = this._user.dep_id;
    this.isAdmin = (this._user.access_role_id == 4);
    this.isYmy = (this._user.access_role_id == 3);
  }
  ngOnChanges(): void {
    // this._httpOwn.getAcPlan(this.group.group_id)
    //   .subscribe(result => {
    //     this.acPlan = result;
    //   }, error => {
    //     console.log('error/ngOnInit', error);
    //   }
    //   );

    this._user = this.share.getUser();
    console.log('changed: user is ', this._user);

    console.log(this.direction);
    console.log(this.group);

    this._httpOwn.getBlockNums(this.direction.AcPl_id, this.group.Group_id)
      .subscribe(result => {
        this.acPlan = result
        console.log(this.acPlan);
        // this.snack.openSnackBarWithMsg('?????????????? ???????? ?????? ???????????????? ?? ??????????????????.');
      });

    // this._httpOwn.getCorrespondBlockNums(this._user.dep_id = -1, this.direction.acPl_id, this.group.group_id)
    //   .subscribe(result => {
    //     this.acPlan = result
    //     console.log(this.acPlan);
    //     // this.snack.openSnackBarWithMsg('?????????????? ???????? ?????? ???????????????? ?? ??????????????????.');
    //   });

    console.log('variables changes');
    console.log(this.blockRecs);
  }

  openModal(direction, group, acPlan, subject, item) {
    let isUnmapped = false;
    if (!this.isAdmin) {
      if (subject.CorrespDep == null || subject.CorrespDep.Dep_id == null) {
        if (!confirm(`?? ?????????????????? ???????????????????? ???? ?????????????????? ??????????????, ???????????????????? ???? ???????? ???????????????? ?????????????????????????????`)) { return; }
        isUnmapped = true;
      }
      else {
        if (
          this._user.dep_id != subject.CorrespDep.Dep_id
        ) {
          this.snack.openSnackBarFull(`???? ???? ???????????? ?????????????????? ?????????????????????????? ???? '${subject.SubjectName}'`, 'center', '', 3000);
          return;
        }
      }
    }
    // this.share.doSelectedDir(item);
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = "modalPromote-component";
    dialogConfig.height = "500px";
    dialogConfig.width = "750px";
    dialogConfig.data = {
      isUnmappedSubject: isUnmapped,
      subjectDepId: !isUnmapped ? subject.CorrespDep.Dep_id : null,
      selectedDir: direction,
      selectedGroup: group,
      selectedAcPl: acPlan,
      selectedSubject: subject,
      selectedAttRec: item
    }

    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(HodModalPromoteComponent, dialogConfig);
    modalDialog.componentInstance.isUnmappedSubject = isUnmapped;
    modalDialog.componentInstance.subjectDepId = subject.CorrespDep.Dep_id;
    modalDialog.componentInstance.selectedDir = direction;
    modalDialog.componentInstance.selectedGroup = group;
    modalDialog.componentInstance.selectedAcPl = acPlan;
    modalDialog.componentInstance.selectedSubject = subject;
    modalDialog.componentInstance.selectedAttRec = item;

    modalDialog.afterClosed().subscribe(result => {
      console.log(result);
      console.log('The dialog was closed');
      // this.submittedTeacher = result;

      this.selectedSubject.Loads.forEach(x => {
        x.AtAcPlId == item.AtAcPlId ? x.FshId = result.fsh_id : x.FshId = x.FshId;
        x.AtAcPlId == item.AtAcPlId ? x.TeachName = result.teacherName : x.TeachName = x.TeachName;
      });
      console.log('lol, i did it');

    });

    // this.matDialog.

    // this.matDialog.afterAllClosed.toPromise() .subscribe(result => {
    //   console.log(result);
    //   console.log('in close event, lol');

    //   if(result != undefined && result.fsh_id != undefined)
    //   {
    //     this.selectedSubject.loads.forEach(x => {
    //       x.atAcPlId == item.atAcPlId ? x.fshId = res.fsh_id : x.fshId = x.fshId;
    //       x.atAcPlId == item.atAcPlId ? x.teachName = res.teacherName : x.teachName = x.teachName;
    //     });
    //     console.log('lol, i did it');
    //   }

    //   setTimeout(() => {
    //     console.log('time is up');
    //     function findSelectedItem(value) {
    //       if (item.atAcPlId == value.atAcPlId) { return true; }
    //       return false;
    //     }

    //     let res = this.share.getUpdateAttAcPlan();
    //     console.log('result ==', res);
    //     if (res) {
    //       // this.selectedSubject.loads.filter(findSelectedItem)

    //     }
    //   }, 2000);
    // });

  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource_subjects.filter = filterValue.trim().toLowerCase();
  }

  public subjectClicked(item) {
    this.selectedSubject = item;
  }

  public panel_clicked(item) {
    console.log(item);
    if (item == 2) {
      // this.dataSource = new MatTableDataSource(this.ELEMENT_DATA2);
    } else {
      // this.dataSource = new MatTableDataSource(this.ELEMENT_DATA1);
    }
  }

  public setSelectedBlockNum(item) {
    console.log(item);
    this.selectedBlockNum = item;
    // this.pathString = `::/${item.dir_name}`;
    this.dataSource_subjects = new MatTableDataSource(this.selectedBlockNum.Subjects);
    this.selectedIndex_plan = 2;
    console.log(item);
    console.log(this.selectedBlockNum);
  }

}