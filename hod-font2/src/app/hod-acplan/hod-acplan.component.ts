import { Component, Inject, OnDestroy, OnInit, Input, ViewChild } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { MatTableDataSource } from '@angular/material/table';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// import { NgbdModalOptions } from './modal-options';

import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { animate, state, style, transition, trigger } from '@angular/animations';

import { acplan_HttpService } from './_http.serviceHodAcPlan';
import {
  Group, BlockRec, AcPlan,
  BlocNum, Subject, Semester, Load
} from '../_models/groups-models';
import { Direction } from '../_models/deps-models';

import { HodPromoteComponent } from '../hod-promote/hod-promote.component'

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
  public selectedBlockNum: BlocNum;
  public selectedSubject: Subject;
  public selectedLoad: Load;

  public blockRecs: BlockRec[];
  public acPlan: AcPlan;

  private _httpOwn: acplan_HttpService;
  constructor(
    private _router: Router,
    private _http: HttpClient
  ) {
    this._httpOwn = new acplan_HttpService(_http);
  }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    // this._httpOwn.getAcPlan(this.group.group_id)
    //   .subscribe(result => {
    //     this.acPlan = result;
    //   }, error => {
    //     console.log('error/ngOnInit', error);
    //   }
    //   );

    this.acPlan = this._httpOwn.getFakeAcPlan(this.group.group_id);

    console.log('variables changes');
    console.log(this.blockRecs);
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

  onPromote(event: any) {

    // this.clickedOnPromote = false;

    console.log('callback value', event);
    // console.log('selectedBlockRecord', this.selectedBlockRecord);

    // for (let i = 0; i < event.length; i++) {

    //   console.log('in', event[i]);

    //   if (event[i].typeSubject.toLowerCase().includes('лек'))
    //     if (event[i].id_teacherCath) { // !(check on null and undefinded)
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-les`).classList.remove("donotpromoted");
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-les`).classList.add("promoted");
    //     }

    //   if (event[i].typeSubject.toLowerCase().includes('лаб'))
    //     if (event[i].id_teacherCath) {
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-lab`).classList.remove("donotpromoted");
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-lab`).classList.add("promoted");
    //     }

    //   if (event[i].typeSubject.toLowerCase().includes('пр'))
    //     if (event[i].id_teacherCath) {
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-pr`).classList.remove("donotpromoted");
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-pr`).classList.add("promoted");
    //     }

    //   if (event[i].typeSubject.toLowerCase().includes('из'))
    //     if (event[i].id_teacherCath) {
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-iz`).classList.remove("donotpromoted");
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-iz`).classList.add("promoted");
    //     }

    //   if (event[i].typeSubject.toLowerCase().includes('ак'))
    //     if (event[i].id_teacherCath) {
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-ak`).classList.remove("donotpromoted");
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-ak`).classList.add("promoted");
    //     }

    //   if (event[i].typeSubject.toLowerCase().includes('кпр'))
    //     if (event[i].id_teacherCath) {
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-kpr`).classList.remove("donotpromoted");
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-kpr`).classList.add("promoted");
    //     }

    //   if (event[i].typeSubject.toLowerCase().includes('ср'))
    //     if (event[i].id_teacherCath) {
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-sr`).classList.remove("donotpromoted");
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-sr`).classList.add("promoted");
    //     }

    //   if (event[i].typeSubject.toLowerCase().includes('контроль'))
    //     if (event[i].id_teacherCath) {
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-controll`).classList.remove("donotpromoted");
    //       document.getElementById(`${this.selectedBlockRecord.id_blockRec}-controll`).classList.add("promoted");
    //     }

    // }

    console.log('did it');
  }

  public openPromoteDialog(event: any, item: any) {
    console.log(event);
    console.log(item);
    this.selectedLoad = item;

    // let temp = this.viewTeacherLoad.filter((element) => { return element.blockrecs_id_blockRec == j.id_blockRec; });;

    console.log('temp', this.selectedLoad);

    // this.promotionData = temp;

    document.getElementById('popup-selector-promotion').hidden = false;

    // console.log(i, j);
  }

  teacherPromoted(event: any, element: any) {
    // call pop-up menu
    // i - mapped blockRec  - object
    // j - blockRec         - object

    console.log(event);
    console.log(element);


    document.getElementById('popup-selector-promotion').hidden = false;
  }

  // callback
  teacherPromoted1(event: any, i: any, j: any) {
    // call pop-up menu
    // i - mapped blockRec  - object
    // j - blockRec         - object

    // this.clickedOnPromote = true;

    // console.log('this.indexOfRow', this.indexOfRow);

    // this.selectedBlockRecord = j;
    // let temp = this.viewTeacherLoad.filter((element) => { return element.blockrecs_id_blockRec == j.id_blockRec; });

    // console.log('temp', temp);

    // this.promotionData = temp;

    // document.getElementById('popup-selector-promotion').hidden = false;

    // console.log(i, j);
  }

  public setSelectedBlockNum(item) {
    this.selectedBlockNum = item;
    // this.pathString = `::/${item.dir_name}`;
    this.dataSource_subjects = new MatTableDataSource(this.selectedBlockNum.Subjects);
    this.selectedIndex_plan = 2;
    console.log(item);
    console.log(this.selectedBlockNum);
  }



  public showSearch(el_id) {
    // this.accordion.nativeElement.focus();
    // this.show = !this.show;
    // document.getElementById(el_id).focus();
    // setTimeout(() => { // this will make the execution after the above boolean has changed
    //   this.searchElement.nativeElement.focus();
    // }, 0);
  }

}