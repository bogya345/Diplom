import { Component, OnInit, Inject } from '@angular/core';
import { serviceTimeTableTeacher } from './http.serviceTimeTableTeacher';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
@Component({
  selector: 'app-timetable-teacher',
  templateUrl: './timetable-teacher.component.html',
  styleUrls: ['./timetable-teacher.component.css']
})
export class TimetableTeacherComponent implements OnInit {
  public http: serviceTimeTableTeacher;
  public baseUrl: string;
  public TimeTable: TimeTable;
  public TimeTable2: TimeTable2;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = new serviceTimeTableTeacher(http);
    this.baseUrl = baseUrl;
    
  }
  selectChangeHandler(event: any) {
    //update the ui
    this.TimeTable2.IdSelectedDraft = event.target.value;
    console.log(this.TimeTable2.IdSelectedDraft);
    this.http.getTeacherClassList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected )
      .subscribe(result => {
        this.TimeTable2 = result;
        this.TimeTable2.Days = result.Days;
        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  selectChangeHandler2(event: any) {
    //update the ui
    this.TimeTable2.IdSelectedDraftType = event.target.value;
    console.log(this.TimeTable2.IdSelectedDraft);
    this.http.getTeacherClassList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected)
      .subscribe(result => {
        this.TimeTable2 = result;
        this.TimeTable2.Days = result.Days;
        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  selectChangeHandler3(event: any) {
    //update the ui
    this.TimeTable2.IdDateSelected = event.target.value;
    console.log(this.TimeTable2.IdSelectedDraft);
    this.http.getTeacherClassList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected )
      .subscribe(result => {
        this.TimeTable2 = result;
        this.TimeTable2.Days = result.Days;
        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  ngOnInit() {
    this.http.getTeacherClassList(-1096224834, 2007228761, '2001 - 01 - 08T00: 00: 00')
      .subscribe(result => {
        this.TimeTable2 = result;
        this.TimeTable2.Days = result.Days;

        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }

}

interface SubjectVM {
  //sfgs: SubjectForGroup[];
  IdSubject: number,
  SubjectName: string
}
interface TeacherClass {
  IdSFG: number,
  IdSubject: number,
  IdPerson: number,
  IdCourse: number,
  PersonFIO: number,
  StudyYearIdStudyYear: number
}
interface TimeTable {
  StudyYears: StudyYear[],
  selectedSY: StudyYear,
  SubjectVMs: SubjectVM[];
  idLect: number,
  LecturerFIO: string
}
interface StudyYear {
  IdStudyYear: number,
  _Description: string,
  DateTimeStart: string,
  DateTimeEnd: string
}
interface SubjectForGroup {

  IdSFG: number,
  IdGroup: number,
  IdCourse: number,
  DepartmentID: number,
  TypeStudy: TypeStudy
}
interface TypeStudy {
  IdTS: number,
  TypeStudyName: string,
  ShortTypeStudyName: string
}
interface EXTCforTimeTable {
  Auditory: string,
  IdECFLCT: number,
  SubjectName: string,
  DateTime: string,
  DayOfWeek: string
}

interface SubjectVM {
  //public List<SubjectForGroup> sfgs = new List<SubjectForGroup>();
  IdSubject: number,
  SubjectName: string
}
interface DraftTimeTable {
  IdDFTT: number,
  _Description: string
} 
interface TypeTimeTable {
  IdDTTT: number,
  _Description: string
} 
interface TimeTable2 {
  Drafts: DraftTimeTable[],
  IdSelectedDraft: number,
  DraftTypes: TypeTimeTable[],
  IdSelectedDraftType: number,
  Days: Day[],
  IdDateSelected: string
}
interface Day {
  DayOfWeek: string,
  EXTCforTimeTables: EXTCforTimeTable[];
}
