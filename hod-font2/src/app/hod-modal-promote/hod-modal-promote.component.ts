import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpRequest, HttpHeaders } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { FormBuilder, FormGroup } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';

import { ShareService } from '../share.service';
// import { promotion_HttpService } from '../hod-promotion/_http.serviceHodPromotion';

import { Teacher, GroupTeacher, TeacherRate } from '../_models/teacher-models';
import { Direction, DepInfo } from '../_models/deps-models';
import { Group } from '../_models/groups-models';
import { environment } from 'src/environments/environment';


export interface StateGroup {
  letter: string;
  names: string[];
}
export const _filter = (opt: Teacher[], value: string): Teacher[] => {
  // console.log('filter', value);
  if (value == undefined) { return opt.filter(item => true); }
  const filterValue = value.toLowerCase();
  return opt.filter(item => item.FullName.toLowerCase().indexOf(filterValue) === 0);
};


@Component({
  selector: 'app-hod-modal-promote',
  templateUrl: './hod-modal-promote.component.html',
  styleUrls: ['./hod-modal-promote.component.css']
})
export class HodModalPromoteComponent implements OnInit {

  isUnmappedSubject: boolean;
  subjectDepId: number;
  // selectedDep: DepInfo;
  selectedDir: Direction;
  // selectedGroup: Group;
  selectedAcPl: any;
  selectedSubject: any;
  selectedAttRec: any;

  btn_class: string;

  secondTeacher: boolean;

  stateForm: FormGroup = this._formBuilder.group({
    stateGroup: '',
  });
  stateForm2: FormGroup = this._formBuilder.group({
    stateGroup2: '',
  });

  selectedName: string;

  stateGroups: GroupTeacher[];
  stateGroups2: GroupTeacher[];

  stateGroupOptions: Observable<GroupTeacher[]>;
  stateGroupOptions2: Observable<GroupTeacher[]>;

  saved: boolean;

  submitedAttAcPlan: any;

  submitedTeacher: TeacherRate;
  submitedTeacher2: TeacherRate;

  constructor(
    private _http: HttpClient,
    private _formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<HodModalPromoteComponent>,
    private share: ShareService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.saved = false;
    this.secondTeacher = false;
  }

  ngOnInit(): void {
    this.saved = false;
    this.btn_class = "btn btn-secondary";
    console.log('inited', this.selectedSubject, this.selectedAttRec);

    if (this.isUnmappedSubject) { // this.subjectDepId == null
      // получаем всех преподавателей
      this._http.get<GroupTeacher[]>(`${environment.hod_api_url}teachers/get/all`, {
        headers: new HttpHeaders
          ({
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
          })
      })
        .subscribe(result => {
          this.stateGroups = result;
          this.stateGroups2 = result;
          console.log(result);
        });
    }
    else {  // this.subjectDepId != null
      /// получаем всех преподавателей кафедры
      this._http.get<GroupTeacher[]>(`${environment.hod_api_url}teachers/get/correspond/${this.subjectDepId}`, {
        headers: new HttpHeaders
          ({
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName)
          })
      })
        .subscribe(result => {
          this.stateGroups = result;
          this.stateGroups2 = result;
          console.log(result);
        });
    }

