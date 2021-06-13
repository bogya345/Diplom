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

  dataSource_subjects: any;
  displayedColumns_subjects: string[] = ['SubjectName'];

  expandedElement: Subject | null;

  public selectedIndex_plan: number;
  public selectedBlockNum: BlockNum;
  public selectedSubject: Subject;
  public selectedLoad: Load;

  public blockRecs: BlockRec[];
  // public acPlan: AcPlan;
  public acPlan: BlockNum[];
  public subjects: Subject[];

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

    this._httpOwn.getSubjects(this.direction.AcPl_id)
      .subscribe(result => {
        this.subjects = result;
        // this.dataSource_subjects = this.subjects;
        this.dataSource_subjects = new MatTableDataSource(this.subjects);
        console.log(this.subjects);
        // this.snack.openSnackBarWithMsg('Учебный план был загружен и обработан.');
      });

    // this._httpOwn.getCorrespondBlockNums(this._user.dep_id = -1, this.direction.acPl_id, this.group.group_id)
    //   .subscribe(result => {
    //     this.acPlan = result
    //     console.log(this.acPlan);
    //     // this.snack.openSnackBarWithMsg('Учебный план был загружен и обработан.');
    //   });

    console.log('variables changes');
    console.log(this.blockRecs);

    this.snack.openSnackBarFull('Загрузка дисциплин...', 'center', 'right', 1000);
  }

  openModal(direction, acPlan, subject, item) {
    let isUnmapped = false;
    if (
      !((this.isAdmin || this.isYmy) && !(this.isAdmin && this.isYmy))
    ) {
      if (subject.CorrespDep == null || subject.CorrespDep.Dep_id == null) {
        if (!confirm(`К выбранной дисциплине не привазяна кафедра, продолжить со всем перечнем преподавателей?`)) { return; }
        isUnmapped = true;
      }
      else {
        if (
          this._user.dep_id != subject.CorrespDep.Dep_id
        ) {
          this.snack.openSnackBarFull(`Вы не можете назначить преподавателя на '${subject.SubjectName}'`, 'center', '', 3000);
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
      selectedAcPl: acPlan,
      selectedSubject: subject,
      selectedAttRec: item
    }

    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(HodModalPromoteComponent, dialogConfig);
    modalDialog.componentInstance.isUnmappedSubject = isUnmapped;
    modalDialog.componentInstance.subjectDepId = subject.CorrespDep.Dep_id;
    modalDialog.componentInstance.selectedDir = direction;
    modalDialog.componentInstance.selectedAcPl = acPlan;
    modalDialog.componentInstance.selectedSubject = subject;
    modalDialog.componentInstance.selectedAttRec = item;

    modalDialog.afterClosed().subscribe(result => {
      console.log(result);
      console.log('The dialog was closed');

      this.selectedSubject.Loads.forEach(x => {
        x.AtAcPlId == item.AtAcPlId ? x.FshId1 = result.fsh_id : x.FshId1 = x.FshId1;
        x.AtAcPlId == item.AtAcPlId ? x.TeachName1 = result.teacherName : x.TeachName1 = x.TeachName1;
        x.AtAcPlId == item.AtAcPlId && result.fsh_id2 != null ? x.FshId2 = result.fsh_id2 : x.FshId2 = x.FshId2;
        x.AtAcPlId == item.AtAcPlId && result.teacherName2 != null ? x.TeachName2 = result.teacherName2 : x.TeachName2 = x.TeachName2;
      });
      console.log('lol, i did it');

    });
  }

  applyFilter(event: Event) {
    console.log(event);
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource_subjects.filter = filterValue.trim().toLowerCase();
    console.log(this.dataSource_subjects.filter);
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
    // this.dataSource_subjects = new MatTableDataSource(this.selectedBlockNum.Subjects);
    this.dataSource_subjects = new MatTableDataSource(this.subjects);
    this.selectedIndex_plan = 2;
    console.log(item);
    console.log(this.selectedBlockNum);
  }

}