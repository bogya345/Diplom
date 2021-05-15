import { Component, OnInit, Inject } from '@angular/core';
import { homeworkListTeacher_HttpService } from './http.serviceHomeworkListTeacher';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
@Component({
  selector: 'app-homework-list-teacher',
  templateUrl: './homework-list-teacher.component.html',
  styleUrls: ['./homework-list-teacher.component.css']
})
export class HomeworkListTeacherComponent implements OnInit {
  public http: homeworkListTeacher_HttpService;
  public IdSelectedDraft: number;
  public IdSelectedDraftType: number;
  public IdDateSelected: string;
  public baseUrl: string;

  public TimeTable2: AttedanceForWork[];
  public DraftTimeTables: DraftTimeTable[];
  public TypesTimeTable: TypeTimeTable[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = new homeworkListTeacher_HttpService(http);
    this.baseUrl = baseUrl;
    this.IdSelectedDraftType = -1045036686;
    this.IdSelectedDraft = -1096224834;


  }
  selectChangeHandler(event: any) {
    //update the ui
    this.IdSelectedDraft = event.target.value;
    console.log(this.IdSelectedDraft);
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.IdDateSelected)
      .subscribe(result => {
        this.TimeTable2 = result;
      
        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  selectChangeHandler2(event: any) {
    //update the ui
    this.IdSelectedDraftType = event.target.value;
    console.log(this.IdSelectedDraftType);
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.IdDateSelected)
      .subscribe(result => {
        this.TimeTable2 = result;
        console.log('IdSelectedType', this.IdSelectedDraftType);
        console.log('IdSelectedType', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  selectChangeHandler3(event: any) {
    //update the ui
    this.IdDateSelected = event.target.value;
    console.log(this.IdSelectedDraft);
    this.http.getTeacherClassList(this.IdSelectedDraft, this.IdSelectedDraftType, this.IdDateSelected)
      .subscribe(result => {
        this.TimeTable2 = result;
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

        console.log('keks', this.TimeTable2);
        console.log('result/constructor1', result);

      }, error => {
        console.log('error/constructor1', error);
      }
    );
    this.http.getDrafts(this.IdSelectedDraft)
      .subscribe(result => {
        this.DraftTimeTables = result;

        console.log('keks', this.DraftTimeTables);
      console.log('result/constructor2', result);

    }, error => {
      console.log('error/constructor2', error);
    }
    );
    this.http.getDraftTypes(this.IdSelectedDraftType)
      .subscribe(result => {
        this.TypesTimeTable = result;

        console.log('TypesTimeTable', this.TypesTimeTable);
      console.log('result/constructor3', result);

    }, error => {
      console.log('error/constructor', error);
    }
    );
  }

}
interface AttedanceForWork {
  IdAtt: number,
  TextDoClassWork: string,
  FilePath: string,
  PersonFIO: string,
  BallHW: number,
  Done: string,
  DatePass: string
}
interface DraftTimeTable {
  IdDFTT: number,
  _Description: string
}
interface TypeTimeTable {
  IdDTTT: number,
  _Description: string
} 