    this.stateGroupOptions = this.stateForm.get('stateGroup')!.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filterGroup(value))
      );

    this.stateGroupOptions2 = this.stateForm2.get('stateGroup2')!.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filterGroup2(value))
      );

    this.dialogRef.disableClose = true;//disable default close operation
    this.dialogRef.backdropClick().subscribe(result => {
      this.dialogRef.close(this.submitedAttAcPlan);
    });

  }

  displayFn(shop: Teacher): string {
    return shop.FullName;
  }
  displayFn2(shop: Teacher): string {
    return shop.FullName;
  }

  displayApplyT1(): string {
    // console.log()
    switch (this.stateForm.get('stateGroup').value.ApplyT_id){
      case 1: return "Внутреннее";
      case 2: return "Внешнее, ГПХ";
      default: return "Внутреннее";
    }
  }
  displayApplyT2(): string {
    switch (this.stateForm2.get('stateGroup2').value.ApplyT_id){
      case 1: return "Внутреннее";
      case 2: return "Внешнее, ГПХ";
      default: return "Внутреннее";
    }
  }

  private _filterGroup(value: string): GroupTeacher[] {
    if (value) {
      console.log('value is ', value.toString());
      return this.stateGroups
        .map(group => ({
          letter: group.letter,
          teachers: _filter(group.teachers, value.toString())
        }))
        .filter(group => group.teachers.length > 0);
    }
    return this.stateGroups;
  }
  private _filterGroup2(value: string): GroupTeacher[] {
    if (value) {
      console.log('value2 is ', value.toString());
      return this.stateGroups2
        .map(group => ({
          letter: group.letter,
          teachers: _filter(group.teachers, value.toString())
        }))
        .filter(group => group.teachers.length > 0);
    }
    return this.stateGroups2;
  }

  switchTeacher() {
    this.secondTeacher = !this.secondTeacher;
  }

  saveChanges() {

    console.log(this.selectedAttRec);

    let selectedTeacher = this.stateForm.get('stateGroup');
    console.log(selectedTeacher);

    let selectedTeacher2 = this.stateForm2.get('stateGroup2');
    console.log(selectedTeacher2);

    if (selectedTeacher.value.Fsh_id == undefined) { alert('Отказ в сохранении, поскольку преподаватель не был выбран из доступного списка.'); return null; }

    let formFake = {
      'fsh_id': selectedTeacher.value.Fsh_id,
      'teacherName': selectedTeacher.value.FullName,
      'fsh_id2': null,
      'teacherName2': null,
      'attAcPlan_id': this.selectedAttRec.AtAcPlId
    };
    alert();
    if(selectedTeacher2) {
      formFake = {
        'fsh_id': selectedTeacher.value.Fsh_id,
        'teacherName': selectedTeacher.value.FullName,
        'fsh_id2': selectedTeacher2.value.Fsh_id,
        'teacherName2': selectedTeacher2.value.FullName,
        'attAcPlan_id': this.selectedAttRec.AtAcPlId
      }
    }
    // form.append('fsh_id', selectedTeacher.value.fsh_id);
    // form.append('attAcPlan_id', this.selectedAttRec.atAcPlId);
    console.log(formFake);

    this._http.post(
      `${environment.hod_api_url}teachers/post/on/att-ac-plan/${this.selectedAttRec.AtAcPlId}`,
      formFake,
      {
        headers: new HttpHeaders
          ({
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem(environment.hod_sessionConst.accessTokenName),
            // 'Accept': '*/*',
            // 'Content-Type': 'undefined',
            // 'Content-Type': 'multipart/form-data; boundary=------WebKitFormBoundaryqy14R5oY6FqgxfWA',//charset=utf-8;
            // 'Content-Type': 'multipart/form-data',
            // 'Content-Type': 'application/json',
            // 'Content-Type': 'application/json; charset=utf-8',
            // 'Content-Type': 'application/x-www-form-urlencoded',
            'X-Content-Type-Options': 'nosniff',
            'Connetion': 'keep-alive'
          })
      }
    )
      .subscribe(event => {

        // if (event.type === HttpEventType.UploadProgress)
        //   this.progress = Math.round(100 * event.loaded / event.total);
        // else if (event.type === HttpEventType.Response)
        //   this.message = event.body.toString();

        // this.selectedDep.

        // this.share.shareUpdateAttAcPlan(event); // share

        console.log(event);
      });;
    this.saved = true;
    this.submitedAttAcPlan = formFake;
    this.btn_class = "btn btn-primary";
  }

  // When the user clicks the action button a.k.a. the logout button in the\
  // modal, show an alert and followed by the closing of the modal
  actionFunction() {
    // alert("You have logged out.");
    this.closeModal();
  }

  // If the user clicks the cancel button a.k.a. the go back button, then\
  // just close the modal
  closeModal() {

    if (this.saved) {
      this.dialogRef.close(this.submitedAttAcPlan);
    }
    else {

      if (confirm('Вы действительно хотите выйти без сохранения?')) {
        this.dialogRef.close(this.submitedAttAcPlan);
      }
      else {
        return;
        let selectedTeacher = this.stateForm.get('stateGroup');
        console.log(selectedTeacher);
        console.log(this.selectedAttRec);

        let formFake = {
          'fsh_id': selectedTeacher.value.fsh_id,
          'teacherName': selectedTeacher.value.fullName,
          'attAcPlan_id': this.selectedAttRec.atAcPlId
        };
        // form.append('fsh_id', selectedTeacher.value.fsh_id);
        // form.append('attAcPlan_id', this.selectedAttRec.atAcPlId);
        console.log(formFake);

        this._http.post(
          `${environment.hod_api_url}teachers/post/on/att-ac-plan/${this.selectedAttRec.atAcPlId}`,
          formFake,
          {
            headers: new HttpHeaders
              ({
                // 'Accept': '*/*',
                // 'Content-Type': 'undefined',
                // 'Content-Type': 'multipart/form-data; boundary=------WebKitFormBoundaryqy14R5oY6FqgxfWA',//charset=utf-8;
                // 'Content-Type': 'multipart/form-data',
                // 'Content-Type': 'application/json',
                // 'Content-Type': 'application/json; charset=utf-8',
                // 'Content-Type': 'application/x-www-form-urlencoded',
                'X-Content-Type-Options': 'nosniff',
                'Connetion': 'keep-alive'
              })
          }
        )
          .subscribe(event => {

            // if (event.type === HttpEventType.UploadProgress)
            //   this.progress = Math.round(100 * event.loaded / event.total);
            // else if (event.type === HttpEventType.Response)
            //   this.message = event.body.toString();

            // this.selectedDep.

            // this.share.shareUpdateAttAcPlan(event); // share

            console.log(event);
          });
      }

      this.dialogRef.close();
    }
    //    
  }

}
