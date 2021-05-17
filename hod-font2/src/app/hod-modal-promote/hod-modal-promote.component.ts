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

import { Teacher, GroupTeacher } from '../_models/teacher-models';
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
  selectedGroup: Group;
  selectedAcPl: any;
  selectedSubject: any;
  selectedAttRec: any;

  btn_class: string;

  stateForm: FormGroup = this._formBuilder.group({
    stateGroup: '',
  });

  selectedName: string;

  stateGroups: GroupTeacher[];
  // stateGroups: GroupTeacher[] = [
  //   {
  //     letter: 'A',
  //     teachers: [
  //       {fullName: 'a1'}
  //     ]
  //   }, {
  //     letter: 'C',
  //     teachers: []
  //   }
  // ];

  stateGroupOptions: Observable<GroupTeacher[]>;

  saved: boolean;

  submitedAttAcPlan: any;

  constructor(
    private _http: HttpClient,
    private _formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<HodModalPromoteComponent>,
    private share: ShareService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.saved = false;
  }

  ngOnInit(): void {
    this.saved = false;
    this.btn_class = "btn btn-secondary";
    console.log('inited', this.selectedSubject, this.selectedAttRec);

    if (this.isUnmappedSubject) { // this.subjectDepId == null
      // получаем всех преподавателей
      this._http.get(`${environment.hod_api_url}teachers/get/all`)
        .subscribe(result => {
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
          console.log(result);
        });
    }

    this.stateGroupOptions = this.stateForm.get('stateGroup')!.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filterGroup(value))
      );

    this.dialogRef.disableClose = true;//disable default close operation
    this.dialogRef.backdropClick().subscribe(result => {
      this.dialogRef.close(this.submitedAttAcPlan);
    });

  }

  displayFn(shop: Teacher): string {
    return shop.FullName;
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

  saveChanges() {
    let selectedTeacher = this.stateForm.get('stateGroup');
    console.log(selectedTeacher);
    console.log(this.selectedAttRec);

    if (selectedTeacher.value.Fsh_id == undefined) { alert('Отказ некорректно в сохранении, не выбран преподаватель.'); return null; }

    let formFake = {
      'fsh_id': selectedTeacher.value.Fsh_id,
      'teacherName': selectedTeacher.value.FullName,
      'attAcPlan_id': this.selectedAttRec.AtAcPlId
    };
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
    alert("You have logged out.");
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
